using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexidiaCodingChallenge
{
    [TestFixture]
    class NUnitTest
    {
        [Test]
        public void TestHandingExceptions1()
        {
            Exception checkFileNotFoundException = null;
            string[] path = { "c:\\" };
            try {
                Program.HandlingExceptions(path);
            }
            catch (Exception ex)
            {
                checkFileNotFoundException = ex;
            }
            string s =checkFileNotFoundException.Message;
            Assert.IsNotNull(checkFileNotFoundException); //Exception was handled so it does not throw any exception therefore failing the test
        }

        [Test]
        public void TestHandingExceptions2()
        {
            Exception checkFileNotFoundException = null;
            string[] path = { "c:\\file.pdf" };
            try
            {
                Program.HandlingExceptions(path);
            }
            catch (Exception ex)
            {
                checkFileNotFoundException = ex;
            }
            string s = checkFileNotFoundException.Message;
            Assert.IsNotNull(checkFileNotFoundException); //Condition was handled and printed to the screen, so it does not throw any exception therefore failing the test
        }

        [Test]
        public void TestHandingExceptions3()
        {
            Exception checkFileNotFoundException = null;
            string[] path = { "c:\\testcase1.pdf" };
            try
            {
                Program.HandlingExceptions(path);
            }
            catch (Exception ex)
            {
                checkFileNotFoundException = ex;
            }
            string s = checkFileNotFoundException.Message;
            Assert.IsNotNull(checkFileNotFoundException); //Condition was handled and printed to the screen, so it does not throw any exception therefore failing the test
        }

        [Test]
        public void TestHandingExceptions4()
        {
            Exception checkFileNotFoundException = null;
            string[] path = { "c:\\\\file.txt" };
            try
            {
                Program.HandlingExceptions(path);
            }
            catch (Exception ex)
            {
                checkFileNotFoundException = ex;
            }
            string s = checkFileNotFoundException.Message;
            Assert.IsNotNull(checkFileNotFoundException); //Exception was handled so it does not throw any exception therefore failing the test
        }

        [Test]
        public void TestAddingTwosToList1()
        {
            List<long> factors = new List<long>();
           Assert.AreEqual(3,Program.AddTwosToList(12, factors));
        }

        [Test]
        public void TestAddingTwosToList2()
        {
            List<long> factors = new List<long>();
            Assert.AreEqual(1, Program.AddTwosToList(1, factors));
        }

        [Test]
        public void TestAddingTwosToList3()
        {
            Exception test = null;
            List<long> factors = new List<long>();
            try
            {
                Assert.AreEqual(0, Program.AddTwosToList(0, factors)); // handle zero case again in the while therefore no exception, otherwise - infinite loop
            }
            catch(Exception e)
            {
                test = e;
            }
            Assert.IsNotNull(test);
            
            }

        [Test]
        public void TestAddingTwosToList4()
        {
            Exception test = null;
            List<long> factors = new List<long>();
            try
            {
                Assert.AreEqual(-1999999999999999999, Program.AddTwosToList(-1999999999999999999, factors)); // handle negative number case again in the while therefore no exception
            }
            catch (Exception e)
            {
                test = e;
            }
            Assert.IsNotNull(test);

        }

        [Test]
        public void TestAddingTwosToList5()
        {
            Exception test = null;
            List<long> factors = new List<long>();
            try
            {
                Assert.AreEqual(1999999999999999999, Program.AddTwosToList(1999999999999999999, factors)); 
            }
            catch (Exception e)
            {
                test = e;
            }
            Assert.IsNotNull(test);
        }

        [Test]
        public void TestAddAnotherFactor1()
        {
            Exception test = null;
            List<long> factors = new List<long>();
            try
            {
                Assert.AreEqual(-1999999999999999999, Program.AddOtherFactors(-1999999999999999999, factors)); 
            }
            catch (Exception e)
            {
                test = e;
            }
            Assert.IsNotNull(test);
        }

        [Test]
        public void TestAnotherFactor2()
        {
            Exception test = null;
            List<long> factors = new List<long>();
            try
            {
                Assert.AreEqual(3, Program.AddOtherFactors(1999999999999999999, factors)); //Assert fails therefore throws exception
            }
            catch (Exception e)
            {
                test = e;
            }
            Assert.IsNotNull(test);
        }

        [Test]
        public void TestAnotherFactor3()
        {
            Exception test = null;
            List<long> factors = new List<long>();
            try
            {
                Assert.AreEqual(1, Program.AddOtherFactors(1, factors));
            }
            catch (Exception e)
            {
                test = e;
            }
            Assert.IsNotNull(test);
        }

        [Test]
        public void TestAnotherFactor4()
        {
            Exception test = null;
            List<long> factors = new List<long>();
            try
            {
                Assert.AreEqual(0, Program.AddOtherFactors(0, factors));
            }
            catch (Exception e)
            {
                test = e;
            }
            Assert.IsNotNull(test);
        }

        [Test]
        public void TestFactorial1()
        {
            List<long> factors = new List<long>();
            Assert.AreEqual(3, Program.CalculatePrimeFactors(12).Count);
        }

        [Test]
        public void TestFactorial2()
        {
            List<long> factors = new List<long>();
            Assert.AreEqual(2, Program.CalculatePrimeFactors(1999999999999999999).Count);
        }

        [Test]
        public void TestFactorial3()
        {
            List<long> factors = new List<long>();
            Assert.AreEqual(0, Program.CalculatePrimeFactors(-1999999999999999999).Count); //only if number greater than 0, it stores in the list. Therefore list is empty 
        }

        [Test]
        public void TestFactorial4()
        {
            List<long> factors = new List<long>();
            Assert.AreEqual(0, Program.CalculatePrimeFactors(0).Count); //only if number greater than 0, it stores in the list. Therefore list is empty 
        }

        [Test]
        public void TestFactorial5()
        {
            List<long> factors = new List<long>();
            Assert.AreEqual(0, Program.CalculatePrimeFactors(1).Count); //only if number greater than 0, it stores in the list. Therefore list is empty 
        }
    }

}
