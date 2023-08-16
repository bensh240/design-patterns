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
using System.Speech.Synthesis.TtsEngine;

namespace BasicFacebookFeatures
{
    public sealed partial class FormFriends : Form
    {
        private LoginResult m_LoginResult;
        private User m_LoggedInUser;
        private static FormFriends s_FormFriends = null;
        private static readonly object sr_CreationalLockObject = new object();
        private readonly Dictionary<User, double> r_FriendsDictionary;
        private readonly Dictionary<string, CheckBox> r_MonthCheckBoxes;
        private FacadeFriends m_FacadeFriends;
        private DummyData m_DummyData = new DummyData();
        private FormMain m_FormMain;
        private FormDesigner m_FormDesigner;

        private FormFriends(LoginResult loginResult, FormMain i_FormMain)
        {
            InitializeComponent();
            this.m_FormMain = i_FormMain;
            this.m_FacadeFriends = new FacadeFriends(loginResult);
            this.m_LoginResult = loginResult;
            this.m_LoggedInUser = loginResult.LoggedInUser;
            r_MonthCheckBoxes = new Dictionary<string, CheckBox>()
            {
                { "01", checkBoxJanuary}, { "02", checkBoxFebruary}, { "03", checkBoxMarch},
                { "04", checkBoxApril}, { "05", checkBoxMay}, { "06", checkBoxJune}, { "07", checkBoxJuly},
                { "08", checkBoxAugust}, { "09", checkBoxSeptember}, { "10", checkBoxOctober}, { "11", checkBoxNovember},
                { "12", checkBoxDecember}
            };
            this.m_FormDesigner = new FormDesigner(this);
            this.m_FormMain.m_ReportBackColorChanged += new Action<Color>(m_FormDesigner.UpdateBackColor);
            this.m_FormMain.m_ReportFontChanged += new Action<Font>(m_FormDesigner.UpdateFont);
            this.BackColor = m_FormMain.CheckCurrentBackGroundColor();
            m_FormDesigner.SetAllControlsFont(this.Controls, m_FormMain.CheckCurrentFont());

        }
        public static FormFriends GetOrCreateFormFriends(LoginResult i_LoginResult, FormMain i_FormMain)
        {
            if (s_FormFriends == null)
            {
                lock (sr_CreationalLockObject)
                {
                    if (s_FormFriends == null)
                    {
                        s_FormFriends = new FormFriends(i_LoginResult, i_FormMain);
                    }
                }
            }

            return s_FormFriends;
        }
        // The original code was supposed to work with data binding, but since the app doesn't get any data from
        // the server regarding the friends, we have created dummy data (and dummy friend) that works in the same logic.
        private void linkLabelFriendsList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //userBindingSource.DataSource = m_LoggedInUser.Friends;
            m_FacadeFriends.GetDummyFriends(listBoxFriends);
            
        }
        private void listBoxFriends_SelectedIndexChanged(object sender, EventArgs e)
        {
            //m_FormsFacade.ShowDistance(textBoxDistance, listBoxFriends);
            m_FacadeFriends.GetInfoOnSelectedDummyFriend(listBoxFriends, birthdayTextBox, emailTextBox, religionTextBox,
                cityTextBox, countryTextBox, textBoxDistance);
        }
        private void checkBoxJanuary_CheckedChanged(object sender, EventArgs e)
        {
            /* m_FormsFacade.GetFriensdList(userBindingSource, r_MonthCheckBoxes);*/
            m_FacadeFriends.ShowDummyFriendsFilteredByBD(listBoxFriends, r_MonthCheckBoxes);
        }
        private void checkBoxFebruary_CheckedChanged(object sender, EventArgs e)
        {
            /* m_FormsFacade.GetFriensdList(userBindingSource, r_MonthCheckBoxes);*/
            m_FacadeFriends.ShowDummyFriendsFilteredByBD(listBoxFriends, r_MonthCheckBoxes);
        }
        private void checkBoxMarch_CheckedChanged(object sender, EventArgs e)
        {
            /* m_FormsFacade.GetFriensdList(userBindingSource, r_MonthCheckBoxes);*/
            m_FacadeFriends.ShowDummyFriendsFilteredByBD(listBoxFriends, r_MonthCheckBoxes);
        }
        private void checkBoxApril_CheckedChanged(object sender, EventArgs e)
        {
            /* m_FormsFacade.GetFriensdList(userBindingSource, r_MonthCheckBoxes);*/
            m_FacadeFriends.ShowDummyFriendsFilteredByBD(listBoxFriends, r_MonthCheckBoxes);
        }
        private void checkBoxMay_CheckedChanged(object sender, EventArgs e)
        {
            /* m_FormsFacade.GetFriensdList(userBindingSource, r_MonthCheckBoxes);*/
            m_FacadeFriends.ShowDummyFriendsFilteredByBD(listBoxFriends, r_MonthCheckBoxes);
        }
        private void checkBoxJune_CheckedChanged(object sender, EventArgs e)
        {
            /* m_FormsFacade.GetFriensdList(userBindingSource, r_MonthCheckBoxes);*/
            m_FacadeFriends.ShowDummyFriendsFilteredByBD(listBoxFriends, r_MonthCheckBoxes);
        }
        private void checkBoxJuly_CheckedChanged(object sender, EventArgs e)
        {
            /* m_FormsFacade.GetFriensdList(userBindingSource, r_MonthCheckBoxes);*/
            m_FacadeFriends.ShowDummyFriendsFilteredByBD(listBoxFriends, r_MonthCheckBoxes);
        }
        private void checkBoxAugust_CheckedChanged(object sender, EventArgs e)
        {
            /* m_FormsFacade.GetFriensdList(userBindingSource, r_MonthCheckBoxes);*/
            m_FacadeFriends.ShowDummyFriendsFilteredByBD(listBoxFriends, r_MonthCheckBoxes);
        }
        private void checkBoxSeptember_CheckedChanged(object sender, EventArgs e)
        {
            /* m_FormsFacade.GetFriensdList(userBindingSource, r_MonthCheckBoxes);*/
            m_FacadeFriends.ShowDummyFriendsFilteredByBD(listBoxFriends, r_MonthCheckBoxes);
        }
        private void checkBoxOctober_CheckedChanged(object sender, EventArgs e)
        {
            /* m_FormsFacade.GetFriensdList(userBindingSource, r_MonthCheckBoxes);*/
            m_FacadeFriends.ShowDummyFriendsFilteredByBD(listBoxFriends, r_MonthCheckBoxes);
        }
        private void checkBoxNovember_CheckedChanged(object sender, EventArgs e)
        {
            /* m_FormsFacade.GetFriensdList(userBindingSource, r_MonthCheckBoxes);*/
            m_FacadeFriends.ShowDummyFriendsFilteredByBD(listBoxFriends, r_MonthCheckBoxes);
        }
        private void checkBoxDecember_CheckedChanged(object sender, EventArgs e)
        {
            /* m_FormsFacade.GetFriensdList(userBindingSource, r_MonthCheckBoxes);*/
            m_FacadeFriends.ShowDummyFriendsFilteredByBD(listBoxFriends, r_MonthCheckBoxes);
        }
    }
}
