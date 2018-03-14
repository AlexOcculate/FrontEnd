using System;
using System.Linq;

namespace TimerTest
{
   public class MultithreadedTimer
   {
      public static void EntryPoint()
      {
         // First interval = 5000ms; subsequent intervals = 1000ms
         //tmr = new System.Threading.Timer( Tick, "tick...", 5000, 1000 );
         timer.Change( 5000, 1000 );

         System.Threading.Thread.Sleep( 10 * 1000 );
         timer.Dispose( );         // This both stops the timer and cleans up.
      }

      private static System.Threading.Timer timer = new System.Threading.Timer( Tick,
                                                                             timerState,
                                                                             System.Threading.Timeout.Infinite,
                                                                             System.Threading.Timeout.Infinite );
      private static ulong timerCounter = 0;
      private static object timerState = null;

      private static void Tick( object data )
      {
         timerCounter++;
         // This runs on a pooled thread
         Console.WriteLine( data + ":" + timerCounter );          // Writes "tick..."
      }
   }
}
