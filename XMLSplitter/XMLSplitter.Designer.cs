namespace XMLSplitter
{
    partial class XMLSplitter
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
            this.openButton = new System.Windows.Forms.Button();
            this.openXMLDialog = new System.Windows.Forms.OpenFileDialog();
            this.splitButton = new System.Windows.Forms.Button();
            this.filepathlbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(105, 189);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(204, 68);
            this.openButton.TabIndex = 0;
            this.openButton.Text = "Select XML File";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // openXMLDialog
            // 
            this.openXMLDialog.FileName = "openFileDialog1";
            // 
            // splitButton
            // 
            this.splitButton.Location = new System.Drawing.Point(409, 189);
            this.splitButton.Name = "splitButton";
            this.splitButton.Size = new System.Drawing.Size(204, 68);
            this.splitButton.TabIndex = 1;
            this.splitButton.Text = "Split File";
            this.splitButton.UseVisualStyleBackColor = true;
            this.splitButton.Click += new System.EventHandler(this.splitButton_Click);
            // 
            // filepathlbl
            // 
            this.filepathlbl.AutoSize = true;
            this.filepathlbl.Location = new System.Drawing.Point(132, 86);
            this.filepathlbl.Name = "filepathlbl";
            this.filepathlbl.Size = new System.Drawing.Size(0, 13);
            this.filepathlbl.TabIndex = 2;
            this.filepathlbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // XMLSplitter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 396);
            this.Controls.Add(this.filepathlbl);
            this.Controls.Add(this.splitButton);
            this.Controls.Add(this.openButton);
            this.Name = "XMLSplitter";
            this.Text = "XMLSplitter";
            this.Load += new System.EventHandler(this.XMLSplitter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.OpenFileDialog openXMLDialog;
        private System.Windows.Forms.Button splitButton;
        private System.Windows.Forms.Label filepathlbl;
    }
}

