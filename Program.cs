using System;
using System.Collections.Generic;
using System.Globalization;

namespace ProjectV3
{
    public class Program
    {

        static void Main(string[] args)
        {
            SocialNet SN = new SocialNet();
            Users a = new Users("Yuval", new DateTime(2000, 10, 30), Interests.Music | Interests.Art | Interests.Investing);
            Users b = new Users("Shir", new DateTime(2002, 07, 30), Interests.Music | Interests.Art);
            Users c = new Users("Idan", new DateTime(1999, 03, 16), Interests.Sports | Interests.Cooking | Interests.Investing);
            Users d = new Users("Ido", new DateTime(1998, 03, 23), Interests.Sports | Interests.Art);
            Users e = new Users("Shlomi", new DateTime(2001, 10, 30), Interests.Photography | Interests.Music);
            Users f = new Users("Ran", new DateTime(2002, 03, 23), Interests.Investing | Interests.Cooking);
            SN.addUser(a);
            SN.addUser(b);
            SN.addUser(c);
            SN.addUser(d);
            SN.addUser(e);
            SN.addUser(f);
            Post p1 = new Post("sadfsd", new DateTime(2020, 10, 20));
            Post p2 = new Post("sadfsd", new DateTime(2021, 11, 20));
            Post p3 = new Post("sadfsd", new DateTime(2019, 12, 20));
            Post p4 = new Post("sadfsd", new DateTime(2022, 01, 20));
            Post p6 = new Post("sa432dfsd", new DateTime(2023, 01, 20));
            Post p5 = new Post("sadfsd", new DateTime(2023, 03, 16));
            Post p7 = new Post("sadfsd", new DateTime(2022, 05, 20));
            Post p8 = new Post("sadfsd", new DateTime(2022, 06, 20));

            SN.addPost(a, p1);
            SN.addPost(a, p2);
            SN.addPost(b, p3);
            SN.addPost(c, p4);
            SN.addPost(b, p5);
            SN.addPost(d, p6);
            SN.addPost(f, p7);
            SN.addPost(e, p8);
            SN.addFriend(a, b);
            SN.addFriend(a, c);
            SN.addFriend(a, d);
            SN.addFriend(a, f);
            SN.addFriend(a, e);
            SN.addFriend(b, e);
            SN.addFriend(f, e);
            SN.addFriend(d, c);
            SN.addFriend(d, e);
            Start(SN);
        }
        static void Start(SocialNet S)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. New User\n2. Login\n3. Manager\n4. Quit");
                switch (Console.ReadLine())
                {
                    case "1":
                        AddNew(S);
                        break;
                    case "2":
                        Login(S);
                        break;
                    case "3":
                        Manager(S);
                        break;
                    case "4":
                        return;

                }
            }
        }
        void DELETEFUNC()
        {
            Console.WriteLine("Name:");
            string name;
            name = Console.ReadLine();
            Console.WriteLine("Please enter your birthday (MM/DD/YYYY):");
            string birthdayString = Console.ReadLine();
            DateTime birthday = DateTime.ParseExact(birthdayString, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            Console.WriteLine("Interests:");
            foreach (string item in Enum.GetNames(typeof(Interests)))
            {
                Console.WriteLine(item + " ");
            }
            string input = Console.ReadLine();
            Interests userInter;
            Enum.TryParse(input, out userInter);
            // u1 = new Users(name, birthday, userInter);
        }

        static void AddNew(SocialNet S)
        {
            Console.Clear();
            string name;
            Console.WriteLine("Enter Your name: ");
            while (true)
            {
                name = Console.ReadLine();
                try
                {
                    S.info(name);
                    Console.WriteLine("User already exist");
                }
                catch (Exception)
                {
                    break;
                }
            }
            Console.WriteLine("Please enter your birthday (MM/DD/YYYY):");
            string birthdayString;
            DateTime birthday;
            while (true)
            {
                try
                {
                     birthdayString = Console.ReadLine();
                    birthday = DateTime.ParseExact(birthdayString, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid date");
                }
            }
            Console.Clear();
            Console.WriteLine("Interests:");
            foreach (string item in Enum.GetNames(typeof(Interests)))
            {
                Console.WriteLine(item + " ");
            }
            string input;
            Interests userInter = Interests.None;
            Console.WriteLine("If you dont want to add more Write STOP");
            while (true)
            {
                try
                {
                    input = Console.ReadLine();
                    if(input.ToLower() == "stop")
                        break;
                   
                    Enum.TryParse(input, out Interests inter);
                    userInter |= inter;
                }
                catch (Exception)
                {

                    Console.WriteLine("Enter a valid intersets from the list");
                }
            }
            Users u1 = new Users(name, birthday, userInter);
            S.addUser(u1);
            UserMenu(S, u1);
        }
        static void Login(SocialNet S)
        {
            Console.Clear();
            string name;
            Console.WriteLine("Enter Your name: ");
            Users u1;
            while (true)
            {
                name = Console.ReadLine();
                try
                {
                    u1 = S.info(name);
                    UserMenu(S, u1);
                }
                catch (Exception)
                {
                    Console.WriteLine("User Not exist");
                    
                }
            }
        }
        static void UserMenu(SocialNet S, Users u1)
        {
           
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Welcome {u1.UserName}");
                Console.WriteLine("1. Add interests\n2. Add friend\n3. Show friends\n4. People you may know\n5. Info\n6. Add Post\n7. Exit to menu");
                switch (Console.ReadLine())
                {
                    case "1":
                        AddInterests(S, u1);
                        break;
                    case "2":
                        AddFriend(S, u1);
                        break;
                    case "3":
                        ShowFriends(S, u1);
                        break;
                    case "4":
                        MayKnow(S, u1);
                        break;
                    case "5":
                        UserInfo(S, u1);
                        break;
                    case "6":
                        Addpost(S, u1);
                        break;
                    case "7":
                        Start(S);
                        break;
                }
            }

        }
        static void AddInterests(SocialNet S, Users u1)
        {
            Console.Clear();
            Console.WriteLine("Interests:");
            foreach (string item in Enum.GetNames(typeof(Interests)))
            {
                Console.WriteLine(item + " ");
            }
            string input;
            Console.WriteLine("If you dont want to add more Write STOP");
            while (true)
            {
                try
                {
                    input = Console.ReadLine();
                    if (input.ToLower() == "stop")
                        break;

                    Interests intres = (Interests)Enum.Parse(typeof(Interests), input);
                    u1.MyInterests |= intres;
                }
                catch (Exception)
                {

                    Console.WriteLine("Enter a valid intersets from the list");
                }
            }
        }
        static void AddFriend(SocialNet S, Users u1)
        {
            Console.Clear();
            string input;
            while (true)
            {
                Console.WriteLine("Enter a friend name you want to add");
                input = Console.ReadLine();
                try
                {
                    Users u2 = S.info(input);
                    S.addFriend(u1,u2);
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Name does not exist");
                }
            }
        }
        static void ShowFriends(SocialNet S,Users u1) 
        {
            Console.Clear();
          List<Users> list = S.ListOfFriends(u1);
            Console.WriteLine(string.Join(",",list));
            Console.ReadLine();
           
        }
        static void MayKnow(SocialNet S,Users u1)
        {
            Console.Clear();
            List<Users>List = S.FriendsOfFreinds(u1);
            Console.WriteLine(string.Join(",", List));
            Console.ReadLine();
        }
        static void UserInfo(SocialNet S,Users u1)
        {
            Console.Clear();
            Console.WriteLine(u1.ToString());
            Console.ReadLine();
        }
        static void Addpost(SocialNet S, Users u1)
        {
            Console.Clear();
            Console.WriteLine("Add your new post here: ");
            string userpost = Console.ReadLine();
            Post p1 = new Post(userpost,DateTime.Now);
            S.addPost(u1 ,p1);
            Console.WriteLine("Post added");
            Console.ReadLine();
        }
        static void Manager(SocialNet s)
        {

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome dear manager");
                Console.WriteLine("1. Today birthday list\n2. Show User info\n3. Show User Posts\n4. Back to manu");
                switch(Console.ReadLine())
                {
                    case "1":
                        Birthdaylist(s);
                        break;
                    case "2":
                        ShowUserInfo(s);
                        break;
                    case "3":
                        ShowUserPosts(s);
                        break;
                    case "4":
                        Start(s);
                        break;
                }
            }
        }
        static void Birthdaylist(SocialNet s)
        {
            List<Users> list = s.birthday();
            Console.WriteLine(string.Join(",", list));
            Console.ReadLine();
        }
        static void ShowUserInfo(SocialNet s)
        {
            Console.WriteLine("Enter User name: ");
            string userinfo = Console.ReadLine();
            try
            {
                Users u3 = s.info(userinfo);
                Console.WriteLine(u3.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("User name can not be found");
            }
            Console.ReadKey();
            
        }
        static void ShowUserPosts(SocialNet s)
        {
            string date2= "";
            DateTime end= default;
            string date1= "";
            DateTime start= default;
            string username = "";
            Users u1 = default;
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter user name:");
                    username = Console.ReadLine();
                    u1 = s.info(username);
                    break;
                }
                catch (Exception)
                {

                    Console.WriteLine("UserName can not be found");

                }
            }
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter first date (\"MM/dd/yyyy\")");
                    date1 = Console.ReadLine();
                    start = DateTime.ParseExact(date1, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    Console.WriteLine("Enter second date(\"MM/dd/yyyy\")");
                    date2 = Console.ReadLine();
                    end = DateTime.ParseExact(date2, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    break;
                }
                catch (Exception)
                {

                    Console.WriteLine("Date is not valid");
                }
            }
                
                List<Post> list = s.Postdate(u1, start, end);
                Console.WriteLine(string.Join(",", list));
                Console.ReadLine();
        }
    }

}
