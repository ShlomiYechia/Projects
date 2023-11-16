using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectV3
{
    public class SocialNet
    {
        Graph<Users> graph = new Graph<Users>();
        Dictionary<Birthday, List<Users>> BDays = new Dictionary<Birthday, List<Users>>();
        public void addUser(Users user)
        {
            graph.addVertex(user);
            Birthday bday = new Birthday(user.Bday);
            if (BDays.ContainsKey(bday))
                BDays[bday].Add(user);
            else
                BDays.Add(bday, new List<Users>() { user });
        }
        public void AddInterests(Users user, Interests i)
        {
            if (user.MyInterests == 0)
                user.MyInterests &= ~Interests.None;

            user.MyInterests |= i;
        }
        public void RemoveInterests(Users user, Interests i)
        {
            user.MyInterests &= ~i;
            if (user.MyInterests == 0)
                user.MyInterests |= Interests.None;
        }
        public void addFriend(Users user,Users friends)
        {
            graph.addEdge(user, friends);
        }
        public List<Users> ListOfFriends(Users user)
        {
            return graph.getNeigbours(user);
        }
        public List<Users> FriendsOfFreinds(Users user)
        {
            List<Users> friends = new List<Users>();
            List<Users> UserFreinds = ListOfFriends(user);
            foreach (Users item in UserFreinds)
            {
                foreach (Users var in ListOfFriends(item))
                {
                    if(var!= user && !friends.Contains(var) && !UserFreinds.Contains(var))
                        friends.Add(var);
                }
            }
            return friends; 
        }
        public List<Users> birthday()
        {

            Birthday bday = new Birthday(DateTime.Now);
            if(BDays.ContainsKey(bday))
                return BDays[bday];
            return new List<Users>();
        }
        public Users info(string name)
        {
            foreach (Users item in graph.GetVertex())
            {
                if (name == item.UserName)
                    return item;
            }
            throw new VertexNotExistException();
        }
       
        public List<Post>Postdate(Users user,DateTime date1,DateTime date2)
        {
            SortedSet<Post> subset = user.Posts.GetViewBetween(new Post("", date1), new Post("", date2));
            return subset.ToList();
        }
        public void addPost(Users user,Post post)
        {
            if(post!= null && graph.Contains(user) && !user.Posts.Contains(post))
            {
                user.AddPost(post);
            }
        }
    }
}
