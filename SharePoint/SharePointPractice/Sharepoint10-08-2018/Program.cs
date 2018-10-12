﻿using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Sharepoint10_08_2018
{
    public class Program
    {
        static void Main(string[] args)
        {
            string UserName = "rajesh.yalamarthi@acuvate.com";
            Console.WriteLine("Enter Your Password");
            SecureString password = GetPassword();


            using ( var ClientContext =new ClientContext("https://acuvatehyd.sharepoint.com/teams/Info"))
            {
                ClientContext.Credentials = new SharePointOnlineCredentials(UserName, password);
                Web webobj = ClientContext.Web;
                ClientContext.Load(webobj);
                ClientContext.ExecuteQuery();
                Console.WriteLine("Title :" + webobj.Title);
                Console.WriteLine("SiteUrl:"+webobj.Url);
                Console.WriteLine("siteUsers:" +webobj.SiteGroups);
                Console.WriteLine( "User"+ webobj.CurrentUser);

                Console.ReadLine();

            }

        }
        private static SecureString GetPassword()
        {
            ConsoleKeyInfo info;
            //Get the user's password as a SecureString  
            SecureString securePassword = new SecureString();
            do
            {
                info = Console.ReadKey(true);
                if (info.Key != ConsoleKey.Enter)
                {
                    securePassword.AppendChar(info.KeyChar);
                }
            }
            while (info.Key != ConsoleKey.Enter);
            return securePassword;
        }
    }

}

