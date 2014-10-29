using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SysSK.Models
{
    public enum AppTypes
    {
        App,
        Cmd
    }

    public class Cmd
    {
        public string Name { get; set; }
        public AppTypes Type { get; set; }
        public string Location { get; set; }
        public string ShortKey { get; set; }
        public string Remark { get; set; }
    }
}
