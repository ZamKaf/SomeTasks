using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;

namespace YandexContest.Algorithms2.DivA.DivA6
{
    public class COlympiadScore : IRunnable
    {
        static long _n;
        static long _m;
        static long _r;
        static readonly List<Participant> Participants = new List<Participant>();
        static readonly HashSet<long> Regions = new HashSet<long>();
        public void Run()
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
}