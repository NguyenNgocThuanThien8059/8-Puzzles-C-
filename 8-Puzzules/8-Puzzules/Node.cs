using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_Puzzules
{
    internal class Node
    {
        //Tạo List node con
        public List<Node> Children = new List<Node>();
        //Tạo node cha
        public Node Parent;
        //Tạo ma trận Puzzle
        public int [,] Puzzle = new int[3,3];
        //Dùng để tìm tọa độ chỗ trống
        public int x;
        public int y;
        //Khởi tạo contructor
        public Node(int[,] a)
        {
            SetPuzzle(a);
        }
        //Thiết lập puzzle
        public void SetPuzzle(int[,] a) 
        {
            for(int i = 0; i < 3; i++) 
            {
                for (int j = 0; j < 3; j++)
                {
                    this.Puzzle[i,j] = a[i,j];
                }
            }
        }
        //Di chuyển sang trái (Ma trận cha, Tọa độ)
        public void MoveLeft(int[,] a, int i, int j)
        {
            //Nếu không gần rìa bên trái
            if (j - 1 >= 0)
            {
                //Tạo ma trận con
                int[,] b = new int[3, 3];
                //Sao chép cho ma trận con = ma trận cha
                CopyPuzzle(b, a);
                //Đổi vị trí khoảng trống và số
                int temp = b[i, j - 1];
                b[i, j - 1] = b[i, j];
                b[i, j] = temp;
                //Tạo node con, truyền ma trận con vào node
                Node Child = new Node(b);
                //Thêm node vào List node con
                Children.Add(Child);
                //Cha của node Child
                Child.Parent = this;
            }
        }
        //Di chuyển lên
        public void MoveUp(int[,] a, int i, int j)
        {
            //Nếu không gần rìa bên trên
            if (i - 1 >= 0)
            {
                //Tạo ma trận con
                int[,] b = new int[3, 3];
                //Sao chép cho ma trận con = ma trận cha
                CopyPuzzle(b, a);
                //Đổi vị trí khoảng trống và số
                int temp = b[i - 1, j];
                b[i - 1, j] = b[i, j];
                b[i, j] = temp;
                //Tạo node con, truyền ma trận con vào node
                Node Child = new Node(b);
                //Thêm node vào List node con
                Children.Add(Child);
                //Cha của node Child
                Child.Parent = this;
            }
        }
        //Di chuyển sang phải
        public void MoveRight(int[,] a, int i, int j)
        {
            //Nếu không gần rìa bên phải
            if (j + 1 <= 2)
            {
                //Tạo ma trận con
                int[,] b = new int[3,3];
                //Sao chép cho ma trận con = ma trận cha
                CopyPuzzle(b, a);
                //Đổi vị trí khoảng trống và số
                int temp = b[i, j + 1];
                b[i, j + 1] = b[i, j];
                b[i, j] = temp;
                //Tạo node con, truyền ma trận con vào node
                Node Child = new Node(b);
                //Thêm node vào List node con
                Children.Add(Child);
                //Cha của node Child
                Child.Parent = this;
            }
        }
        //Di chuyển xuống
        public void MoveDown(int[,] a, int i, int j)
        {
            //Nếu không gần rìa bên dưới
            if (i + 1 <= 2)
            {
                //Tạo ma trận con
                int[,] b = new int[3, 3];
                //Sao chép cho ma trận con = ma trận cha
                CopyPuzzle(b, a);
                //Đổi vị trí khoảng trống và số
                int temp = b[i + 1, j];
                b[i + 1, j] = b[i, j];
                b[i, j] = temp;
                //Tạo node con, truyền ma trận con vào node
                Node Child = new Node(b);
                //Thêm node vào List node con
                Children.Add(Child);
                //Cha của node Child
                Child.Parent = this;
            }
        }
        public void ExpandNode()
        {
            //Xác định vị trí khoảng trống
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    if (Puzzle[i, j] == 0)
                    {
                        x = i;
                        y = j;
                    }
                }
            }
            MoveLeft(Puzzle, x, y);
            MoveUp(Puzzle, x, y);
            MoveRight(Puzzle, x, y);
            MoveDown(Puzzle, x, y);
        }
        //Xuất Puzzle
        public void PrintPuzzle()
        {
            Console.WriteLine();
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    Console.Write(Puzzle[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        //Kiểm tra trùng lặp puzzle
        public bool IsSamePuzzle(int[,] a)
        {
            bool SamePuzzle = true;
            for(int i = 0; i < 3; i++)
            {
                for (int j = 0;j < 3; j++)
                {
                    if (Puzzle[i,j] != a[i,j])
                    {
                        SamePuzzle = false;
                    }
                }
            }
            return SamePuzzle;
        }
        //Sao chép puzzle
        public void CopyPuzzle(int[,] a, int[,] b)
        {
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    a[i,j] = b[i,j];
                }
            }
        }
        //Trạng thái hoàn thành
        public bool GoalState()
        {
            bool isGoal = true;
            int[,] m = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } };
            for (int i = 0; i < 3; i++) 
            {
                for (int j = 0; j < 3; j++)
                {
                    //Kiểm tra từng phần tử
                    if (m[i,j] > Puzzle[i,j])
                    {
                        isGoal = false;
                    }
                }
            }
            return isGoal;
        }
    }
}
