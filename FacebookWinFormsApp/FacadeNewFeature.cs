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
    public class FacadeNewFeature: IFacebookDisplayData
    {
        private LoginResult m_LoginResult;
        private User m_LoggedInUser;
        private LogicFacebookApp m_LogicFacebookApp;
        public FacadeNewFeature(LoginResult i_LoginResult)
        {
            this.m_LoginResult = i_LoginResult;
            this.m_LoggedInUser = i_LoginResult.LoggedInUser;
            m_LogicFacebookApp = new LogicFacebookApp(i_LoginResult);
        }

        public void ExecuteDisplayingInfo(Object[] i_Objects)
        {
            Dictionary<string, int> locationsDictionary = i_Objects[0] as Dictionary<string, int>;
            DataGridView dataGridViewLocationsCounter = i_Objects[1] as DataGridView;

            m_LogicFacebookApp.ShowLocationDetailsInTable(locationsDictionary, dataGridViewLocationsCounter);
        }
        public void ExecucuteDisplaySelectedInfo(Object[] i_Objects)
        {
            DataGridView dataGridViewLocationsCounter = i_Objects[0] as DataGridView;
            WebBrowser webBrowser1 = i_Objects[1] as WebBrowser;
            m_LogicFacebookApp.ShowLocationInGoogle(dataGridViewLocationsCounter, webBrowser1);
        }
        internal void DisplayInitialInfo(Dictionary<string, int> i_LocationsDictionary,
            TextBox i_TextBoxPopularLocation, TextBox i_TextBoxUnPopularLocation, WebBrowser i_WebBrowser)
        {
            m_LogicFacebookApp.FillLocationsDict(i_LocationsDictionary);
            m_LogicFacebookApp.ShowMostPopularLocationAndMostUnpopularLocation(i_LocationsDictionary,
                i_TextBoxPopularLocation, i_TextBoxUnPopularLocation);
            m_LogicFacebookApp.ExploreInGoogledMostUnpopularLocation(i_TextBoxUnPopularLocation, i_WebBrowser);
        }

    }
}
