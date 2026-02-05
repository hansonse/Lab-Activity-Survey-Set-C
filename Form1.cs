using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Survey_Set_C
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string gender = "Not answered";
        private string age = "Not answered";
        private string marital = "Not answered";
        private string income = "Not answered";
        private string employment = "Not answered";
        private string education = "Not answered";
        private string GetSelectedRadio(GroupBox grp)
        {
            if (grp == null || grp.Controls.Count == 0)
                return "Not answered";

            foreach (RadioButton rb in grp.Controls.OfType<RadioButton>())
            {
                if (rb.Checked)
                    return rb.Text;
            }

            return "Not answered";
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            gender = GetSelectedRadio(grpGender);
            age = GetSelectedRadio(grpAge);
            marital = GetSelectedRadio(grpMarital);
            income = GetSelectedRadio(grpIncome);
            employment = GetSelectedRadio(grpEmployment);
            education = GetSelectedRadio(grpEducation);

            Form2 f2 = new Form2(gender, age, marital, income, employment, education);
            f2.Show();
            this.Hide();
        }

        private void grpEducation_Enter(object sender, EventArgs e)
        {

        }
    }
}
