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
    public sealed partial class FormLikedPages : Form
    {
        private LoginResult m_LoginResult;
        private User m_LoggedInUser;
        private static FormLikedPages s_FormLikedPages = null;
        private FacadeLikedPages m_FacadeLikedPages;
        private static readonly object sr_CreationalLockObject = new object();
        private FormMain m_FormMain;
        private FormDesigner m_FormDesigner;

        private FormLikedPages(LoginResult i_LoginResult, FormMain i_FormMain)
        {
            InitializeComponent();
            this.m_FormMain = i_FormMain;
            this.m_LoginResult = i_LoginResult;
            this.m_LoggedInUser = m_LoginResult.LoggedInUser;
            this.m_FacadeLikedPages = new FacadeLikedPages(i_LoginResult);
            this.m_FormDesigner = new FormDesigner(this);
            this.m_FormMain.m_ReportBackColorChanged += new Action<Color>(m_FormDesigner.UpdateBackColor);
            this.m_FormMain.m_ReportFontChanged += new Action<Font>(m_FormDesigner.UpdateFont);
            this.BackColor = m_FormMain.CheckCurrentBackGroundColor();
            m_FormDesigner.SetAllControlsFont(this.Controls, m_FormMain.CheckCurrentFont());

        }
        public static FormLikedPages GetOrCreateFormLikedPages(LoginResult i_LoginResult, FormMain i_FormMain)
        {
            if (s_FormLikedPages == null)
            {
                lock (sr_CreationalLockObject)
                {
                    if (s_FormLikedPages == null)
                    {
                        s_FormLikedPages = new FormLikedPages(i_LoginResult, i_FormMain);
                    }
                }
            }

            return s_FormLikedPages;
        }
        private void linkLabelLikedPages_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            m_FacadeLikedPages.ExecuteDisplayingInfo(new Object[] { listBoxLikedPages });
        }
        private void listBoxLikedPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_FacadeLikedPages.ExecucuteDisplaySelectedInfo(new Object[] { listBoxLikedPages, pictureBoxChosenLikedPage, textBoxLikedPage });
        }
    }
}
