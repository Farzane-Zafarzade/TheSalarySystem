using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheSalarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSalarySystem.Models.Tests
{
    [TestClass()]
    public class AdminTests
    {
        

        [TestMethod()]
        [DataRow("Dennis", "Lund", "denlu", "sen123", "staff", 1200, false, -1)]

        public void CreateUserTest_CreateNewUser(string fname, string lname, string uname, string pass, string role, int salary, bool isAdmin, int expected)
        {
            Admin newAdmin = new();
            var actual = newAdmin.CreateUser(fname, lname, uname, pass, role, salary, isAdmin);
           
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow("admin1", "admin1234", false)]
        
        public void DeleteTest_DeleteAdminAccount_ReturnFalse(string userName, string passWord, bool expected)
        {
            var admin = new Admin("Sammy", "Wong", "admin1", "admin1234", 23000, "adminstrator", true);
            var actual = admin.Delete(userName, passWord);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow("davidberg", "david123", true)]

        public void DeleteTest_DeleteUserAccount_ReturnTrue(string userName, string passWord, bool expected)
        {
            var admin = new Admin("Sammy", "Wong", "admin1", "admin1234", 23000, "adminstrator", true);
            var user = new User("David", "Berg", "davidberg", "david123", 24000, "staff", false);

            var actual = admin.Delete(userName, passWord);
            Assert.AreEqual(expected, actual);
        }

    }
}