using System;
using System.Linq;
using System.Windows.Forms;

namespace LinqXml
{
   internal static class Program
   {
      [System.Runtime.InteropServices.DllImport( "kernel32.dll", SetLastError = true )]
      [return: System.Runtime.InteropServices.MarshalAs( System.Runtime.InteropServices.UnmanagedType.Bool )]
      static extern bool AllocConsole();

      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      private static void Main()
      {
         AllocConsole( );
         Application.EnableVisualStyles( );
         Application.SetCompatibleTextRenderingDefault( false );
         {
            LinqXml.EntryPoint( );
         }
//         Application.Run( new Form1( ) );
      }
   }
}
