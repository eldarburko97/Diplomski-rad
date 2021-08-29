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
    public partial class frmNotificationsData : Form
    {
        private readonly APIService _notificationService = new APIService("Notifications");
        public frmNotificationsData()
        {
            InitializeComponent();
        }

        private async void FrmNotificationsData_Load(object sender, EventArgs e)
        {
            var result = await _notificationService.GetAll<List<Notification>>(null);
            dgvNotifications.AutoGenerateColumns = false;
            dgvNotifications.DataSource = result;
        }

        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            NotificationSearchRequest request = new NotificationSearchRequest
            {
                StartDate = dtpStartDate.Value.Date,
                EndDate = dtpEndDate.Value.Date
            };

            if (request.EndDate.Value.Date < request.StartDate.Value.Date)
            {
                MessageBox.Show("End date field must be greater than field Start date");
                return;
            }

            var result = await _notificationService.GetAll<List<Notification>>(request);
            dgvNotifications.AutoGenerateColumns = false;
            dgvNotifications.DataSource = result;
            if (result.Count == 0)
            {
                MessageBox.Show("There are not results for this search", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DgvNotifications_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvNotifications.SelectedRows[0].Cells[0].Value;
            frmNotificationDetails frm = new frmNotificationDetails(int.Parse(id.ToString()));
            frm.Show();
        }
    }
}
