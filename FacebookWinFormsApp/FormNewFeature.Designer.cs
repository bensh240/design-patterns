namespace BasicFacebookFeatures
{
    partial class FormNewFeature
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
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.dataGridViewLocationsCounter = new System.Windows.Forms.DataGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.textBoxPopularLocation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxUnPopularLocation = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.linkLabelNewFeature = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLocationsCounter)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(857, 44);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(384, 490);
            this.webBrowser1.TabIndex = 1;
            // 
            // dataGridViewLocationsCounter
            // 
            this.dataGridViewLocationsCounter.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dataGridViewLocationsCounter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLocationsCounter.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dataGridViewLocationsCounter.Location = new System.Drawing.Point(22, 44);
            this.dataGridViewLocationsCounter.Name = "dataGridViewLocationsCounter";
            this.dataGridViewLocationsCounter.RowHeadersWidth = 62;
            this.dataGridViewLocationsCounter.RowTemplate.Height = 28;
            this.dataGridViewLocationsCounter.Size = new System.Drawing.Size(360, 369);
            this.dataGridViewLocationsCounter.TabIndex = 2;
            this.dataGridViewLocationsCounter.SelectionChanged += new System.EventHandler(this.dataGridViewLocationsCounter_SelectionChanged);
            // 
            // textBoxPopularLocation
            // 
            this.textBoxPopularLocation.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.textBoxPopularLocation.Location = new System.Drawing.Point(65, 51);
            this.textBoxPopularLocation.Name = "textBoxPopularLocation";
            this.textBoxPopularLocation.Size = new System.Drawing.Size(212, 27);
            this.textBoxPopularLocation.TabIndex = 3;
            this.textBoxPopularLocation.Text = "Most popuar location";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.label1.Location = new System.Drawing.Point(46, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "Your most popular location is:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.label2.Location = new System.Drawing.Point(15, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(331, 84);
            this.label2.TabIndex = 5;
            this.label2.Text = "Our recommendation is to visit new\r\n places every day. The place that we find\r\n a" +
    "s your most unvisited one is :\r\n\r\n";
            // 
            // textBoxUnPopularLocation
            // 
            this.textBoxUnPopularLocation.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.textBoxUnPopularLocation.Location = new System.Drawing.Point(28, 82);
            this.textBoxUnPopularLocation.Name = "textBoxUnPopularLocation";
            this.textBoxUnPopularLocation.Size = new System.Drawing.Size(361, 27);
            this.textBoxUnPopularLocation.TabIndex = 6;
            this.textBoxUnPopularLocation.Text = "Most unpopuar location";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxPopularLocation);
            this.panel1.Location = new System.Drawing.Point(454, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(341, 103);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Controls.Add(this.textBoxUnPopularLocation);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(406, 184);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(432, 129);
            this.panel2.TabIndex = 8;
            // 
            // linkLabelNewFeature
            // 
            this.linkLabelNewFeature.AutoSize = true;
            this.linkLabelNewFeature.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.linkLabelNewFeature.Location = new System.Drawing.Point(126, 9);
            this.linkLabelNewFeature.Name = "linkLabelNewFeature";
            this.linkLabelNewFeature.Size = new System.Drawing.Size(142, 21);
            this.linkLabelNewFeature.TabIndex = 9;
            this.linkLabelNewFeature.TabStop = true;
            this.linkLabelNewFeature.Text = "Display locations ";
            this.linkLabelNewFeature.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelNewFeature_LinkClicked);
            // 
            // FormNewFeature
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1277, 558);
            this.Controls.Add(this.linkLabelNewFeature);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridViewLocationsCounter);
            this.Controls.Add(this.webBrowser1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormNewFeature";
            this.Text = "FormLocations";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLocationsCounter)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.DataGridView dataGridViewLocationsCounter;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox textBoxPopularLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxUnPopularLocation;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.LinkLabel linkLabelNewFeature;
    }
}