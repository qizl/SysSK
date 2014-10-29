using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SysSK.Models
{
    public class Cmds
    {
        /// <summary>
        /// 新建命令文件
        /// </summary>
        /// <param name="cmd">命令（文件）名称，快捷键</param>
        /// <param name="appPath">命令指向应用路径</param>
        /// <param name="cmdsFolder">命令文件保存路径</param>
        /// <returns></returns>
        public bool CreateCmd(string cmd, string appPath, string cmdsFolder)
        {
            try
            {
                string fileName = Path.Combine(cmdsFolder, cmd + ".bat");
                FileInfo file = new FileInfo(appPath);
                if (!Directory.Exists(cmdsFolder))
                    Directory.CreateDirectory(cmdsFolder);

                using (StreamWriter stream = new StreamWriter(fileName, false))
                {
                    stream.WriteLine("@echo off");
                    stream.WriteLine(file.Directory.Root.ToString().Substring(0, 2));
                    stream.WriteLine("cd \"" + file.DirectoryName + "\"");
                    stream.WriteLine("start " + file.Name);
                    stream.Flush();
                    stream.Close();
                }
            }
            catch { return false; }

            return true;
        }

        /// <summary>
        /// 删除命令文件
        /// </summary>
        /// <param name="cmd">命令（文件）名称，快捷键</param>
        /// <param name="cmdsFolder">命令文件保存路径</param>
        /// <returns></returns>
        public bool RemoveCmd(string cmd, string cmdsFolder)
        {
            string fileName = Path.Combine(cmdsFolder, cmd + ".bat");
            try
            {
                if (File.Exists(fileName))
                    File.Delete(fileName);
            }
            catch { return false; }

            return true;
        }
    }
}
