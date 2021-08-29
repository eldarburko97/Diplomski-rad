using eDentalClinic.Model;
using Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForumPage : ContentPage
    {
        private ForumViewModel model = null;
        public ForumPage()
        {
            InitializeComponent();
            BindingContext = model = new ForumViewModel();
            this.Title = "Forum";
            NavigationPage.SetHasNavigationBar(this, true);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                // await Navigation.PushModalAsync(new CommentsPage((e.SelectedItem as Topic).TopicID));
                await Navigation.PushAsync(new CommentsPage((e.SelectedItem as Topic).TopicID));
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            // await Navigation.PushModalAsync(new NewTopicPage());
            await Navigation.PushAsync(new NewTopicPage());
        }
    }
}