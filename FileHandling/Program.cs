﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ReadWrite readwrite = new ReadWrite();
            readwrite.ReWrOperation();
        }
    }
}