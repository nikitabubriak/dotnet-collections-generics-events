using System;
using CustomCollection;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MyStack<int> stack = new MyStack<int>(3);

            stack.StackEvent += ConsoleMessage;

            foreach (var item in stack)
            {
                Console.WriteLine(item.ToString());
            }

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Peek();
            stack.Pop();
            stack.Push(stack.Pop());

            foreach (var item in stack)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private static void ConsoleMessage(object source, StackEventArgs args)
        {
            Console.WriteLine(args.Message);
        }
    }
}
