using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV3
{
    [Serializable]
    public class VertexNotExistException : Exception
    {
        public VertexNotExistException() : base("Vertex Not Exists") { }
        public VertexNotExistException(string message) : base(message) { }

    }
    [Serializable]
    public class VertexExistException : Exception
    {
        public VertexExistException() : base("Vertex Already Exists") { }
        public VertexExistException(string message) : base(message) { }
    }
}
