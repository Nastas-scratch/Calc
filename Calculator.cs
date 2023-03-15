using System;

namespace Main
{
    class Calculator
    {
        public static string Calculate(string line)
        {
            Space(ref line);
            string operation = "";
            if (line.IndexOf(',') < line.IndexOf('('))
                operation = line.Substring(line.IndexOf(',') + 1, line.IndexOf('(') - line.IndexOf(',') - 1);
            else
                operation = line.Substring(0, line.IndexOf('('));
            line = line.Substring(line.IndexOf('(') + 1, line.Length - line.IndexOf('(') - 1);
            while (line[line.Length - 1] != ')')
                line = line.Remove(line.Length - 1);
            line = line.Remove(line.Length - 1);
            while (line.IndexOf('(') >= 0 && line.IndexOf(')') >= 0)
            {
                if (line.IndexOf(',') != -1 && line.IndexOf(',') < line.IndexOf('('))
                {   //выражение справа от запятой
                    string sub = line.Substring(line.IndexOf(',') + 1, IndexLast(line) - line.IndexOf(','));
                    line = line.Replace(sub, Calculate(sub));
                }
                else
                {   //Выражение слева от запятой, или в скобках одиночное выражение
                    string sub = line.Substring(0, IndexLast(line) + 1);
                    line = line.Replace(sub, Calculate(sub));
                }
            }
            if (line.IndexOf(',') != -1 && line.IndexOf(',') < (line.IndexOf(')') > -1 ? line.IndexOf(')') : line.Length))
            {
                string left = line.Remove(line.IndexOf(','));
                string right = line.Replace(left + ",", "");
                Space(ref left);
                Space(ref right);
                if (left != "" && right != "")
                {
                    return CountUp(operation, left, right);
                }
                else
                {
                    Console.WriteLine("Не удалось посчитать выражение, проверьте его правильность.");
                    return "";
                }
            }
            else
            {
                string center = line;
                if (center != null)
                {
                    return CountUp(operation, center);
                }

            }
            return "";
        }

        static string CountUp(string oper, string left, string right)
        {
            Dot_Comma(ref left);
            Dot_Comma(ref right);
            string result = "";
            switch (oper)
            {
                case "+":
                    result = Convert.ToString(Double.Parse(left) + Double.Parse(right));
                    break;
                case "-":
                    result = Convert.ToString(Double.Parse(left) - Double.Parse(right));
                    break;
                case "*":
                    result = Convert.ToString(Double.Parse(left) * Double.Parse(right));
                    break;
                case "/":
                    result = Convert.ToString(Double.Parse(left) / Double.Parse(right));
                    break;
            }
            Dot_Comma(ref result);
            return result;
        }

        static string CountUp(string oper, string center)
        {
            Dot_Comma(ref center);
            string result = "";
            switch (oper)
            {
                case "-":
                    result = Convert.ToString(-Double.Parse(center));
                    break;
                case "":
                    result = Convert.ToString(Double.Parse(center));
                    break;
                case "sin":
                    result = Convert.ToString(Math.Sin(Double.Parse(center) * Math.PI / 180));
                    break;
                case "cos":
                    result = Convert.ToString(Math.Cos(Double.Parse(center) * Math.PI / 180));
                    break;
                case "tan":
                    result = Convert.ToString(Math.Tan(Double.Parse(center) * Math.PI / 180));
                    break;
                case "log10":
                    result = Convert.ToString(Math.Log(Double.Parse(center), 10));
                    break;
                default:
                    if (oper.Contains("log"))
                    {
                        int n = Int32.Parse(oper.Substring(3, oper.Length - 3));
                        result = Convert.ToString(Math.Log(Double.Parse(center), n));
                    }
                    break;
            }
            Dot_Comma(ref result);
            return result;
        }

        static int IndexLast(string line)
        {
            int count = 0, index = line.IndexOf(')');
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == '(') count++;
                if (line[i] == ')') count--;
                if (line[i] == ')' && count == 0)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        static void Space(ref string line)
        {
            if (line != "")
            {
                while (line[0] == ' ')
                    line = line.Substring(1, line.Length - 1);
                while (line[line.Length - 1] == ' ')
                    line = line.Substring(0, line.Length - 1);
            }
        }

        static void Dot_Comma(ref string line)
        {
            if (line.Contains(","))
            {
                line = line.Replace(",", ".");
            }
            else if (line.Contains("."))
            {
                line = line.Replace(".", ",");
            }
        }
    }
}
