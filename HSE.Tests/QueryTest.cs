using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HSE.Main;
using System.IO;
using System.Collections.Generic;

namespace HSE.Tests
{
    [TestClass]
    public class QueryTest
    {
        private static DocDirectory dir = new DocDirectory(new DirectoryInfo(@"C:\Users\user\Desktop\toUche"));
        private static IndexWriter ind = new IndexWriter(new DirectoryInfo(@"C:\Users\user\Documents\c# programs\HSE\HSE"));

        static QueryTest()
        {
            ind.indexDirectory(dir);
        }
   
        [TestMethod]
        public void TestMethod1()
        {
           
            IndexReader ind2 = new IndexReader(new DirectoryInfo(@"C:\Users\user\Documents\c# programs\HSE\HSE"));
            Query query = new Query("my name is");
            string expected = query.QueryType;
            string actual = "FTQ";

            Assert.AreEqual<string>(expected, actual);
        }

        [TestMethod]
        public void TestMethod2()
        {
    
            IndexReader ind2 = new IndexReader(new DirectoryInfo(@"C:\Users\user\Documents\c# programs\HSE\HSE"));
            Query query = new Query("i love");
            List<string> expect = query.Terms;
            string expected = expect[0];
            string actual = "love";

            Assert.AreEqual(expected, actual);
        }
    }
}
