using eDentalClinic.Model;
using eDentalClinic.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eDentalClinic.WinUI.Treatments
{  
    public partial class frmAddTreatment : Form
    {
        private int? _id = null;
        private readonly APIService _treatmentService = new APIService("Treatments");
        TreatmentInsertRequest request = new TreatmentInsertRequest();
        public frmAddTreatment(int? id = null)
        {
            InitializeComponent();
            this.AutoValidate = AutoValidate.Disable;
            _id = id;
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                request.Name = txtName.Text;
                request.Price = nudPrice.Value;
                request.TimeRequired = (int)nudRequiredTime.Value;
                using (MemoryStream stream = new MemoryStream())
                {
                    treatmentImage.Image.Save(stream, ImageFormat.Png);
                    request.Image = stream.ToArray();
                }
                if (_id.HasValue)
                {
                    await _treatmentService.Update<Treatment>(_id, request);
                    MessageBox.Show("Treatment successfully updated !", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    await _treatmentService.Insert<Model.Treatment>(request);
                    MessageBox.Show("New treatment successfully added!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }               
                this.Close();
            }
        }

        private void TxtName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtName, Messages.Validation_Field_Required);
            }
            else
            {
                errorProvider.SetError(txtName, null);
            }
        }

        private void BtnAddImage_Click(object sender, EventArgs e)
        {
            var result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                var fileName = openFileDialog.FileName;
                var file = File.ReadAllBytes(fileName);
                request.Image = file;
                // txtImage.Text = fileName;

                Image img = Image.FromFile(fileName);
                treatmentImage.Image = img;
                treatmentImage.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private async void FrmAddTreatment_Load(object sender, EventArgs e)
        {
                        
            if (_id.HasValue)
            {
                var treatment = await _treatmentService.GetById<Treatment>(_id);
                txtName.Text = treatment.Name;
                nudPrice.Value = treatment.Price;
                nudRequiredTime.Value = treatment.TimeRequired;
                treatmentImage.Image = System.Drawing.Image.FromStream(new MemoryStream(treatment.Image));
            }
            else
            {
                Assembly asm = Assembly.GetExecutingAssembly();
                Stream stm = asm.GetManifestResourceStream("eDentalClinic.WinUI.Images.treatment.jpg");

                using (var memoryStream = new MemoryStream())
                {
                    stm.CopyTo(memoryStream);
                    var image = new Bitmap(Image.FromStream(memoryStream), treatmentImage.Width, treatmentImage.Height);
                    treatmentImage.Image = image;
                }
            }
        }

        private void NudPrice_Validating(object sender, CancelEventArgs e)
        {
            if(nudPrice.Value <= 0)
            {
                e.Cancel = true;
                errorProvider.SetError(nudPrice, Messages.Validation_Field_Required);
            }
            else
            {
                errorProvider.SetError(nudPrice, null);
            }
        }

        private void NudRequiredTime_Validating(object sender, CancelEventArgs e)
        {
            if (nudRequiredTime.Value <= 0)
            {
                e.Cancel = true;
                errorProvider.SetError(nudRequiredTime, Messages.Validation_Field_Required);
            }
            else if ((int)nudRequiredTime.Value == 0)
            {
                e.Cancel = true;
                errorProvider.SetError(nudRequiredTime, Messages.Validation_Field_Required);
            }
            else
            {
                errorProvider.SetError(nudRequiredTime, null);
            }

        }

       
    }
}
