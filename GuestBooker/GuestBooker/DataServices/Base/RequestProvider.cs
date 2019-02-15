using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ModernHttpClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using GuestBooker.Services.Interfaces;
using GuestBooker.ViewModels.Base;
using GuestBooker.Services.Exceptions;
using Plugin.Settings;
using GuestBooker.Helper;
using GuestBooker.Services;
using GuestBooker.ViewModels.Main;

namespace GuestBooker.DataServices.Base
{
    public class RequestProvider : IRequestProvider
    {
        readonly JsonSerializerSettings _serializerSettings;
        protected readonly IDialogService DialogService;

        public RequestProvider()
        {
            DialogService = ViewModelLocator.Instance.Resolve<IDialogService>();
            _serializerSettings = new JsonSerializerSettings
            {
                //ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                DateFormatHandling = DateFormatHandling.MicrosoftDateFormat,
                DateParseHandling = DateParseHandling.DateTime,
                NullValueHandling = NullValueHandling.Ignore
            };

            _serializerSettings.Converters.Add(new StringEnumConverter());
        }

        public async Task<TResult> GetAsync<TResult>(string uri)
        {
            HttpClient httpClient = CreateHttpClient();
            HttpResponseMessage response = await httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, new Uri(uri)));

            await HandleResponse(response);

            string serialized = await response.Content.ReadAsStringAsync();
            TResult result = await Task.Run(() => JsonConvert.DeserializeObject<TResult>(serialized, _serializerSettings));
            return result;

        }

        public Task<TResult> PostAsync<TResult>(string uri, TResult data)
        {
            return PostAsync<TResult, TResult>(uri, data);
        }

        public async Task<TResult> PostAsync<TRequest, TResult>(string uri, TRequest data)
        {
            await CheckConnection();

            string responseData = string.Empty;
            HttpClient httpClient = CreateHttpClient();

            //TODO: En android no funcionan las llmadas a servicios https
            //if (Device.RuntimePlatform == Device.Android)
            //{
            //    uri = uri.Replace("https", "http");
            //    uri = uri.Replace(":443", "");
            //}

            //Set username and password for service
            //var usrGuid = Settings.UserGuid != Guid.Empty ? Settings.UserGuid : new Guid("023C125B-7D09-41EC-9AB9-691253DF0204");
            //var valGuid = GetValGuid(usrGuid, DateTime.UtcNow);

            //var encoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(String.Format("{0}:{1}", usrGuid, valGuid)));
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", encoded);

            string serialized = string.Empty;
            try
            {
                //serialized = JsonConvert.SerializeObject(data, _serializerSettings);
                serialized = await Task.Run(() => JsonConvert.SerializeObject(data, _serializerSettings));
            }
            catch (Exception ex)
            { throw ex; }

            WebExceptionStatus exceptionStatus = WebExceptionStatus.Pending;
            do
            {
                try
                {
                    HttpResponseMessage response = await httpClient.PostAsync(uri, new StringContent(serialized, Encoding.UTF8, "application/json"));
                    await HandleResponse(response);
                    responseData = await response.Content.ReadAsStringAsync();
                    exceptionStatus = WebExceptionStatus.Success;
                }
                catch (WebException ex)
                {
                    exceptionStatus = ex.Status;
                    //await DialogService.ShowAlertAsync(AppResources.NoInternetConnection, AppResources.TitleWarning, AppResources.RetryButtonLabel);
                }
                catch (ServiceAuthenticationException ex)
                {
                    CrossSettings.Current.Clear();
                    //Settings.UserProfileSignUp = new UserProfileSignUp();
                    NavigationService ns = new NavigationService();
                    await ns.NavigateToAsync<LoginViewModel>();
                    break;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            while (exceptionStatus != WebExceptionStatus.Success);

            //return JsonConvert.DeserializeObject<TResult>(responseData, _serializerSettings);
            return await Task.Run(() => JsonConvert.DeserializeObject<TResult>(responseData, _serializerSettings));
        }

        public Task<TResult> PutAsync<TResult>(string uri, TResult data)
        {
            return PutAsync<TResult, TResult>(uri, data);
        }

        public async Task<TResult> PutAsync<TRequest, TResult>(string uri, TRequest data)
        {
            HttpClient httpClient = CreateHttpClient();
            string serialized = await Task.Run(() => JsonConvert.SerializeObject(data, _serializerSettings));
            HttpResponseMessage response = await httpClient.PutAsync(uri, new StringContent(serialized, Encoding.UTF8, "application/json"));

            await HandleResponse(response);

            string responseData = await response.Content.ReadAsStringAsync();

            return await Task.Run(() => JsonConvert.DeserializeObject<TResult>(responseData, _serializerSettings));
        }

        static HttpClient Client = new HttpClient(new NativeMessageHandler());

        HttpClient CreateHttpClient()
        {
            var httpClient = Client;
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return httpClient;
        }

        async Task HandleResponse(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.Forbidden || response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new ServiceAuthenticationException(content);
                }

                throw new HttpRequestException(content);
            }
        }

        public async Task CheckConnection()
        {
            while (!ConnectivityService.IsActiveInternetConnection())
            {
                for (int i = 0; i < 3; i++)
                {
                    if (ConnectivityService.IsActiveInternetConnection())
                        return;
                    await Task.Delay(100);
                }

                //await DialogService.ShowAlertAsync(AppResources.NoInternetConnection, AppResources.TitleWarning, AppResources.RetryButtonLabel);
                await Task.Delay(100);
            }

            //while (!await ConnectivityService.IsConnected())
            //{
            //    for (int i = 0; i < 3; i++)
            //    {
            //        if (await ConnectivityService.IsConnected())
            //            return;
            //        await Task.Delay(100);
            //    }
            //    await DialogService.ShowAlertAsync(AppResources.NoServiceAvailable, AppResources.TitleWarning, AppResources.RetryButtonLabel);
            //    await Task.Delay(100);
            //}

            return;
        }

        private Guid GetValGuid(Guid usrGuid, DateTime dt)
        {
            var dateFactor = dt.Year * (dt.Month + dt.DayOfYear + dt.Hour) * (dt.Minute + 1);
            var arrGuid = usrGuid.ToByteArray();

            byte[] bytes = new byte[16];
            for (var i = 0; i < bytes.Length; i++)
            {
                bytes[i] = (byte)(arrGuid[i] ^ dateFactor - (i * dt.Minute));
            }

            return new Guid(bytes);
        }
    }
}
