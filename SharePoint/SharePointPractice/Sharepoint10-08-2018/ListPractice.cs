using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

using SP=System.Collections.Generic;

namespace Sharepoint10_08_2018
{
   public class ListPractice
    {
        static void Main(string[] args)
        {
            string UserName = "rajesh.yalamarthi@acuvate.com";
            Console.WriteLine("Enter Your Password");
            SecureString password = GetPassword();


            ClientContext context = new ClientContext("https://acuvatehyd.sharepoint.com/teams/Info");
            Web oWebsite = context.Web;
            context.Credentials = new SharePointOnlineCredentials(UserName, password);

            //ListCollection Clist = oWebsite.Lists;
            //context.Load(oWebsite);
            
            //IEnumerable<SP.List> result = context.LoadQuery(Web.Lists.Include(list => list.Created,
            //                                                     list => list.Title,
            //                                                     list => list.Id));

            context.Load(oWebsite.Lists, lists => lists.Include(list => list.Created,
                                                                  list => list.Title,
                                                                  list => list.Id,
                                                                  list => list.ItemCount));

            context.ExecuteQuery();

            foreach (List list in oWebsite.Lists)
                {

                Console.WriteLine(list.Created);
                Console.WriteLine(list.Title);
                Console.WriteLine(list.ItemCount);
                }

                Console.ReadLine();

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


