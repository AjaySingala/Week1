using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestingLibrary;

namespace UnitTestingLibrary_MSTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange.
            string expected = "Ajay Singala";
            Library sh = new Library();

            // Act.
            string result = sh.Fullname("Ajay", "Singala");

            // Assert.
            Assert.AreEqual(result, expected);
        }

        // CollectionAssert Tests
        [TestMethod]
        public void CollectionAreEqualTest()
        {
            List<string> first = new List<string>();
            first.Add("a");

            List<string> second = new List<string>();
            //second.Add("b");
            second.Add("a");

            CollectionAssert.AreEqual(first, second);
        }

        [TestMethod]
        public void CollectionAllItemsAreUniqueTest()
        {
            List<string> first = new List<string>();
            first.Add("a");
            first.Add("b");
            first.Add("c");

            CollectionAssert.AllItemsAreUnique(first);
        }

        [TestMethod]
        public void CollectionContainsTest()
        {
            List<string> first = new List<string>();
            first.Add("a");
            first.Add("b");
            first.Add("c");

            //CollectionAssert.Contains(first, "x");
            CollectionAssert.Contains(first, "a");
        }

        [TestMethod]
        public void CollectionDoesNotContainTest()
        {
            List<string> first = new List<string>();
            first.Add("a");
            first.Add("b");
            first.Add("c");

            CollectionAssert.DoesNotContain(first, "x");
        }

        [TestMethod]
        public void CollectionReferenceEqualsTest()
        {
            List<string> str1 = new List<string>();
            List<string> str2 = new List<string>();

            // Will pass because both are string collections.
            CollectionAssert.ReferenceEquals(str1, str2);
        }

        [TestMethod]
        public void CollectionAllItemsAreNotNullTest()
        {
            List<string> str1 = new List<string>();
            //str1.Add(null);
            str1.Add("c");
            str1.Add("a");
            str1.Add("b");
            CollectionAssert.AllItemsAreNotNull(str1);
        }

        [TestMethod]
        public void CollectionAllItemsAreInstanceOfTypeTest()
        {
            List<string> str1 = new List<string>();
            CollectionAssert.AllItemsAreInstancesOfType(str1, typeof(string));
        }

        // ExpectedException Testing.
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void ExpectedExceptionTest()
        {
            Library lib = new Library();
            var result = lib.Divide(10, 0);
            Assert.AreEqual(10, 0);
        }
    }
}
