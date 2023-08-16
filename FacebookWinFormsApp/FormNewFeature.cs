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
    public sealed partial class FormNewFeature : Form
    {
        private LoginResult m_LoginResult;
        private User m_LoggedInUser;
        private static FormNewFeature s_FormNewFeature = null;
        private FacadeNewFeature m_FacadeNewFeature;
        private static readonly object sr_CreationalLockObject = new object();
        private readonly Dictionary<string, int> r_LocationsDictionary;
        private FormMain m_FormMain;
        private FormDesigner m_FormDesigner;

        private  FormNewFeature(LoginResult i_LoginResult, FormMain i_FormMain)
        {
            InitializeComponent();
            this.m_LoginResult = i_LoginResult;
            this.m_LoggedInUser = m_LoginResult.LoggedInUser;
            this.r_LocationsDictionary = new Dictionary<string, int>();
            this.m_FacadeNewFeature = new FacadeNewFeature(i_LoginResult);
            this.m_FacadeNewFeature.DisplayInitialInfo(r_LocationsDictionary, textBoxPopularLocation,
                                                                textBoxUnPopularLocation, webBrowser1);
            this.m_FormMain = i_FormMain;
            this.m_FormDesigner = new FormDesigner(this);
            this.m_FormMain.m_ReportBackColorChanged += new Action<Color>(m_FormDesigner.UpdateBackColor);
            this.m_FormMain.m_ReportFontChanged += new Action<Font>(m_FormDesigner.UpdateFont);
            this.BackColor = m_FormMain.CheckCurrentBackGroundColor();
            m_FormDesigner.SetAllControlsFont(this.Controls, m_FormMain.CheckCurrentFont());
        }
        public static FormNewFeature GetOrCreateFormNewFeature(LoginResult i_LoginResult, FormMain i_FormMain)
        {
            if (s_FormNewFeature == null)
            {
                lock (sr_CreationalLockObject)
                {
                    if (s_FormNewFeature == null)
                    {
                        s_FormNewFeature = new FormNewFeature(i_LoginResult, i_FormMain);
                    }
                }
            }

            return s_FormNewFeature;
        }
        private void dataGridViewLocationsCounter_SelectionChanged(object sender, EventArgs e)
        {
            m_FacadeNewFeature.ExecucuteDisplaySelectedInfo(new Object[] { dataGridViewLocationsCounter, webBrowser1 });
        }
        private void linkLabelNewFeature_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            m_FacadeNewFeature.ExecuteDisplayingInfo(new Object[] { r_LocationsDictionary, dataGridViewLocationsCounter });
        }
    }
}
