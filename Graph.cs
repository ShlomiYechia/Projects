using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV3
{
    internal class Graph <T>
    {
        Dictionary<T,List<T>> _graph = new Dictionary<T, List<T>>();
        public void addVertex(T vertex)
        {
            if (vertex == null) throw new ArgumentNullException();
            if (_graph.ContainsKey(vertex)) throw new VertexExistException();//Func
            _graph.Add(vertex, new List<T>());
        }
        public void addEdge(T var1,T var2)
        {
            if (!_graph.ContainsKey(var1) || !_graph.ContainsKey(var2)) throw new VertexExistException();//Func
            _graph[var1].Add(var2);
            _graph[var2].Add(var1);
        }
        public List<T>getNeigbours(T Ver)
        {
            if (!_graph.ContainsKey(Ver)) throw new VertexExistException();//Func
            return _graph[Ver];
        }
        public List<T> GetVertex()
        {
            return _graph.Keys.ToList();
        }
        public List<T> BFS(T from, T to)
        {
            if (!_graph.ContainsKey(from) || !_graph.ContainsKey(to))
                throw new VertexNotExistException();

            Queue<List<T>> ways = new Queue<List<T>>();

            ways.Enqueue(new List<T>() { from });

            while (ways.Count > 0)
            {
                List<T> temp = ways.Dequeue();

                foreach (var item in _graph[temp.Last()])
                {
                    List<T> r = temp.ToList();
                    if (!r.Contains(item))
                    {
                        r.Add(item);
                        if (r.First().ToString() == from.ToString() && r.Last().ToString() == to.ToString())
                            return r;
                        ways.Enqueue(r);
                    }
                }
            }
            return new List<T>();
        }
        public bool Contains(T i)
        {
            return _graph.ContainsKey(i);
        }
    }
}
