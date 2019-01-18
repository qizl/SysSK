using System.IO;

namespace EnjoyCodes.SysSK.Models
{
    public class CmdControl
    {
        /// <summary>
        /// 新建命令文件
        /// </summary>
        /// <param name="cmd">命令（文件）名称，快捷键</param>
        /// <param name="appPath">命令指向应用路径</param>
        /// <param name="cmdsFolder">命令文件保存路径</param>
        /// <returns></returns>
        public bool CreateCmd(Cmd cmd, string cmdsFolder)
        {
            try
            {
                var fileName = Path.Combine(cmdsFolder, cmd.ShortKey + ".bat");
                if (cmd.Type == AppTypes.App)
                {
                    FileInfo file = new FileInfo(cmd.Location);
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
                else if (cmd.Type == AppTypes.Cmd)
                {
                    using (StreamWriter stream = new StreamWriter(fileName, false))
                    {
                        stream.WriteLine("@echo off");
                        stream.WriteLine(cmd.Name);
                        stream.Flush();
                        stream.Close();
                    }
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
        public bool RemoveCmd(Cmd cmd, string cmdsFolder)
        {
            try
            {
                var fileName = Path.Combine(cmdsFolder, cmd.ShortKey + ".bat");
                if (File.Exists(fileName))
                    File.Delete(fileName);
            }
            catch { return false; }

            return true;
        }

        /// <summary>
        /// 移除所有命令文件
        /// </summary>
        /// <param name="cmdsFolder"></param>
        /// <returns></returns>
        public bool RemoveAll(string cmdsFolder)
        {
            FileInfo[] files = new DirectoryInfo(cmdsFolder).GetFiles();
            foreach (var item in files)
                if (item.Extension == ".bat")
                    File.Delete(item.FullName);

            return true;
        }
    }
}
