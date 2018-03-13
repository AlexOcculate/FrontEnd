using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqXml
{
   public partial class DataStoreConfigurationManager : Component
   {
      public DataStoreConfigurationManager()
      {
         InitializeComponent( );
      }

      public DataStoreConfigurationManager( IContainer container )
      {
         container.Add( this );
         InitializeComponent( );
      }

      // ----------------------------------------------------------------------------
      private SystemConnectionStringHandler sysConnectionStringHandler;
      private ConnectionStringHandler connectionStringHandler;
      private DataStoreConfigurationHandler dataStoreConfigurationHandler;
      private void ResetOthersComponent()
      {
         // sysConnectionStringHandler
         this.sysConnectionStringHandler.LoadProgressEvent -= this.systemConnectionStringHandler_ProgressUpdateEvent;
         this.sysConnectionStringHandler.LoadCompletedEvent -= this.systemConnectionStringHandler_LoadCompletedEvent;
         this.sysConnectionStringHandler = null;
         // connectionStringHandler
         this.connectionStringHandler.LoadProgressEvent -= this.connectionStringHandler_LoadProgressEvent;
         this.connectionStringHandler.LoadCompletedEvent -= this.connectionStringHandler_LoadCompletedEvent;
         this.connectionStringHandler = null;
         // dataStoreConfigurationHandler
         this.dataStoreConfigurationHandler.LoadProgressEvent -= this.dataStoreConfigurationHandler_LoadProgressEvent;
         this.dataStoreConfigurationHandler.LoadCompletedEvent -= this.dataStoreConfigurationHandler_LoadCompletedEvent;
         this.dataStoreConfigurationHandler = null;
      }
      private void InitializeOthersComponent()
      {
         this.sysConnectionStringHandler = new LinqXml.SystemConnectionStringHandler( this.components );
         this.connectionStringHandler = new LinqXml.ConnectionStringHandler( this.components );
         this.dataStoreConfigurationHandler = new LinqXml.DataStoreConfigurationHandler( this.components );
         // 
         // sysConnectionStringHandler
         // 
         this.sysConnectionStringHandler.LoadProgressEvent += new LinqXml.SystemConnectionStringHandler.LoadProgressEventHandler( this.systemConnectionStringHandler_ProgressUpdateEvent );
         this.sysConnectionStringHandler.LoadCompletedEvent += new LinqXml.SystemConnectionStringHandler.LoadCompletedEventHandler( this.systemConnectionStringHandler_LoadCompletedEvent );
         // 
         // connectionStringHandler
         // 
         this.connectionStringHandler.LoadProgressEvent += new LinqXml.ConnectionStringHandler.LoadProgressEventHandler( this.connectionStringHandler_LoadProgressEvent );
         this.connectionStringHandler.LoadCompletedEvent += new LinqXml.ConnectionStringHandler.LoadCompletedEventHandler( this.connectionStringHandler_LoadCompletedEvent );
         // 
         // dataStoreConfigurationHandler
         // 
         this.dataStoreConfigurationHandler.LoadProgressEvent += new LinqXml.DataStoreConfigurationHandler.LoadProgressEventHandler( this.dataStoreConfigurationHandler_LoadProgressEvent );
         this.dataStoreConfigurationHandler.LoadCompletedEvent += new LinqXml.DataStoreConfigurationHandler.LoadCompletedEventHandler( this.dataStoreConfigurationHandler_LoadCompletedEvent );
      }
      // ----------------------------------------------------------------------------
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
      // ----------------------------------------------------------------------------
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
      // ----------------------------------------------------------------------------
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
