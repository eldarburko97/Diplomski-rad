using eDentalClinic.Model;
using eDentalClinic.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eDentalClinic.WinUI.Dentists
{
    public partial class frmAddDentist : Form
    {
        private int? _id = null;
        private readonly APIService _branchService = new APIService("Branches");
        private readonly APIService _dentistService = new APIService("Dentists");
        DentistInsertRequest request = new DentistInsertRequest();
        public frmAddDentist(int? id = null)
        {
            InitializeComponent();
            this.AutoValidate = AutoValidate.Disable;
            _id = id;
        }

        private async void FrmAddDentist_Load(object sender, EventArgs e)
        {
            await LoadBranches();
            if (_id.HasValue)
            {
                var dentist = await _dentistService.GetById<Dentist>(_id);

                txtFirstName.Text = dentist.FirstName;
                txtLastName.Text = dentist.LastName;
                txtPhone.Text = dentist.Phone;
                txtEmail.Text = dentist.Email;
                txtAddress.Text = dentist.Address;
                dtpBirthdate.Value = dentist.BirthDate.Date;
                // cmbBranch.SelectedItem = dentist.Branch;
                checkBoxActive.Checked = dentist.Active;
                txtDescription.Text = dentist.Description;
                if (dentist.Image.Count() != 0)
                {
                    using (MemoryStream stream = new MemoryStream(dentist.Image))
                    {
                        var image = new Bitmap(Image.FromStream(stream), userImage.Width, userImage.Height);
                        userImage.Image = image;
                    }
                }
                else
                {
                    //  userImage.Image = null;
                }
            }
            else
            {
                Assembly asm = Assembly.GetExecutingAssembly();
                Stream stm = asm.GetManifestResourceStream("eDentalClinic.WinUI.Images.userDefault.png");

                using (var memoryStream = new MemoryStream())
                {
                    stm.CopyTo(memoryStream);
                    var image = new Bitmap(Image.FromStream(memoryStream), userImage.Width, userImage.Height);
                    userImage.Image = image;
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            /*
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPG files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*.*)|*.*";
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string location = "";
                location = openFileDialog.FileName;
                userPicture.ImageLocation = location;
            }*/

            var result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                var fileName = openFileDialog.FileName;
                var file = File.ReadAllBytes(fileName);
                request.Image = file;
                // txtImage.Text = fileName;

                Image img = Image.FromFile(fileName);
                userImage.Image = img;
                userImage.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private async Task LoadBranches()
        {
            if (_id.HasValue)
            {
                var dentist = await _dentistService.GetById<Dentist>(_id);
                var branchId = dentist.BranchID;
                var list = await _branchService.GetAll<List<Branch>>(null);
                int index = 0;
                for (int i = 0; i < list.Count; i++)
                {
                    cmbBranch.Items.Add(list[i]);
                    if (list[i].BranchID == branchId)
                    {
                        index = i;
                    }
                }
                cmbBranch.DisplayMember = "Name";
                cmbBranch.SelectedIndex = index;
            }
            else
            {
                var branches = await _branchService.GetAll<List<Branch>>(null);
                branches.Insert(0, new Branch());

                cmbBranch.DisplayMember = "Name";
                cmbBranch.ValueMember = "BranchID";
                cmbBranch.DataSource = branches;
            }
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                request.FirstName = txtFirstName.Text;
                request.LastName = txtLastName.Text;
                request.Phone = txtPhone.Text;
                request.Email = txtEmail.Text;
                request.Address = txtAddress.Text;
                request.BirthDate = dtpBirthdate.Value.Date;
                request.Active = checkBoxActive.Checked;
                request.Description = txtDescription.Text;
                request.DentalClinicID = 1; 
                
                var branch = cmbBranch.SelectedItem as Branch;
                request.BranchID = branch.BranchID;
                
                using (MemoryStream stream = new MemoryStream())
                {
                    userImage.Image.Save(stream, ImageFormat.Png);
                    request.Image = stream.ToArray();
                }
                if (_id.HasValue)
                {
                    await _dentistService.Update<Model.Dentist>(_id, request);
                    MessageBox.Show("Dentist successfully updated", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var result = await _dentistService.Insert<Model.Dentist>(request);
                    MessageBox.Show("New dentist successfully added!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Close();
            }
        }

        private void TxtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtFirstName, Messages.Validation_Field_Required);
            }
            else
            {
                errorProvider.SetError(txtFirstName, null);
            }          
        }

        private void TxtLastName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtLastName, Messages.Validation_Field_Required);
            }
            else
            {
                errorProvider.SetError(txtLastName, null);
            }            
        }

        private void TxtPhone_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtPhone, Messages.Validation_Field_Required);
            }
            else
            {
                errorProvider.SetError(txtPhone, null);
            }
        }

        private void TxtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtEmail, Messages.Validation_Field_Required);
            }
            else if (!Regex.IsMatch(txtEmail.Text, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
            {
                e.Cancel = true;
                errorProvider.SetError(txtEmail, Messages.email_err);
            }
            else
            {
                errorProvider.SetError(txtEmail, null);
            }
        }

        private void TxtAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtAddress, Messages.Validation_Field_Required);
            }
            else
            {
                errorProvider.SetError(txtAddress, null);
            }
        }

        private void CmbBranch_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbBranch.Text))
            {
                errorProvider.SetError(cmbBranch, Messages.Validation_Field_Required);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cmbBranch, null);
            }
        }

        private void TxtDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                errorProvider.SetError(txtDescription, Messages.Validation_Field_Required);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtDescription, null);
            }
        }
    }
}
