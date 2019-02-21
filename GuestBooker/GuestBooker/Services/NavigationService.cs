using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GuestBooker.Pages.Main;
using GuestBooker.Pages.Navigation;
using GuestBooker.Services.Interfaces;
using GuestBooker.ViewModels.Base;
using GuestBooker.ViewModels.Main;
using Xamarin.Forms;

namespace GuestBooker.Services
{
    public class NavigationService : INavigationService
    {
        protected readonly Dictionary<Type, Type> _mappings;

        protected Application CurrentApplication
        {
            get
            {
                return Application.Current;
            }
        }

        public NavigationService()
        {
            _mappings = new Dictionary<Type, Type>();

            CreatePageViewModelMappings();
        }

        public Task InitializeAsync()
        {
            return NavigateToAsync<SplashViewModel>();
        }

        public Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase
        {
            return InternalNavigateToAsync(typeof(TViewModel), null);
        }

        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase
        {
            return InternalNavigateToAsync(typeof(TViewModel), parameter);
        }

        public Task NavigateToAsync(Type viewModelType)
        {
            return InternalNavigateToAsync(viewModelType, null);
        }

        public Task NavigateToAsync(Type viewModelType, object parameter)
        {
            return InternalNavigateToAsync(viewModelType, parameter);
        }

        public async Task NavigateBackAsync()
        {
            if (CurrentApplication.MainPage != null)
            {
                await CurrentApplication.MainPage.Navigation.PopAsync();
            }
        }

        protected virtual async Task InternalNavigateToAsync(Type viewModelType, object parameter)
        {
            Page page = CreateAndBindPage(viewModelType, parameter);
            CustomNavigationPage nav = new CustomNavigationPage(page)
            {
                BarTextColor = Color.White,
                BackgroundColor = Color.Black,
            };

            if (page is SplashPage)
            {
                CurrentApplication.MainPage = nav;
            }
            else if (page is LoginPage)
            {
                CurrentApplication.MainPage = nav;
            }
            else
            {
                var navigationPage = CurrentApplication.MainPage as CustomNavigationPage;

                if (navigationPage != null)
                {
                    await navigationPage.PushAsync(page, true);
                }
                else
                {
                    CurrentApplication.MainPage = nav;
                }
            }

            await (page.BindingContext as ViewModelBase).InitializeAsync(parameter);
        }

        public async Task NavigateBackToHomeAsync()
        {
            if (CurrentApplication.MainPage != null)
            {
                //while (!(CurrentApplication.MainPage.Navigation.NavigationStack[CurrentApplication.MainPage.Navigation.NavigationStack.Count - 1] is HomePage))
                //{
                //    await CurrentApplication.MainPage.Navigation.PopAsync(false);
                //}

                /*
                while (!(CurrentApplication.MainPage.Navigation.NavigationStack[CurrentApplication.MainPage.Navigation.NavigationStack.Count - 2] is HomePage))
                {
                    var page = CurrentApplication.MainPage.Navigation.NavigationStack[CurrentApplication.MainPage.Navigation.NavigationStack.Count - 2];
                    CurrentApplication.MainPage.Navigation.RemovePage(page);
                }
                */

                await CurrentApplication.MainPage.Navigation.PopAsync(true);
            }
        }

        protected Type GetPageTypeForViewModel(Type viewModelType)
        {
            if (!_mappings.ContainsKey(viewModelType))
            {
                throw new KeyNotFoundException($"No map for ${viewModelType} was found on navigation mappings");
            }

            return _mappings[viewModelType];
        }

        protected Page CreateAndBindPage(Type viewModelType, object parameter)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);

            if (pageType == null)
            {
                throw new Exception($"Mapping type for {viewModelType} is not a page");
            }

            Page page = Activator.CreateInstance(pageType) as Page;
            ViewModelBase viewModel = ViewModelLocator.Instance.Resolve(viewModelType) as ViewModelBase;
            page.BindingContext = viewModel;

            if (page is IPageWithParameters)
            {
                ((IPageWithParameters)page).InitializeWith(parameter);
            }

            return page;
        }

        private void CreatePageViewModelMappings()
        {
            _mappings.Add(typeof(SplashViewModel), typeof(SplashPage));
            _mappings.Add(typeof(LoginViewModel), typeof(LoginPage));
            _mappings.Add(typeof(HomeViewModel), typeof(HomePage));

            /*
            _mappings.Add(typeof(CreateClientViewModel), typeof(CreateClientPage));
            _mappings.Add(typeof(TermsAndConditionsViewModel), typeof(TermsAndConditionsPage));
            _mappings.Add(typeof(ShowClientViewModel), typeof(ShowClientPage));
            _mappings.Add(typeof(UserInfoViewModel), typeof(UserInfoPage));
            _mappings.Add(typeof(ClientInfoViewModel), typeof(ClientInfoPage));
            _mappings.Add(typeof(ChangeStatusViewModel), typeof(ChangeStatusPage));
            _mappings.Add(typeof(TabbedViewModel), typeof(TabbedMainPage));
            */
        }
    }
}
