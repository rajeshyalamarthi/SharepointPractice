using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharepoint10_08_2018
{
  public  class Website
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the password");
            Credentials credentials = new Credentials();

            using (ClientContext clientContext = new ClientContext("https://acuvatehyd.sharepoint.com/teams/Info"))
            {
                clientContext.Credentials = new SharePointOnlineCredentials(credentials.UserName, credentials.password);
            }
        }

        public static void CreateWebSite(ClientContext clientContext)
        {
            Web web = clientContext.Web;
            string blogDescription = "A new blog Web site.";
            int blogLanguage = 1033;
            string blogTitle = "backend";
           
            string webTemplate = "BLOG#0";
           
            WebCreationInformation webCreationInformation = new WebCreationInformation();
            webCreationInformation.Description = blogDescription;
            webCreationInformation.Title = blogTitle;
            webCreationInformation.Language = blogLanguage;
            webCreationInformation.WebTemplate = webTemplate;

            Web website = web.Webs.Add(webCreationInformation);
            clientContext.Load(website,
                website1 => website1.ServerRelativeUrl,
                website2 => website2.Created
                );


            clientContext.ExecuteQuery();

            Console.WriteLine("ServerRelativeurl:{0}  Created:{1}",website.ServerRelativeUrl,website.Created);


           
        }


    }
}
