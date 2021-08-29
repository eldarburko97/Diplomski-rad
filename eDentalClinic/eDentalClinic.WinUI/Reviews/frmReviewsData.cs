using eDentalClinic.Model;
using eDentalClinic.Model.Requests;
using eDentalClinic.Model.ViewModels;
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
    public partial class frmReviewsData : Form
    {
        private readonly APIService _ratingService = new APIService("Ratings");
        public frmReviewsData()
        {
            InitializeComponent();
        }

        private async void FrmReviewsData_Load(object sender, EventArgs e)
        {
            var list = await _ratingService.GetAll<List<Rating>>(null);
            List<frmReviewsDataVM> reviews = new List<frmReviewsDataVM>();
            foreach (var item in list)
            {
                frmReviewsDataVM review = new frmReviewsDataVM
                {
                    RatingID = item.RatingID,
                    ClientName = item.User.FirstName,
                    ClientSurname = item.User.LastName,
                    Dentist = item.Dentist.Branch.Title + " " + item.Dentist.FirstName + " " + item.Dentist.LastName,
                    RatingValue = item.DentistRating
                };
                reviews.Add(review);
            }
            dgvReviews.AutoGenerateColumns = false;
            dgvReviews.DataSource = reviews;
        }

        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            RatingSearchRequest request = new RatingSearchRequest
            {
                DentistName = txtDentistName.Text,
                DentistSurname = txtDentistSurname.Text
            };
            var list = await _ratingService.GetAll<List<Rating>>(request);
            List<frmReviewsDataVM> reviews = new List<frmReviewsDataVM>();
            foreach (var item in list)
            {
                frmReviewsDataVM review = new frmReviewsDataVM
                {
                    RatingID = item.RatingID,
                    ClientName = item.User.FirstName,
                    ClientSurname = item.User.LastName,
                    Dentist = item.Dentist.Branch.Title + " " + item.Dentist.FirstName + " " + item.Dentist.LastName,
                    RatingValue = item.DentistRating
                };
                reviews.Add(review);
            }
            dgvReviews.AutoGenerateColumns = false;
            dgvReviews.DataSource = reviews;

            if(reviews.Count == 0)
            {
                MessageBox.Show("There are no results for this search", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DgvReviews_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvReviews.SelectedRows[0].Cells[0].Value;
            frmReviewDetails frm = new frmReviewDetails(int.Parse(id.ToString()));
            frm.Show();
        }
    }
}
