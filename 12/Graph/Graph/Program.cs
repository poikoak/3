using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{

    class Vertex<T>
    {

        List<Vertex<T>> neighbors;
        T value;
        bool isVisited;

        public List<Vertex<T>> Neighbors { get { return neighbors; } set { neighbors = value; } }
        public T Value { get { return value; } set { this.value = value; } }
        public bool IsVisited { get { return isVisited; } set { isVisited = value; } }
        public int NeighborsCount { get { return neighbors.Count; } }

        public Vertex(T value)
        {
            this.value = value;
            isVisited = false;
            neighbors = new List<Vertex<T>>();
        }

        public Vertex(T value, List<Vertex<T>> neighbors)
        {
            this.value = value;
            isVisited = false;
            this.neighbors = neighbors;
        }

        public void Visit()
        {
            isVisited = true;
        }

        public void AddEdge(Vertex<T> vertex)
        {
            neighbors.Add(vertex);
        }

        public void AddEdges(List<Vertex<T>> newNeighbors)
        {
            neighbors.AddRange(newNeighbors);
        }

        public void RemoveEdge(Vertex<T> vertex)
        {
            neighbors.Remove(vertex);
        }


        public override string ToString()
        {

            StringBuilder allNeighbors = new StringBuilder("");
            allNeighbors.Append(value + ": ");

            foreach (Vertex<T> neighbor in neighbors)
            {
                allNeighbors.Append(neighbor.value + "  ");
            }

            return allNeighbors.ToString();

        }

    }

    class UndirectedGenericGraph<T>
    {

        // The list of vertices in the graph
        private List<Vertex<T>> vertices;

        // The number of vertices
        int size;

        public List<Vertex<T>> Vertices { get { return vertices; } }
        public int Size { get { return vertices.Count; } }


        public UndirectedGenericGraph(int initialSize)
        {
            if (size < 0)
            {
                throw new ArgumentException("Number of vertices cannot be negative");
            }

            size = initialSize;

            vertices = new List<Vertex<T>>(initialSize);

        }

        public UndirectedGenericGraph(List<Vertex<T>> initialNodes)
        {
            vertices = initialNodes;
            size = vertices.Count;
        }

        public void AddVertex(Vertex<T> vertex)
        {
            vertices.Add(vertex);
        }

        public void RemoveVertex(Vertex<T> vertex)
        {
            vertices.Remove(vertex);
        }

        public bool HasVertex(Vertex<T> vertex)
        {
            return vertices.Contains(vertex);
        }

        public void DepthFirstSearch(Vertex<T> root)
        {
            if (!root.IsVisited)
            {
                Console.Write(root.Value + " ");
                root.Visit();

                foreach (Vertex<T> neighbor in root.Neighbors)
                {
                    DepthFirstSearch(neighbor);
                }

            }
        }


        public void BreadthFirstSearch(Vertex<T> root)
        {

            Queue<Vertex<T>> queue = new Queue<Vertex<T>>();

            root.Visit();

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                Vertex<T> current = queue.Dequeue();

                foreach (Vertex<T> neighbor in current.Neighbors)
                {
                    if (!neighbor.IsVisited)
                    {
                        Console.Write(neighbor.Value + " ");
                        neighbor.Visit();
                        queue.Enqueue(neighbor);
                    }
                }
            }

        }

    }


    class Program
    {
        static void Main(string[] args)
        {

            // Create a list of vertices using the Vertex<T> class
            List<Vertex<string>> vertices = new List<Vertex<string>>
            (
                new Vertex<string>[]
                    {
                new Vertex<string>("Los Angeles"),
                new Vertex<string>("San Francisco"),
                new Vertex<string>("Las Vegas"),
                new Vertex<string>("Seattle"),
                new Vertex<string>("Austin"),
                new Vertex<string>("Portland")
                    }
            );

       
            vertices[0].AddEdges(new List<Vertex<string>>(new Vertex<string>[]
            {
            vertices[1], vertices[2], vertices[5]
            }));


            // Create graph using the UndirectedGenericGraph<T> class
            UndirectedGenericGraph<string> testGraph = new UndirectedGenericGraph<string>(vertices);

            // Check to see that all neighbors are properly set up
            foreach (Vertex<string> vertex in vertices)
            {
                Console.WriteLine(vertex.ToString());
            }

            // Test searching algorithms
            testGraph.DepthFirstSearch(vertices[0]);
            //testGraph.BreadthFirstSearch(vertices[0]);

        }
    }
}
