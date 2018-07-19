using System;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix = new AdjacencyMatrix(5);
            
            matrix.Connect(1, 2);
            matrix.Connect(2, 3);
            matrix.Connect(3, 4);
            matrix.Connect(2, 4);
            matrix.Connect(2, 0);
            matrix.Disconnect(1, 2);
            
            Console.Write(matrix.ToString());
        }
    }
}