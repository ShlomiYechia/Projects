using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV3
{
    [Flags]
    public enum Interests
    {
        None = 0, Music = 1, Cooking = 2, Art = 4, Sports = 8, Photography = 16, Investing = 32,
        Reading = 64, Writing = 128, Traveling = 256, Gaming = 512, Dancing = 1024, Gardening = 2048, Fashion = 4096,
        Technology = 8192, Fitness = 16384
    }
    public class Users
    {
        SortedSet<Post> posts = new SortedSet<Post>(new PostComparer());
        public SortedSet<Post> Posts { get { return posts; } }
        public string UserName { get; set; }
        public DateTime Bday { get; set; }
        public Interests MyInterests { get; set; }
        public int Age
        {
            get
            {
                TimeSpan age = DateTime.Now - Bday;
                int years = (int)(age.TotalDays / 365.25);
                return years;
            }
        }
        public Users(string name,DateTime bday,Interests inter)
        {
            UserName = name;
            Bday = bday;
            MyInterests = inter;
        }
        public void AddPost(Post p)
        {
            if (p != null && !Posts.Contains(p))
                posts.Add(p);
        }
        public void AddPost(string info)
        {
            if (info != null)
            {
                Post p = new Post(info, DateTime.Now);
                AddPost(p);
            }
        }
        public void RemovePost(Post p)
        {
            if (p != null && Posts.Contains(p))
                posts.Remove(p);
        }

        public override string ToString()
        {
            return $"Name: {UserName}\nBirthDay: {Bday}\nInterest: {MyInterests}\n";
        }

    }
}
