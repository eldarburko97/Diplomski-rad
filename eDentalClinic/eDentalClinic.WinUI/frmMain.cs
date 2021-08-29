using eDentalClinic.WinUI.Appointments;
using eDentalClinic.WinUI.Branches;
using eDentalClinic.WinUI.Clients;
using eDentalClinic.WinUI.Dentists;
using eDentalClinic.WinUI.Notifications;
using eDentalClinic.WinUI.Payments;
using eDentalClinic.WinUI.Reports;
using eDentalClinic.WinUI.Reviews;
using eDentalClinic.WinUI.Treatments;
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
    public partial class frmMain : Form
    {
        private int childFormNumber = 0;

        public frmMain()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        /*
        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }*/

        /*
    private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
    {
        statusStrip.Visible = statusBarToolStripMenuItem.Checked;
    }*/

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }


        private void AddDentistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddDentist frm = new frmAddDentist();
            frm.Show();
        }

        private void DeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDentistsData frm = new frmDentistsData();
            frm.Show();
        }

        private void AddBranchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddBranch frm = new frmAddBranch();
            frm.Show();
        }

        private void BranchDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBranchesData frm = new frmBranchesData();
            frm.Show();
        }

        private void AddTreatmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddTreatment frm = new frmAddTreatment();
            frm.Show();
        }

        private void TreatmentDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTreatmentsData frm = new frmTreatmentsData();
            frm.Show();
        }

        private void AppointmentsDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAppointmentsData frm = new frmAppointmentsData();
            frm.Show();
        }

        private void ReviewsDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReviewsData frm = new frmReviewsData();
            frm.Show();
        }



        private void ClientsDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClientsData frm = new frmClientsData();
            frm.Show();
        }

        private void PaymentsDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPaymentsData frm = new frmPaymentsData();
            frm.Show();
        }

        private void AddPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddPayment frm = new frmAddPayment();
            frm.Show();
        }

        private void NewReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBestSellingTreatment frm = new frmBestSellingTreatment();
            frm.Show();
        }

        private void NewReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmBusinessReportDentists frm = new frmBusinessReportDentists();
            frm.Show();
        }

        private void AddNotificationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNotification frm = new frmAddNotification();
            frm.Show();
        }

        private void NotificationsDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNotificationsData frm = new frmNotificationsData();
            frm.Show();
        }
    }
}
