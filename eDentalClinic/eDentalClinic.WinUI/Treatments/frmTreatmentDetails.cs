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

namespace eDentalClinic.WinUI.Treatments
{
    public partial class frmTreatmentDetails : Form
    {
        private readonly APIService _treatmentService = new APIService("Treatments");
        private int? _id = null;
        public frmTreatmentDetails(int? id)
        {
            InitializeComponent();
            _id = id;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void FrmTreatmentDetails_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                var result = await _treatmentService.GetById<Model.Treatment>(_id);
                txtName.Text = result.Name;
                nudPrice.Value = result.Price;
                nudTimeRequired.Value = result.TimeRequired;
                if (result.Image.Count() != 0)
                {
                    using (MemoryStream stream = new MemoryStream(result.Image))
                    {
                        var image = new Bitmap(Image.FromStream(stream), treatmentImage.Width, treatmentImage.Height);
                        treatmentImage.Image = image;
                    }
                }
            }
        }
    }
}
