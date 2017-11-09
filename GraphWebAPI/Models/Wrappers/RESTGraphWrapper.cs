namespace GraphWebAPI.Models.Wrappers
{
    public class RESTGraphWrapper
    {
        public Graph Graph { get; set; }
        public Vertex Source { get; set; }
        public Vertex Destination { get; set; }
    }
}