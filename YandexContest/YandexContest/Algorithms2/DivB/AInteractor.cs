using System;

namespace YandexContest.Algorithms2.DivB
{
    public class AInteractor:IRunnable
    {
        public void Run()
        {
            var exitCode = sbyte.Parse(Console.ReadLine());
            var interactorResult = byte.Parse(Console.ReadLine());
            var checkerResult = byte.Parse(Console.ReadLine());
            int result;
            switch (interactorResult)
            {
                case 0:
                    result = 0 != exitCode ? 3 : checkerResult;
                    break;
                case 1:
                    result = checkerResult;
                    break;
                case 4:
                    result = 0 != exitCode ? 3 : 4;
                    break;
                case 6:
                    result = 0;
                    break;
                case 7:
                    result = 1;
                    break;
                default:
                    result = interactorResult;
                    break;
            }

            Console.WriteLine(result);
        }
    }
}