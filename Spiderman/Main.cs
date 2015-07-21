using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Net;
using System.Threading;

namespace Spiderman
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void parseBtn_Click(object sender, EventArgs e)
        {
            // Check if real url
            Uri uriResult;
            bool result = Uri.TryCreate(urlTxtBox.Text, UriKind.Absolute, out uriResult) && uriResult.Scheme == Uri.UriSchemeHttp;

            // Check to for earch parameters
            if (searchParameters.CheckedItems.Count == 0)
            {
                MessageBox.Show("You need to select some search parameters before continuing.", 
                    "Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
            else if (result == false) // is not real url
            {
                MessageBox.Show("You need to input a URL in the format \'http://www.example.com\' .",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    // Reset everything
                    clearBoxes();
                    progBar.Value = 0;

                    // Begin main code
                    string url = urlTxtBox.Text;

                    eventLogTxt.Text += "Downloading HTML.\n";
                    HtmlWeb htmlWeb = new HtmlWeb();
                    HtmlAgilityPack.HtmlDocument htmlDoc = htmlWeb.Load(url);
                    eventLogTxt.Text += "HTML downloaded.\n";

                    IEnumerable<HtmlNode> links = htmlDoc.DocumentNode.Descendants("a").Where(x => x.Attributes.Contains("href"));
                    int counter = 0;
                    int progress = 1; // for progress bar

                    foreach (object itemChecked in searchParameters.CheckedItems)
                    {
                        foreach (var link in links)
                        {
                            if (link.Attributes["href"].Value.Contains(itemChecked.ToString()))
                            {
                                parsedDataDisplay.Items.Add(link.Attributes["href"].Value);
                                counter++;
                            }
                        }

                        // Progress bar update
                        progBar.Value = (100 / searchParameters.CheckedItems.Count) * (progress);
                        progress++;

                        // Event log update
                        eventLogTxt.Text += "Found " + counter.ToString() + " ." + itemChecked.ToString() + " files.\n";
                        counter = 0;
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    eventLogTxt.Text += "An error occurred.\n";
                }

            }

        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            clearBoxes();
        }

        private void clearBoxes()
        {
            parsedDataDisplay.Items.Clear();
            parsedDataDisplay.Update();
            eventLogTxt.Clear();
            eventLogTxt.Update();

            progBar.Value = 0;
        }

        private void downloadBtn_Click(object sender, EventArgs e)
        {
            if (parsedDataDisplay.SelectedItems.Count != 0)
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string saveLocation = fbd.SelectedPath;
                    foreach(object selectedItem in parsedDataDisplay.SelectedItems)
                    {
                        WebClient wClient = new WebClient();
                        wClient.DownloadFileCompleted += new AsyncCompletedEventHandler(completedWClient);
                        wClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(downloadProgressChanged);
                        wClient.DownloadFileAsync(new Uri(selectedItem.ToString()), saveLocation + "\\" + selectedItem.ToString().Split('/').Last());
                    }
                }
            }
            else
            {
                MessageBox.Show("You need to click parse and then select some items from the list below.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void downloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progBar.Value = e.ProgressPercentage;
        }

        private void completedWClient(object sender, AsyncCompletedEventArgs e)
        {
            eventLogTxt.Text += "A file has downloaded.\n";
        }

    }
}
