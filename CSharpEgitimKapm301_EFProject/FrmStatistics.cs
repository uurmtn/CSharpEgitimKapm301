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
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        EgitimKamp301DbEFEntities db = new EgitimKamp301DbEFEntities();

        private void FrmStatistics_Load(object sender, EventArgs e)
        {

            lblLocationCount.Text = db.Location.Count().ToString();
            lblSumCapacity.Text = db.Location.Sum(x => x.Capacity).ToString();
            lblGuideCount.Text = db.Guide.Count().ToString();
            lblAvgCapacity.Text = db.Location.Average(x => x.Capacity).Value.ToString("0.0");
            lblAvgLocationPrice.Text = db.Location.Average(x => x.Price).Value.ToString("0.00") + " ₺";

            int lastCountryId = db.Location.Max(x => x.LocationId);
            lblLastCountry.Text = db.Location.Where(x => x.LocationId == lastCountryId).Select(y => y.Country).FirstOrDefault();

            lblKapLocCapacity.Text = db.Location.Where(x => x.City == "Kapadokya").Select(y => y.Capacity).FirstOrDefault().ToString();
            lblTrAvgCapacity.Text = db.Location.Where(x => x.Country == "Türkiye").Average(y => y.Capacity).Value.ToString("0.0");

            var romeGuideId = db.Location.Where(x => x.City == "Roma").Select(y => y.GuideId).FirstOrDefault();
            lblRomeGuide.Text = db.Guide.Where(x => x.GuideId == romeGuideId).Select(y => y.GName + " " + y.GSurname).FirstOrDefault().ToString();

            var maxCapacity = db.Location.Max(x => x.Capacity);
            lblMaxCapacityLocation.Text = db.Location.Where(x => x.Capacity == maxCapacity).Select(y => y.City).FirstOrDefault().ToString();

            var expensiveLocation = db.Location.Max(x => x.Price);
            lblExpensiveLocation.Text = db.Location.Where(x => x.Price == expensiveLocation).Select(y => y.City).FirstOrDefault().ToString();

            var guideIdByNameUgur = db.Guide.Where(x => x.GName == "Uğur" && x.GSurname == "Mardin").Select(y => y.GuideId).FirstOrDefault();
            lblUgurLocCount.Text = db.Location.Where(x => x.GuideId == guideIdByNameUgur).Count().ToString();
        }


    }
}
