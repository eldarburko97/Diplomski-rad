using eDentalClinic.Model;
using eDentalClinic.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mobile.ViewModels
{
    public class ForumViewModel : BaseViewModel
    {
        private readonly APIService _topicService = new APIService("Topics");
        private readonly APIService _userService = new APIService("Users");
        private readonly APIService _commentService = new APIService("Comments");
        public CommentSearchRequest request = new CommentSearchRequest();
        public ForumViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        public ObservableCollection<Topic> TopicList { get; set; } = new ObservableCollection<Topic>();
        public ICommand InitCommand { get; set; }

        public async Task Init()
        {
            if(TopicList.Count > 0)
            {
                TopicList.Clear();
            }
            var list = await _topicService.GetAll<List<Topic>>(null);
          
            foreach (var topic in list)
            {
                var client = await _userService.GetById<User>(topic.UserID);
                topic.Client = client.FirstName + " " + client.LastName; //Client that posted topic
                request.TopicID = topic.TopicID;
                var _commentList = await _commentService.GetAll<List<Comment>>(request);
                topic.Comments = _commentList.Count; // Number of comments
                var _lastComment = _commentList[_commentList.Count - 1]; // Last comment of topic
                var client_lastComment = await _userService.GetById<User>(_lastComment.UserID);
                topic.LastComment = client_lastComment.FirstName + " " + client_lastComment.LastName;
                TopicList.Add(topic);
            }
        }
    }
}
