﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            string strTmp = "abcdefg某某某";
            byte[] byt =  System.Text.Encoding.Default.GetBytes(strTmp);
            int i = System.Text.Encoding.UTF8.GetBytes(strTmp).Length;
            int j = strTmp.Length;
            Console.WriteLine("X={0},Y={1}", i, j);
            Console.ReadKey();
        }
    }
}
