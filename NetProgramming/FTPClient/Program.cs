using System.Net;

bool DisplayFileFromServer(Uri serverUri)
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



Console.WriteLine("Hello, World!");
