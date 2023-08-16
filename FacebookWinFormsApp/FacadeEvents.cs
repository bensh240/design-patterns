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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BasicFacebookFeatures
{
    public class FacadeEvents: IFacebookDisplayData
    {
        private LoginResult m_LoginResult;
        private User m_LoggedInUser;
        private LogicFacebookApp m_LogicFacebookApp;
        public FacadeEvents(LoginResult i_LoginResult)
        {
            this.m_LoginResult = i_LoginResult;
            this.m_LoggedInUser = i_LoginResult.LoggedInUser;
            m_LogicFacebookApp = new LogicFacebookApp(i_LoginResult);
        }
        public void ExecuteDisplayingInfo(Object[] i_Objects)
        {
            ListBox listBoxEvents = i_Objects[0] as ListBox;
            Dictionary<Event, double> eventsDictionary = i_Objects[1] as Dictionary<Event, double>;
            m_LogicFacebookApp.DisplayEventsSortedByLocationFromloggedUser(listBoxEvents, eventsDictionary);
        }
        public void ExecucuteDisplaySelectedInfo(Object[] i_Objects)
        {
            ListBox listBoxEvents = i_Objects[0] as ListBox;
            Dictionary<Event, double> eventsDictionary = i_Objects[1] as Dictionary<Event, double>;
            System.Windows.Forms.TextBox textBoxDistance = i_Objects[2] as System.Windows.Forms.TextBox;
            System.Windows.Forms.TextBox textBoxDescription = i_Objects[3] as System.Windows.Forms.TextBox;
            System.Windows.Forms.TextBox textBoxNumOfAttendings = i_Objects[4] as System.Windows.Forms.TextBox;
            System.Windows.Forms.TextBox textBoxNumOfDeclines = i_Objects[5] as System.Windows.Forms.TextBox;
            PictureBox pictureBoxEvent = i_Objects[6] as PictureBox;
            System.Windows.Forms.TextBox textBoxEventLocation = i_Objects[7] as System.Windows.Forms.TextBox;

            m_LogicFacebookApp.DisplayDistanceFromYourCityToEventLocation(listBoxEvents, eventsDictionary, textBoxDistance);
            m_LogicFacebookApp.DislplayEventDescription(listBoxEvents, textBoxDescription);
            m_LogicFacebookApp.DisplayEventAttendingsAndDeclines(listBoxEvents, textBoxNumOfAttendings, textBoxNumOfDeclines);
            m_LogicFacebookApp.DisplayEventPicture(listBoxEvents, pictureBoxEvent);
            m_LogicFacebookApp.DisplayEventLocation(listBoxEvents, textBoxEventLocation);
        }
    }
}
