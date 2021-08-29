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
   public class NewTopicViewModel : BaseViewModel
    {
        private readonly APIService _service = new APIService("Topics");
        private readonly APIService _userService = new APIService("Users");
        private readonly APIService _commentService = new APIService("Comments");
        public TopicInsertRequest request = new TopicInsertRequest();
        public UserSearchRequest request2 = new UserSearchRequest();
        public CommentInsertRequest _commentRequest = new CommentInsertRequest();
        public NewTopicViewModel()
        {
            PostNewTopicCommand = new Command(async () =>
            {
                await Post();
            });
        }

        string _subject = string.Empty;
        public string Subject
        {
            get { return _subject; }
            set { SetProperty(ref _subject, value); }
        }

        string _description = string.Empty;
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        string _text = string.Empty;
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }

        DateTime _date = DateTime.Now;
        public DateTime Date
        {
            get { return _date; }
            set { SetProperty(ref _date, value); }
        }

        public ICommand PostNewTopicCommand { get; set; }

        async Task Post()
        {
            try
            {
                if(string.IsNullOrWhiteSpace(Subject) || string.IsNullOrWhiteSpace(Description) || string.IsNullOrWhiteSpace(Text))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "All fields are required!", "OK");
                    return;
                }
                request.Subject = Subject;
                request.Description = Description;
                request.Text = Text;
                request.Date = Date;

                request2.Username = APIService.Username;
                var list = await _userService.GetAll<List<eDentalClinic.Model.User>>(request2);
                var Client = list[0];
                request.UserID = Client.UserID;
                var topic = await _service.Insert<eDentalClinic.Model.Topic>(request);

                _commentRequest.TopicID = topic.TopicID;
                _commentRequest.UserID = Client.UserID;
                _commentRequest.Text = Text;
                await _commentService.Insert<eDentalClinic.Model.Comment>(_commentRequest);
                await Application.Current.MainPage.DisplayAlert("Success", "You have successfully posted new topic", "OK");
                Application.Current.MainPage = new MainPage();
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Something went wrong", "OK");
            }
        }
    }
}
