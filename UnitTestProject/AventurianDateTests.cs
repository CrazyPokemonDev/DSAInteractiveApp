using System;
using DSAInteractiveApp.Modeling.Calendar;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class AventurianDateTests
    {
        [TestMethod]
        public void AventurianDateSubtractionTest1()
        {
            AventurianDate date1 = new AventurianDate(5, 0, 1040);
            AventurianDate date2 = new AventurianDate(1, 1, 1041);
            Assert.AreEqual(date1, date1);
            Assert.IsTrue(date1 - date2 == date2 - date1);
            Assert.IsTrue(date1 < date2);
            Assert.AreEqual(date1 - date2, new AventurianDateSpan(days: 1));
        }

        [TestMethod]
        public void AventurianDateSubtractionTest2()
        {
            AventurianDate date1 = new AventurianDate(14, 8, 1040);
            AventurianDate date2 = new AventurianDate(11, 4, 1043);
            Assert.IsTrue(date1 - date2 == date2 - date1);
            Assert.IsTrue(date1 < date2);
            Assert.AreEqual(new AventurianDateSpan(2, 7, 32), date1 - date2);
        }

        [TestMethod]
        public void AventurianDateSubtractionTest3()
        {
            AventurianDate date1 = new AventurianDate(9, 9, 1040);
            AventurianDate date2 = new AventurianDate(8, 8, 1039);
            Assert.IsTrue(date1 - date2 == date2 - date1);
            Assert.IsTrue(date1 > date2);
            Assert.AreEqual(new AventurianDateSpan(1, 1, 1), date1 - date2);
        }
    }
}
