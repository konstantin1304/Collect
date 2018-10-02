using Microsoft.VisualStudio.TestTools.UnitTesting;
using Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.Tests
{
    [TestClass()]
    public class MyArrayListTests
    {
        MyArrayList<int> list;

        [TestInitialize]
        public void Initializer_Test()
        {
            list = new MyArrayList<int>();
        }
        [TestMethod()]
        public void AddTest()
        {
            list.Add(7);
            list.Add(9);

            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(9, list[1]);
        }

        [TestMethod()]
        public void ClearTest()
        {
            list.Add(7);
            list.Add(9);

            list.Clear();
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod()]
        public void ContainsTest()
        {
            list.Add(7);
            list.Add(9);

            Assert.AreEqual(true, list.Contains(9));
            Assert.AreEqual(false, list.Contains(22));
        }

        [TestMethod()]
        public void CopyToTest()
        {
            list.Add(7);
            list.Add(9);

            int[] array = new int[2];

            list.CopyTo(array, 0);

            Assert.AreEqual(list.Count, array.Length);
            Assert.AreEqual(9, array[1]);
        }

        [TestMethod()]
        public void IndexOfTest()
        {
            list.Add(7);
            list.Add(9);
            list.Add(1);
            list.Add(2);

            Assert.AreEqual(1, list.IndexOf(9));
        }

        [TestMethod()]
        public void RemoveTest()
        {
            list.Add(7);
            list.Add(9);
            list.Add(1);

            list.Remove(9);

            Assert.AreEqual(1, list[1]);
        }

        [TestMethod()]
        public void RemoveAtTest()
        {
            list.Add(7);
            list.Add(9);
            list.Add(1);

            list.RemoveAt(1);

            Assert.AreEqual(1, list[1]);
        }

        [TestMethod()]
        public void InsertTest()
        {
            list.Add(7);
            list.Add(9);
            list.Insert(1, 3);

            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(3, list[1]);
        }

        [TestMethod()]
        public void GetEnumeratorTest()
        {
            Assert.AreEqual(list, list.GetEnumerator());
        }

        [TestMethod()]
        public void EnumerableTest2()
        {
            list.Add(7);
            list.Add(9);

            Assert.AreEqual(list.MoveNext(), true);
            Assert.AreEqual(list.Current, 7);
            Assert.AreEqual(list.MoveNext(), true);
            Assert.AreEqual(list.Current, 9);
            Assert.AreEqual(list.MoveNext(), false);

            list.Reset();
            Assert.AreEqual(list.MoveNext(), true);
            Assert.AreEqual(list.Current, 7);
            list.Reset();
            Assert.ThrowsException<IndexOutOfRangeException>(()=>list.Current);

        }
        [TestMethod]
        public void EnumerableTestMethod()
        {
            int[] inArr = new[] { 65, 77, 19, 34, 62 };
            list = new MyArrayList<int>(5);
            for (int i = 0; i < inArr.Length; i++)
            {
                list.Add(inArr[i]);
            }
            
            int[] checkArr = new int[inArr.Length];
            int index = 0;

            foreach (var item in list)
            {
                checkArr[index++] = item;
            }

            CollectionAssert.AreEqual(inArr, checkArr);
        }



    }
}