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
    public sealed partial class FormGroups : Form
    {
        private LoginResult m_LoginResult;
        private User m_LoggedInUser;
        private static FormGroups s_FormGroups = null;
        private static readonly object sr_CreationalLockObject = new object();
        private FacadeGroups m_FacadeGroups;
        private FormMain m_FormMain;
        private FormDesigner m_FormDesigner;

        private FormGroups(LoginResult i_LoginResult, FormMain i_FormMain)
        {
            InitializeComponent();
            this.m_LoginResult = i_LoginResult;
            this.m_LoggedInUser = m_LoginResult.LoggedInUser;
            this.m_FacadeGroups = new FacadeGroups(i_LoginResult);
            this.m_FormMain = i_FormMain;
            this.m_FormDesigner = new FormDesigner(this);
            this.m_FormMain.m_ReportBackColorChanged += new Action<Color>(m_FormDesigner.UpdateBackColor);
            this.m_FormMain.m_ReportFontChanged += new Action<Font>(m_FormDesigner.UpdateFont);
            this.BackColor = m_FormMain.CheckCurrentBackGroundColor();
            m_FormDesigner.SetAllControlsFont(this.Controls, m_FormMain.CheckCurrentFont());
        }
        public static FormGroups GetOrCreateFormGroups(LoginResult i_LoginResult, FormMain i_FormMain)
        {
            if (s_FormGroups == null)
            {
                lock (sr_CreationalLockObject)
                {
                    if (s_FormGroups == null)
                    {
                        s_FormGroups = new FormGroups(i_LoginResult, i_FormMain);
                    }
                }
            }

            return s_FormGroups;
        }
        private void linkLabelGroups_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            m_FacadeGroups.ExecuteDisplayingInfo(new Object[] { listBoxGroups });
        }
        private void listBoxGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_FacadeGroups.ExecucuteDisplaySelectedInfo(new Object[] { listBoxGroups, pictureBoxGroup, textBoxGroupDescription });
        }
    }
}
