using System;
namespace GuestBooker
{
    public static class GlobalSettings
    {
        #region service
        //Prod
        public const string ServiceEndpoint = "http://salesservicesdev.azurewebsites.net/";

        //Dev
        //public const string ServiceEndpoint = "http://saleservicesdev.cloudapp.net/";
        #endregion

        //Prod mobile app                               
        public static string ApplicationURL = @"https://salesforce.azurewebsites.net";

        public static float DefaultLatitude = 47.673988f;
        public static float DefaultLongitude = -122.121513f;

        public const string AnimateLogoUrl = "/animateLogo.html";

        public const string twilioParameter = "twilioCellphoneNumber";
        public const string versionParameter = "droidVersion";
        public const string versionParameterIos = "iosVersion";
        public const string urlAppleStoreParameter = "urlAppleStore";
        public const string urlPlayStoreParameter = "urlPlayStore";
        public const string forceUpdateParameter = "forceUpdate";
        public const string facebookGraphUrlParameter = "facebookGraphUrl";
        public const int UserPictureSize = 250;

        public const string urlParameter = "urlApp";
        public const string urlHelpParameter = "urlAppHelp";
        public const string urlTermsAndConditions = "urlTermsAndConditions";
    }
}
