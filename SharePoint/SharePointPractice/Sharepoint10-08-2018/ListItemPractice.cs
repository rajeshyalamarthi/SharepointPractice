using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Sharepoint10_08_2018
{
    public class ListItemPractice
    {
        public static void Main(string[] args)
        {
            //string UserName = "rajesh.yalamarthi@acuvate.com";
            Console.WriteLine("Enter Your Password");
            Credentials credentials = new Credentials();

            /* SecureString password = GetPassword();*/
            using (ClientContext clientContext = new ClientContext("https://acuvatehyd.sharepoint.com/teams/Info"))
            {

                clientContext.Credentials = new SharePointOnlineCredentials(credentials.UserName, credentials.password);

                //GetListitems(clientContext);
                //Additems(clientContext);
                //DeleteListitem(clientContext);
                UpdatelistItem(clientContext);
            }
        }
        
           public static void GetListitems(ClientContext context)
            {
              
                List list = context.Web.Lists.GetByTitle("Players");
                CamlQuery camlQuery = new CamlQuery();

                camlQuery.ViewXml = "<View><FieldRef Name='PlayerName'/>" +
                                           "<filedRef Name='Belongs To Team'/>" +
                                           "</View>";
                ListItemCollection listItems = list.GetItems(camlQuery);
                 context.Load(listItems);
            context.ExecuteQuery();
  
            context.Load(listItems,
                    items => items.Include(
                        item => item["ID"],
                        item => item["Title"]
                     
                        ));
            context.ExecuteQuery();

                foreach (ListItem lists in listItems)
                {
                    //dataTable.Rows.Add(lists.Id, lists["PlayerName"], lists["Belongs To team"]);
                    Console.WriteLine("ID: {0} \nPlayer name: {1}\nBelongstoTeam ", lists["ID"], lists["Title"]);
                }
                Console.ReadLine();



            }


        public static void Additems(ClientContext clientContext)
        {
            List list = clientContext.Web.Lists.GetByTitle("BackendTest");
            ListItemCreationInformation creationInformation = new ListItemCreationInformation();
            ListItem listItem = list.AddItem(creationInformation);
            listItem["Title"] = "rajeshyyy";
            listItem["Info"] = "chowdaryyy";
            listItem["Extra"] = "acuvatyyye";
            //listItem["Address"] = "hyderabad";

            //listItem["Description"] = "tested";

            try
            {
                listItem.Update();
                clientContext.ExecuteQuery();
                Console.WriteLine("inserted");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine()  ;


        }

        public static void DeleteListitem( ClientContext clientContext)
        {
            List list = clientContext.Web.Lists.GetByTitle("BackendTest");
            ListItem listItem = list.GetItemById(2);
            listItem.DeleteObject();
            clientContext.ExecuteQuery();

        }

        public static void UpdatelistItem(ClientContext clientContext)
        {
            List list = clientContext.Web.Lists.GetByTitle("BackendTest");
            ListItem listItem = list.GetItemById(1);
            listItem["Title"] = "yyy";
            //listItem["Info"] = "yyy";
            //listItem["Extra"] = "yyye";
            listItem.Update();
            clientContext.ExecuteQuery();
            Console.WriteLine("Updated");
            Console.ReadLine();
        }

        }









    }