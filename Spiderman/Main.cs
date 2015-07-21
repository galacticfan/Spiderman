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
using System.Net.Http;
using System.Threading;

namespace Spiderman
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        // Parse Button Code
        private void parseBtn_Click(object sender, EventArgs e)
        {
            // Check if real url
            Uri uriResult;
            bool result = Uri.TryCreate(urlTxtBox.Text, UriKind.Absolute, out uriResult) && uriResult.Scheme == Uri.UriSchemeHttp;

            // Check to for earch parameters
            if (searchParametersLink.CheckedItems.Count == 0 && searchParametersImg.CheckedItems.Count == 0)
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
                    progLabel.Text = "0%";

                    // Begin main code
                    string url = urlTxtBox.Text;

                    eventLogTxt.Text += "Downloading HTML.\n";
                    currentTaskLabel.Text = "Current Task: Downloading HTML";

                    // Get HTML
                    HtmlWeb htmlWeb = new HtmlWeb();
                    HtmlAgilityPack.HtmlDocument htmlDoc = htmlWeb.Load(url);

                    eventLogTxt.Text += "HTML downloaded.\n";
                    currentTaskLabel.Text = "Current Task: HTML Downloaded";

                    // PARSE FOR LINKS
                    IEnumerable<HtmlNode> links = htmlDoc.DocumentNode.Descendants("a").Where(x => x.Attributes.Contains("href"));
                    int counter = 0;
                    int progress = 1; // for progress bar

                    currentTaskLabel.Text = "Current Task: Parsing HTML for Links";

                    foreach (object itemChecked in searchParametersLink.CheckedItems)
                    {
                        foreach (var link in links)
                        {
                            if (link.Attributes["href"].Value.ToLower().Contains(itemChecked.ToString()))
                            {
                                parsedDataDisplay.Items.Add(link.Attributes["href"].Value);
                                counter++;
                            }
                        }

                        // Progress bar update
                        progBar.Value = (100 / searchParametersLink.CheckedItems.Count) * (progress);
                        progLabel.Text = ((100 / searchParametersLink.CheckedItems.Count) * (progress)).ToString() + "%";
                        progress++;

                        // Event log update
                        eventLogTxt.Text += "Found " + counter.ToString() + " ." + itemChecked.ToString() + " files.\n";
                        counter = 0;
                    }

                    // PARSE FOR IMAGES
                    IEnumerable<HtmlNode> images = htmlDoc.DocumentNode.Descendants("img").Where(x => x.Attributes.Contains("src"));
                    IEnumerable<HtmlNode> images_link = htmlDoc.DocumentNode.Descendants("a").Where(x => x.Attributes.Contains("href"));
                    counter = 0;
                    progress = 1; // for progress bar

                    currentTaskLabel.Text = "Current Task: Parsing HTML for Images";

                    foreach (object itemChecked in searchParametersImg.CheckedItems)
                    {
                        foreach (var image in images)
                        {
                            if (image.Attributes["src"].Value.ToLower().Contains(itemChecked.ToString()))
                            {
                                if (image.Attributes["src"].Value.StartsWith("//")) // in case of different url formatting
                                {
                                    parsedDataDisplay.Items.Add("http://" + image.Attributes["src"].Value.TrimStart('/'));
                                }
                                else
                                {
                                    parsedDataDisplay.Items.Add(image.Attributes["src"].Value);
                                }

                                counter++;
                            }
                        }

                        foreach (var image_link in images_link)
                        {
                            if (image_link.Attributes["href"].Value.ToLower().Contains(itemChecked.ToString()))
                            {
                                parsedDataDisplay.Items.Add(image_link.Attributes["href"].Value);
                                counter++;
                            }
                        }

                        // Progress bar update
                        progBar.Value = (100 / searchParametersImg.CheckedItems.Count) * (progress);
                        progLabel.Text = ((100 / searchParametersImg.CheckedItems.Count) * (progress)).ToString() + "%";
                        progress++;

                        // Event log update
                        eventLogTxt.Text += "Found " + counter.ToString() + " ." + itemChecked.ToString() + " files.\n";
                        counter = 0;
                    }

                    currentTaskLabel.Text = "Current Task: N/A";

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    eventLogTxt.Text += "An error occurred.\n";
                }

            }

        }

        // Clearing Boxes Code
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
            progLabel.Text = "0%";
        }

        // Download Button Code
        private void downloadBtn_Click(object sender, EventArgs e)
        {
            if (parsedDataDisplay.SelectedItems.Count != 0)
            {
                try
                {
                    FolderBrowserDialog fbd = new FolderBrowserDialog();
                    DialogResult result = fbd.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        string saveLocation = fbd.SelectedPath;
                        foreach (object selectedItem in parsedDataDisplay.SelectedItems)
                        {
                            string fileName = selectedItem.ToString().Split('/').Last();
                            currentTaskLabel.Text = "Current Task: Downloading " + fileName;

                            progLabel.Text = "0%";
                            progBar.Value = 0;

                            WebClient wClient = new WebClient();
                            wClient.DownloadFileCompleted += new AsyncCompletedEventHandler(completedWClient);
                            wClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(downloadProgressChanged);
                            wClient.DownloadFileAsync(new Uri(selectedItem.ToString()), saveLocation + "\\" + fileName);
                        }
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            progLabel.Text = e.ProgressPercentage.ToString() + "%";
        }

        private void completedWClient(object sender, AsyncCompletedEventArgs e)
        {
            eventLogTxt.Text += "A file has downloaded.\n";
            currentTaskLabel.Text = "Current Task: N/A"; // may need to be commented out
        }

    }
}
