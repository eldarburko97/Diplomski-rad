using Mobile.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            //MenuPages.Add((int)MenuItemType.Browse, (NavigationPage)Detail);


            //Ovo je novo
           // MenuPages.Add((int)MenuItemType.Home, (NavigationPage)Detail);
            this.Detail = new NavigationPage( new HomePage());
           
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Home:
                        MenuPages.Add(id, new NavigationPage(new HomePage()));
                        break;
                  /*  case (int)MenuItemType.Browse:
                        MenuPages.Add(id, new NavigationPage(new ItemsPage()));
                        break;*/
                  /*  case (int)MenuItemType.About:
                        MenuPages.Add(id, new NavigationPage(new AboutPage()));
                        break;*/
                    case (int)MenuItemType.YourProfile:
                        MenuPages.Add(id, new NavigationPage(new YourProfilePage()));
                        break;
                    case (int)MenuItemType.Forum:
                        MenuPages.Add(id, new NavigationPage(new ForumPage()));
                        break;
                    case (int)MenuItemType.BookingAppointments:
                        MenuPages.Add(id, new NavigationPage(new DentistPage()));
                        break;
                    case (int)MenuItemType.MyAppointments:
                        MenuPages.Add(id, new NavigationPage(new MyAppointmentsPage()));
                        break;
                    case (int)MenuItemType.Rating:
                        MenuPages.Add(id, new NavigationPage(new DentistRating()));
                        break;
                    case (int)MenuItemType.LogOut:
                        MenuPages.Add(id, new NavigationPage(new LoginPage()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}