using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LinqXml
{
   public partial class Form1 : Form
   {
      public Form1()
      {
         this.InitializeComponent( );
      }

      private void Form1_Load( object sender, EventArgs e )
      {
         this.sysConnectionStringHandler.Load( );
         {
            XDocument doc = LinqXmlTest.GetDsCfgDoc( );
            {
               IEnumerable<XElement> csList = doc.Root.Element( "csColl" ).Descendants( "cs" );
               XElement csColl = doc.Root.Element( "csColl" );
               //using( ConnectionStringHandler x = new ConnectionStringHandler( ) )
               //{
               //   x.Load( csColl );
               //}
               this.connectionStringHandler.Load( csColl );
            }
            {
               IEnumerable<XElement> dsList = doc.Root.Element( "dsCfg" ).Element( "dsColl" ).Descendants( "ds" );
               XElement dsColl = doc.Root.Element( "dsCfg" ).Element( "dsColl" );
               //using( DataStoreConfigurationHandler x = new DataStoreConfigurationHandler( ) )
               //{
               //   x.Load( dsColl );
               //}
               this.dataStoreConfigurationHandler.Load( dsColl );
            }
         }
      }

      private List<ConnectionString> csList;
      private void connectionStringHandler_LoadProgressEvent( object sender, ConnectionStringHandler.LoadProgressEventArgs ea )
      {
      }
      private void connectionStringHandler_LoadCompletedEvent( object sender, ConnectionStringHandler.LoadCompletedEventArgs ea )
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
            this.csList = ea.Result as List<ConnectionString>;
         }
      }

      private List<ConnectionString> sysCsList;
      private void systemConnectionStringHandler_ProgressUpdateEvent( object sender, SystemConnectionStringHandler.LoadProgressEventArgs ea )
      {
      }
      private void systemConnectionStringHandler_LoadCompletedEvent( object sender, SystemConnectionStringHandler.LoadCompletedEventArgs ea )
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
            this.sysCsList = ea.Result as List<ConnectionString>;
         }
      }

      private List<DataStore> dsList;
      private void dataStoreConfigurationHandler_LoadProgressEvent( object sender, DataStoreConfigurationHandler.LoadProgressEventArgs ea )
      {

      }
      private void dataStoreConfigurationHandler_LoadCompletedEvent( object sender, DataStoreConfigurationHandler.LoadCompletedEventArgs ea )
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
            this.dsList = ea.Result as List<DataStore>;
         }
      }
   }
}
