using eDentalClinic.Model;
using eDentalClinic.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eDentalClinic.WinUI.Notifications
{
    public partial class frmAddNotification : Form
    {
        private readonly APIService _userService = new APIService("Users");
        private readonly APIService _notificationService = new APIService("Notifications");
        public frmAddNotification()
        {
            InitializeComponent();
            this.AutoValidate = AutoValidate.Disable;
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                var users = await _userService.GetAll<List<User>>(new UserSearchRequest { Username = APIService.Username });
                var user = users[0];
                NotificationInsertRequest request = new NotificationInsertRequest
                {
                    Title = txtTitle.Text,
                    Text = txtText.Text,
                    NotificationDate = DateTime.Now,
                    UserID = user.UserID
                };
                await _notificationService.Insert<Notification>(request);
                MessageBox.Show("New notification successfully added!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void TxtTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtTitle, Messages.Validation_Field_Required);
            }
            else
            {
                errorProvider.SetError(txtTitle, null);
            }
        }

        private void TxtText_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtText.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtText, Messages.Validation_Field_Required);
            }
            else
            {
                errorProvider.SetError(txtText, null);
            }
        }
    }
}
