using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Linq;

namespace LinqXml
{
   public partial class DataStoreConfigurationManager : Component
   {
      public DataStoreConfigurationManager()
      {
         this.InitializeComponent( );
      }

      public DataStoreConfigurationManager( IContainer container )
      {
         container.Add( this );
         this.InitializeComponent( );
         this.InitializeLoadBackgroundWorkerComponent( );
         this.InitializeOthersComponent( );
      }

      // ----------------------------------------------------------------------------
      public void Load( XElement e )
      {
         this.LoadBackgroundWorker.RunWorkerAsync( e );
      }

      public bool IsBusyLoad
      {
         get
         {
            return this.LoadBackgroundWorker.IsBusy;
         }
      }

      public void CancelLoad()
      {
         if( this.IsBusyLoad )
         {
            this.LoadBackgroundWorker.CancelAsync( );
         }
      }

      #region --- Load BackgroundWorker Init, Events, Handlers & Exceptions... ---

      private System.ComponentModel.BackgroundWorker LoadBackgroundWorker;

      private void InitializeLoadBackgroundWorkerComponent()
      {
         this.LoadBackgroundWorker = new System.ComponentModel.BackgroundWorker( );
         this.LoadBackgroundWorker.WorkerReportsProgress = true;
         this.LoadBackgroundWorker.WorkerSupportsCancellation = true;
         this.LoadBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler( this.LoadBackgroundWorker_DoWork );
         this.LoadBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler( this.LoadBackgroundWorker_ProgressChanged );
         this.LoadBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler( this.LoadBackgroundWorker_RunWorkerCompleted );
      }

      private void LoadBackgroundWorker_DoWork( object sender, DoWorkEventArgs e )
      {
         e.Cancel = true;
         this.LoadBackgroundWorker.ReportProgress( 0 );
         if( !(e.Argument is XElement) )
         {
            return;
         }

         XElement cfgElement = e.Argument as XElement; // get argument...
         if( !this.LoadBackgroundWorker.CancellationPending )
         {
            XElement dsCfgElement = cfgElement.Element( "dsCfg" );
            XElement stgDirElement = dsCfgElement.Element( "stgDir" );
            {
               XElement dsCollElement = dsCfgElement.Element( "dsColl" );
               this.dataStoreConfigurationHandler.Load( dsCollElement );
            }
            {
               XElement csCollElement = cfgElement.Element( "csColl" );
               this.connectionStringHandler.Load( csCollElement );
               this.sysConnectionStringHandler.Load( );
            }
            this.timer = new System.Threading.Timer( this.timerTick,
                                                    null,
                                                    500,
                                                    System.Threading.Timeout.Infinite );
            for( int i = 0; i < 10; i++ )
            {
               if( !this.isAnyComponentsBusy )
               {
                  this.LoadBackgroundWorker.ReportProgress( 100 );
                  e.Cancel = false;
                  e.Result = 1234567890;
                  return;
               }
               int percentage = this.dataStoreHandlerProgressPercentage +
                  this.connectionStringHandlerProgressPercentage +
                  this.systemConnectionStringHandlerProgressPercentage;
               this.LoadBackgroundWorker.ReportProgress( percentage/3 );
               System.Threading.Thread.Sleep( 1000 );
            }
         }
      }

      private System.Threading.Timer timer;
      private ulong timerCounter = 0;
      private bool isAnyComponentsBusy = true;

      // This runs on a pooled thread
      private void timerTick( object data )
      {
         this.timerCounter++;
         this.isAnyComponentsBusy = this.dataStoreConfigurationHandler.IsBusyLoad ||
            this.connectionStringHandler.IsBusyLoad ||
            this.sysConnectionStringHandler.IsBusyLoad
            ;
         if( this.isAnyComponentsBusy )
         {
            this.timer.Change( 500, System.Threading.Timeout.Infinite );
         }
      }

      private void LoadBackgroundWorker_ProgressChanged( object sender,
                                                        ProgressChangedEventArgs e )
      {
         if( this.LoadProgressEvent == null )
         {
            return;
         }

         LoadProgressEventArgs args = new LoadProgressEventArgs( e );
         this.LoadProgressEvent?.Invoke( this, args );
      }

