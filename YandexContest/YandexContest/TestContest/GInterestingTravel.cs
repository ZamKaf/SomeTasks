using System;
using System.Collections.Generic;
using System.Linq;

namespace YandexContest.TestContest
{
    public class GInterestingTravel : IRunnable
    {
        public void Run()
        {
            var count = int.Parse(Console.ReadLine());
            var list = new List<TreeNode>();
            for (var i = 0; i < count; i++)
            {
                var nums = Console.ReadLine().Split(' ').Select(long.Parse)
                					.ToArray();
                list.Add(new TreeNode(nums[0], nums[1], i));
            }
            
            var maxDistance = long.Parse(Console.ReadLine());
            var nums1 = Console.ReadLine().Split(' ').Select(int.Parse)
                					.ToArray();
            var startIndex = nums1[0] - 1;
            var finishIndex = nums1[1] - 1;
            
            for (var i = 0; i < list.Count; i++)
            {
                var currentNode = list[i];
                for (var j = i+1; j < list.Count; j++)
                {
                    var node = list[j];
                    if (currentNode.CalcDistance(node) <= maxDistance)
                    {
                        currentNode.Neigh.Add(node);
                        node.Neigh.Add(currentNode);
                    }
                }
            }
            Console.WriteLine(list[startIndex].Fs(finishIndex));
        }
        
    }
    
    class TreeNode
    {
        public int Index { get; }
        public List<TreeNode> Neigh { get; } = new List<TreeNode>();
        readonly long _x;
        readonly long _y;
        int Distance { get; set; }
        
        public int Fs(int finishIndex)
        {
            var hashSet = new HashSet<int>();
            var queue = new Queue<TreeNode>();
            Distance = 0;
            queue.Enqueue(this);
            hashSet.Add(Index);
            while (0 != queue.Count)
            {
                var node = queue.Dequeue();
                foreach (var n in node.Neigh.Where(n => !hashSet.Contains(n.Index)))
                {
                    if (n.Index == finishIndex)
                        return node.Distance + 1;
                    n.Distance = node.Distance + 1;
                    queue.Enqueue(n);
                    hashSet.Add(n.Index);
                }
            }
            return -1;
        }
        
        public TreeNode(long x, long y, int index)
        {
            _x = x;
            _y = y;
            Index = index;
        }
        
        public long CalcDistance(TreeNode p)
        {
            return Math.Abs(_x - p._x) + Math.Abs(_y - p._y);
        }
    }
}