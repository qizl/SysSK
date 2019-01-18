using System.Diagnostics;
using System.Linq;

namespace EnjoyCodes.RunAsAministrator
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args?.Length > 0)
                Process.Start(args.First(), string.Join(" ", args.Skip(1)));
        }
    }
}
