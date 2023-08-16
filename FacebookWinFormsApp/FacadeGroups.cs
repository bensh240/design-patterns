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
    public class FacadeGroups : IFacebookDisplayData
    {
        private LoginResult m_LoginResult;
        private User m_LoggedInUser;
        private LogicFacebookApp m_LogicFacebookApp;
        public FacadeGroups(LoginResult i_LoginResult)
        {
            this.m_LoginResult = i_LoginResult;
            this.m_LoggedInUser = i_LoginResult.LoggedInUser;
            m_LogicFacebookApp = new LogicFacebookApp(i_LoginResult);
        }

        public void ExecuteDisplayingInfo(Object[] i_Objects)
        {
            ListBox listBoxGroups = i_Objects[0] as ListBox;
            m_LogicFacebookApp.ExploreYourGroups(listBoxGroups);
        }
        public void ExecucuteDisplaySelectedInfo(Object[] i_Objects)
        {
            ListBox listBoxGroups = i_Objects[0] as ListBox;
            PictureBox pictureBoxGroup = i_Objects[1] as PictureBox;
            TextBox textBoxGroupDescription = i_Objects[2] as TextBox;

            m_LogicFacebookApp.DisplayGroupWallPosts(listBoxGroups);
            m_LogicFacebookApp.DisplayGroupMembers(listBoxGroups);
            m_LogicFacebookApp.DisplayGroupPicture(listBoxGroups, pictureBoxGroup);
            m_LogicFacebookApp.DisplayGroupDecription(listBoxGroups, textBoxGroupDescription);
        }
    }
}
