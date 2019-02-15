using System;
using System.Collections.Generic;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
//using salesforce.Models.DTO;
//using salesforce.Models.Main;

namespace GuestBooker.Helper
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string UserGuidKey = "user_guid_key";
        private static readonly Guid UserGuidDefault = Guid.Empty;

        private const string UserGuidKeyTmp = "user_guid_key_tmp";
        private static readonly Guid UserGuidTmpDefault = Guid.Empty;

        private const string IsVersionSavedKey = "IsVersionSaved_key";
        private static readonly bool IsVersionSavedDefault = false;

        private const string EmailKey = "email_key";
        private static readonly string EmailDefault = string.Empty;

        private const string EmailNvKey = "emailNv_key";
        private static readonly string EmailNvDefault = string.Empty;

        private const string AccessTokenKey = "access_token_key";
        private static readonly string AccessTokenDefault = string.Empty;

        #endregion

        public static Guid UserGuid
        {
            get
            {
                return AppSettings.GetValueOrDefault(UserGuidKey, UserGuidDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(UserGuidKey, value);
            }
        }

        public static Guid UserGuidTmp
        {
            get
            {
                return AppSettings.GetValueOrDefault(UserGuidKeyTmp, UserGuidTmpDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(UserGuidKeyTmp, value);
            }
        }

        public static bool IsVersionSaved
        {
            get
            {
                return AppSettings.GetValueOrDefault(IsVersionSavedKey, IsVersionSavedDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(IsVersionSavedKey, value);
            }
        }

        public static string Email
        {
            get
            {
                return AppSettings.GetValueOrDefault(EmailKey, EmailDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(EmailKey, value);
            }
        }

        public static string EmailNv
        {
            get
            {
                return AppSettings.GetValueOrDefault(EmailNvKey, EmailNvDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(EmailNvKey, value);
            }
        }

        public static string AccessToken
        {
            get
            {
                return AppSettings.GetValueOrDefault(AccessTokenKey, AccessTokenDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(AccessTokenKey, value);
            }
        }

        public static int carrouselRunning
        {
            get; set;
        }



        //public static UserInfo UserInfo{get;set;}

        public static bool eMailValidated { get; internal set; }
        public static bool IsActive { get; set; }
        //public static UserProfileSignUp UserProfileSignUp { get; set; }

        public static double Latitude { get; set; }
        public static double Longitude { get; set; }

        public static DateTime ConfigParametersConsulted { get; set; }
    }
}