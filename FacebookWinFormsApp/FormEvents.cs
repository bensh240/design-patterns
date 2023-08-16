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
    public sealed partial class FormEvents : Form
    {
        private LoginResult m_LoginResult;
        private User m_LoggedInUser;
        private static FormEvents s_FormEvents = null;
        private static readonly object sr_CreationalLockObject = new object();
        private FacadeEvents m_FacadeEvent;
        private readonly Dictionary<Event, double> r_EventsDictionary;
        private FormMain m_FormMain;
        private FormDesigner m_FormDesigner;


        private FormEvents(LoginResult i_LoginResult, FormMain i_FormMain)
        {
            InitializeComponent();
            this.m_FormDesigner = new FormDesigner(this);
            this.m_LoginResult = i_LoginResult;
            this.m_LoggedInUser = m_LoginResult.LoggedInUser;
            this.m_FacadeEvent = new FacadeEvents(i_LoginResult);
            r_EventsDictionary = new Dictionary<Event, double>();
            this.m_FormMain = i_FormMain;
            this.BackColor = m_FormMain.CheckCurrentBackGroundColor();
            m_FormDesigner.SetAllControlsFont(this.Controls, m_FormMain.CheckCurrentFont());
            this.m_FormMain.m_ReportBackColorChanged += new Action<Color>(m_FormDesigner.UpdateBackColor);
            this.m_FormMain.m_ReportFontChanged += new Action<Font>(m_FormDesigner.UpdateFont);
        }
    

        public static FormEvents GetOrCreateFormEvents(LoginResult i_LoginResult, FormMain i_FormMain)
        {
            if (s_FormEvents == null)
            {
                lock (sr_CreationalLockObject)
                {
                    if (s_FormEvents == null)
                    {
                        s_FormEvents = new FormEvents(i_LoginResult, i_FormMain);
                    }
                }
            }

            return s_FormEvents;
        }
        private void linkLabelEvents_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            m_FacadeEvent.ExecuteDisplayingInfo(new Object[] { listBoxEvents, r_EventsDictionary });
        }
        private void listBoxEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_FacadeEvent.ExecucuteDisplaySelectedInfo(new Object[] {listBoxEvents, r_EventsDictionary, textBoxDistance, textBoxDescription,
                textBoxNumOfAttendings, textBoxNumOfDeclines, pictureBoxEvent, textBoxEventLocation });
        }
    }
}
