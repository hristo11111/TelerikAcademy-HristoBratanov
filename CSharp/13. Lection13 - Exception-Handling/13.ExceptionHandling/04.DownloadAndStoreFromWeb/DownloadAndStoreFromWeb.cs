using System;
using System.Net;

class DownloadAndStoreFromWeb
{
    static void Main()
    {
        try
        {
            WebClient webClient = new WebClient();
            webClient.DownloadFile("http://www.devbg.org/img/Logo-BASD.jpg", @"logo-BASD.jpg");
        }
        catch (WebException)
        {
            Console.WriteLine("The URI is invalid");
            Console.WriteLine("-or-");
            Console.WriteLine("filename is null ot Empty");
            Console.WriteLine("-or-");
            Console.WriteLine("The file does not exist");
            Console.WriteLine("-or-");
            Console.WriteLine("An error occured while downloading data");
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("The address parameter is null");
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("The method has been called simultaneously on multiple threads");
        }
        finally
        {
            Console.WriteLine("Exit.");
        }
    }
}
