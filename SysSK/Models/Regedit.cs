using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SysSK.Models
{
    public class Regedit
    {
        /// <summary>
        /// 获取注册表中的应用列表
        /// </summary>
        /// <returns></returns>
        public List<App> ReadApps()
        {
            List<App> apps = new List<App>();

            string appKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths";
            //string appKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(appKey))
            {
                foreach (string skName in rk.GetSubKeyNames())
                {
                    using (RegistryKey sk = rk.OpenSubKey(skName))
                    {
                        App app = new App() { Name = skName, Location = sk.GetValue("").ToString() };
                        apps.Add(app);
                    }
                }
            }

            return apps;
        }

        /// <summary>
        /// 将命令文件夹路径添加到系统环境变量Path中
        /// </summary>
        /// <param name="value">命令文件保存路径</param>
        /// <returns></returns>
        public bool AddSystemEnvironmentVariable_Path(string value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 将命令文件夹路径从系统环境变量Path中移除
        /// </summary>
        /// <param name="value">命令文件保存路径</param>
        /// <returns></returns>
        public bool RemoveSystemEnvironmentVariable_Path(string value)
        {
            throw new NotImplementedException();
        }
    }
}
