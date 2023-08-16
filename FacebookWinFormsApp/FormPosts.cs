using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;

namespace BasicFacebookFeatures
{
    public sealed partial class FormPosts : Form
    {
        private LoginResult m_LoginResult;
        private User m_LoggedInUser;
        private static FormPosts s_FormPosts = null;
        private static readonly object sr_CreationalLockObject = new object();
        private FacadePosts m_FacadePosts;
        private FormMain m_FormMain;
        private FormDesigner m_FormDesigner;

        private FormPosts(LoginResult i_LoginResult, FormMain i_FormMain)
        {
            InitializeComponent();
            this.m_LoginResult = i_LoginResult;
            this.m_LoggedInUser = m_LoginResult.LoggedInUser;
            this.m_FacadePosts = new FacadePosts(i_LoginResult);
            this.m_FormMain = i_FormMain;
            this.m_FormDesigner = new FormDesigner(this);
            this.m_FormMain.m_ReportBackColorChanged += new Action<Color>(m_FormDesigner.UpdateBackColor);
            this.m_FormMain.m_ReportFontChanged += new Action<Font>(m_FormDesigner.UpdateFont);
            this.BackColor = m_FormMain.CheckCurrentBackGroundColor();
            m_FormDesigner.SetAllControlsFont(this.Controls, m_FormMain.CheckCurrentFont());
        }
        public static FormPosts GetOrCreateFormPosts(LoginResult i_LoginResult, FormMain i_FormMain)
        {
            if (s_FormPosts == null)
            {
                lock (sr_CreationalLockObject) 
                {
                    if (s_FormPosts == null)
                    {
                        s_FormPosts = new FormPosts(i_LoginResult, i_FormMain);
                    }
                }
            }

            return s_FormPosts;
        }
        private void linkLabelExplorePosts_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            m_FacadePosts.ExecuteDisplayingInfo(new object[] { listBoxPosts, listBoxPosts });
        }
        private void listBoxPosts_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_FacadePosts.ExecucuteDisplaySelectedInfo(new object[] { listBoxPosts, pictureBoxPost });
        }
        private void buttonPostStatus_Click(object sender, EventArgs e)
        {
            m_FacadePosts.PostStatus(textBoxPostStatus);
        }
        private void textBoxPostStatus_TextChanged(object sender, EventArgs e)
        {
            this.buttonPostStatus.Enabled = !string.IsNullOrWhiteSpace(this.textBoxPostStatus.Text);
        }
    }
}
