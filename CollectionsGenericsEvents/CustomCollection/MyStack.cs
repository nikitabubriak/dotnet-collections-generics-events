using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCollection
{
    /// <summary>
    /// This class is used for throwing empty stack exception message
    /// </summary>
    public class EmptyStackException : Exception
    {
        public EmptyStackException(string message) : base(message) { }
    }

    /// <summary>
    /// This class is used for storing arguments in standard event handling
    /// </summary>
    public class StackEventArgs : EventArgs
    {
        public string Message { get; }

        public StackEventArgs(string message)
        {
            Message = message;
        }
    }

    public delegate void StackHandler(object source, StackEventArgs arg);

    /// <summary>
    /// This class is used to store data as a custom stack of generic elements.
    /// The order in which elements come off a stack is LIFO (last in, first out)
    /// </summary>
    /// <typeparam name="T">Generic argument</typeparam>
    public class MyStack<T>
    {
        //storage
        T[] stack;

        //index of the element on top of the stack
        int topIndex = -1;

        public event StackHandler StackEvent;

        //constructors create stack with certain capacity
        public MyStack(int capacity)
        {
            stack = new T[capacity];
        }

        public MyStack() : this(10) 
        {
            
        }

        //yield operator implements IEnumerator<T> interface in the iterator
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in stack)
            {
                yield return item;
            }
        }

        //pushes an element on the top of the stack
        public void Push(T item) 
        {
            if (topIndex >= stack.Length - 1) 
            {
                throw new IndexOutOfRangeException("Could not push into full stack");
            }

            topIndex++;

            stack[topIndex] = item;

            StackEvent?.Invoke(this, new StackEventArgs($"Push. Now {(topIndex + 1).ToString()} item(s) in stack"));
        }

        //removes and returns the top element of the stack
        public T Pop()
        {
            if (topIndex == -1) 
            {
                throw new EmptyStackException("Could not pop from empty stack");
            } 

            topIndex--;

            StackEvent?.Invoke(this, new StackEventArgs($"Pop. Now {(topIndex + 1).ToString()} item(s) in stack"));

            return stack[topIndex];
        }

        //returns the top element of the stack without removing it
        public T Peek()
        {
            if (topIndex == -1)
            {
                throw new EmptyStackException("Could not peek into empty stack");
            }

            StackEvent?.Invoke(this, new StackEventArgs($"Peek. Now {(topIndex + 1).ToString()} item(s) in stack"));

            return stack[topIndex];
        }
    }
}
