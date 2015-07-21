namespace Spiderman
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.urlLabel = new System.Windows.Forms.Label();
            this.urlTxtBox = new System.Windows.Forms.TextBox();
            this.parseBtn = new System.Windows.Forms.Button();
            this.parsedDataDisplay = new System.Windows.Forms.ListBox();
            this.downloadBtn = new System.Windows.Forms.Button();
            this.eLogLabel = new System.Windows.Forms.Label();
            this.eventLogTxt = new System.Windows.Forms.RichTextBox();
            this.searchParametersLink = new System.Windows.Forms.CheckedListBox();
            this.searchPermLabel = new System.Windows.Forms.Label();
            this.parsedLinksLabel = new System.Windows.Forms.Label();
            this.clearBtn = new System.Windows.Forms.Button();
            this.progBar = new System.Windows.Forms.ProgressBar();
            this.progLabel = new System.Windows.Forms.Label();
            this.currentTaskLabel = new System.Windows.Forms.Label();
            this.searchParametersImg = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // urlLabel
            // 
            this.urlLabel.AutoSize = true;
            this.urlLabel.Location = new System.Drawing.Point(12, 9);
            this.urlLabel.Name = "urlLabel";
            this.urlLabel.Size = new System.Drawing.Size(32, 13);
            this.urlLabel.TabIndex = 0;
            this.urlLabel.Text = "URL:";
            // 
            // urlTxtBox
            // 
            this.urlTxtBox.Location = new System.Drawing.Point(50, 6);
            this.urlTxtBox.Name = "urlTxtBox";
            this.urlTxtBox.Size = new System.Drawing.Size(267, 20);
            this.urlTxtBox.TabIndex = 1;
            // 
            // parseBtn
            // 
            this.parseBtn.Location = new System.Drawing.Point(12, 32);
            this.parseBtn.Name = "parseBtn";
            this.parseBtn.Size = new System.Drawing.Size(78, 23);
            this.parseBtn.TabIndex = 2;
            this.parseBtn.Text = "Parse";
            this.parseBtn.UseVisualStyleBackColor = true;
            this.parseBtn.Click += new System.EventHandler(this.parseBtn_Click);
            // 
            // parsedDataDisplay
            // 
            this.parsedDataDisplay.FormattingEnabled = true;
            this.parsedDataDisplay.HorizontalScrollbar = true;
            this.parsedDataDisplay.Location = new System.Drawing.Point(15, 82);
            this.parsedDataDisplay.Name = "parsedDataDisplay";
            this.parsedDataDisplay.ScrollAlwaysVisible = true;
            this.parsedDataDisplay.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.parsedDataDisplay.Size = new System.Drawing.Size(302, 160);
            this.parsedDataDisplay.TabIndex = 3;
            // 
            // downloadBtn
            // 
            this.downloadBtn.Location = new System.Drawing.Point(96, 32);
            this.downloadBtn.Name = "downloadBtn";
            this.downloadBtn.Size = new System.Drawing.Size(145, 23);
            this.downloadBtn.TabIndex = 4;
            this.downloadBtn.Text = "Download Selected";
            this.downloadBtn.UseVisualStyleBackColor = true;
            this.downloadBtn.Click += new System.EventHandler(this.downloadBtn_Click);
            // 
            // eLogLabel
            // 
            this.eLogLabel.AutoSize = true;
            this.eLogLabel.Location = new System.Drawing.Point(323, 157);
            this.eLogLabel.Name = "eLogLabel";
            this.eLogLabel.Size = new System.Drawing.Size(59, 13);
            this.eLogLabel.TabIndex = 5;
            this.eLogLabel.Text = "Event Log:";
            // 
            // eventLogTxt
            // 
            this.eventLogTxt.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.eventLogTxt.DetectUrls = false;
            this.eventLogTxt.Location = new System.Drawing.Point(326, 173);
            this.eventLogTxt.Name = "eventLogTxt";
            this.eventLogTxt.ReadOnly = true;
            this.eventLogTxt.Size = new System.Drawing.Size(245, 111);
            this.eventLogTxt.TabIndex = 6;
            this.eventLogTxt.Text = "";
            // 
            // searchParametersLink
            // 
            this.searchParametersLink.ColumnWidth = 50;
            this.searchParametersLink.FormattingEnabled = true;
            this.searchParametersLink.Items.AddRange(new object[] {
            "mp3",
            "aac",
            "wav",
            "m4a",
            "raw",
            "flv",
            "avi",
            "mov",
            "wmv",
            "mkv",
            "mpg",
            "mp4",
            "m4p",
            "mpeg",
            "mp2"});
            this.searchParametersLink.Location = new System.Drawing.Point(326, 27);
            this.searchParametersLink.MultiColumn = true;
            this.searchParametersLink.Name = "searchParametersLink";
            this.searchParametersLink.ScrollAlwaysVisible = true;
            this.searchParametersLink.Size = new System.Drawing.Size(165, 124);
            this.searchParametersLink.TabIndex = 7;
            // 
            // searchPermLabel
            // 
            this.searchPermLabel.AutoSize = true;
            this.searchPermLabel.Location = new System.Drawing.Point(323, 9);
            this.searchPermLabel.Name = "searchPermLabel";
            this.searchPermLabel.Size = new System.Drawing.Size(100, 13);
            this.searchPermLabel.TabIndex = 8;
            this.searchPermLabel.Text = "Search Parameters:";
            // 
            // parsedLinksLabel
            // 
            this.parsedLinksLabel.AutoSize = true;
            this.parsedLinksLabel.Location = new System.Drawing.Point(12, 66);
            this.parsedLinksLabel.Name = "parsedLinksLabel";
            this.parsedLinksLabel.Size = new System.Drawing.Size(71, 13);
            this.parsedLinksLabel.TabIndex = 9;
            this.parsedLinksLabel.Text = "Parsed Links:";
            // 
            // clearBtn
            // 
            this.clearBtn.Location = new System.Drawing.Point(247, 32);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(70, 23);
            this.clearBtn.TabIndex = 10;
            this.clearBtn.Text = "Clear";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // progBar
            // 
            this.progBar.Location = new System.Drawing.Point(15, 261);
            this.progBar.Name = "progBar";
            this.progBar.Size = new System.Drawing.Size(255, 23);
            this.progBar.TabIndex = 11;
            // 
            // progLabel
            // 
            this.progLabel.AutoSize = true;
            this.progLabel.BackColor = System.Drawing.Color.Transparent;
            this.progLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progLabel.Location = new System.Drawing.Point(276, 265);
            this.progLabel.Name = "progLabel";
            this.progLabel.Size = new System.Drawing.Size(27, 16);
            this.progLabel.TabIndex = 12;
            this.progLabel.Text = "0%";
            // 
            // currentTaskLabel
            // 
            this.currentTaskLabel.AutoSize = true;
            this.currentTaskLabel.Location = new System.Drawing.Point(12, 245);
            this.currentTaskLabel.Name = "currentTaskLabel";
            this.currentTaskLabel.Size = new System.Drawing.Size(94, 13);
            this.currentTaskLabel.TabIndex = 13;
            this.currentTaskLabel.Text = "Current Task: N/A";
            // 
            // searchParametersImg
            // 
            this.searchParametersImg.FormattingEnabled = true;
            this.searchParametersImg.Items.AddRange(new object[] {
            "jpg",
            "jpeg",
            "png",
            "gif",
            "svg",
            "bmp",
            "tif"});
            this.searchParametersImg.Location = new System.Drawing.Point(497, 27);
            this.searchParametersImg.Name = "searchParametersImg";
            this.searchParametersImg.ScrollAlwaysVisible = true;
            this.searchParametersImg.Size = new System.Drawing.Size(74, 124);
            this.searchParametersImg.TabIndex = 14;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 296);
            this.Controls.Add(this.searchParametersImg);
            this.Controls.Add(this.currentTaskLabel);
            this.Controls.Add(this.progLabel);
            this.Controls.Add(this.progBar);
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.parsedLinksLabel);
            this.Controls.Add(this.searchPermLabel);
            this.Controls.Add(this.searchParametersLink);
            this.Controls.Add(this.eventLogTxt);
            this.Controls.Add(this.eLogLabel);
            this.Controls.Add(this.downloadBtn);
            this.Controls.Add(this.parsedDataDisplay);
            this.Controls.Add(this.parseBtn);
            this.Controls.Add(this.urlTxtBox);
            this.Controls.Add(this.urlLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.Text = "Spiderman";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label urlLabel;
        private System.Windows.Forms.TextBox urlTxtBox;
        private System.Windows.Forms.Button parseBtn;
        private System.Windows.Forms.ListBox parsedDataDisplay;
        private System.Windows.Forms.Button downloadBtn;
        private System.Windows.Forms.Label eLogLabel;
        private System.Windows.Forms.RichTextBox eventLogTxt;
        private System.Windows.Forms.CheckedListBox searchParametersLink;
        private System.Windows.Forms.Label searchPermLabel;
        private System.Windows.Forms.Label parsedLinksLabel;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.ProgressBar progBar;
        private System.Windows.Forms.Label progLabel;
        private System.Windows.Forms.Label currentTaskLabel;
        private System.Windows.Forms.CheckedListBox searchParametersImg;
    }
}

