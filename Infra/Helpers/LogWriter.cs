﻿using System;
using System.IO;

namespace Infra.Helpers
{
    public class LogWriter
    {
        public static void Write(string logMessage)
        {
            try
            {
                if (!File.Exists("./log.txt"))
                {
                    File.Create("./log.txt");
                }

                using (StreamWriter w = File.AppendText("./log.txt"))
                {
                    Log(logMessage, w);
                }
            }
            catch (Exception){}
        }

        private static void Log(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("\r\nLog Entry : ");
                txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                txtWriter.WriteLine("  :");
                txtWriter.WriteLine("  :{0}", logMessage);
                txtWriter.WriteLine("-------------------------------");

                Console.WriteLine(logMessage);
            }
            catch (Exception){}
        }
    }
}
