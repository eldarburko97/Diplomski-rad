using eDentalClinic.Model.Requests;
using Mobile.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mobile.ViewModels
{
   public class NewCommentViewModel : BaseViewModel
    {
        private readonly APIService _commentService = new APIService("Comments");
        private readonly APIService _userService = new APIService("Users");
        public UserSearchRequest _searchRequest = new UserSearchRequest();
        public CommentInsertRequest _commentRequest = new CommentInsertRequest();
        private int _id;

        public NewCommentViewModel(int id)
        {
            _id = id;
            PostNewCommentCommand = new Command(async () =>
            {
                await Post(_id);
            });
        }

        string _text = string.Empty;
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }

        public ICommand PostNewCommentCommand { get; set; }

        async Task Post(int Id) //TopicId
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Text))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Text field is required!", "OK");
                    return;
                }
                _searchRequest.Username = APIService.Username;
                var list = await _userService.GetAll<List<eDentalClinic.Model.User>>(_searchRequest);
                var Client = list[0];
                _commentRequest.UserID = Client.UserID;
                _commentRequest.TopicID = Id;
                _commentRequest.Text = Text;
                _commentRequest.Date = DateTime.Now.Date;
                await _commentService.Insert<eDentalClinic.Model.Comment>(_commentRequest);
                await Application.Current.MainPage.DisplayAlert("Success", "You have successfully posted new comment", "OK");
                Application.Current.MainPage = new MainPage();
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Somethning went wrong", "OK");
            }
        }
    }
}
