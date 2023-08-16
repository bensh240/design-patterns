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
    public class FacadePosts : IFacebookDisplayData
    {
        private LoginResult m_LoginResult;
        private User m_LoggedInUser;
        private LogicFacebookApp m_LogicFacebookApp;
        public FacadePosts(LoginResult i_LoginResult)
        {
            this.m_LoginResult = i_LoginResult;
            this.m_LoggedInUser = i_LoginResult.LoggedInUser;
            m_LogicFacebookApp = new LogicFacebookApp(i_LoginResult);
        }
        public void ExecuteDisplayingInfo(Object[] i_Objects)
        {
            ListBox listBoxPosts = i_Objects[0] as ListBox;
            ListBox listBoxPostsTaggedIn = i_Objects[1] as ListBox;
            Thread thread1 = new Thread(() => m_LogicFacebookApp.ExplorePosts(listBoxPosts));
            thread1.Start();
            Thread thread2 = new Thread(() => m_LogicFacebookApp.ExplorePostsTaggedIn(listBoxPostsTaggedIn));
            thread2.Start();
        }
        public void ExecucuteDisplaySelectedInfo(Object[] i_ObjectArr)
        {
            ListBox i_ListBox = i_ObjectArr[0] as ListBox;
            PictureBox i_PictureBox = i_ObjectArr[1] as PictureBox;
            m_LogicFacebookApp.DisplayPhotoOfPost(i_ListBox, i_PictureBox);
        }

        internal void PostStatus(TextBox i_TextBox)
        {
            m_LogicFacebookApp.PostStatus(i_TextBox);
        }
    }
}
