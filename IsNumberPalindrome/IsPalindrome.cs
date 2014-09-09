using System;

namespace IsNumberPalindrome
{
    public class IsPalindrome
    {
        public static void Test()
        {

            Console.WriteLine(int.MaxValue); //2147483647
            Console.WriteLine(isPalindrome(1));
            Console.WriteLine(isPalindrome(2147447412)); 
            Console.WriteLine(isPalindromeSameTime(2147447412));
            Console.WriteLine(IsPalindrome.isPalindromeRecursive(32123));
            Console.WriteLine(isPalindrome(121));
            Console.WriteLine(isPalindrome(65656));
        }
        private static bool isPalindrome(int input)
        {
            var revert =0;
            var intNum = input;
            if (input < 0)
                return false;
            while (intNum > 0)
            {
                revert = revert * 10 + intNum % 10;
                intNum /= 10;
            }

            return input == revert;
        }

        public static bool isPalindromeSameTime(int input)
        {
            var intNum = input;
            var divisor = 1;
            if (input < 0)
                return false;

            while (intNum/divisor >= 10)
            {
                divisor *= 10;
            }

            while (intNum > 0)
            {
                var l = intNum/divisor;
                var r = intNum%10;
                if (l != r) return false;
                intNum = (intNum%divisor)/10;
                divisor /= 100;
            }
            return true;
        }

        public static bool isPalindromeRecursive(int input)
        {
            return isPalindrome(input, ref input);
        }

        public static bool isPalindrome(int x, ref int y)
        {
            if (x < 0) return false;
            if (x == 0) return true;
            if (isPalindrome(x / 10, ref y) && (x % 10 == y % 10))
            {
                y /= 10;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}