using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraphWebAPI.Models
{
    public class Edge
    {
        public Edge(String id, Vertex source, Vertex destination, int weight)
        {
            this.id = id;
            this.source = source;
            this.destination = destination;
            this.weight = weight;
        }


        private String id;

        public String Id
        {
            get { return id; }
            set { id = value; }
        }

        private Vertex source;

        public Vertex Source
        {
            get { return source; }
            set { source = value; }
        }

        private Vertex destination;

        public Vertex Destination
        {
            get { return destination; }
            set { destination = value; }
        }

        private int weight;

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public override string ToString()
        {
            return source + " " + destination;
        }


    }
}