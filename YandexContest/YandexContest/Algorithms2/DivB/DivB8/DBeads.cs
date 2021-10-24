using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace YandexContest.Algorithms2.DivB.DivB8
{
    public class DBeads : IRunnable
    {
        public void Run()
        {
            const string inFile = "input.txt";

            var tree = new GenTree();
            var data = File.ReadAllLines(inFile);
            var count = int.Parse(data[0]);
            for (var i = 1; i < count; i++)
            {
                var pair = data[i].Split(' ').Where(s => s != "").Select(int.Parse).ToArray();
                tree.Add(pair[0], pair[1]);
            }
            Console.WriteLine(tree.MaxLineCount());
        }
        class TreeNode
        {
            public TreeNode(int key)
            {
                Key = key;
            }
            public int Key { get; }
            public List<TreeNode> Neighbours = new List<TreeNode>();
            public int Distance { get; set; }
        }

        class GenTree
        {
            readonly Dictionary<int, TreeNode> _elements = new Dictionary<int, TreeNode>();

            public void Add(int key1, int key2)
            {
                var node1 = _elements.ContainsKey(key1)
                    ? _elements[key1]
                    : _elements[key1] = new TreeNode(key1);
                var node2 = _elements.ContainsKey(key2)
                    ? _elements[key2]
                    : _elements[key2] = new TreeNode(key2);
                node1.Neighbours.Add(node2);
                node2.Neighbours.Add(node1);
            }

            public int MaxLineCount()
            {
                var d = 0;
                var distance = 0;
                var node = FurtherNode(_elements.Values.First(), out d);
                FurtherNode(node, out distance);
                return distance + 1;
            }

            TreeNode FurtherNode(TreeNode node, out int distance)
            {
                var que = new Queue<TreeNode>();
                var counted = new HashSet<int>();
                node.Distance = 0;
                que.Enqueue(node);
                counted.Add(node.Key);
                TreeNode elem = null;
                while (que.Count != 0)
                {
                    elem = que.Dequeue();
                    foreach (var neighbour in elem.Neighbours.Where(neighbour => !counted.Contains(neighbour.Key)))
                    {
                        neighbour.Distance = elem.Distance + 1;
                        que.Enqueue(neighbour);
                        counted.Add(neighbour.Key);
                    }
                }

                distance = elem?.Distance ?? 0;
                return elem;
            }
        }
    }
}