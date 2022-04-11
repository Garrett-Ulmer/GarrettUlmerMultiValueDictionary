using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiValueDictionaryNS;
using System.Collections.Generic;

namespace MultiValueDictionaryUnitTests
{
    [TestClass]
    public class MultiValueDictionaryTests
    {
        
        MultiValueDictionary multiValueDictionary = new();
        string keyCase1 = "foo";
        string keyCase2 = "far";
        List<string> valueCase1 = new List<string> { "bar" };
        List<string> valueCase2 = new List<string> { "bar", "baz" };

        [TestMethod]
        public void Keys_ValidInput_Equal()
        {
            multiValueDictionary.Clear();
            multiValueDictionary.Add(keyCase1, valueCase1);
            multiValueDictionary.Add(keyCase2, valueCase2);
            List<string> expected = new();
            expected.Add(keyCase1);
            expected.Add(keyCase2);
            List<string> actual = multiValueDictionary.Keys();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Members_ValidInput_Equal()
        {
            multiValueDictionary.Clear();
            multiValueDictionary.Add(keyCase2, valueCase2);
            List<string> expected = new();
            expected.AddRange(valueCase2);
            List<string> actual = multiValueDictionary.Members(keyCase2);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Remove_ValidInput_NotEqual()
        {
            multiValueDictionary.Clear();
            multiValueDictionary.Add(keyCase1, valueCase1);
            List<string> expected = new();
            expected.AddRange(valueCase1);
            multiValueDictionary.Remove(keyCase1, valueCase1[0]);
            List<string> actual = multiValueDictionary.Members(keyCase1);
            CollectionAssert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void Remove_ValidInput_NotEqual2()
        {
            multiValueDictionary.Clear();
            multiValueDictionary.Add(keyCase2, valueCase2);
            List<string> expected = new();
            expected.AddRange(valueCase2);
            multiValueDictionary.Remove(keyCase1, valueCase1[0]);
            List<string> actual = multiValueDictionary.Members(keyCase1);
            CollectionAssert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveAll_ValidInput_Equal()
        {
            multiValueDictionary.Clear();
            multiValueDictionary.Add(keyCase1, valueCase1);
            multiValueDictionary.Add(keyCase2, valueCase2);
            List<string> expected = new();
            expected.AddRange(valueCase2);
            multiValueDictionary.RemoveAll(keyCase1);
            List<string> actual = multiValueDictionary.Members(keyCase2);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveAll_ValidInput_Equal2()
        {
            multiValueDictionary.Clear();
            multiValueDictionary.Add(keyCase1, valueCase1);
            multiValueDictionary.Add(keyCase2, valueCase2);
            List<string> expected = new();
            expected.AddRange(valueCase1);
            multiValueDictionary.RemoveAll(keyCase2);
            List<string> actual = multiValueDictionary.Members(keyCase1);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void KeyExists_ValidInput_True()
        {
            multiValueDictionary.Clear();
            multiValueDictionary.Add(keyCase1, valueCase1);
            multiValueDictionary.Add(keyCase2, valueCase2);
            
            Assert.IsTrue(multiValueDictionary.KeyExists(keyCase2));
        }

        [TestMethod]
        public void KeyExists_ValidInput_False()
        {
            multiValueDictionary.Clear();
            multiValueDictionary.Add(keyCase1, valueCase1);
            multiValueDictionary.Add(keyCase2, valueCase2);

            Assert.IsFalse(multiValueDictionary.KeyExists("cat"));
        }

        [TestMethod]
        public void MemberExists_ValidInput_True()
        {
            multiValueDictionary.Clear();
            multiValueDictionary.Add(keyCase1, valueCase1);
            multiValueDictionary.Add(keyCase2, valueCase2);

            Assert.IsTrue(multiValueDictionary.MemberExists(keyCase1, valueCase1[0]));
        }

        [TestMethod]
        public void MemberExists_ValidInput_False()
        {
            multiValueDictionary.Clear();
            multiValueDictionary.Add(keyCase1, valueCase1);
            multiValueDictionary.Add(keyCase2, valueCase2);

            Assert.IsFalse(multiValueDictionary.MemberExists(keyCase1, valueCase2[1]));
        }

        [TestMethod]
        public void AllMembers_ValidInput_Equal()
        {
            multiValueDictionary.Clear();
            multiValueDictionary.Add(keyCase1, valueCase1);
            multiValueDictionary.Add(keyCase2, valueCase2);
            List<string> expected = new();
            expected.AddRange(valueCase1);
            expected.AddRange(valueCase2);
            List<string> actual = multiValueDictionary.AllMembers();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AllMembers_ValidInput_NotEqual()
        {
            multiValueDictionary.Clear();
            multiValueDictionary.Add(keyCase1, valueCase1);
            multiValueDictionary.Add(keyCase2, valueCase2);
            List<string> expected = new();
            expected.AddRange(valueCase1);
            List<string> actual = multiValueDictionary.AllMembers();
            CollectionAssert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void Items_ValidInput_Equal()
        {
            multiValueDictionary.Clear();
            multiValueDictionary.Add(keyCase1, valueCase1);
            multiValueDictionary.Add(keyCase2, valueCase2);
            List<(string, string)> expected = new List<(string, string)>{("foo", "bar"), ("far", "bar"), ("far", "baz") };
            List <(string, string)> actual = multiValueDictionary.Items();
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
