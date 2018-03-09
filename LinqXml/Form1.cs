using System;
using System.Linq;
using System.Windows.Forms;

namespace LinqXml
{
   public partial class Form1 : Form
   {
      public Form1()
      {
         this.InitializeComponent( );
         //this.systemConnectionStringHandler1.Load( );
      }

      private void systemConnectionStringHandler1_ProgressUpdateEvent( object sender, SystemConnectionStringHandler.LoadProgressEventArgs ea )
      {
      }

      private void systemConnectionStringHandler1_LoadCompletedEvent( object sender, SystemConnectionStringHandler.LoadCompletedEventArgs ea )
      {
         if( ea.Cancelled )
         {
            // "Process was cancelled";
         }
         else if( ea.Exception != null )
         {
            // "There was an error running the process. The thread aborted";
         }
         else
         {
            // "Process was completed";
            System.Collections.Generic.List<ConnectionString> list=  ea.Result as System.Collections.Generic.List<ConnectionString>;
         }
      }
   }
}
