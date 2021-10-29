using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace YandexContest.Algorithms2.DivA.DivA8
{
    public class ACities1 : IRunnable
    {
        public void Run()
        {
            const string inFile = "input.txt";

            var tree = new GenTree();
            var data = File.ReadAllLines(inFile);
            var count = long.Parse(data[0]);
            for (var i = 1; i < count; i++)
            {
                var pair = data[i].Split(' ').Where(s => s != "").Select(int.Parse).ToArray();
                tree.Add(pair[0], pair[1]);
            }

            var distance = 0;
            var res = tree.MinMaxDistances(out distance);
            res.Sort();
            Console.Write($"{distance} {res.Count} {string.Join(" ", res)}");
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

            public override string ToString()
            {
                return $"{Key} (d {Distance})";
            }
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

            public List<int> MinMaxDistances(out int minDistance)
            {
                var leaves = new List<int>();
                var first = _elements.Values.FirstOrDefault();
                
                if (null == first)
                {
                    minDistance = 0;
                    leaves.Add(1);
                    return leaves;
                }

                var node = _elements.Values.First();
                TreeNode furtherNode;
                FurtherDistance(node, out furtherNode);
                var min = 0;
                var maxDistance = FurtherDistance(furtherNode, out furtherNode);
                if (maxDistance % 2 == 0)
                {
                    min = maxDistance / 2;
                    leaves.Add(_elements.Values.First(e => e.Distance == min).Key);
                }
                else
                {
                    
                    min = maxDistance / 2 + 1;
                    leaves.Add(_elements.Values.First(e => e.Distance == min).Key);
                    leaves.Add(_elements.Values.First(e => e.Distance == min - 1).Key);
                }
                minDistance = min;

                return leaves;
            }

            int FurtherDistance(TreeNode node, out TreeNode furtherNode)
            {
                var que = new Queue<TreeNode>();
                var counted = new HashSet<int>();
                node.Distance = 0;
                que.Enqueue(node);
                counted.Add(node.Key);
                while (que.Count != 0)
                {
                    node = que.Dequeue();
                    foreach (var neighbour in node.Neighbours.Where(neighbour => !counted.Contains(neighbour.Key)))
                    {
                        neighbour.Distance = node.Distance + 1;
                        que.Enqueue(neighbour);
                        counted.Add(neighbour.Key);
                    }
                }

                furtherNode = node;
                return node.Distance;
            }
        }
    }
}