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
    public class FacadeLikedPages : IFacebookDisplayData
    {
        private LoginResult m_LoginResult;
        private User m_LoggedInUser;
        private LogicFacebookApp m_LogicFacebookApp;
        public FacadeLikedPages(LoginResult i_LoginResult)
        {
            this.m_LoginResult = i_LoginResult;
            this.m_LoggedInUser = i_LoginResult.LoggedInUser;
            m_LogicFacebookApp = new LogicFacebookApp(i_LoginResult);
        }
        public void ExecuteDisplayingInfo(Object[] i_Objects)
        {
            ListBox listBoxLikedPages = i_Objects[0] as ListBox;
            m_LogicFacebookApp.ExploreLikedPages(listBoxLikedPages);
        }
        public void ExecucuteDisplaySelectedInfo(Object[] i_Objects)
        {
            ListBox listBoxLikedPageInfo = i_Objects[0] as ListBox;
            PictureBox pictureBoxChosenLikedPage = i_Objects[1] as PictureBox;
            TextBox textBoxLikedPage = i_Objects[2] as TextBox;
            m_LogicFacebookApp.DisplayPagePicture(listBoxLikedPageInfo, pictureBoxChosenLikedPage);
            m_LogicFacebookApp.DisplayPageDescription(listBoxLikedPageInfo, textBoxLikedPage);
        }
    }
}
