using System;
using System.Collections.Generic;
using System.Text;
using System.Net;


class autoupdater
{    

    public static int GetLatestVersion()
    {
        //let us screenscrape the Google Site.
        WebClient wc = new WebClient ();
        byte [] pageData = wc.DownloadData ("http://code.google.com/p/skimpt");
        string pageHtml = System.Text.Encoding.ASCII.GetString(pageData);

        string ver;
        ver = pageHtml.Substring (pageHtml.IndexOf ("!!ver:"));
        ver = ver.Substring (6);
        ver = ver.Remove(ver.IndexOf("!!"));
     
        return Convert.ToInt32(ver);
    }
}

