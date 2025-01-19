using System;
using System.Text;
using System.Net;

namespace SeriesUpdater.Util
{
    public class DownloadData
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static string GetDownloadString(string url)
        {            
            string myData = string.Empty;
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;

            try {
                log.Info("Download Start for URL : " + url);
                myData = client.DownloadString(System.Uri.EscapeUriString(url));
                //log.Info("Download End : " + url);
            } catch (WebException we) {
                myData = string.Empty;
                log.Error("Downloading Error : ",we);
            } finally {
                client.Dispose();
            }
            return myData;            
        }
    }
}
