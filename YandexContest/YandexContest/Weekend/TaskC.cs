namespace YandexContest.Weekend
{
    public class TaskC : IRunnable
    {
        public void Run()
        {
            throw new System.NotImplementedException();
        }
    }
    /*
     *
     * using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Globalization;
using System.Text;

namespace YandexContest
{
    class Program
    {
        static readonly Dictionary<string, TreeNode> Dict = new Dictionary<string, TreeNode>(); // по хорошему - отдельный класс, который граф.
        static void Main()
        {
            var reader = new NumbersReader();
            var nums = reader.ReadInt32Array();
            var n = nums[0];
            var m = nums[1];
            var count = reader.ReadInt32();

            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < m; j++)
                {
                    var node = new TreeNode(i, j);
                    Dict[node.Key] = node;
                }
            }
            for (var i = 0; i < count; i++)
            {
                var points = reader.ReadInt32Array();
                var key = GenKey(points[0] - 1, points[1] - 1);
                //Dict[key].IsMine = true;
                Dict.Remove(key);
            }

            foreach (var node in Dict.Values)
            {
                var x = node.X;
                var y = node.Y;
                if (x > 0)
                    AddNodes(node, x - 1, y);

                if (x < n - 1)
                    AddNodes(node, x + 1, y);
                    
                if (y > 0)
                    AddNodes(node, x, y - 1);
                
                if (y < m - 1)
                    AddNodes(node, x, y + 1);
            }

            var res = 0;
            while (Dict.Count != 0)
            {
                res++;
                Dict.Values.First().Fs();;
            }
            Console.WriteLine(res);
        }

        static void AddNodes(TreeNode node, int x, int y)
        {
            var key = GenKey(x, y);
            if (Dict.ContainsKey(key))
            {
                var nei = Dict[key];
                node.Nodes.Add(nei);
                nei.Nodes.Add(node);
            }
        }

        static string GenKey(int x, int y)
        {
            return $"X{x}Y{y}";
        }
        
        sealed class TreeNode
        {
            public string Key { get; }
            public int X { get; }
            public int Y { get; }
            public bool IsMine { get; set; }
            public List<TreeNode> Nodes { get; } = new List<TreeNode>();

            public TreeNode(int x, int y)
            {
                (X, Y) = (x, y);
                Key = ToString();
            }

            public void Fs()
            {
                var hashSet = new HashSet<string>();
                var queue = new Queue<TreeNode>();
                queue.Enqueue(this);
                hashSet.Add(Key);
                while (0 != queue.Count)
                {
                    var node = queue.Dequeue();
                    foreach (var n in node.Nodes.Where(n => !hashSet.Contains(n.Key)))
                    {
                        queue.Enqueue(n);
                        hashSet.Add(n.Key);
                    }

                    Dict.Remove(node.Key);
                }
            }

            public override string ToString()
            {
                return GenKey(X, Y);
            }
        }
    }

      class NumbersReader
    {
        public int ReadInt32()
        {
            return int.Parse(Console.ReadLine());
        }
        

        public long ReadInt64()
        {
            return long.Parse(Console.ReadLine());
        }

        public int[] ReadInt32Array()
        {
            return Console.ReadLine().Trim(' ').Split(' ').Where(s => s != "")
                .Select(i => int.Parse(i)).ToArray();
        }

        public long[] ReadInt64Array()
        {
            return Console.ReadLine().Trim(' ').Split(' ').Where(s => s != "")
                .Select(i => long.Parse(i)).ToArray();
        }

        public double[] ReadDoubleArray()
        {
            return Console.ReadLine().Trim(' ').Split(' ').Where(s => s != "")
                .Select(d => double.Parse(d, new NumberFormatInfo())).ToArray();
        }
    }
}
     */
}