using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Reverse_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            string[] numbers = input.Split(' ');

            var stack = new Stack<string>();

            for (int i = 0; i < numbers.Length; i++)
            {
                stack.Push(numbers[i]);
            }

            while (stack.Count != 0)
            {

                Console.Write(stack.Pop() + " ");
            }
        }
    }
}
