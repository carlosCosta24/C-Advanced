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
        //protected virtual void CalculationComplet(int Result)
        //{
        //    Action<int> Handeler = OnCalculate;
        //    if(Handeler != null)
        //    {
        //        Handeler(Result);
        //    }
        //}
        // define a an event class 
        public class CalculatCompletion : EventArgs
        {
            public int FirstValue { get; }
            public int SecondValue { get; }
            public int Result { get; }

            public CalculatCompletion(int firstValue, int secondValue, int result)
            {
                this.FirstValue = firstValue;
                this.SecondValue = secondValue;
                this.Result = result;
            }
        }
        //declare the event Handler 
        public event EventHandler<CalculatCompletion> OnCalculateCompletion;
        
        //declare the action 
        protected virtual void AfterCalculatCompletion(CalculatCompletion e)
        {
            OnCalculateCompletion?.Invoke(this, e);
        }
        // declare constructing function
        public void RaisOnCalculatCompletion(int FirstValue, int SecondValue, int Result)
        {
            AfterCalculatCompletion(new CalculatCompletion(FirstValue, SecondValue, Result));
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
           int FirstNumber = int.Parse(tbFirstNumber.Text);
           int SecondNumber = int.Parse(tbSecondNumber.Text);
           int Result = FirstNumber + SecondNumber;

           lbResult.Text = Result.ToString();
            if(OnCalculateCompletion != null)
            {
                RaisOnCalculatCompletion(FirstNumber,SecondNumber,Result);
            }
        }
    }
}
