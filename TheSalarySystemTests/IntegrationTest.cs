namespace TheSalarySystemTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TheSalarySystem.Menu.Tests;
    using TheSalarySystem.Models.Tests;
    using TheSalarySystem.Models;
    using TheSalarySystem.Interfaces;
    using TheSalarySystem.Menu;

    [TestClass()]
    public class IntegrationTest
    {
        [TestMethod()]

        public void Integration_Admin_TesT()
        {
            IAccount admin = StartMenu.GetUser(StartMenu.Login("admin1", "admin1234"));
            var actual = admin.Delete("admin1", "admin1234");
            Assert.IsFalse(actual);
        }



       
    }
}
