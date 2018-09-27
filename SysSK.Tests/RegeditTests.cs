using EnjoyCodes.SysSK.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace EnjoyCodes.SysSK.Tests
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

        [TestMethod]
        public void AddSystemEnvironmentVariable_Path()
        {
            return;
            string[] vars = new string[] { @"D:\PL\Cygwin\bin", @"D:\PL\Cygwin\sbin" };

            Regedit regedit = new Regedit();
            bool b = true;
            foreach (var item in vars)
                b &= regedit.AddSystemEnvironmentVariable_Path(item);
            Assert.IsTrue(b);
        }
    }
}
