using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SysSK.Models
{
    public class Common
    {
        public static Config Config { get; set; }
        public static string ConfigPath = Path.Combine(Environment.CurrentDirectory, "Config.xml");

        public static Config DefaultConfig = new Models.Config()
        {
            IsEnabled = true,
            CanRemoveCurrentFolder = true,
            ShortKeys = new List<App>(),
            ShortKeysFolder = Path.Combine(Environment.CurrentDirectory, "bat"),
            CreateTime = DateTime.Now,
            UpdateTime = DateTime.Now
        };
    }
}
