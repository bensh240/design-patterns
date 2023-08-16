using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;
using static BasicFacebookFeatures.EnumsForms;
using System.Speech.Recognition;
using System.Runtime.Remoting.Messaging;

namespace BasicFacebookFeatures
{
    public partial class FormMain : Form
    {
        private LoginResult m_LoginResult;
        private User m_LoggedInUser;
        private readonly List<Control> r_MainMenuListControls;
        public event Action<Font> m_ReportFontChanged;
        public event Action<Color> m_ReportBackColorChanged;
       
        public FormMain()
        {
            InitializeComponent();
            FacebookWrapper.FacebookService.s_CollectionLimit = 100;
            r_MainMenuListControls = new List<Control>(9) { buttonAlbums, buttonPosts, buttonEvents, buttonLikedPages, buttonGroups,
            buttonFriends, buttonNewFeature, panelFonts, panelColors};
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("design.patterns20cc"); /// the current password for Desig Patter

            m_LoginResult = FacebookService.Login(
                    /// (This is Desig Patter's App ID. replace it with your own)
                    "724564805258180", 
                    /// requested permissions:
					"email",
                    "public_profile",
                    "user_age_range",
                    "user_birthday",
                    "user_events",
                    "user_friends",
                    "user_gender",
                    "user_hometown",
                    "user_likes",
                    "user_link",
                    "user_location",
                    "user_photos",
                    "user_posts",
                    "user_videos"
                    );

            buttonLogin.Text = $"Logged in as {m_LoginResult.LoggedInUser.Name}";
            
            if (!string.IsNullOrEmpty(m_LoginResult.AccessToken))
            {
                m_LoggedInUser = m_LoginResult.LoggedInUser;
            }
            else
            {
                MessageBox.Show(m_LoginResult.ErrorMessage, "Login Failed");
            }

            formStatusChange(this.Controls);
            panelAboutUser.Visible = true;
            textBoxOptionMenu.Visible = true;
            loadingDataOnLogginUser();
        }
        private void formStatusChange(Control.ControlCollection i_controls)
        {
            foreach (Control ctrl in r_MainMenuListControls)
            {
                ctrl.Visible = !ctrl.Visible;
            }
        }
        private void loadingDataOnLogginUser()
        {
            textBoxFirstName.Text = m_LoggedInUser.FirstName;
            textBoxLastName.Text = m_LoggedInUser.LastName;
            textBoxBirthday.Text = m_LoggedInUser.Birthday;
            textBoxEmail.Text = m_LoggedInUser.Email;
            textBoxGender.Text = m_LoggedInUser.Gender.ToString();
            textBoxLocation.Text = m_LoggedInUser.Location.Name;
            pictureBoxProfilePicture.LoadAsync(m_LoggedInUser.PictureNormalURL);
        }
        private void buttonLogout_Click(object sender, EventArgs e)
        {
			FacebookService.LogoutWithUI();
			buttonLogin.Text = "Login";
            formStatusChange(this.Controls);
            panelAboutUser.Visible = false;
            textBoxOptionMenu.Visible = false;
        }
        private void buttonAlbums_Click(object sender, EventArgs e)
        {
            FormAlbums formAlbum = StaticFormFactory.CreateFormOrGetIfExists(eFormType.FormAlbum, m_LoginResult, this) as FormAlbums;
            formAlbum.ShowDialog();
        }
        private void buttonPosts_Click(object sender, EventArgs e)
        {
            FormPosts formPosts = StaticFormFactory.CreateFormOrGetIfExists(eFormType.FormPosts, m_LoginResult, this) as FormPosts;
            formPosts.ShowDialog();
        }
        private void buttonEvents_Click(object sender, EventArgs e)
        {
            FormEvents formEvents = StaticFormFactory.CreateFormOrGetIfExists(eFormType.FormEvents, m_LoginResult, this) as FormEvents;
            formEvents.ShowDialog();
        }
        private void buttonGroups_Click(object sender, EventArgs e)
        {
            FormGroups formGroups = StaticFormFactory.CreateFormOrGetIfExists(eFormType.FormGroups, m_LoginResult, this) as FormGroups;
            formGroups.ShowDialog();
        }
        private void buttonLikedPages_Click(object sender, EventArgs e)
        {
            FormLikedPages formLikedPages = StaticFormFactory.CreateFormOrGetIfExists(eFormType.FormLikedPages, m_LoginResult, this) as FormLikedPages;
            formLikedPages.ShowDialog();
        }
        private void buttonFriends_Click(object sender, EventArgs e)
        {
            FormFriends formfriends = StaticFormFactory.CreateFormOrGetIfExists(eFormType.FormFriends, m_LoginResult, this) as FormFriends;
            formfriends.ShowDialog();
        }
        private void buttonNewFeature_Click(object sender, EventArgs e)
        {
            FormNewFeature formNewFeature = StaticFormFactory.CreateFormOrGetIfExists(eFormType.FormNewFeature, m_LoginResult, this) as FormNewFeature;
            formNewFeature.ShowDialog();
        }

        private void radioButtonFont1_CheckedChanged(object sender, EventArgs e)
        {
           if (m_ReportFontChanged != null)
           {
                m_ReportFontChanged.Invoke(new Font("Comic Sans MS", 8F));
           }
        }
        private void radioButtonFont2_CheckedChanged(object sender, EventArgs e)
        {
            if(m_ReportFontChanged != null)
            {
                m_ReportFontChanged.Invoke(new Font("Papyrus", 8F));
            }
        }

        private void radioButtonFont3_CheckedChanged(object sender, EventArgs e)
        {
            if (m_ReportFontChanged != null)
            {
                m_ReportFontChanged.Invoke(new Font("Century Gothic", 8F));
            }
        }

        private void radioButtonColor1_CheckedChanged(object sender, EventArgs e)
        {
            if(m_ReportBackColorChanged != null)
            {
                m_ReportBackColorChanged.Invoke(Color.Red);
            }
        }

        private void radioButtonColor2_CheckedChanged(object sender, EventArgs e)
        {
            if(m_ReportBackColorChanged != null)
            {
                m_ReportBackColorChanged.Invoke(Color.Green);
            }
        }

        private void radioButtonColor3_CheckedChanged(object sender, EventArgs e)
        {
            if(m_ReportBackColorChanged != null)
            {
                m_ReportBackColorChanged.Invoke(SystemColors.GradientActiveCaption);
            }
        }
        public Color CheckCurrentBackGroundColor()
        {
            Color colorToReturn = SystemColors.GradientActiveCaption;
            foreach(Control control in panelColors.Controls)
            {
                if(control is RadioButton && (control as RadioButton).Checked)
                {
                    if (control.Text == "Red") 
                    {
                        colorToReturn = Color.Red;
                        break;
                    }
                    if (control.Text == "Green")
                    {
                        colorToReturn = Color.Green;
                        break;
                    }
                }
            }
            return colorToReturn;
        }
        public Font CheckCurrentFont()
        {
            Font fontToReturn = new Font("Century Gothic", 8F);
            foreach (Control control in panelFonts.Controls)
            {
                if (control is RadioButton && (control as RadioButton).Checked)
                {
                    if (control.Text == "Comic Sans MS")
                    {
                        fontToReturn = new Font("Comic Sans MS", 8F);
                        break;
                    }
                    if (control.Text == "Papyrus")
                    {
                        fontToReturn = new Font("Papyrus", 8F);
                        break;
                    }
                }
            }
            return fontToReturn;
        }
    }
}
