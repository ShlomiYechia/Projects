using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV3
{
    class PostComparer : IComparer<Post>
    {
        public int Compare(Post x, Post y)
        {
            return x.infoDate.CompareTo(y.infoDate);
        }
    }

    public class Post
    {
        public string _info { get; set; }
        public DateTime infoDate { get; set; }

        public Post(string info,DateTime time)
        {
            _info = info;
            infoDate = time;
        }
        public override string ToString()
        {
            return $"{_info}\n{infoDate}";
        }
    }
}
