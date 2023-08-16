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
    public class FacadeAlbums : IFacebookDisplayData
    {
        private LoginResult m_LoginResult;
        private User m_LoggedInUser;
        private LogicFacebookApp m_LogicFacebookApp;

        public FacadeAlbums(LoginResult i_LoginResult)
        {
            this.m_LoginResult = i_LoginResult;
            this.m_LoggedInUser = i_LoginResult.LoggedInUser;
            m_LogicFacebookApp = new LogicFacebookApp(i_LoginResult);
        }
        public void ExecuteDisplayingInfo(Object[] i_Objects)
        {
                ListBox listBox = i_Objects[0] as ListBox;
                Thread thread = new Thread(() => m_LogicFacebookApp.ExploreAlbums(listBox));
                thread.Start();
        }
        public void ExecucuteDisplaySelectedInfo(Object[] i_Objects)
        {
            ListBox listBoxAlbums = i_Objects[0] as ListBox;
            TextBox textBoxAlbumLocation = i_Objects[1] as TextBox;
            PictureBox pictureBoxAlbum = i_Objects[2] as PictureBox;
            PictureBox[] fourPicturesArr = i_Objects[3] as PictureBox[];
            Thread thread = new Thread(() =>
            {
                m_LogicFacebookApp.DisplayAlbumLocation(listBoxAlbums, textBoxAlbumLocation);
                m_LogicFacebookApp.DispayAlbumPicture(listBoxAlbums, pictureBoxAlbum);
                m_LogicFacebookApp.DisplayFourPicturtsFromAlbum(listBoxAlbums, fourPicturesArr);
            });
            thread.Start();
        }
    }
}
