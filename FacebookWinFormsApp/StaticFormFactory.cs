using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;
using System.Windows.Forms;
using FacebookWrapper;
using static BasicFacebookFeatures.EnumsForms;

namespace BasicFacebookFeatures
{
    public static class StaticFormFactory
    {
        internal static Form CreateFormOrGetIfExists(eFormType i_FromType, LoginResult i_LoginResult, FormMain i_FormMain)
        {
            switch (i_FromType)
            {
                case eFormType.FormAlbum:
                    return FormAlbums.GetOrCreateFormAlbums(i_LoginResult, i_FormMain);
                case eFormType.FormEvents:
                    return FormEvents.GetOrCreateFormEvents(i_LoginResult, i_FormMain);
                case eFormType.FormFriends:
                    return FormFriends.GetOrCreateFormFriends(i_LoginResult, i_FormMain);
                case eFormType.FormGroups:
                    return FormGroups.GetOrCreateFormGroups(i_LoginResult, i_FormMain);
                case eFormType.FormLikedPages:
                    return FormLikedPages.GetOrCreateFormLikedPages(i_LoginResult, i_FormMain);
                case eFormType.FormNewFeature:
                    return FormNewFeature.GetOrCreateFormNewFeature(i_LoginResult, i_FormMain);
                case eFormType.FormPosts:
                    return FormPosts.GetOrCreateFormPosts(i_LoginResult, i_FormMain);
            }
            return null;
        }
    }
}
