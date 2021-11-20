namespace TheSalarySystemTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TheSalarySystem.Menu.Tests;
    using TheSalarySystem.Models.Tests;

    [TestClass()]
    public class IntegrationTest
    {
        private AdminTests adminTest = new();

        private UserTests useTest = new();

        [TestMethod()]

        public void Integration_Admin_TesT()
        {
            StartMenuTests.LoginTest("admin1", "admin1234", "admin1");
            adminTest.CreateUserTest_CreateNewUser("Dennis", "Lund", "denlu", "sen123", "staff", 1200, false, -1);
            adminTest.DeleteTest_DeleteAdminAccount_ReturnFalse("admin1", "admin1234", false);
        }

        public void Integration_User_Test()
        {
            StartMenuTests.LoginTest("farzanezafar", "password1", "farzanezafar");
            useTest.DeleteTest_DeleteOnesOwnAccount_ShouldReturnTrue("farzanezafar", "password1", true);
            useTest.DeleteTest_DeleteOnesOwnAccount_ShouldReturnTrue("davidberg", "david123", false);
        }
    }
}
