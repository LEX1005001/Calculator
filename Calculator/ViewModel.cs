using Calculator_Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class ViewModel
    {
        private Calculater calc;
        private string equation;

        public ViewModel()
        {
            calc = new Calculater();
        }

        public string Equation { get => equation; set => equation = value; }

        public string Evaluate()
        {
            if (calc.IsCorrectBrackets(Equation.Split(' ')))
            {
                return Convert.ToString(calc.EvaluatePostfix(calc.Parse(equation).ToArray()));
            }
            else {
                return "Неверно введено выражение!";
            }
        }
        
    }
}
