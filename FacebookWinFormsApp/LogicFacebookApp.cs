using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using CefSharp;
using System.Data;
using System.Drawing;
 

namespace BasicFacebookFeatures
{
    internal class LogicFacebookApp
    {
        private LoginResult m_LoginResult;
        private User m_LoggedInUser;
        private DummyData m_DummyData = new DummyData();
        public LogicFacebookApp(LoginResult i_LoginResult)
        {
            this.m_LoginResult = i_LoginResult;
            this.m_LoggedInUser = i_LoginResult.LoggedInUser;
        }
        internal static void DisplayPicture(PictureBox io_PictueBox, string io_PictureUrl)
        {
            if (!string.IsNullOrEmpty(io_PictureUrl))
            {
                io_PictueBox.LoadAsync(io_PictureUrl);
            }
            else
            {
                io_PictueBox.Image = io_PictueBox.ErrorImage;
            }
        }
        internal static void DisplayDescription(TextBox io_TextBox, string io_Description)
        {
            if (!string.IsNullOrEmpty(io_Description))
            {
                io_TextBox.Text = io_Description;
            }
            else
            {
                io_TextBox.Text = "Description wasn't found ...";
            }
        }
        internal static void DisplayLocation(TextBox io_TextBox, string io_Location)
        {
            if (!string.IsNullOrEmpty(io_Location))
            {
                io_TextBox.Text = io_Location;
            }
            else
            {
                io_TextBox.Text = "Location wasn't found ...";
            }
        }
        internal static void DisplayWallPosts(ListBox io_ListBox, FacebookObjectCollection<Post> io_PostCollection)
        {
            foreach (Post post in io_PostCollection)
            {
                if (!string.IsNullOrEmpty(post.Message))
                {
                    io_ListBox.Items.Add(post.Message);
                }
                else if (!string.IsNullOrEmpty(post.Caption))
                {
                    io_ListBox.Items.Add(post.Caption);
                }
            }
        }
        internal void ExploreAlbums(ListBox i_ListBoxAlbums)
        {
            i_ListBoxAlbums.Invoke(new Action(() => i_ListBoxAlbums.DisplayMember = "Name"));
            foreach (Album album in m_LoggedInUser.Albums)
            {
                i_ListBoxAlbums.Invoke(new Action(() => i_ListBoxAlbums.Items.Add(album)));

            }
            i_ListBoxAlbums.Invoke(new Action(() => {
                if (i_ListBoxAlbums.Items.Count == 0)
                {
                    MessageBox.Show("No Albums to retrieve");
                }
            }));
        }
        internal void DisplayAlbumLocation(ListBox i_ListBoxAlbums, TextBox i_TextBoxAlbumLocation)
        {
            if (i_ListBoxAlbums.SelectedItems.Count == 1)
            {
                Album selectedAlbum = i_ListBoxAlbums.SelectedItem as Album;
                i_ListBoxAlbums.Invoke(new Action(() => LogicFacebookApp.DisplayLocation(i_TextBoxAlbumLocation, selectedAlbum.Location)));
            }
        }
        internal void DispayAlbumPicture(ListBox i_ListBoxAlbums, PictureBox i_PictureBoxAlbum)
        {
            if (i_ListBoxAlbums.SelectedItems.Count == 1)
            {
                Album selectedAlbum = i_ListBoxAlbums.SelectedItem as Album;
                i_ListBoxAlbums.Invoke(new Action(() => LogicFacebookApp.DisplayPicture(i_PictureBoxAlbum, selectedAlbum.PictureAlbumURL)));
            }
        }
        internal void DisplayFourPicturtsFromAlbum(ListBox i_ListBoxAlbums, PictureBox[] i_FourPicturesArr)
        {
            if (i_ListBoxAlbums.SelectedItems.Count == 1)
            {
                Album selectedAlbum = i_ListBoxAlbums.SelectedItem as Album;
                i_ListBoxAlbums.Invoke(new Action(() => DisplayFourPicturts(i_ListBoxAlbums, i_FourPicturesArr, selectedAlbum)));
            }
        }
        private void DisplayFourPicturts(ListBox i_listBoxAlbums, PictureBox[] i_FourPicturesArr, Album i_SelectedAlbum)
        {
            int amoumtOfPhotosInAlbum = Math.Min(i_SelectedAlbum.Photos.Count, 4), i;
            for (i = 0; i < amoumtOfPhotosInAlbum; i++)
            {
                i_FourPicturesArr[i].LoadAsync(i_SelectedAlbum.Photos[i].PictureThumbURL);
            }
            for (int j = i; j < 4; j++)
            {
                i_FourPicturesArr[j].Image = i_FourPicturesArr[j].ErrorImage;
            }
        }
        internal void DisplayEventsSortedByLocationFromloggedUser(ListBox i_ListBoxEvents, Dictionary<Event, double> i_EventsDictionary)
        {
            i_ListBoxEvents.Items.Clear();
            i_ListBoxEvents.DisplayMember = "Name";
            double userLatitude = 0;
            double userLongitude = 0;
            if (m_LoggedInUser.Hometown != null && m_LoggedInUser.Hometown.Location != null)
            {
                userLatitude = (double)m_LoggedInUser.Hometown.Location.Latitude;
                userLatitude = (double)m_LoggedInUser.Hometown.Location.Longitude;
            }
            foreach (Event fbEvent in m_LoggedInUser.Events)
            {
                double eventLatitude = 0, eventLongitude = 0;
                if (fbEvent.Venue != null && fbEvent.Venue.Location != null)
                {
                    eventLatitude = (double)fbEvent.Venue.Location.Latitude;
                    eventLongitude = (double)fbEvent.Venue.Location.Longitude;
                }
                i_EventsDictionary.Add(fbEvent, calcDistanceMethodByKilometer(userLatitude, userLongitude, eventLatitude, eventLongitude));
            }
        
            if (i_EventsDictionary.Count == 0)
            {
                MessageBox.Show("Sorry, the list is empty :(");
            }
            else
            {
                foreach (KeyValuePair<Event, double> entry in i_EventsDictionary.OrderBy(key => key.Value))
                {
                    i_ListBoxEvents.Items.Add(entry.Key);
                }
            }
        }
        internal void DisplayDistanceFromYourCityToEventLocation(ListBox i_ListBoxEvents, Dictionary<Event, double> i_EventsDictionary, TextBox i_TextBoxDistance)
        {
            if (i_ListBoxEvents.SelectedItems.Count == 1)
            {
                Event selectedEvent = i_ListBoxEvents.SelectedItem as Event;
                i_TextBoxDistance.Text = i_EventsDictionary[selectedEvent] + "Km";
            }
        }
        internal void DislplayEventDescription(ListBox i_ListBoxEvents, TextBox i_TextBoxDescription)
        {
            if (i_ListBoxEvents.SelectedItems.Count == 1)
            {
                Event selectedEvent = i_ListBoxEvents.SelectedItem as Event;
                LogicFacebookApp.DisplayDescription(i_TextBoxDescription, selectedEvent.Description);
            }
        }
        internal void DisplayEventAttendingsAndDeclines(ListBox i_ListBoxEvents, TextBox i_TextBoxNumOfAttendings,
            TextBox i_TextBoxNumOfDeclines)
        {
            if (i_ListBoxEvents.SelectedItems.Count == 1)
            {
                Event selectedEvent = i_ListBoxEvents.SelectedItem as Event;
                i_TextBoxNumOfAttendings.Text = selectedEvent.AttendingCount.ToString();
                i_TextBoxNumOfDeclines.Text = selectedEvent.DeclinedCount.ToString();
            }
        }
        internal void DisplayEventPicture(ListBox i_ListBoxEvents, PictureBox i_PictureBoxEvent)
        {
            if (i_ListBoxEvents.SelectedItems.Count == 1)
            {
                Event selectedEvent = i_ListBoxEvents.SelectedItem as Event;
                LogicFacebookApp.DisplayPicture(i_PictureBoxEvent, selectedEvent.PictureNormalURL);
            }
        }
        internal void DisplayEventLocation(ListBox i_ListBoxEvents, TextBox i_TextBoxEventLocation)
        {
            if (i_ListBoxEvents.SelectedItems.Count == 1)
            {
                Album selectedAlbum = i_ListBoxEvents.SelectedItem as Album;
                LogicFacebookApp.DisplayLocation(i_TextBoxEventLocation, selectedAlbum.Location);
            }
        }
        internal void ExploreYourGroups(ListBox i_ListBoxGroups)
        {
            i_ListBoxGroups.Items.Clear();
            i_ListBoxGroups.DisplayMember = "Name";

            try
            {
                foreach (Group group in m_LoggedInUser.Groups)
                {
                    i_ListBoxGroups.Items.Add(group);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (i_ListBoxGroups.Items.Count == 0)
            {
                MessageBox.Show("No groups to retrieve :(");
            }
        }
        internal void DisplayGroupWallPosts(ListBox i_ListBoxGroups)
        {
            if (i_ListBoxGroups.SelectedItems.Count == 1)
            {
                Group selectedGroup = i_ListBoxGroups.SelectedItem as Group;
                LogicFacebookApp.DisplayWallPosts(i_ListBoxGroups, selectedGroup.WallPosts);
            }
        }
        internal void DisplayGroupMembers(ListBox i_ListBoxGroups)
        {
            Group selectedGroup = i_ListBoxGroups.SelectedItem as Group;

            try
            {
                foreach (User memberInGroup in selectedGroup.Members)
                {
                    i_ListBoxGroups.Items.Add(memberInGroup.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (i_ListBoxGroups.Items.Count == 0)
            {
                MessageBox.Show("No members groups to retrieve :(");
            }
        }
        internal void DisplayGroupPicture(ListBox i_ListBoxGroups, PictureBox i_PictureBoxGroup)
        {
            if (i_ListBoxGroups.SelectedItems.Count == 1)
            {
                Group selectedGroup = i_ListBoxGroups.SelectedItem as Group;
                LogicFacebookApp.DisplayPicture(i_PictureBoxGroup, selectedGroup.PictureNormalURL);
            }
        }
        internal void DisplayGroupDecription(ListBox i_ListBoxGroups, TextBox i_TextBoxGroupDescription)
        {
            if (i_ListBoxGroups.SelectedItems.Count == 1)
            {
                Group selectedGroup = i_ListBoxGroups.SelectedItem as Group;
                LogicFacebookApp.DisplayDescription(i_TextBoxGroupDescription, selectedGroup.Description);
            }
        }
        internal void ExploreLikedPages(ListBox i_ListBoxLikedPages)
        {
            i_ListBoxLikedPages.Items.Clear();
            i_ListBoxLikedPages.DisplayMember = "Name";

            if (m_LoggedInUser.LikedPages.Count == 0)
            {
                MessageBox.Show("No liked pages to retrieve :(");
            }

            try
            {
                foreach (Page page in m_LoggedInUser.LikedPages)
                {
                    i_ListBoxLikedPages.Items.Add(page);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        internal void DisplayPagePicture(ListBox i_ListBoxLikedPages, PictureBox i_PictureBoxChosenLikedPage)
        {
            if (i_ListBoxLikedPages.SelectedItems.Count == 1)
            {
                Page selectedLikedPage = i_ListBoxLikedPages.SelectedItem as Page;
                LogicFacebookApp.DisplayPicture(i_PictureBoxChosenLikedPage, selectedLikedPage.PictureNormalURL);
            }
        }
        internal void DisplayPageDescription(ListBox i_ListBoxLikedPages, TextBox i_TextBoxLikedPage)
        {
            if (i_ListBoxLikedPages.SelectedItems.Count == 1)
            {
                Page selectedLikedPage = i_ListBoxLikedPages.SelectedItem as Page;
                LogicFacebookApp.DisplayDescription(i_TextBoxLikedPage, selectedLikedPage.Description);
            }
        }
        internal void FillLocationsDict(Dictionary<string, int> i_LocationsDictionary)
        {
            foreach (Album album in m_LoggedInUser.Albums)
            {
                if (album.Location != null)
                {
                    if (!i_LocationsDictionary.ContainsKey(album.Location))
                    {
                        i_LocationsDictionary.Add(album.Location, 1);
                    }
                    else
                    {
                        i_LocationsDictionary[album.Location]++;
                    }
                }
            }

            foreach (Event fbevent in m_LoggedInUser.Events)
            {
                if (fbevent.Location != null)
                {
                    if (!i_LocationsDictionary.ContainsKey(fbevent.Location))
                    {
                        i_LocationsDictionary.Add(fbevent.Location, 1);
                    }
                    else
                    {
                        i_LocationsDictionary[fbevent.Location]++;
                    }
                }
            }

            foreach (Checkin checkin in m_LoggedInUser.Checkins)
            {
                if (checkin != null && checkin.Place != null && checkin.Place.Location != null &&
                    checkin.Place.Location.City != null)
                {
                    if (!i_LocationsDictionary.ContainsKey(checkin.Place.Location.City))
                    {
                        i_LocationsDictionary.Add(checkin.Place.Location.City, 1);
                    }
                    else
                    {
                        i_LocationsDictionary[checkin.Place.Location.City]++;
                    }
                }
            }
        }
        internal void ShowMostPopularLocationAndMostUnpopularLocation(Dictionary<string, int> i_LocationsDictionary, 
            TextBox i_TextBoxPopularLocation, TextBox i_TextBoxUnPopularLocation)
        {
            int max = 0;
            int min = int.MaxValue;
            string maxAppearancesLocation = "";
            string minAppearancesLocation = "";

            if (i_LocationsDictionary.Count == 0)
            {
                i_TextBoxPopularLocation.Text = "We didn't get any location ...";
                i_TextBoxUnPopularLocation.Text = "We didn't get any location ...";
            }
            else
            {
                foreach (KeyValuePair<string, int> entry in i_LocationsDictionary)
                {
                    if (i_LocationsDictionary[entry.Key] < min)
                    {
                        min = i_LocationsDictionary[entry.Key];
                        minAppearancesLocation = entry.Key;
                    }
                    if (i_LocationsDictionary[entry.Key] > max)
                    {
                        max = i_LocationsDictionary[entry.Key];
                        maxAppearancesLocation = entry.Key;
                    }
                }
                i_TextBoxPopularLocation.Text = maxAppearancesLocation;
                i_TextBoxUnPopularLocation.Text = minAppearancesLocation;
            }
        }
        internal void ExploreInGoogledMostUnpopularLocation(TextBox i_TextBoxUnPopularLocation, WebBrowser i_WebBrowser)
        {
            if (!i_TextBoxUnPopularLocation.Text.Equals("We didn't get any location ..."))
            {
                string searchingInGoogleStr = "https://www.google.com/search?q=";
                string chosenLocationInTable = i_TextBoxUnPopularLocation.Text;
                searchingInGoogleStr += chosenLocationInTable;
                i_WebBrowser.Navigate(searchingInGoogleStr);
            }
        }
        internal void ShowLocationInGoogle(DataGridView i_DataGridViewLocationsCounter, WebBrowser i_WebBrowser1)
        {
            if (i_DataGridViewLocationsCounter.SelectedRows.Count == 1)
            {
                try
                {
                    string searchingInGoogleStr = "www.google.com/search?q=";
                    string chosenLocationInTable = i_DataGridViewLocationsCounter.SelectedRows[0].Cells[0].Value.ToString();
                    searchingInGoogleStr += chosenLocationInTable;
                    i_WebBrowser1.Navigate(searchingInGoogleStr);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            } 
        }
        internal void ShowLocationDetailsInTable(Dictionary<string, int> i_LocationsDictionary,
            DataGridView i_DataGridViewLocationsCounter)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Location", typeof(string));
            dataTable.Columns.Add("NumOfAppearances", typeof(int));
            foreach (KeyValuePair<string, int> entry in i_LocationsDictionary)
            {
                dataTable.Rows.Add(entry.Key, entry.Value);
            }
            i_DataGridViewLocationsCounter.DataSource = dataTable;
        }
        internal void CalcDistance(TextBox i_TextBoxDistance, ListBox i_ListBoxFriends)
        {
            if (i_ListBoxFriends.SelectedItems.Count == 1)
            {
                User selectedFriend = i_ListBoxFriends.SelectedItem as User;
                double userLatitude = m_LoggedInUser.Hometown.Location.Latitude ?? 0;
                double userLongitude = m_LoggedInUser.Hometown.Location.Longitude ?? 0;
                double friendLatitude = selectedFriend.Hometown.Location.Latitude ?? 0;
                double friendLongitude = selectedFriend.Hometown.Location.Longitude ?? 0;
                i_TextBoxDistance.Text = calcDistanceMethodByKilometer(userLatitude, userLongitude, friendLatitude, friendLongitude).ToString();
            }
        }
        private static double calcDistanceMethodByKilometer(double i_FirstLatitude, double i_FirstLongitude, double i_SecondLatitude, double i_SecondLongitude)
        {
            double distance;
            if ((i_FirstLatitude == i_SecondLatitude) && (i_FirstLongitude == i_SecondLongitude))
            {

                distance = 0;
            }
            else
            {
                double theta = i_FirstLongitude - i_SecondLongitude;
                distance = Math.Sin(convertDegreesToRadians(i_FirstLatitude)) * Math.Sin(convertDegreesToRadians(i_SecondLatitude)) + Math.Cos(convertDegreesToRadians(i_FirstLatitude)) * Math.Cos(convertDegreesToRadians(i_SecondLatitude)) * Math.Cos(convertDegreesToRadians(theta));
                distance = Math.Acos(distance);
                distance = convertRadiansToDegrees(distance);
                distance = distance * 60 * 1.1515;
                distance = distance * 1.609344;
            }

            return distance;
        }
        private static double convertDegreesToRadians(double io_Degree)
        {
            return (io_Degree * Math.PI / 180.0);
        }
        private static double convertRadiansToDegrees(double io_Radiands)
        {
            return (io_Radiands / Math.PI * 180.0);
        }
        internal void ShowFriendsFilteredByBDMonth(BindingSource i_UserBindingSource, Dictionary<string,CheckBox> i_MonthCheckBoxes)
        {
            List<User> friendsList = new List<User>();
            String bdMonth = string.Empty;
            foreach (User friend in m_LoggedInUser.Friends)
            {
                if (!String.IsNullOrEmpty(friend.Birthday))
                {
                    bdMonth = friend.Birthday.Substring(0, 2);
                }
                else
                {
                    continue;
                }
                if (i_MonthCheckBoxes[bdMonth].Checked)
                {
                    friendsList.Add(friend);
                }
            }
            i_UserBindingSource.DataSource = friendsList;
        }
        internal void FillListBoxDummyFriends(ListBox i_ListBox)
        {
            i_ListBox.DisplayMember = "Name";
            for (int i = 0; i < 10; i++)
            {
                i_ListBox.Items.Add(m_DummyData.DummyFriendsList[i]);
            }
        }
        internal void DisplayInfoOnSelectedDummyFriend(ListBox i_ListBox, TextBox i_BirthdayTextBox,
            TextBox i_EmailTextBox, TextBox i_ReligionTextBox, TextBox i_CityTextBox, TextBox i_CountryTextBox,
            TextBox i_TextBoxDistance)
        {
            if (i_ListBox.SelectedItems.Count == 1)
            {
                DummyFriend selectedDummyFriend = i_ListBox.SelectedItem as DummyFriend;
                i_BirthdayTextBox.Text = selectedDummyFriend.BirthDay;
                i_EmailTextBox.Text = selectedDummyFriend.Email;
                i_ReligionTextBox.Text = selectedDummyFriend.Religion;
                i_CityTextBox.Text = selectedDummyFriend.City;
                i_CountryTextBox.Text = selectedDummyFriend.Country;
                i_TextBoxDistance.Text = dummyCalcDistance(selectedDummyFriend);
            }
        }
        //userLatitude and userLongitude get null, so we put dummy values instead.
        private string dummyCalcDistance(DummyFriend i_SelectedDummyFriend)
        {
            /*double userLatitude = m_LoggedInUser.Hometown.Location.Latitude ?? 0;
            double userLongitude = m_LoggedInUser.Hometown.Location.Longitude ?? 0;*/
            double friendLatitude = i_SelectedDummyFriend.LatitudeLocation;
            double friendLongitude = i_SelectedDummyFriend.LongtitudeLocation;
            return(calcDistanceMethodByKilometer(12.12, 24.24, friendLatitude, friendLongitude).ToString());
        }
        internal void ShowDummyFriendsFiltredByBirthDay(ListBox i_ListBox, Dictionary<string, CheckBox> i_MonthCheckBoxes)
        {
            List<DummyFriend> friendsList = new List<DummyFriend>();
            String bdMonth = string.Empty;
            i_ListBox.Items.Clear();
            foreach (DummyFriend friend in m_DummyData.DummyFriendsList)
            {
                if (!String.IsNullOrEmpty(friend.BirthDay))
                {
                    bdMonth = friend.BirthDay.Substring(0, 2);
                }
                else
                {
                    continue;
                }
                if (i_MonthCheckBoxes[bdMonth].Checked)
                {
                    i_ListBox.Items.Add(friend);
                }
            }
        }
        internal void ExplorePosts(ListBox i_listBoxPosts)
        {
            foreach (Post post in m_LoggedInUser.Posts)
            {
                if (post.Message != null)
                {
                    i_listBoxPosts.Invoke(new Action(() => i_listBoxPosts.Items.Add(post.Message)));
                }
                else if (post.Caption != null)
                {
                    i_listBoxPosts.Invoke(new Action(() => i_listBoxPosts.Items.Add(post.Caption)));
                }
            }
            
            i_listBoxPosts.Invoke(new Action(() =>
            {
                if (i_listBoxPosts.Items.Count == 0)
                {
                    MessageBox.Show("No Posts to retrieve :( ");
                }
            }));
        }
        internal void ExplorePostsTaggedIn(ListBox i_listBoxPosts)
        {
            try
            {
                foreach (Post post in m_LoggedInUser.PostsTaggedIn)
                {
                    if (!string.IsNullOrEmpty(post.Message))
                    {
                        i_listBoxPosts.Invoke(new Action(() => i_listBoxPosts.Items.Add(post.Message)));
                    }
                    else if (!string.IsNullOrEmpty(post.Caption))
                    {
                        i_listBoxPosts.Invoke(new Action(() => i_listBoxPosts.Items.Add(post.Caption)));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Didn't find any Posts you were tagged in:(");
            }
        }
        internal void PostStatus(TextBox i_TextBox)
        {
            try
            {
                m_LoggedInUser.PostStatus(i_TextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Posting status option isn't available now");
            }
        }
        internal void DisplayPhotoOfPost(ListBox i_ListBox, PictureBox i_PictureBox)
        {
            if (i_ListBox.SelectedItems.Count == 1)
            {
                Post selectedPost = i_ListBox.SelectedItem as Post;
                i_PictureBox.LoadAsync(selectedPost.PictureURL);
            }
        }
    }
}
