using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Plugin.Messaging;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Plugin.VersionTracking;
using Xamarin.Forms;
//using salesforce.Services;
//using salesforce.ViewModels.Main;
using GuestBooker.Helper;

namespace GuestBooker.Helper
{
    public static class Utils
    {
        public static bool ExistsNewVersion()
        {
            bool isNewVersion = false;
            return isNewVersion;
        }
    }
}
