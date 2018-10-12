using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Sharepoint10_08_2018
{
    public class ToUploadFile
    {
        static void Main(string[] args)
        {
            string UserName = "rajesh.yalamarthi@acuvate.com";
            Console.WriteLine("Enter Your Password");

            SecureString password = GetPassword();
            ClientContext clientContext = new ClientContext("https://acuvatehyd.sharepoint.com/teams/Info");
            clientContext.Credentials = new SharePointOnlineCredentials(UserName, password);
            Web web = clientContext.Web;
            var newfile = @"D:/My Code/SharePoint/SharePointPractice/Sharepoint10-08-2018/Information.txt";
            //newfile.Url = "Information";

            FileCreationInformation fileCreation = new FileCreationInformation
            {
                Content = System.IO.File.ReadAllBytes(newfile),
                Overwrite = true,
                Url = Path.Combine("rajeshDocument/Rajesh/", Path.GetFileName(newfile))


        };

            //var docs = web.Lists.GetByTitle("rajeshDocument");
            //var subfolder = docs.RootFolder.Folders.Where(folder => folder.Name == "Rajesh");
            var list = clientContext.Web.Lists.GetByTitle("rajeshDocument");
            var uploadFile = list.RootFolder.Files.Add(fileCreation);

            clientContext.Load(uploadFile);
            clientContext.ExecuteQuery();
            Console.WriteLine("Uploaded Successfully");
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
