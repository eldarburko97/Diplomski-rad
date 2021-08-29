using eDentalClinic.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eDentalClinic.WinUI.Clients
{
    public partial class frmClientDetails : Form
    {
        private readonly APIService _userService = new APIService("Users");
        private int? _id = null;
        public frmClientDetails(int? id)
        {
            InitializeComponent();
            _id = id;
        }

        private async void FrmClientDetails_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                var client = await _userService.GetById<User>(_id);
                txtFirstName.Text = client.FirstName;
                txtLastName.Text = client.LastName;
                txtPhone.Text = client.Phone;
                txtEmail.Text = client.Email;
                txtAddress.Text = client.Address;
                txtBirthDate.Text = client.BirthDate.ToString("MM/dd/yyyy");
                txtCity.Text = client.City.Name;
                txtGender.Text = client.Gender.Type;
                txtUsername.Text = client.Username;
                if (client.Image.Count() != 0)
                {
                    using (MemoryStream stream = new MemoryStream(client.Image))
                    {
                        var image = new Bitmap(Image.FromStream(stream), clientImage.Width, clientImage.Height);
                        clientImage.Image = image;
                    }
                }
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
