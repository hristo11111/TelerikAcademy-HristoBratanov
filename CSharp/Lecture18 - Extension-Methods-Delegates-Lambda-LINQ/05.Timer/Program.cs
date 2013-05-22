//Using delegates write a class Timer that can execute certain method at each t seconds.

﻿using System;
using System.Linq;
using System.Diagnostics;

public delegate void TimerForSeconds(int seconds);

public static class Timer
{
    public static void SendMessage(int seconds)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        while (true)
        {
            if (sw.ElapsedMilliseconds == seconds * 1000)
            {
                Console.WriteLine("Surprise");
                sw.Restart();
            }
        }
    }
    static void Main()
    {
        Console.WriteLine("enter interval: ");
        int interval = Int32.Parse(Console.ReadLine());
        TimerForSeconds timer = new TimerForSeconds(SendMessage);
        timer(interval);
    }
}

//second version

//  int interval = Int32.Parse(Console.ReadLine());
//  Stopwatch sw = new Stopwatch();
//  sw.Start();
//  Func<int, bool> sleep = (x) =>
//  {
//      if (x * 1000 == sw.ElapsedMilliseconds)
//          return true;
//      else
//          return false;
//  };
//  while (true)
//  {
//      if (sleep(interval) == true)
//      {
//          Console.WriteLine("surprise");
//          sw.Restart();
//      }
//  }