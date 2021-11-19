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

        public void CreateUserTest(string fname, string lname, string uname, string pass, string role, int salary, bool isAdmin, int expected)
        {
            Admin newAdmin = new();
            var actual = newAdmin.CreateUser(fname, lname, uname, pass, role, salary, isAdmin);
            Assert.AreNotEqual(actual, expected);
        }

        [TestMethod()]
        [DataRow("samwon", "123abc", false)]
        [DataRow("farzanezafar", "password", true)]
        [DataRow(null, "password", false)]
        [DataRow("farzanezafar", null, false)]

        public void DeleteTest(string userName, string passWord, bool expected)
        {
            var admin = new Admin( "Sammy", "Wong", "samwon", "123abc", 23000, "staff", true);
            var actual = admin.Delete(userName, passWord);
            Assert.AreEqual(expected, actual);
        }
    }
}