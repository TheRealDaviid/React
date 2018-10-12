using System;
using UnityEngine;
using System.IO.Ports;

namespace SerialReader
{
    public class Program
    {
        
        //Set up the serial port. Use the following values for an Arduino
        SerialPort sp = new SerialPort("COM9", 115200, Parity.None, 8, StopBits.One);
        int x = 0, y = 0;
        static void Main(string[] args)
        {
            //Open the Program function
            new Program();
        }

        private Program()
        {
            //Set the datareceived event handler
            sp.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
            //Open the serial port
            sp.Open();
            //Read from the console, to stop it from closing.
            Console.Clear();
            Console.Read();
        }

        private void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //Write the serial port data to the console.
            string tmp = sp.ReadExisting();
            string[] data = tmp.Split('|');
            string[] _x = data[0].Split(':');
            string[] _y = data[1].Split(':');
            try
            {
                if (Math.Abs(x - Convert.ToInt16(_x[1])) > 5)
                {
                    Console.WriteLine("X: " + _x[1]);
                    Console.WriteLine("Y: " + _y[1]);
                }
                if (Math.Abs(y - Convert.ToInt16(_y[1])) > 5)
                {
                    Console.WriteLine("X: " + _x[1]);
                    Console.WriteLine("Y: " + _y[1]);

                }

                x = Convert.ToInt32(_x[1]);
                y = Convert.ToInt32(_y[1]);
                
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }
    }
}