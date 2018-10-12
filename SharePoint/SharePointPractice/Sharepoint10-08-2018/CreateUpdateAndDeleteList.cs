using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;


namespace Sharepoint10_08_2018
{
  public class CreateUpdateAndDeleteList
    {
        static void Main(string[] args)
        {
            string UserName = "rajesh.yalamarthi@acuvate.com";
            Console.WriteLine("Enter Your Password");


            SecureString password = GetPassword();

          
            ClientContext context = new ClientContext("https://acuvatehyd.sharepoint.com/teams/Info");
            context.Credentials = new SharePointOnlineCredentials(UserName, password);
            Web oWebsite = context.Web;

            //****************List Creation*************************//
            //ListCreationInformation listCreationInformation = new ListCreationInformation();
            //listCreationInformation.Title = "ListViaCsom";
            //listCreationInformation.TemplateType = (int)ListTemplateType.Announcements;

            //List list = oWebsite.Lists.Add(listCreationInformation);
            //********************************************************//


            // ***********************adding fields to the list***********************
            context.Load(oWebsite);
            List list = context.Web.Lists.GetByTitle("BackendTest");

            string field = "<Field Type='Text' DisplayName = 'Silicon' Name='Silicon'/>";
            FieldCollection fields = list.Fields;
            fields.AddFieldAsXml(field, true, AddFieldOptions.AddToDefaultContentType);
            //ListItem listItem= list.AddItem()
            //list.Fields.AddFieldAsXml("<Field Name='Decoy' DisplayName='Decoy' type='text' Required='FALSE'></Field>", true, AddFieldOptions.DefaultValue);

            //FieldNumber fieldNumber = context.CastTo<FieldNumber>(field);
            //fieldNumber.MaximumValue = 100;
            //fieldNumber.MinimumValue = 35;


            

            context.ExecuteQuery();
            Console.WriteLine("ListCreated Go and check");

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
