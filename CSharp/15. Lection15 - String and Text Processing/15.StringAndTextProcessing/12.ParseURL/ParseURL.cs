using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

class ParseURL
{
    static void Main()
    {
        string url = @"http://www.devbg.org/forum/index.php";
        string protocol = FindProtocol(url);
        string server = FindServer(url);
        int indexOfResource = protocol.Length + server.Length + 3;
        string resource = url.Substring(indexOfResource);
        Console.WriteLine("[protocol] = {0}", protocol);
        Console.WriteLine("[server] = {0}", server);
        Console.WriteLine("[resource] = {0}", resource);
    }

    static string FindProtocol(string url)
    {
        string pattern = @"(?<protocol>\S+\b://)";
        Match res = Regex.Match(url, pattern);
        string protocol = res.Value;
        protocol = protocol.TrimEnd('/', ':');
        return protocol;
    }

    static string FindServer(string url)
    {
        string pattern = @"\b://\w*\.*\w+\.\w+\b/";
        Match res = Regex.Match(url, pattern);
        string server = res.Value;
        server = server.Trim('/', ':');
        return server;
    }

}
