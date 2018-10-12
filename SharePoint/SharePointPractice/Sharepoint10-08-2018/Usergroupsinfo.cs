using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharepoint10_08_2018
{
    public class Usergroupsinfo
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the Password");
            Credentials credentials = new Credentials();

            using (ClientContext clientContext = new ClientContext("https://acuvatehyd.sharepoint.com/teams/Info"))
            {

                clientContext.Credentials = new SharePointOnlineCredentials(credentials.UserName, credentials.password);
                //GetAllUsers(clientContext);
                 AddUser(clientContext);
                //GetAllUsergroups(clientContext);



            }

        }

        public static void GetAllUsers(ClientContext clientContext)
        {
            GroupCollection collgroups = clientContext.Web.SiteGroups;
            Group group = collgroups.GetByName("FreshersNew");
            UserCollection users = group.Users;
            clientContext.Load(users);
            clientContext.ExecuteQuery();

            foreach(User user in users)
            {
                Console.WriteLine("USER:{0}\n  LOGINNAME:{1}\n  USerTitle{2}\n",user.Title,user.LoginName,user.Email);
            }

            Console.ReadLine();

        }

        public static void AddUser(ClientContext clientContext)
        {
            Web web = clientContext.Web;

            //User user=web.
            User users = web.EnsureUser("pratik.mishra@acuvate.com");
            users.Title = "Software Engineer-Trainee";
            
            //GroupCollection groupscoll = clientContext.Web.SiteGroups;
            Group group = web.SiteGroups.GetByName("FreshersNew");
            //Group group = groupscoll.GetByName("FreshersNew");
            group.Users.AddUser(users);
            

            //UserCreationInformation userCreationInformation = new UserCreationInformation();
            //userCreationInformation.Title = "Harsha Poosarla";
            //userCreationInformation.LoginName = "harsha.poosarla@acuvate.com";
            //userCreationInformation.Email = "harsha.poosarla@acuvate.com";

            //User user = group.Users.Add(userCreationInformation);
           
           //clientContext.Load(user);
            clientContext.ExecuteQuery();

            Console.WriteLine("Added");
            Console.ReadLine();

        }


        public static void GetAllUsergroups(ClientContext clientContext )
        {
            GroupCollection groupscoll = clientContext.Web.SiteGroups;
            clientContext.Load(groupscoll);
            clientContext.Load(groupscoll,
                groups => groups.Include(
                    group => group.Users));

            clientContext.ExecuteQuery();

            foreach(Group group in groupscoll)
            {
                UserCollection users = group.Users;
                foreach(User user in users)
                {
                    Console.WriteLine("groupId:{0}   GroupTitle:{1}  UserTitle:{2}",group.Id,group.Title,user.Title);

                    Console.ReadLine();
                }
            }



        }



    }
}
