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

            stack.Push(64);
            stack.Push(32);
            stack.Push(128);
            stack.Peek();
            stack.Pop();
            stack.Push(stack.Pop());
        }

        private static void ConsoleMessage(object source, StackEventArgs args)
        {
            Console.WriteLine(args.Message);
        }
    }
}
