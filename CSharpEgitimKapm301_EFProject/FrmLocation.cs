using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKapm301_EFProject
{
    public partial class FrmLocation : Form
    {
        public FrmLocation()
        {
            InitializeComponent();
        }
        EgitimKamp301DbEFEntities db = new EgitimKamp301DbEFEntities();

        private void btnList_Click(object sender, EventArgs e)
        {
            var values=db.Location.ToList();
            dataGridView1.DataSource = values;
        }

        private void FrmLocation_Load(object sender, EventArgs e)
        {
            var values=db.Guide.Select(x=> new { fullName=x.GName+" "+x.GSurname,x.GuideId}).ToList();
            cmbGuide.DisplayMember= "fullName";
            cmbGuide.ValueMember = "GuideId";
            cmbGuide.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Location location = new Location();
            location.Capacity = byte.Parse(nudCapasity.Value.ToString());
            location.City=txtCity.Text;
            location.Country=txtCountry.Text;
            location.Price = decimal.Parse(txtPrice.Text);
            location.DayNight=txtDays.Text;
            location.GuideId = int.Parse(cmbGuide.SelectedValue.ToString());
            db.Location.Add(location);
            db.SaveChanges();
            MessageBox.Show("Ekleme İşlemi Başarılı");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id= int.Parse(txtID.Text);
            var deleteValue = db.Location.Find(id);
            db.Location.Remove(deleteValue);
            db.SaveChanges();
            MessageBox.Show("Silme İşlemi Başarılı");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id=int.Parse(txtID.Text);
            var updatedValue = db.Location.Find(id);
            updatedValue.DayNight = txtDays.Text;
            updatedValue.Price= decimal.Parse(txtPrice.Text);
            updatedValue.Capacity = byte.Parse(nudCapasity.Value.ToString());
            updatedValue.Country = txtCountry.Text;
            updatedValue.City = txtCity.Text;
            updatedValue.GuideId = int.Parse(cmbGuide.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Güncelleme İşlemi Başarılı");
        }
    }
}
