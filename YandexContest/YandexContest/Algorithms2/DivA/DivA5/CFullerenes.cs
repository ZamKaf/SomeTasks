using System;
using System.IO;
using System.Linq;
using System.Xml.Schema;

namespace YandexContest.Algorithms2.DivA.DivA5
{
    public class CFullerenes : IRunnable
    {
        public void Run()
        {
            const string file = "input.txt";
            var data = File.ReadAllText(file).Split("\n");
            var count = int.Parse(data[0]);
            var tubes = data[1].Split(" ").Select(long.Parse).ToArray();
            
            /*
            var reader = new NumbersReader();
            var count = reader.ReadInt32();
            var tubes = reader.ReadInt64Array();
            */
            if (count < 3)
            {
                Console.WriteLine(0);
                return;
            }
            Console.WriteLine($"{count} {tubes.Length}");

            long partiesCount = 0;
            for (var aPointer = 0; aPointer < count - 2; aPointer++)
            {
                var a = tubes[aPointer];
                var bPointer = aPointer + 1;
                
                var cPointerMax = bPointer + 1;
                var cPointerMin = bPointer + 1;
                var cPointerMaxFound = false;
                var cPointerMinFound = false;
                while (true)
                {
                    var b = tubes[bPointer];
                    var cMin = tubes[cPointerMin];
                    var cMax = tubes[cPointerMax];
                    
                    // Ищем нижнюю границу подходящего отрезка, определяется "тупоугольностью".
                    if (!cPointerMinFound)
                    {
                        if (!IsObtuseTriangle(a, b, cMin))
                        {
                            if (cPointerMin == count - 1)
                                break;
                            
                            cPointerMin++;
                        }
                        else
                        {
                            cPointerMinFound = true;
                        }
                    }

                    // Ищем верхнюю границу подходящего отрезка, определяется неравенством треугольника.
                    if (!cPointerMaxFound)
                    {
                        if (cMax < a + b)
                        {
                            if (cPointerMax == count - 1)
                                cPointerMaxFound = true;
                            else
                                cPointerMax++;
                        }
                        else
                        {
                            if (cPointerMax - 1 == bPointer)
                            {
                                if (bPointer == count - 2)
                                    break;
                                bPointer++;
                                cPointerMin = Math.Max(cPointerMin, bPointer + 1);
                                cPointerMax = Math.Max(cPointerMax, bPointer + 1);
                                cPointerMaxFound = false;
                                cPointerMinFound = false;
                            }
                            else
                            {
                                cPointerMax--;
                                cPointerMaxFound = true;   
                            }
                        }
                    }

                    if (cPointerMaxFound && cPointerMinFound)
                    {
                        if (cPointerMax >= cPointerMin)
                            partiesCount += cPointerMax - cPointerMin + 1;
                        if (bPointer == count - 2)
                            break;
                        bPointer++;
                        cPointerMin = Math.Max(cPointerMin, bPointer + 1);
                        cPointerMax = Math.Max(cPointerMax, bPointer + 1);
                        cPointerMaxFound = false;
                        cPointerMinFound = false;
                    }
                }
            }
            Console.WriteLine(partiesCount);
        }

        static bool IsObtuseTriangle(long a, long b, long c) // Min mid max side.
        {
            return a * a < c * c -  b * b;
        }
    }
}