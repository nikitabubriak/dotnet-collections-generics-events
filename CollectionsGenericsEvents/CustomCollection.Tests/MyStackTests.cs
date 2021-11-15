using NUnit.Framework;
using CustomCollection;
using System.Collections;
using System.Collections.Generic;
using System;

//dotnet test --collect:"XPlat Code Coverage"
//reportgenerator -reports:"###\coverage.cobertura.xml" -targetdir:"coveragereport" -reporttypes:Html

namespace CustomCollection.Tests
{
    [TestFixture]
    public class MyStackTests
    {
        private MyStack<int> stack;

        [SetUp]
        public void SetUp()
        {
            stack = new MyStack<int>(2);

            stack.Push(1);
        }

        [Test]
        public void Push_Pushed3ItemsIntoStackOfCapacity2_ThrownIndexOutOfRangeException()
        {
            stack.Push(2);

            Assert.Throws<IndexOutOfRangeException>(() => stack.Push(3));
        }

        [Test]
        public void Push_LastPushedItemOnTopOfTheStackIs1_PoppedItemIs1()
        {
            var pushedItem = stack.Pop();

            Assert.AreEqual(1, pushedItem);
        }

        [Test]
        public void Pop_Popped2ItemsFromStackWith1Item_ThrownEmptyStackException()
        {
            stack.Pop();

            Assert.Throws<EmptyStackException>(() => stack.Pop());
        }

        [Test]
        public void Pop_ItemOnTopOfTheStackIs2Then1_Return2Then1()
        {
            stack.Push(2);
            var poppedItemFirst = stack.Pop();
            var poppedItemSecond = stack.Pop();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(2, poppedItemFirst);
                Assert.AreEqual(1, poppedItemSecond);
            });
        }

        [Test]
        public void Peek_PeekedIntoEmptyStack_ThrownEmptyStackException()
        {
            stack.Pop();

            Assert.Throws<EmptyStackException>(() => stack.Peek());
        }

        [Test]
        public void Peek_ItemOnTopOfTheStackIs1_Return1WithoutPeekRemovingItFromTheStack()
        {
            var peekedItem = stack.Peek();
            var poppedItem = stack.Pop();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(1, peekedItem);
                Assert.AreEqual(1, poppedItem);
            });
            
        }
    }
}