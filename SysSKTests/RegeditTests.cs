using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SysSK.Models;
using System.IO;

namespace SysSKTests
{
    [TestClass]
    public class RegeditTests
    {
        [TestMethod]
        public void TestReadApps()
        {
            Regedit regedit = new Regedit();
            regedit.ReadApps();
        }

        [TestMethod]
        public void TestAddSystemEnvironmentVariable_Path()
        {
            Regedit regedit = new Regedit();
            regedit.AddSystemEnvironmentVariable_Path(Path.Combine(Environment.CurrentDirectory, "bat"));
        }

        [TestMethod]
        public void TestRemoveSystemEnvironmentVariable_Path()
        {
            Regedit regedit = new Regedit();
            regedit.RemoveSystemEnvironmentVariable_Path(Path.Combine(Environment.CurrentDirectory, "bat"));
        }
    }
}
