using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Survey_Set_C
{
    public partial class Form4 : Form
    {
        private string gender, age, marital, income, employment, education;
        private string exerciseRate, usageRate, lastBuy, buyPurpose, buyPlace, designPreference, brandFactor;
        private string waterResistance, antiBacteria, softMaterial, endurance, cooling, antiOdour, elasticity;

        public Form4(
            string g, string a, string m, string inc, string emp, string edu,
            string exRate, string usRate, string last, string purpose, string place,
            string design, string brand,
            string water, string bacteria, string soft, string endu,
            string cool, string odour, string elastic)
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

            waterResistance = water;
            antiBacteria = bacteria;
            softMaterial = soft;
            endurance = endu;
            cooling = cool;
            antiOdour = odour;
            elasticity = elastic;
        }

        private string GetCheckedBoxes(GroupBox grp)
        {
            var selected = grp.Controls.OfType<CheckBox>()
                            .Where(cb => cb.Checked)
                            .Select(cb => cb.Text)
                            .ToList();

            return selected.Count > 0 ? string.Join(", ", selected) : "None selected";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3(
                gender, age, marital, income, employment, education,
                exerciseRate, usageRate, lastBuy, buyPurpose, buyPlace, designPreference, brandFactor
            );
            f3.Show();
            this.Close();
        }

        

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            string brandPersonality = GetCheckedBoxes(grpBrandPersonality);
            string otherInterests = GetCheckedBoxes(grpInterests);

            string summary =
                "PERSONAL INFO\n" +
                $"Gender: {gender}\nAge: {age}\nMarital: {marital}\nIncome: {income}\nEmployment: {employment}\nEducation: {education}\n\n" +

                "USAGE INFO\n" +
                $"Exercise Rate: {exerciseRate}\nUsage Rate: {usageRate}\nLast Buy: {lastBuy}\nPurpose: {buyPurpose}\nPlace: {buyPlace}\nDesign: {designPreference}\nBrand Factor: {brandFactor}\n\n" +

                "PRODUCT RATINGS\n" +
                $"Water Resistance: {waterResistance}\nAnti Bacteria: {antiBacteria}\nSoft Material: {softMaterial}\nEndurance: {endurance}\nCooling: {cooling}\nAnti Odour: {antiOdour}\nElasticity: {elasticity}\n\n" +

                "FINAL SECTION\n" +
                $"Brand Personality: {brandPersonality}\n" +
                $"Other Interests: {otherInterests}";

            MessageBox.Show(summary, "Survey Completed");
            Application.Exit();
        }
    }
}
