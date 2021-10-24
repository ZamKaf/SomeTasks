using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace YandexContest.Algorithms2.DivB.DivB8
{
    public class ABinaryTree : IRunnable
    {
        public void Run()
        {
            const string commandAdd = "ADD";
            const string commandSearch = "SEARCH";
            const string commandPrintTree = "PRINTTREE";
            const string answerDone = "DONE";
            const string answerAlready = "ALREADY";
            const string answerYes = "YES";
            const string answerNo = "NO";

            const string inFile = "input.txt";

            var answers = new List<string>();
            var tree = new BinaryTree();
            foreach (var line in File.ReadLines(inFile))
            {
                var command = line.Split(' ');
                switch (command[0])
                {
                    case commandAdd:
                        var key = long.Parse(command[1]);
                        answers.Add(tree.Add(key) ? answerDone : answerAlready);
                        break;
                    case commandSearch:
                        key = long.Parse(command[1]);
                        answers.Add(tree.Search(key) ? answerYes : answerNo);
                        break;
                    case commandPrintTree:
                        answers.Add(tree.Print());
                        break;
                }
            }
            answers.ForEach(Console.WriteLine);
        }

        class BinaryTreeNode
        {
            public BinaryTreeNode(long key)
            {
                Key = key;
            }
            public long Key { get; }
            public BinaryTreeNode LeftNode { get; set; }
            public BinaryTreeNode RightNode { get; set; }
        }

        class BinaryTree
        {
            BinaryTreeNode _root;
            readonly StringBuilder _printBuilder = new StringBuilder();

            public bool Add(long key)
            {
                if (null == _root)
                {
                    _root = new BinaryTreeNode(key);
                    return true;
                }

                return RecursiveAdd(_root, key);
            }

            public bool Search(long key)
            {
                return null != _root && RecursiveSearch(_root, key);
            }

            public string Print()
            {
                _printBuilder.Clear();
                RecursivePrint(_root, 0);
                var res = _printBuilder.ToString().TrimEnd('\n');
                _printBuilder.Clear();
                return res;
            }

            void RecursivePrint(BinaryTreeNode node, int level)
            {
                if (null == node)
                    return;
                
                RecursivePrint(node.LeftNode, level + 1);
                
                for (var i = 0; i < level; i++)
                    _printBuilder.Append('.');
                _printBuilder.Append(node.Key);
                _printBuilder.Append('\n');
                
                RecursivePrint(node.RightNode, level + 1);
            }

            bool RecursiveAdd(BinaryTreeNode node, long key)
            {
                if (key > node.Key)
                {
                    if (null != node.RightNode) 
                        return RecursiveAdd(node.RightNode, key);
                    
                    node.RightNode = new BinaryTreeNode(key);
                    return true;
                }
                if (key < node.Key)
                {
                    if (null != node.LeftNode) 
                        return RecursiveAdd(node.LeftNode, key);
                    
                    node.LeftNode = new BinaryTreeNode(key);
                    return true;
                }
                
                return false;
            }

            bool RecursiveSearch(BinaryTreeNode node, long key)
            {
                if (key == node.Key)
                    return true;

                var nextNode = key > node.Key
                    ? node.RightNode
                    : node.LeftNode;
                
                return null != nextNode && RecursiveSearch(nextNode, key);
            }
        }
        static void Test()
        {
            var tree = new BinaryTree();
            var res = tree.Add(5);
            Console.WriteLine(res);
            res = tree.Add(5);
            Console.WriteLine(res);
            res = tree.Add(6);
            Console.WriteLine(res);
            res = tree.Search(10);
            Console.WriteLine(res);
            res = tree.Search(5);
            Console.WriteLine(res);
            res = tree.Add(3);
            Console.WriteLine(res);
            res = tree.Add(12);
            Console.WriteLine(res);
            res = tree.Add(2);
            Console.WriteLine(res);
            Console.WriteLine(tree.Print());
        }
    }
}