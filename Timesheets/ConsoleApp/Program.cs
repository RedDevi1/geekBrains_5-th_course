using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = " Предложение     один Теперь   предложение       два Предложение три ";

            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex("[ ]{2,}", options);
            string res = regex.Replace(str, " ").Trim(' ');

            var result = new StringBuilder(res);

            for (var i = 1; i < result.Length; i++)
            {
                if (Char.IsUpper(result[i]))
                {
                    result.Insert(i - 1, '.');
                    i += 1;
                }
            }
            result.Append('.');
            Console.WriteLine(result);
        }
    }
}
