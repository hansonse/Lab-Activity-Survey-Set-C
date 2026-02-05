using System;
using System.Windows.Forms;

namespace Survey_Set_C
{
    public partial class Form3 : Form
    {
        private string gender, age, marital, income, employment, education;
        private string exerciseRate, usageRate, lastBuy, buyPurpose, buyPlace, designPreference, brandFactor;

        private string waterResistance = "Not rated";
        private string antiBacteria = "Not rated";
        private string softMaterial = "Not rated";
        private string endurance = "Not rated";
        private string cooling = "Not rated";
        private string antiOdour = "Not rated";
        private string elasticity = "Not rated";

        public Form3(
            string g, string a, string m, string inc, string emp, string edu,
            string exRate, string usRate, string last, string purpose, string place,
            string design, string brand)
        {
            InitializeComponent();

            gender = g;
            age = a;
            marital = m;
            income = inc;
            employment = emp;
            education = edu;

            exerciseRate = exRate;
            usageRate = usRate;
            lastBuy = last;
            buyPurpose = purpose;
            buyPlace = place;
            designPreference = design;
            brandFactor = brand;
        }

        

        private void btnBack3_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(gender, age, marital, income, employment, education);
            f2.Show();
            this.Close();
        }
        private void btnNext3_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4(
                gender, age, marital, income, employment, education,
                exerciseRate, usageRate, lastBuy, buyPurpose, buyPlace, designPreference, brandFactor,
                waterResistance, antiBacteria, softMaterial, endurance,
                cooling, antiOdour, elasticity
            );
            f4.Show();
            this.Hide();
        }

        private void Rating_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null || btn.Tag == null) return;

            int value = int.Parse(btn.Tag.ToString());

            // Traverse parents to find the GroupBox
            Control parent = btn.Parent;
            while (parent != null && !(parent is GroupBox))
                parent = parent.Parent;

            if (parent == null) return; // not inside a groupbox

            GroupBox grp = parent as GroupBox;

            // Assign value based on which groupbox it is
            if (grp == grpWaterResistance) waterResistance = value.ToString();
            else if (grp == grpAntiBacteria) antiBacteria = value.ToString();
            else if (grp == grpSoftMaterial) softMaterial = value.ToString();
            else if (grp == grpEndurance) endurance = value.ToString();
            else if (grp == grpCooling) cooling = value.ToString();
            else if (grp == grpAntiOdour) antiOdour = value.ToString();
            else if (grp == grpElasticity) elasticity = value.ToString();
        }

    }
}
