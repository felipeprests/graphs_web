using GraphWebAPI.Models;
using GraphWebAPI.Models.Djikstra;
using GraphWebAPI.Models.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GraphWebAPI.Controllers
{
    public class HomeController : Controller
    {
        private List<Vertex> nodes;
        private List<Edge> edges;
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult ViewGraphs()
        {
            ViewBag.Title = "Grafos";

            ViewBag.Graph = GetGraph();

            return View();
        }

        public Graph GetGraph()
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

            return new Graph(nodes, edges);
            //{
                //Graph = new Graph(nodes, edges),
                //Source = nodes[1],
                //Destination = nodes[5]
            //};
        }

        public LinkedList<Vertex> ShortestPath(RESTGraphWrapper restGraphWrapper)
        {
            Dijkstra dijkstra = new Dijkstra(restGraphWrapper.Graph);
            dijkstra.Execute(restGraphWrapper.Source);
            var path = dijkstra.GetPath(restGraphWrapper.Destination);
            return path;
        }

        private void addLane(string laneId, int sourceLocNo, int destLocNo, int duration)
        {
            Edge lane = new Edge(laneId, nodes[sourceLocNo], nodes[destLocNo], duration);
            edges.Add(lane);
        }
    }
}
