using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;

namespace BasicFacebookFeatures
{
    public class FacadeFriends
    {
        private LoginResult m_LoginResult;
        private User m_LoggedInUser;
        private LogicFacebookApp m_LogicFacebookApp;


        public FacadeFriends(LoginResult i_LoginResult)
        {
            this.m_LoginResult = i_LoginResult;
            this.m_LoggedInUser = i_LoginResult.LoggedInUser;
            m_LogicFacebookApp = new LogicFacebookApp(i_LoginResult);
        }

        internal void ShowDistance(TextBox i_TextBoxDistance, ListBox i_ListBoxFriends)
        {
            m_LogicFacebookApp.CalcDistance(i_TextBoxDistance, i_ListBoxFriends);
        }
        internal void GetFriensdList(BindingSource i_UserBindingSource, Dictionary<string, CheckBox> i_MonthCheckBoxes)
        {
            m_LogicFacebookApp.ShowFriendsFilteredByBDMonth(i_UserBindingSource, i_MonthCheckBoxes);
        }
        internal void GetDummyFriends(ListBox i_listBoxFriends)
        {
            m_LogicFacebookApp.FillListBoxDummyFriends(i_listBoxFriends);
        }
        internal void GetInfoOnSelectedDummyFriend(ListBox i_ListBox, TextBox i_BirthdayTextBox,
            TextBox i_EmailTextBox, TextBox i_ReligionTextBox, TextBox i_CityTextBox, TextBox i_CountryTextBox,
            TextBox i_TextBoxDistance)
        {
            m_LogicFacebookApp.DisplayInfoOnSelectedDummyFriend(i_ListBox, i_BirthdayTextBox,
            i_EmailTextBox, i_ReligionTextBox, i_CityTextBox, i_CountryTextBox, i_TextBoxDistance);
        }
        internal void ShowDummyFriendsFilteredByBD(ListBox i_ListBox, Dictionary<string, CheckBox> i_MonthCheckBoxes)
        {
            m_LogicFacebookApp.ShowDummyFriendsFiltredByBirthDay(i_ListBox, i_MonthCheckBoxes);
        }
    }
}
