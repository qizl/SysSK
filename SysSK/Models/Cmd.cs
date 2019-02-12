namespace EnjoyCodes.SysSK.Models
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
        /// <summary>
        /// 是否需要以管理员权限运行
        /// </summary>
        public bool RequireAdmin { get; set; }
        public string ShortKey { get; set; }
        public string Remark { get; set; }
    }
}
