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
using CefSharp;

namespace BasicFacebookFeatures
{
    public sealed partial class FormAlbums : Form
    {
        private LoginResult m_LoginResult;
        private User m_LoggedInUser;
        private static FormAlbums s_FormAlbums = null;
        private static readonly object sr_CreationalLockObject = new object();
        private FacadeAlbums m_FacadeAlbum;
        private readonly PictureBox[] r_FourPicturesArr = new PictureBox[4];
        private FormMain m_FormMain;
        private FormDesigner m_FormDesigner;

        private FormAlbums(LoginResult i_LoginResult, FormMain i_FormMain)
        {
            InitializeComponent();
            this.m_FormDesigner = new FormDesigner(this);
            this.m_LoginResult = i_LoginResult;
            this.m_LoggedInUser = m_LoginResult.LoggedInUser;
            this.m_FacadeAlbum = new FacadeAlbums(i_LoginResult);
            this.r_FourPicturesArr[0] = pictureBox1;
            this.r_FourPicturesArr[1] = pictureBox2;
            this.r_FourPicturesArr[2] = pictureBox3;
            this.r_FourPicturesArr[3] = pictureBox4;
            this.m_FormMain = i_FormMain;
            this.BackColor = m_FormMain.CheckCurrentBackGroundColor();
            m_FormDesigner.SetAllControlsFont(this.Controls, m_FormMain.CheckCurrentFont());
            this.m_FormMain.m_ReportBackColorChanged += new Action<Color>(m_FormDesigner.UpdateBackColor);
            this.m_FormMain.m_ReportFontChanged += new Action<Font>(m_FormDesigner.UpdateFont);
        }

        public static FormAlbums GetOrCreateFormAlbums(LoginResult i_LoginResult, FormMain i_FormMain)
        {
            if (s_FormAlbums == null)
            {
                lock (sr_CreationalLockObject)
                {
                    if (s_FormAlbums == null)
                    {
                        s_FormAlbums = new FormAlbums(i_LoginResult, i_FormMain);
                    }
                }
            }

            return s_FormAlbums;
        }

        private void linkLabelExploreAlbums_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            m_FacadeAlbum.ExecuteDisplayingInfo(new Object[] { listBoxAlbums });
        }
        private void listBoxAlbums_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_FacadeAlbum.ExecucuteDisplaySelectedInfo(new Object[] { listBoxAlbums, textBoxAlbumLocation, pictureBoxAlbum, r_FourPicturesArr });

        }
    }
}
