﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using YandexContest.Algorithms2.DivA.DivA6;

namespace YandexContest
{
    class Program
    {
        static long _n;
        static long _m;
        static long _r;
        static readonly List<Participant> Participants = new List<Participant>();
        static readonly HashSet<long> Regions = new HashSet<long>();
        
        static void Main(string[] args)
        {
            var reader = new NumbersReader();
            var nums = reader.ReadInt64Array();
            _n = nums[0];
            _m = nums[1];
            _r = nums[2];
            long max = 0;
            for (var i = 0; i < _n; i++)
            {
                var data = reader.ReadInt64Array();
                Participants.Add(new Participant
                {
                    Id = data[0],
                    Region = data[1],
                    Score = data[2],
                    LastYearWinner = data[3] == 1,
                });
                Regions.Add(data[1]);
                if (data[2] > max)
                    max = data[2];
            }

            var res = Search(0, max + 1, Compare);
            Console.WriteLine(res);
        }
        
        static long Search(long left, long right, Func<long, bool> compare)
        {
            while (right > left)
            {
                var mid = (right + left) / 2 ;
                if (compare(mid))
                    right = mid;
                else
                    left = mid + 1;
            }

            return left;
        }

        static bool Compare(long value)
        {
            long totalCount = 0;
            var completedRegions = new HashSet<long>();
            
            foreach (var participant in Participants.Where(participant => participant.LastYearWinner || participant.Score >= value))
            {
                totalCount++;
                completedRegions.Add(participant.Region);
            }

            totalCount += Regions.Count - completedRegions.Count;

            return totalCount <= _m;
        }
    
    }

    class Participant 
    {
        public long Id { get; set; }
        public long Region { get; set; }
        public long Score { get; set; }
        public bool LastYearWinner { get; set; }
    }
    class NumbersReader
    {
        static void ShowPrefix()
        {
            var reader = new NumbersReader();
            var array = reader.ReadInt64Array();
            var arrayLen = array.Length;
            var prefix = new long[arrayLen + 1];
            for (var i = 1; i < arrayLen + 1; i++)
            {
                prefix[i] = prefix[i - 1] + array[i - 1];
            }

            Console.WriteLine(string.Join(" ", prefix));
        }

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
                .Select(int.Parse).ToArray();
        }

        public long[] ReadInt64Array()
        {
            return Console.ReadLine().Trim(' ').Split(' ').Where(s => s != "")
                .Select(long.Parse).ToArray();
        }
    }
}