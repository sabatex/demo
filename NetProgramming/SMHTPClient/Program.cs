using System;
using System.IO;
using System.Net;

namespace SMHTPClient
{
    class Program
    {
        public static bool DisplayFileFromServer(Uri serverUri)
        {
            // The serverUri parameter should start with the ftp:// scheme.
            if (serverUri.Scheme != Uri.UriSchemeFtp)
            {
                return false;
            }
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(serverUri);

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential("anonymous", "");
            request.Method = WebRequestMethods.Ftp.ListDirectory;
            try
            {
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                var str = response.GetResponseStream();
                var sr = new StreamReader(str);
                var s = sr.ReadToEnd();
                

                //byte[] newFileData = request.DownloadData(serverUri.ToString());
                //string fileString = System.Text.Encoding.UTF8.GetString();
                //Console.WriteLine(fileString);
            }
            catch (WebException e)
            {
                Console.WriteLine(e.ToString());
            }
            return true;
        }

        static void Main(string[] args)
        {



            var uri = new UriBuilder();
            uri.Host = "ftp.etersoft.ru";
            uri.Scheme = "ftp";
            //uri.UserName = "anonymous";

            DisplayFileFromServer(uri.Uri);


            Console.ReadKey();
        }
    }
}
