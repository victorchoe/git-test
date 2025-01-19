using System.Configuration;

namespace EconChart.Util
{
    public class Config
    {
        public static readonly string connectionString = ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString;
    }
}
