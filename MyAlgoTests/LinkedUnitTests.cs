using AlgoDataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyAlgoTests
{
    [TestClass]
    public class LinkedUnitTests
    {
        [TestMethod]
        public void SingleLinkedListAddTest()
        {
            SingleLinkedList<int> sll = new SingleLinkedList<int>();
            sll.Add(10);
            sll.Add(15);
            Assert.AreEqual(2, sll.Count);
        }

        [TestMethod]
        public void SingleLinkedListInsertTest()
        {
            SingleLinkedList<int> sll = new SingleLinkedList<int>();
            sll.Add(10);
            sll.Add(15);
            sll.Insert(13, 1);
            Assert.AreEqual(3, sll.Count);
        }

        [TestMethod]
        public void SingleLinkedListGetTest()
        {
            SingleLinkedList<int> sll = new SingleLinkedList<int>();
            sll.Add(15);
            sll.Add(17);
            sll.Add(23);
            sll.Add(27);
            Assert.AreEqual(23, sll.Get(2));
        }

        [TestMethod]
        public void SingleLinkedListRemoveTest()
        {
            SingleLinkedList<int> sll = new SingleLinkedList<int>();
            sll.Add(25);
            sll.Add(44);
            sll.Add(56);
            sll.Add(122);
            sll.Remove();
            Assert.AreNotEqual(25, sll.Get(0));
        }

        public void SingleLinkedListRemoveLastTest()
        {
            SingleLinkedList<int> sll = new SingleLinkedList<int>();
            sll.Add(144);
            sll.Add(169);
            sll.Add(205);
            sll.Add(455);
            sll.Add(14);
            sll.RemoveLast();
            Assert.AreNotEqual(14, sll.Get(sll.Count));
        }

        [TestMethod]
        public void SingleLinkedListClearTest()
        {
            SingleLinkedList<int> sll = new SingleLinkedList<int>();
            sll.Add(133);
            sll.Add(1092);
            sll.Add(45);
            sll.Add(1);
            sll.Add(54);
            sll.Add(12312);
            sll.Clear();
            Assert.AreEqual(0, sll.Count);
        }

        [TestMethod]
        public void SingleLinkedSearchTest()
        {
            SingleLinkedList<int> sll = new SingleLinkedList<int>();
            sll.Add(1232);
            sll.Add(4523);
            sll.Add(4633);
            sll.Add(124);
            sll.Add(3212);
            sll.Add(5463);
            sll.Add(552);
            sll.Add(12342);
            Assert.AreEqual(1, sll.Search(4523));
        }

        [TestMethod]
        public void DoubleLinkedListAddTest()
        {
            DoubleLinkedList<int> sll = new DoubleLinkedList<int>();
            sll.Add(10);
            sll.Add(15);
            Assert.AreEqual(2, sll.Count);
        }

        [TestMethod]
        public void DoubleLinkedListInsertTest()
        {
            DoubleLinkedList<int> sll = new DoubleLinkedList<int>();
            sll.Add(10);
            sll.Add(15);
            sll.Insert(13, 1);
            Assert.AreEqual(3, sll.Count);
            Assert.AreEqual(13, sll.Get(1));
        }

        [TestMethod]
        public void DoubleLinkedListGetTest()
        {
            DoubleLinkedList<int> sll = new DoubleLinkedList<int>();
            sll.Add(15);
            sll.Add(17);
            sll.Add(23);
            sll.Add(27);
            Assert.AreEqual(23, sll.Get(2));
        }

        [TestMethod]
        public void DoubleLinkedListRemoveTest()
        {
            DoubleLinkedList<int> sll = new DoubleLinkedList<int>();
            sll.Add(25);
            sll.Add(44);
            sll.Add(56);
            sll.Add(122);
            sll.Remove();
            Assert.AreNotEqual(25, sll.Get(0));
        }

        public void DoubleLinkedListRemoveLastTest()
        {
            DoubleLinkedList<int> sll = new DoubleLinkedList<int>();
            sll.Add(144);
            sll.Add(169);
            sll.Add(205);
            sll.Add(455);
            sll.Add(14);
            sll.RemoveLast();
            Assert.AreNotEqual(14, sll.Get(sll.Count));
        }

        [TestMethod]
        public void DoubleLinkedListClearTest()
        {
            DoubleLinkedList<int> sll = new DoubleLinkedList<int>();
            sll.Add(133);
            sll.Add(1092);
            sll.Add(45);
            sll.Add(1);
            sll.Add(54);
            sll.Add(12312);
            sll.Clear();
            Assert.AreEqual(0, sll.Count);
        }

        [TestMethod]
        public void DoubleLinkedSearchTest()
        {
            DoubleLinkedList<int> sll = new DoubleLinkedList<int>();
            sll.Add(1232);
            sll.Add(4523);
            sll.Add(4633);
            sll.Add(124);
            sll.Add(3212);
            sll.Add(5463);
            sll.Add(552);
            sll.Add(12342);
            Assert.AreEqual(6, sll.Search(552));
        }

        [TestMethod]
        public void SingleLinkedToStringTest()
        {
            SingleLinkedList<int> sll = new SingleLinkedList<int>();
            sll.Add(1);
            sll.Add(12);
            sll.Add(123);
            sll.Add(91);
            Assert.AreEqual("1, 12, 123, 91", sll.ToString());
        }

        [TestMethod]
        public void DoubleLinkedToStringTest()
        {
            DoubleLinkedList<int> dll = new DoubleLinkedList<int>();
            dll.Add(13);
            dll.Add(133);
            dll.Add(317);
            dll.Add(77);
            dll.Add(41);
            Assert.AreEqual("13, 133, 317, 77, 41", dll.ToString());
        }
    }
}
