using eDentalClinic.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eDentalClinic.WinUI.Reviews
{
    public partial class frmReviewDetails : Form
    {
        private readonly APIService _ratingService = new APIService("Ratings");
        private int? _id = null;
        public frmReviewDetails(int? id)
        {
            _id = id;
            InitializeComponent();
        }

        private async void FrmReviewDetails_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                var review = await _ratingService.GetById<Rating>(_id);
                txtClientName.Text = review.User.FirstName;
                txtClientSurname.Text = review.User.LastName;
                txtDentist.Text = review.Dentist.Branch.Title + " " + review.Dentist.FirstName + " " + review.Dentist.LastName;
                txtRating.Text = review.DentistRating.ToString();
                txtComment.Text = review.Comment;
                txtRatingDate.Text = review.RatingDate.ToString("MM/dd/yyyy");
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
