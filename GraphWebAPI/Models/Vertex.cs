using System;

namespace GraphWebAPI.Models
{
    public class Vertex
    {
        public Vertex(String id, String name)
        {
            this.id = id;
            this.name = name;
        }

        private String id;

        public String Id
        {
            get { return id; }
            set { id = value; }
        }
        private String name;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Vertex other = (Vertex)obj;
            if (id == null)
            {
                if (other.id != null)
                {
                    return false;
                }
            }
            else if (!id.Equals(other.id))
            {
                return false;
            }
            return true;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            int prime = 31;
            int result = 1;
            result = prime * result + ((id == null) ? 0 : id.GetHashCode());
            return result;
        }

        public override string ToString()
        {
            return name;
        }

    }
}