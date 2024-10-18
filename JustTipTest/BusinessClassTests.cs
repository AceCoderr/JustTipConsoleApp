using JustTipConsoleApp.Models;
using JustTipConsoleApp.Strategy;

namespace JustTipTest
{
    [TestClass]
    public class BusinessClassTests
    {
        ITipCalcStrategy strategy = new ProportionalDistribution();
        Business business;
        public  BusinessClassTests()
        {
            business = new Business(strategy);
        }
        [TestMethod]
        public void DistributeTips_LogicCheckForSameHoursTwoEmployees()
        {
            //Arrange
            business.AddEmployee("Akash");
            business.AddEmployee("Sagar");
            business.CreateRoster("Week1");
            business.AssignEmployeesToRoster("Week1", "Akash",DateTime.Parse("2023-10-16 05:00"),DateTime.Parse("2023-10-16 10:00"));
            business.AssignEmployeesToRoster("Week1", "Sagar",DateTime.Parse("2023-10-16 05:00"),DateTime.Parse("2023-10-16 10:00"));

            //Act
            var result = business.DistributeTip("Week1", 500);

            //the tip should be divided by two as number of hours worked by both employees is same

            //Assert
            Assert.AreEqual(result[0].Tips , 250);
            Assert.AreEqual(result[1].Tips, 250);
        }

        [TestMethod]
        public void DistributeTips_LogicCheckForDifferentHoursTwoEmployees()
        {
            //Arrange
            business.AddEmployee("Akash");
            business.AddEmployee("Sagar");
            business.CreateRoster("Week1");
            business.AssignEmployeesToRoster("Week1", "Akash", DateTime.Parse("2023-10-16 05:00"), DateTime.Parse("2023-10-16 10:00"));
            business.AssignEmployeesToRoster("Week1", "Sagar", DateTime.Parse("2023-10-16 05:00"), DateTime.Parse("2023-10-16 08:00"));

            //Act
            var result = business.DistributeTip("Week1", 500);

            //here the tip should be different for each employee based on the number of hours.
            //Here Employee - Akash works more hours than sagar so he should get more tip than sagar

            //Assert
            Assert.AreEqual((float)result[0].Tips, 312.5);
            Assert.AreEqual((float)result[1].Tips, 187.5);
        }

    }
}