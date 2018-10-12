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
    public class ToAddFolder
    {
        static void Main(string[] args)
        {
            string UserName = "rajesh.yalamarthi@acuvate.com";
            Console.WriteLine("Enter Your Password");

            SecureString password = GetPassword();
     


            ClientContext clientContext = new ClientContext("https://acuvatehyd.sharepoint.com/teams/Info");
            clientContext.Credentials = new SharePointOnlineCredentials(UserName, password);
            Web web = clientContext.Web;
            //***********************create folder*****************
            //List list = clientContext.Web.Lists.GetByTitle("rajeshDocument");
            //var Folder = list.RootFolder;
            //clientContext.Load(Folder);
            //clientContext.ExecuteQuery();
            //Folder = Folder.Folders.Add("Rajesh2");
            //clientContext.ExecuteQuery();

            //**************************Delete folder**************
            List list = clientContext.Web.Lists.GetByTitle("rajeshDocument");


            //Folder f = web.GetFolderByServerRelativeUrl("/rajeshDocument/Rajesh2");
            Folder f = web.GetFolderByServerRelativeUrl(Path.Combine("rajeshDocument/Rajesh/"));
            //Folder folder = web.GetFolderByServerRelativeUrl("Rajesh2");
            clientContext.Load(clientContext.Web);
            clientContext.Load(list);
            //clientContext.Load(f);
            f.DeleteObject();
            clientContext.ExecuteQuery();

            


            //clientContext.Load(list);


            //Folder folder1 = list.RootFolder.Folders.;
            //clientContext.Load(folder1);

            //clientContext.ExecuteQuery();

            //FolderCollection folders2 = folder1.Folders;
            //clientContext.Load(folders2);

            ////FileCollection files = folder.Files;
            ////clientContext.Load(files);
            ////clientContext.ExecuteQuery();

            //Folder f = folders2[2];/*("https://acuvatehyd.sharepoint.com/teams/Info/rajeshDocument/Rajesh2")*/;
            //f.DeleteObject();
         
        
            Console.WriteLine("Folder deleted Successfully");
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
