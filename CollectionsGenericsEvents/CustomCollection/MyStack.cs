using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCollection
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>

    //events
    //summary description
    //build solution into dll
    //create console project

    public class MyStack<T>
    {
        //storage
        T[] stack = null;

        //index of the element on top of the stack
        int index = -1;

        //constructors create stack with certain capacity
        public MyStack(int capacity)
        {
            stack = new T[capacity];
        }

        public MyStack() : this(10) 
        {
            
        }

        //pushes an element on the top of the stack
        public void Push(T item) 
        {
            if (index > stack.Length - 1) 
            {
                throw new OverflowException();
            }

            stack[index] = item;

            index++;
        }

        //removes and returns the top element of the stack
        public T Pop()
        {
            if (index == -1) 
            {
                throw new Exception();
            } 

            index--;

            return stack[index];
        }

        //returns the top element of the stack without removing it
        public T Peek()
        {
            if (index == -1)
            {
                throw new Exception();
            }

            return stack[index];
        }

        //yield operator implements IEnumerator<T> interface in the iterator
        public IEnumerator<T> GetEnumerator()
        {
            foreach(var item in stack)
            {
                yield return item; 
            }
        }
    }
}