      private void LoadBackgroundWorker_RunWorkerCompleted( object sender,
                                                           RunWorkerCompletedEventArgs e )
      {
         if( e.Cancelled )
         {
            // "Process was cancelled";
         }
         else if( e.Error != null )
         {
            // "There was an error running the process. The thread aborted";
         }
         else
         {
            // "Process was completed";
         }
         if( this.LoadCompletedEvent == null )
         {
            return;
         }

         LoadCompletedEventArgs args = new LoadCompletedEventArgs( e );
         this.LoadCompletedEvent?.Invoke( this, args );
      }

      #region --- LoadProgress EVENTS + HANDLERS + EXCEPTIONS ---
      public delegate void LoadProgressEventHandler( object sender,
                                                    LoadProgressEventArgs ea );

      public event LoadProgressEventHandler LoadProgressEvent;

      public class LoadProgressEventArgs : System.EventArgs
      {
         private ProgressChangedEventArgs e;

         public LoadProgressEventArgs( ProgressChangedEventArgs e )
         {
            this.e = e;
         }

         public bool Cancel
         {
            get; set;
         }

         //
         // Summary:
         //     Gets the asynchronous task progress percentage.
         //
         // Returns:
         //     A percentage value indicating the asynchronous task progress.
         public int ProgressPercentage
         {
            get
            {
               return this.e.ProgressPercentage;
            }
         }

         //
         // Summary:
         //     Gets a unique user state.
         //
         // Returns:
         //     A unique System.Object indicating the user state.
         public object UserState
         {
            get
            {
               return this.e.UserState;
            }
         }

         public LoadProgressException Exception
         {
            get; set;
         }
      }

      //
      [System.Serializable]
      public class LoadProgressException : System.Exception
      {
         public LoadProgressException() : base( )
         {
         }

         public LoadProgressException( string message ) : base( message )
         {
         }

         public LoadProgressException( string format, params object[ ] args ) : base( string.Format( format,
                                                                                                 args ) )
         {
         }

         public LoadProgressException( string message,
                                      System.Exception innerException ) : base( message,
                                                                              innerException )
         {
         }

         public LoadProgressException( string format,
                                      System.Exception innerException,
                                      params object[ ] args ) : base( string.Format( format,
                                                                                  args ),
                                                                    innerException )
         {
         }

         protected LoadProgressException( System.Runtime.Serialization.SerializationInfo info,
                                         System.Runtime.Serialization.StreamingContext context ) : base( info,
                                                                                                       context )
         {
         }
      }
      #endregion

      #region --- LoadCompleted EVENTS + HANDLERS + EXCEPTIONS ---
      public delegate void LoadCompletedEventHandler( object sender,
                                                     LoadCompletedEventArgs ea );

      public event LoadCompletedEventHandler LoadCompletedEvent;

      public class LoadCompletedEventArgs : System.EventArgs
      {
         private RunWorkerCompletedEventArgs e;

         public LoadCompletedEventArgs( RunWorkerCompletedEventArgs e )
         {
            this.e = e;
            if( this.e.Error != null )
            {
               this.Exception = new LoadCompletedException( string.Empty,
                                                           this.e.Error );
            }
         }

         public bool Cancelled
         {
            get
            {
               return this.e.Cancelled;
            }
         }

         //
         // Summary:
         //     Gets a value that represents the result of an asynchronous operation.
         //
         // Returns:
         //     An System.Object representing the result of an asynchronous operation.
         //
         // Exceptions:
         //   T:System.Reflection.TargetInvocationException:
         //     System.ComponentModel.AsyncCompletedEventArgs.Error is not null. The System.Exception.InnerException
         //     property holds a reference to System.ComponentModel.AsyncCompletedEventArgs.Error.
         //
         //   T:System.InvalidOperationException:
         //     System.ComponentModel.AsyncCompletedEventArgs.Cancelled is true.
         public object Result
         {
            get
            {
               return this.e?.Result;
            }
         }

         //
         // Summary:
         //     Gets a value that represents the user state.
         //
         // Returns:
         //     An System.Object representing the user state.
         [Browsable( false )]
         [EditorBrowsable( EditorBrowsableState.Never )]
         public object UserState
         {
            get
            {
               return this.e?.UserState;
            }
         }

         public LoadCompletedException Exception
         {
            get; set;
         }
      }

      //
      [System.Serializable]
      public class LoadCompletedException : System.Exception
      {
         public LoadCompletedException() : base( )
         {
         }

         public LoadCompletedException( string message ) : base( message )
         {
         }

