using System;
using System.Threading.Tasks;
using Plugin.Connectivity;

namespace GuestBooker.Services
{
    public class ConnectivityService
    {
        public static async Task<bool> IsConnected()
        {
            return await CrossConnectivity.Current.IsRemoteReachable(GlobalSettings.ServiceEndpoint, 80, 1000);
        }

        public static bool IsActiveInternetConnection()
        {
            return CrossConnectivity.Current.IsConnected;
        }
    }
}
