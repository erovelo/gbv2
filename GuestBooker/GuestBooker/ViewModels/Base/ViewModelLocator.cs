using System;
using GuestBooker.DataServices.Base;
using GuestBooker.Services;
using GuestBooker.Services.Interfaces;
using GuestBooker.ViewModels.Main;
using Unity;
using Unity.Lifetime;

namespace GuestBooker.ViewModels.Base
{
    public class ViewModelLocator
    {
        private readonly IUnityContainer _unityContainer;

        private static readonly ViewModelLocator _instance = new ViewModelLocator();

        public static ViewModelLocator Instance
        {
            get
            {
                return _instance;
            }
        }

        protected ViewModelLocator()
        {
            _unityContainer = new UnityContainer();

            // providers
            _unityContainer.RegisterType<IRequestProvider, RequestProvider>();
            //_unityContainer.RegisterType<ILocationProvider, LocationProvider>();

            // services
            _unityContainer.RegisterType<IDialogService, DialogService>();
            RegisterSingleton<INavigationService, NavigationService>();

            // data services
            //_unityContainer.RegisterType<IAuthenticationService, AuthenticationService>();
            //_unityContainer.RegisterType<IClientService, ClientService>();

            // view models
            _unityContainer.RegisterType<ViewModelLocator>();
            _unityContainer.RegisterType<SplashViewModel>();
            _unityContainer.RegisterType<HomeViewModel>();

            /*
            _unityContainer.RegisterType<LoginViewModel>();
            _unityContainer.RegisterType<CreateClientViewModel>();
            _unityContainer.RegisterType<ShowClientViewModel>();
            _unityContainer.RegisterType<UserInfoViewModel>();
            _unityContainer.RegisterType<ClientInfoViewModel>();
            _unityContainer.RegisterType<ChangeStatusViewModel>();
            _unityContainer.RegisterType<TabbedViewModel>();
            */
        }

        public T Resolve<T>()
        {
            return _unityContainer.Resolve<T>();
        }

        public object Resolve(Type type)
        {
            try
            {
                return _unityContainer.Resolve(type);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Register<T>(T instance)
        {
            _unityContainer.RegisterInstance<T>(instance);
        }

        public void Register<TInterface, T>() where T : TInterface
        {
            _unityContainer.RegisterType<TInterface, T>();
        }

        public void RegisterSingleton<TInterface, T>() where T : TInterface
        {
            _unityContainer.RegisterType<TInterface, T>(new ContainerControlledLifetimeManager());
        }
    }
}
