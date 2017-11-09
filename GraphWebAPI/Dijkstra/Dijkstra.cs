using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphWebAPI.Models.Djikstra
{
    public class Dijkstra
    {
        private List<Vertex> nodes;
        private List<Edge> edges;
        private ISet<Vertex> settleNodes;
        private ISet<Vertex> unSettleNodes;
        private Dictionary<Vertex, Vertex> predecessors;
        private Dictionary<Vertex, int> distance;

        public Dijkstra(Graph graph)
        {
            this.nodes = new List<Vertex>(graph.Vertexes);
            this.edges = new List<Edge>(graph.Egdes);
        }

        public void Execute(Vertex source)
        {
            settleNodes = new HashSet<Vertex>();
            unSettleNodes = new HashSet<Vertex>();
            distance = new Dictionary<Vertex, int>();
            predecessors = new Dictionary<Vertex, Vertex>();
            distance.Add(source, 0);
            unSettleNodes.Add(source);
            while (unSettleNodes.Count > 0)
            {
                Vertex node = GetMinimum(unSettleNodes);
                settleNodes.Add(node);
                unSettleNodes.Remove(node);
                FindMinimalDistances(node);
            }
        }

        private void FindMinimalDistances(Vertex node)
        {
            List<Vertex> adjacents = GetNeighbors(node);
            foreach (Vertex target in adjacents)
            {
                if (GetShortestDistance(target) > GetShortestDistance(node) + GetDistance(node, target))
                {
                    distance[target] = GetShortestDistance(node) + GetDistance(node, target);
                    predecessors[target] = node;
                    unSettleNodes.Add(target);
                }
            }
        }

        private int GetDistance(Vertex node, Vertex target)
        {
            foreach (Edge edge in edges)
            {
                if (edge.Source.Equals(node) && edge.Destination.Equals(target))
                {
                    return edge.Weight;
                }
            }
            throw new Exception("Should not happen");
        }

        private int GetShortestDistance(Vertex destination)
        {
            if(distance.TryGetValue(destination,out int d))
            {
                return d;
            }
            return int.MaxValue;
            //int? d = distance[destination];
            //if (d == null)
            //{
            //    return int.MaxValue;
            //}
            //else
            //{
            //    return d.Value;
            //}
        }

        private List<Vertex> GetNeighbors(Vertex node)
        {
            List<Vertex> neighbors = new List<Vertex>();
            foreach(Edge edge in edges)
            {
                if (edge.Source.Equals(node)
                        && !isSettled(edge.Destination))
                {
                    neighbors.Add(edge.Destination);
                }
            }
            return neighbors;
        }

        private bool isSettled(Vertex destination)
        {
            return settleNodes.Contains(destination);
        }

        private Vertex GetMinimum(ISet<Vertex> unSettleNodes)
        {
            Vertex minimum = null;
            foreach (Vertex vertex in unSettleNodes)
            {
                if (minimum == null)
                {
                    minimum = vertex;
                }
                else
                {
                    if (GetShortestDistance(vertex) < GetShortestDistance(minimum))
                    {
                        minimum = vertex;
                    }
                }
            }
            return minimum;
        }

        public LinkedList<Vertex> GetPath(Vertex target)
        {
            LinkedList<Vertex> path = new LinkedList<Vertex>();
            Vertex step = target;
            // check if a path exists
            if (predecessors[step] == null)
            {
                return null;
            }
            path.AddLast(step);
            while (predecessors.ContainsKey(step))
            {
                step = predecessors[step];
                path.AddLast(step);
            }
            // Put it into the correct order
            
            return new LinkedList<Vertex>(path.Reverse()) ;
        }
    }
}