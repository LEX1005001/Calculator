using Calculator_Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form_1 : Form
    {
        ViewModel vm;
        public Form_1()
        {
            InitializeComponent();
            vm=new ViewModel();
        }

        public void button_1_Click(object sender, EventArgs e)
        {
            vm.Equation += "1";
            textBoxInput.Text = vm.Equation;
        }

        private void button_2_Click(object sender, EventArgs e)
        {
            vm.Equation += "2";
            textBoxInput.Text = vm.Equation;
        }

        private void button_3_Click(object sender, EventArgs e)
        {
            vm.Equation += "3";
            textBoxInput.Text = vm.Equation;
        }

        private void button_4_Click(object sender, EventArgs e)
        {
            vm.Equation += "4";
            textBoxInput.Text = vm.Equation;
        }

        private void button_5_Click(object sender, EventArgs e)
        {
            vm.Equation += "5";
            textBoxInput.Text = vm.Equation;
        }

        private void button_6_Click(object sender, EventArgs e)
        {
            vm.Equation += "6";
            textBoxInput.Text = vm.Equation;
        }

        private void button_7_Click(object sender, EventArgs e)
        {
            vm.Equation += "7";
            textBoxInput.Text = vm.Equation;
        }

        private void button_8_Click(object sender, EventArgs e)
        {
            vm.Equation += "8";
            textBoxInput.Text = vm.Equation;
        }

        private void button_9_Click(object sender, EventArgs e)
        {
            vm.Equation += "9";
            textBoxInput.Text = vm.Equation;
        }

        private void button_0_Click(object sender, EventArgs e)
        {
            vm.Equation += "0";
            textBoxInput.Text = vm.Equation;
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            textBoxInput.Text += " + ";
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            textBoxInput.Text += " - ";
        }

        private void buttonUmn_Click(object sender, EventArgs e)
        {
            Text = textBoxInput.Text += " * ";
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            textBoxInput.Text += " / ";
        }

        private void buttonOpnSc_Click(object sender, EventArgs e)
        {
            textBoxInput.Text += " ( ";
        }

        private void buttonClosedSc_Click(object sender, EventArgs e)
        {
            textBoxInput.Text += " ) ";
        }


        private void buttonRavno_Click(object sender, EventArgs e)
        {
           
            textBoxOutput.Text = vm.Evaluate();

        }

        private void buttonDellete_Click(object sender, EventArgs e)
        {
            textBoxInput.Text = string.Empty;
            
        }
    }
}
