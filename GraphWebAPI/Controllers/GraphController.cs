
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GraphWebAPI.Models.Wrappers;
using GraphWebAPI.Models;
using GraphWebAPI.Models.Djikstra;

namespace GraphWebAPI.Controllers
{
    public class GraphController : ApiController
    {
        [AcceptVerbs("POST")]
        public LinkedList<Vertex> ShortestPath(RESTGraphWrapper restGraphWrapper)
        {
            Dijkstra dijkstra = new Dijkstra(restGraphWrapper.Graph);
            dijkstra.Execute(restGraphWrapper.Source);
            var path = dijkstra.GetPath(restGraphWrapper.Destination);
            return path;
        }
        private List<Vertex> nodes;
        private List<Edge> edges;

        [AcceptVerbs("GET")]
        public RESTGraphWrapper GetGraph()
        {
            nodes = new List<Vertex>();
            edges = new List<Edge>();
            for (int i = 0; i < 11; i++)
            {
                Vertex location = new Vertex("Node_" + i, "Node_" + i);
                nodes.Add(location);
            }

            addLane("Edge_0", 0, 1, 85);
            addLane("Edge_1", 0, 2, 217);
            addLane("Edge_2", 0, 4, 173);
            addLane("Edge_3", 2, 6, 186);
            addLane("Edge_4", 2, 7, 103);
            addLane("Edge_5", 3, 7, 183);
            addLane("Edge_6", 5, 8, 250);
            addLane("Edge_7", 8, 9, 84);
            addLane("Edge_8", 7, 9, 167);
            addLane("Edge_9", 4, 9, 502);
            addLane("Edge_10", 9, 10, 40);
            addLane("Edge_11", 1, 10, 600);

            return new RESTGraphWrapper()
            {
                Graph = new Graph(nodes, edges),
                Source = nodes[0],
                Destination = nodes[10]
            };
        }

        private void addLane(string laneId, int sourceLocNo, int destLocNo, int duration)
        {
            Edge lane = new Edge(laneId, nodes[sourceLocNo], nodes[destLocNo], duration);
            edges.Add(lane);
        }
    }
}