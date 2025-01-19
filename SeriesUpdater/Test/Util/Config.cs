using System.Configuration;

namespace Test.Util
{
    public class Config
    {
        //public const string fredKey = "2663b8d59144b89099b15cac8952d69e";
        //public const string ecosKey = "ZZFMSCRGD24H9X50HMCP";
        public static readonly string fredKey = ConfigurationManager.AppSettings["fredKey"];
        public static readonly string ecosKey = ConfigurationManager.AppSettings["ecosKey"];
        public static readonly string connectionString = ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString;

    }
}