         public LoadCompletedException( string format, params object[ ] args ) : base( string.Format( format,
                                                                                                  args ) )
         {
         }

         public LoadCompletedException( string message,
                                       System.Exception innerException ) : base( message,
                                                                               innerException )
         {
         }

         public LoadCompletedException( string format,
                                       System.Exception innerException,
                                       params object[ ] args ) : base( string.Format( format,
                                                                                   args ),
                                                                     innerException )
         {
         }

         protected LoadCompletedException( System.Runtime.Serialization.SerializationInfo info,
                                          System.Runtime.Serialization.StreamingContext context ) : base( info,
                                                                                                        context )
         {
         }
      }
      #endregion

      #endregion

      // ----------------------------------------------------------------------------
      // ----------------------------------------------------------------------------
      // ----------------------------------------------------------------------------
      private SystemConnectionStringHandler sysConnectionStringHandler;
      private ConnectionStringHandler connectionStringHandler;
      private DataStoreConfigurationHandler dataStoreConfigurationHandler;
      private int dataStoreHandlerProgressPercentage;
      private int connectionStringHandlerProgressPercentage;
      private int systemConnectionStringHandlerProgressPercentage;

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

      private void connectionStringHandler_LoadProgressEvent( object sender,
                                                             ConnectionStringHandler.LoadProgressEventArgs ea )
      {
         this.connectionStringHandlerProgressPercentage = ea.ProgressPercentage;
      }

      private void connectionStringHandler_LoadCompletedEvent( object sender,
                                                              ConnectionStringHandler.LoadCompletedEventArgs ea )
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

      private void systemConnectionStringHandler_ProgressUpdateEvent( object sender,
                                                                     SystemConnectionStringHandler.LoadProgressEventArgs ea )
      {
         this.systemConnectionStringHandlerProgressPercentage = ea.ProgressPercentage;
      }

      private void systemConnectionStringHandler_LoadCompletedEvent( object sender,
                                                                    SystemConnectionStringHandler.LoadCompletedEventArgs ea )
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

      private void dataStoreConfigurationHandler_LoadProgressEvent( object sender,
                                                                   DataStoreConfigurationHandler.LoadProgressEventArgs ea )
      {
         this.dataStoreHandlerProgressPercentage = ea.ProgressPercentage;
      }

      private void dataStoreConfigurationHandler_LoadCompletedEvent( object sender,
                                                                    DataStoreConfigurationHandler.LoadCompletedEventArgs ea )
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

      ////////////////////////////////////////////////////////////////////////////////////
      ////////////////////////////////////////////////////////////////////////////////////
      ////////////////////////////////////////////////////////////////////////////////////
      ////////////////////////////////////////////////////////////////////////////////////

      //
      #region --- ConfigLoaded EVENTS + HANDLERS + EXCEPTIONS ---
      public delegate void ConfigLoadedEventHandler( object sender,
                                                    ConfigLoadedEventArgs ea );

      public event ConfigLoadedEventHandler ConfigLoadedEvent;

      public class ConfigLoadedEventArgs : System.EventArgs
      {
         public bool Cancel
         {
            get; set;
         }

         public string Filename
         {
            get; set;
         }

         public ConfigLoadedException Exception
         {
            get; set;
         }
      }

      //
      [System.Serializable]
      public class ConfigLoadedException : System.Exception
      {
         public ConfigLoadedException() : base( )
         {
         }

         public ConfigLoadedException( string message ) : base( message )
         {
         }

         public ConfigLoadedException( string format, params object[ ] args ) : base( string.Format( format,
                                                                                                 args ) )
         {
         }

         public ConfigLoadedException( string message,
                                      System.Exception innerException ) : base( message,
                                                                              innerException )
         {
         }

         public ConfigLoadedException( string format,
                                      System.Exception innerException,
                                      params object[ ] args ) : base( string.Format( format,
                                                                                  args ),
                                                                    innerException )
         {
         }

         protected ConfigLoadedException( System.Runtime.Serialization.SerializationInfo info,
                                         System.Runtime.Serialization.StreamingContext context ) : base( info,
                                                                                                       context )
         {
         }
      }
      //
      //         ConfigLoadedEventArgs args1 = new ConfigLoadedEventArgs( );
      //         args1.Filename = filename;
      //         this.ConfigLoadedEvent?.Invoke( this, args2 );
      //
      #endregion
   }
}
