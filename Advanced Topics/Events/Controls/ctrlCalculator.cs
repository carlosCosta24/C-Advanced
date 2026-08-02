using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Advanced_Topics.Events.Controls
{
    public partial class ctrlCalculator : UserControl
    {
        public event Action<int> OnCalculate;
        protected virtual void CalculationComplet(int Result)
        {
            Action<int> Handeler = OnCalculate;
            if(Handeler != null)
            {
                Handeler(Result);
            }
        }
        public ctrlCalculator()
        {
            InitializeComponent();
        }

        private void ctrlCalculator_Load(object sender, EventArgs e)
        {

        }

        private void tbFirstNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void tbSecondNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            int CalculationResult = int.Parse(tbFirstNumber.Text) + int.Parse(tbSecondNumber.Text);
            lbResult.Text = CalculationResult.ToString();
            if(OnCalculate  != null)
            {
                OnCalculate(CalculationResult);
            }
        }
    }
}
