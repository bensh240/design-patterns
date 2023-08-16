namespace BasicFacebookFeatures
{
    partial class FormLikedPages
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
            this.linkLabelLikedPages = new System.Windows.Forms.LinkLabel();
            this.listBoxLikedPages = new System.Windows.Forms.ListBox();
            this.textBoxLikedPage = new System.Windows.Forms.TextBox();
            this.labelDescriptionPage = new System.Windows.Forms.Label();
            this.labelPagePicture = new System.Windows.Forms.Label();
            this.pictureBoxChosenLikedPage = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxChosenLikedPage)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // linkLabelLikedPages
            // 
            this.linkLabelLikedPages.AutoSize = true;
            this.linkLabelLikedPages.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.linkLabelLikedPages.Location = new System.Drawing.Point(19, 21);
            this.linkLabelLikedPages.Name = "linkLabelLikedPages";
            this.linkLabelLikedPages.Size = new System.Drawing.Size(195, 21);
            this.linkLabelLikedPages.TabIndex = 0;
            this.linkLabelLikedPages.TabStop = true;
            this.linkLabelLikedPages.Text = "Explore your liked pages";
            this.linkLabelLikedPages.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelLikedPages_LinkClicked);
            // 
            // listBoxLikedPages
            // 
            this.listBoxLikedPages.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.listBoxLikedPages.FormattingEnabled = true;
            this.listBoxLikedPages.ItemHeight = 21;
            this.listBoxLikedPages.Location = new System.Drawing.Point(23, 63);
            this.listBoxLikedPages.Name = "listBoxLikedPages";
            this.listBoxLikedPages.Size = new System.Drawing.Size(194, 277);
            this.listBoxLikedPages.TabIndex = 1;
            this.listBoxLikedPages.SelectedIndexChanged += new System.EventHandler(this.listBoxLikedPages_SelectedIndexChanged);
            // 
            // textBoxLikedPage
            // 
            this.textBoxLikedPage.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.textBoxLikedPage.Location = new System.Drawing.Point(45, 58);
            this.textBoxLikedPage.Name = "textBoxLikedPage";
            this.textBoxLikedPage.Size = new System.Drawing.Size(218, 27);
            this.textBoxLikedPage.TabIndex = 2;
            // 
            // labelDescriptionPage
            // 
            this.labelDescriptionPage.AutoSize = true;
            this.labelDescriptionPage.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.labelDescriptionPage.Location = new System.Drawing.Point(58, 20);
            this.labelDescriptionPage.Name = "labelDescriptionPage";
            this.labelDescriptionPage.Size = new System.Drawing.Size(215, 21);
            this.labelDescriptionPage.TabIndex = 3;
            this.labelDescriptionPage.Text = "Chosen page\'s description";
            // 
            // labelPagePicture
            // 
            this.labelPagePicture.AutoSize = true;
            this.labelPagePicture.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.labelPagePicture.Location = new System.Drawing.Point(18, 13);
            this.labelPagePicture.Name = "labelPagePicture";
            this.labelPagePicture.Size = new System.Drawing.Size(185, 21);
            this.labelPagePicture.TabIndex = 4;
            this.labelPagePicture.Text = "Chosen page\'s picture";
            // 
            // pictureBoxChosenLikedPage
            // 
            this.pictureBoxChosenLikedPage.Location = new System.Drawing.Point(22, 58);
            this.pictureBoxChosenLikedPage.Name = "pictureBoxChosenLikedPage";
            this.pictureBoxChosenLikedPage.Size = new System.Drawing.Size(158, 108);
            this.pictureBoxChosenLikedPage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxChosenLikedPage.TabIndex = 5;
            this.pictureBoxChosenLikedPage.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.pictureBoxChosenLikedPage);
            this.panel1.Controls.Add(this.labelPagePicture);
            this.panel1.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.panel1.Location = new System.Drawing.Point(331, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(216, 181);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Controls.Add(this.linkLabelLikedPages);
            this.panel2.Controls.Add(this.listBoxLikedPages);
            this.panel2.Location = new System.Drawing.Point(34, 34);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(251, 388);
            this.panel2.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel3.Controls.Add(this.labelDescriptionPage);
            this.panel3.Controls.Add(this.textBoxLikedPage);
            this.panel3.Location = new System.Drawing.Point(322, 255);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(332, 121);
            this.panel3.TabIndex = 8;
            // 
            // FormLikedPages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(694, 486);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormLikedPages";
            this.Text = "FormLikedPages";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxChosenLikedPage)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabelLikedPages;
        private System.Windows.Forms.ListBox listBoxLikedPages;
        private System.Windows.Forms.TextBox textBoxLikedPage;
        private System.Windows.Forms.Label labelDescriptionPage;
        private System.Windows.Forms.Label labelPagePicture;
        private System.Windows.Forms.PictureBox pictureBoxChosenLikedPage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}