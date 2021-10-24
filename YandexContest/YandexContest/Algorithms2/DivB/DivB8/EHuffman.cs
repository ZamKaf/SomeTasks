using System;
using System.Collections.Generic;
using System.Linq;

namespace YandexContest.Algorithms2.DivB.DivB8
{
    public class EHuffman : IRunnable
    {
        public void Run()
        {
            var count = int.Parse(Console.ReadLine());
            var answers = new List<List<string>>();
            for (var i = 0; i < count; i++)
            {
                var tree = new HuffmanTree(Console.ReadLine());
                answers.Add(tree.Codes());
            }

            foreach (var answer in answers)
            {
                Console.WriteLine(answer.Count);
                answer.ForEach(Console.WriteLine);
            }
        }

        class HuffmanNode
        {
            public int Code { get; set; }
            public HuffmanNode Parent { get; set; }
            public HuffmanNode Left { get; set; }
            public HuffmanNode Right { get; set; }
            public NodeType Type { get; set; }
        }

        enum NodeType
        {
            Root,
            Left,
            Right,
        }

        class HuffmanTree
        {
            readonly HuffmanNode _root = new HuffmanNode { Type = NodeType.Root };

            public HuffmanTree(string input)
            {
                var node = _root;
                foreach (var letter in input)
                {
                    if (letter == 'D')
                    {
                        node.Left = new HuffmanNode { Type = NodeType.Left, Parent = node};
                        node = node.Left;
                    }
                    else
                    {
                        while (node.Type == NodeType.Right)
                        {
                            node = node.Parent;
                        }

                        node = node.Parent;
                        node.Right = new HuffmanNode { Type = NodeType.Right, Parent = node};
                        node = node.Right;
                    }
                }
            }

            List<string> _codes;
            public List<string> Codes()
            {
                _codes = new List<string>();
                Codes(_root, new List<char>());
                return _codes;
            }

            void Codes(HuffmanNode node, List<char> codes)
            {
                if (null == node.Left)
                {
                    _codes.Add(string.Concat(codes));
                    return;
                }

                codes.Add('0');
                Codes(node.Left, codes);
                codes.RemoveAt(codes.Count - 1);
                codes.Add('1');
                Codes(node.Right, codes);
                codes.RemoveAt(codes.Count - 1);
            }
        }
    }
}