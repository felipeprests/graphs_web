using System.Collections.Generic;

namespace GraphWebAPI.Models
{
    public class Graph
    {
        public Graph(List<Vertex> vertexes, List<Edge> edges)
        {
            this.vertexes = vertexes;
            this.edges = edges;
        }

        private List<Vertex> vertexes;

        public List<Vertex> Vertexes
        {
            get { return vertexes; }
            set { vertexes = value; }
        }

        private List<Edge> edges;

        public List<Edge> Egdes
        {
            get { return edges; }
            set { edges = value; }
        }

    }
}