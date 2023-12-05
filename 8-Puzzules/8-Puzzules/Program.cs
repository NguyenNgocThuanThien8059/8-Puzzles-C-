using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_Puzzules
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Khởi tạo ma trận 3x3
            int [,] a = new int[3, 3] { { 1, 8, 2 }, { 0, 4, 3 }, { 7, 6, 5 } };
            //In trạng thái ban đầu
            Console.WriteLine("- Initial State:");
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    Console.Write(a[i,j] + " ");
                }
                Console.WriteLine();
            }
            //Tạo node, truyền ma trận vào node
            Node root = new Node(a);
            UninformedSearch ui = new UninformedSearch();
            List<Node> Solution = ui.BFS(root);
            if(Solution.Count > 0) 
            {
                Solution.Reverse();
                for(int i = 0; i < Solution.Count; i++) 
                {
                    Solution[i].PrintPuzzle();
                }
            }
            else
            {
                Console.WriteLine(" No Path Found ");
            }
            Console.Read();
        }
    }
}
