using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ConnectionString
/// </summary>
public class ConnectionString
{
		
		private static string text =
        @"Data Source=(LocalDB)\v11.0;
        AttachDbFilename=|DataDirectory|\RandonneurDatabase.mdf;
        Integrated Security=True;Connect Timeout=30";

    public static string Text
    {
       get { return text; }
    }
	
}