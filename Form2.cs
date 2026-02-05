using System;
using System.Linq;
using System.Windows.Forms;

namespace Survey_Set_C
{
    public partial class Form2 : Form
    {
        private string gender, age, marital, income, employment, education;

        private string exerciseRate = "Not answered";
        private string usageRate = "Not answered";
        private string lastBuy = "Not answered";
        private string buyPurpose = "None selected";
        private string buyPlace = "None selected";
        private string designPreference = "None selected";
        private string brandFactor = "None selected";

        public Form2(string g, string a, string m, string inc, string emp, string edu)
        {
            InitializeComponent();

            gender = g;
            age = a;
            marital = m;
            income = inc;
            employment = emp;
            education = edu;
        }

        private string GetSelectedRadio(GroupBox grp)
        {
            foreach (RadioButton rb in grp.Controls.OfType<RadioButton>())
            {
                if (rb.Checked)
                    return rb.Text;
            }
            return "Not answered";
        }

        private string GetCheckedBoxes(GroupBox grp)
        {
            var selected = grp.Controls.OfType<CheckBox>()
                            .Where(cb => cb.Checked)
                            .Select(cb => cb.Text)
                            .ToList();

            return selected.Count > 0 ? string.Join(", ", selected) : "None selected";
        }

        private void ExerciseButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null) exerciseRate = btn.Text;
        }

        private void UsageButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null) usageRate = btn.Text;
        }

        private void btnBack2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Close();
        }

        private void btnNext2_Click(object sender, EventArgs e)
        {
            lastBuy = GetSelectedRadio(grpLastBuy);
            buyPurpose = GetCheckedBoxes(grpPurpose);
            buyPlace = GetCheckedBoxes(grpBuyPlace);
            designPreference = GetCheckedBoxes(grpDesign);
            brandFactor = GetCheckedBoxes(grpBrandFactor);

            Form3 f3 = new Form3(
                gender, age, marital, income, employment, education,
                exerciseRate, usageRate, lastBuy, buyPurpose, buyPlace, designPreference, brandFactor
            );
            f3.Show();
            this.Hide();
        }

        private void grpLastBuy_Enter(object sender, EventArgs e)
        {

        }
    }
}
