namespace BasicFacebookFeatures
{
    partial class FormPosts
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
            this.linkLabelExplorePosts = new System.Windows.Forms.LinkLabel();
            this.listBoxPosts = new System.Windows.Forms.ListBox();
            this.listBoxPostsWasTaggedIn = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPostStatus = new System.Windows.Forms.TextBox();
            this.buttonPostStatus = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxPost = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // linkLabelExplorePosts
            // 
            this.linkLabelExplorePosts.ActiveLinkColor = System.Drawing.Color.White;
            this.linkLabelExplorePosts.AutoSize = true;
            this.linkLabelExplorePosts.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.linkLabelExplorePosts.Location = new System.Drawing.Point(392, 0);
            this.linkLabelExplorePosts.Name = "linkLabelExplorePosts";
            this.linkLabelExplorePosts.Size = new System.Drawing.Size(147, 21);
            this.linkLabelExplorePosts.TabIndex = 0;
            this.linkLabelExplorePosts.TabStop = true;
            this.linkLabelExplorePosts.Text = "Explore your posts";
            this.linkLabelExplorePosts.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelExplorePosts_LinkClicked);
            // 
            // listBoxPosts
            // 
            this.listBoxPosts.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.listBoxPosts.FormattingEnabled = true;
            this.listBoxPosts.ItemHeight = 21;
            this.listBoxPosts.Location = new System.Drawing.Point(32, 56);
            this.listBoxPosts.Name = "listBoxPosts";
            this.listBoxPosts.Size = new System.Drawing.Size(213, 298);
            this.listBoxPosts.TabIndex = 1;
            this.listBoxPosts.SelectedIndexChanged += new System.EventHandler(this.listBoxPosts_SelectedIndexChanged);
            // 
            // listBoxPostsWasTaggedIn
            // 
            this.listBoxPostsWasTaggedIn.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.listBoxPostsWasTaggedIn.FormattingEnabled = true;
            this.listBoxPostsWasTaggedIn.ItemHeight = 21;
            this.listBoxPostsWasTaggedIn.Location = new System.Drawing.Point(44, 59);
            this.listBoxPostsWasTaggedIn.Name = "listBoxPostsWasTaggedIn";
            this.listBoxPostsWasTaggedIn.Size = new System.Drawing.Size(304, 298);
            this.listBoxPostsWasTaggedIn.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.label1.Location = new System.Drawing.Point(119, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "Share your thoughts ...";
            // 
            // textBoxPostStatus
            // 
            this.textBoxPostStatus.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.textBoxPostStatus.Location = new System.Drawing.Point(34, 59);
            this.textBoxPostStatus.Name = "textBoxPostStatus";
            this.textBoxPostStatus.Size = new System.Drawing.Size(360, 27);
            this.textBoxPostStatus.TabIndex = 5;
            this.textBoxPostStatus.TextChanged += new System.EventHandler(this.textBoxPostStatus_TextChanged);
            // 
            // buttonPostStatus
            // 
            this.buttonPostStatus.Enabled = false;
            this.buttonPostStatus.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.buttonPostStatus.Location = new System.Drawing.Point(426, 52);
            this.buttonPostStatus.Name = "buttonPostStatus";
            this.buttonPostStatus.Size = new System.Drawing.Size(81, 34);
            this.buttonPostStatus.TabIndex = 6;
            this.buttonPostStatus.Text = "Post";
            this.buttonPostStatus.UseVisualStyleBackColor = true;
            this.buttonPostStatus.Click += new System.EventHandler(this.buttonPostStatus_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.pictureBoxPost);
            this.panel1.Controls.Add(this.listBoxPosts);
            this.panel1.Location = new System.Drawing.Point(30, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(474, 408);
            this.panel1.TabIndex = 7;
            // 
            // pictureBoxPost
            // 
            this.pictureBoxPost.Location = new System.Drawing.Point(286, 72);
            this.pictureBoxPost.Name = "pictureBoxPost";
            this.pictureBoxPost.Size = new System.Drawing.Size(152, 129);
            this.pictureBoxPost.TabIndex = 10;
            this.pictureBoxPost.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Controls.Add(this.listBoxPostsWasTaggedIn);
            this.panel2.Location = new System.Drawing.Point(549, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(386, 419);
            this.panel2.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel3.Controls.Add(this.buttonPostStatus);
            this.panel3.Controls.Add(this.textBoxPostStatus);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(46, 498);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(559, 106);
            this.panel3.TabIndex = 9;
            // 
            // FormPosts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1063, 616);
            this.Controls.Add(this.linkLabelExplorePosts);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.Name = "FormPosts";
            this.Text = "FormPosts";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabelExplorePosts;
        private System.Windows.Forms.ListBox listBoxPosts;
        private System.Windows.Forms.ListBox listBoxPostsWasTaggedIn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPostStatus;
        private System.Windows.Forms.Button buttonPostStatus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBoxPost;
    }
}