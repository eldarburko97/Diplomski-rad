using eDentalClinic.Model;
using eDentalClinic.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.ViewModels
{
   public class CommentsViewModel : BaseViewModel
    {
        private readonly APIService _commentService = new APIService("Comments");
        private readonly APIService _userService = new APIService("Users");
        private readonly APIService _topicService = new APIService("Topics");
        public CommentSearchRequest request = new CommentSearchRequest();

        string topic = string.Empty;
        public string Topic
        {
            get { return topic; }
            set { SetProperty(ref topic, value); }
        }

        public ObservableCollection<Comment> CommentList { get; set; } = new ObservableCollection<Comment>();

       

        public async Task Init(int id)
        {
            var topic = await _topicService.GetById<eDentalClinic.Model.Topic>(id);
            Topic = topic.Subject;
            request.TopicID = id;
            var list = await _commentService.GetAll<List<Comment>>(request);
            CommentList.Clear();
            foreach (var comment in list)
            {
                var client = await _userService.GetById<User>(comment.UserID);
                comment.Client = client.FirstName + " " + client.LastName;
                comment.Image = client.Image;
                CommentList.Add(comment);
            }
        }
    }
}
