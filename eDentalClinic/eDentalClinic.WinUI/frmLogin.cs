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

namespace eDentalClinic.WinUI
{
    public partial class frmLogin : Form
    {
        private readonly APIService _apiService = new APIService("Users");
        public frmLogin()
        {
            InitializeComponent();
        }

        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                APIService.Username = txtUsername.Text;
                APIService.Password = txtPassword.Text;

                if(string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("All fields are required !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var user = await _apiService.GetAll<List<User>>(new UserSearchRequest { Username = txtUsername.Text });

                frmMain frm = new frmMain();
                frm.Show();
                this.Hide();
            }
            catch (Exception )
            {
               // MessageBox.Show(ex.Message, "Authentication", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
