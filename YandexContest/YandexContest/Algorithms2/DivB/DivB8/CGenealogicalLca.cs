using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace YandexContest.Algorithms2.DivB.DivB8
{
    public class CGenealogicalLca : IRunnable
    {
        public void Run()
        {
            const string inFile = "input.txt";

            var tree = new GenTree();
            var data = File.ReadAllLines(inFile);
            var count = int.Parse(data[0]);
            var dataDict = new Dictionary<string, string>();
            for (var i = 1; i < count; i++)
            {
                var pair = data[i].Split(' ');
                dataDict.Add(pair[0], pair[1]);
            }
            tree.Add(dataDict);
            
            var answers = new List<string>();
            for (var i = count; i < data.Length; i++)
            {
                var pair = data[i].Split(' ');
                answers.Add(tree.Lca(pair[0], pair[1]).Key);
            }
            Console.WriteLine(string.Join("\n", answers));
        }
        class GenTreeNode
        {
            public GenTreeNode(string key)
            {
                Key = key;
            }
            public string Key { get; }
            public int Level { get; set; }
            public GenTreeNode Parent { get; set; }
            public Dictionary<string, GenTreeNode> Children { get; } = new Dictionary<string, GenTreeNode>();
        }

        class GenTree
        {
            readonly Dictionary<string, GenTreeNode> _dictionary = new Dictionary<string, GenTreeNode>();
            GenTreeNode _root;

            public GenTreeNode Lca(string name1, string name2)
            {
                // Гарантируется, что есть.
                var node1 = _dictionary[name1];
                var node2 = _dictionary[name2];
                while (node1.Key != node2.Key)
                {
                    if (node1.Level > node2.Level)
                        node1 = node1.Parent;
                    else if (node1.Level < node2.Level)
                        node2 = node2.Parent;
                    else
                    {
                        node1 = node1.Parent;
                        node2 = node2.Parent;
                    }
                }

                return node1;
            }

            public int CheckSomebodyParent(string first, string second)
            {
                var firstNode = _dictionary[first];
                if (CheckParent(firstNode, second))
                    return 2;
                var secondNode = _dictionary[second];
                if (CheckParent(secondNode, first))
                    return 1;
                return 0;
            }
            
            public void Add(Dictionary<string, string> childParents)
            {
                var canBeRoot = new Dictionary<string, GenTreeNode>();
                if (null != _root)
                    canBeRoot[_root.Key] = _root;
                
                foreach (var pair in childParents)
                {
                    var child = pair.Key;
                    var parent = pair.Value;
                    
                    var parentNode = _dictionary.ContainsKey(parent) 
                        ? _dictionary[parent]
                        : new GenTreeNode(parent);
                    
                    var childNode = _dictionary.ContainsKey(child) 
                        ? _dictionary[child]
                        : new GenTreeNode(child);

                    childNode.Parent = parentNode;
                    parentNode.Children[child] = childNode;
                    
                    _dictionary[parent] = parentNode;
                    _dictionary[child] = childNode;

                    if (null == parentNode.Parent)
                        canBeRoot[parent] = parentNode;
                    if (canBeRoot.ContainsKey(child))
                        canBeRoot.Remove(child);
                }

                if (canBeRoot.Count == 1)
                    _root = canBeRoot.Values.First();
                else
                    throw new Exception("Wrong input");
                
                SetLevels(_root);
            }

            void SetLevels(GenTreeNode node, int level = 0)
            {
                node.Level = level;
                level++;
                foreach (var child in node.Children.Values)
                {
                    SetLevels(child, level);
                }
            }

            bool CheckParent(GenTreeNode node, string parentName)
            {
                while (node != null)
                {
                    node = node.Parent;
                    if (node?.Key == parentName)
                        return true;
                }

                return false;

            }

        }
    }
}