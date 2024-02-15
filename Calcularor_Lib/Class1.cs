using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_Lib
{
    public class Calculater
    {
        string[] operators = { "+", "-", "/", "*" };
        string[] openBrackets = { "(", "[", "{" };
        string[] closeBrackets = { ")", "]", "}" };
        string[] tokens;
        Stack<string> stack = new Stack<string>();
        List<string> parsed = new List<string>();

        /// <summary>
        /// Перевод арифметического выражения из инфиксной записи в постфиксную
        /// </summary>
        /// <param name="input">арифметическое выражение в инфиксной записи</param>
        /// <returns>арифметическое выражение в постфиксной записи</returns>
        public List<string> Parse(string input)
        {
            //делим выражение на отдельные операции - токены
            tokens = input.Split(' ');

            //Обрабатываем каждый токен
            foreach (string item in tokens)
            {
                if (item == "(") stack.Push(item);  //Открывающая скобка заносится в стек
                else if (item == ")")    //Закрывающая скобка обрабатывает стек до открывающей, занося его элементы в ответ
                {
                    while (stack.Count != 0 && stack.Peek() != "(") parsed.Add(stack.Pop());
                    stack.Pop();
                }
                else if (isOperator(item))  //Операторы следующие друг за другом по приоритетам заносятся в стек
                {
                    //Операторы с большим приоритетом выносятся вперёд операций с меньшим приоритетом в ответе
                    while (stack.Count != 0 && Priority(stack.Peek()) >= Priority(item)) parsed.Add(stack.Pop());
                    //В стек заносится текущая операция
                    stack.Push(item);
                }
                //Операнд заносится в ответ
                else parsed.Add(item);
            }
            while (stack.Count != 0) parsed.Add(stack.Pop());   //В ответ заносится оставшиеся операции


            return parsed;
        }

        /// <summary>
        /// Определить приоритет арифметической операции
        /// </summary>
        /// <param name="c">арифметическая операция</param>
        /// <returns>число - приоритет операции. Чем больше число, тем выше приоритет</returns>
        public int Priority(string c)
        {
            switch (c)
            {
                case "/":
                    return 4;
                case "*":
                    return 2;

                case "+":
                case "-":
                    return 1;

                default:
                    return 0;
            }
        }
        /// <summary>
        /// Определить, является ли токен оператором или операндом
        /// </summary>
        /// <param name="c">Токен выражения</param>
        /// <returns>True, если токен - оператор </returns>
        public bool isOperator(string c)
        {
            if (c == "+" || c == "-" || c == "*" || c == "/")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Операции
        /// </summary>
        /// <param name="equation">текст</param>
        /// <returns></returns>
        public double EvaluatePostfix(string[] equation)
        {
            double a;
            double b;
            Stack<double> values = new Stack<double>();
            foreach (var token in equation)
            {
                    switch (token)
                    {
                        case "+":
                            a = values.Pop();
                            b = values.Pop();
                            values.Push(a + b);
                            break;

                        case "-":
                            a = values.Pop();
                            b = values.Pop();
                            values.Push(a - b);
                            break;

                        case "*":
                            a = values.Pop();
                            b = values.Pop();
                            values.Push(a * b);
                            break;

                        case "/":
                            a = values.Pop();
                            b = values.Pop();
                            values.Push(a / b);
                            break;
                        default:
                            values.Push(double.Parse(token));
                            break;
                    }
            }
            return values.Peek();
        }
        /// <summary>
        /// Проверка на правильность поставления скобок
        /// </summary>
        /// <param name="equation">текс</param>
        /// <returns></returns>
        public bool IsCorrectBrackets(string[] equation)
        {
            Stack<string> brackets = new Stack<string>();
            string[] copy = equation;

            for (int i = 0; i < copy.Length; i++)
            {
                if (openBrackets.Contains(copy[i]))
                {
                    copy[i] = openBrackets[0];
                }
                if (closeBrackets.Contains(copy[i]))
                {
                    copy[i] = closeBrackets[0];
                }
            }

            foreach (var token in copy)
            {
                if (token == "(")
                {
                    brackets.Push(token);
                }
                else if (token == ")")
                {
                    if (brackets.Count == 0) { return false; }
                    brackets.Pop();
                }
            }
            return brackets.Count == 0;
        }
    }
}
