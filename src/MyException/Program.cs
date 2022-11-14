using MyException.CustomArgs;
using MyException.Exceptions;
using System;
using System.Collections.Concurrent;
using System.Net.Sockets;

namespace MyException
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                throw new GeneralUpdateException<PatchDirtyExceptionArgs>(new PatchDirtyExceptionArgs("C:\\1.pacth"), "This file is probably an encrypted file .");
            }
            catch (GeneralUpdateException<PatchDirtyExceptionArgs> ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}