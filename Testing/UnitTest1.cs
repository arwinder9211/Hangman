using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hangman;
using System.Collections.Generic;
using System.Linq;

namespace Testing
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Score s = new Score();
            int score=s.checkScoreLetter('W');
            Assert.AreEqual(4, score);



          
           
            
        }
    }
}
