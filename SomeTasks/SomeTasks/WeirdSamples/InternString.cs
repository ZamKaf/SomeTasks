using System;

namespace SomeTasks.WeirdSamples
{
    public static class InternString
    {
        public static unsafe void UnsafeCrush()
        {
            var testString = "test string";
            var len = testString.Length;
            fixed (char* pointerStr = testString)
            {
                for (var i = 0; i < len / 2; i++)
                    (pointerStr[i], pointerStr[len - i - 1]) = (pointerStr[len - i - 1], pointerStr[i]);
            }
            Console.WriteLine("test string");
        }

        public static void RefEquals()
        {
            var str1 = "test1";
            var str2 = "te" + "st1";
            var str3 = new string(new[] { 't', 'e', 's', 't', '1' });
            Console.WriteLine($"{str1} == {str2} ? {str1 == str2}");
            Console.WriteLine($"{str1} == {str3} ? {str1 == str3}");
            Console.WriteLine($"{str1} ref == {str2} ? {ReferenceEquals(str1, str2)}");
            Console.WriteLine($"{str1} ref == {str3} ? {ReferenceEquals(str1, str3)}");
        }
    }
}