using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LinqXml
{
   public partial class DataStoreConfigurationHandler : Component
   {
      public DataStoreConfigurationHandler()
      {
         InitializeComponent( );
         InitializeLoadBackgroundWorkerComponent( );
      }
      public DataStoreConfigurationHandler( IContainer container )
      {
         container.Add( this );
         this.InitializeComponent( );
         InitializeLoadBackgroundWorkerComponent( );
      }

      public void Load( XElement e ) { this.LoadBackgroundWorker.RunWorkerAsync( e ); }
      public bool IsBusyLoad { get { return this.LoadBackgroundWorker.IsBusy; } }
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
            return;
         XElement argument = e.Argument as XElement; // get argument...
         if( !this.LoadBackgroundWorker.CancellationPending )
         {
            List<DataStore> list = new List<DataStore>( );
            IEnumerable<XElement> dsColl = argument.Elements( "ds" );
            int total = dsColl.Count<XElement>( );
            for( int i = 0; i < total; i++ )
            {
               if( !this.LoadBackgroundWorker.CancellationPending )
               {
                  XElement elementAt = dsColl.ElementAt<XElement>( i );
                  DataStore o = DataStore.GetPoco( elementAt );
                  list.Add( o );
                  int value = (i + 1) * (100 / total);
                  this.LoadBackgroundWorker.ReportProgress( value, total );
               }
               else
               {
                  this.LoadBackgroundWorker.ReportProgress( 0 );
                  return;
               }
            }
            e.Result = list; // return result...
            e.Cancel = false;
         }
      }

      private void LoadBackgroundWorker_ProgressChanged( object sender, ProgressChangedEventArgs e )
      {
         if( this.LoadProgressEvent == null )
            return;
         LoadProgressEventArgs args = new LoadProgressEventArgs( e );
         this.LoadProgressEvent?.Invoke( this, args );
      }

      private void LoadBackgroundWorker_RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e )
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
            return;
         LoadCompletedEventArgs args = new LoadCompletedEventArgs( e );
         this.LoadCompletedEvent?.Invoke( this, args );
      }

      #region --- LoadProgress EVENTS + HANDLERS + EXCEPTIONS ---
      public delegate void LoadProgressEventHandler( object sender, LoadProgressEventArgs ea );
      public event LoadProgressEventHandler LoadProgressEvent;
      public class LoadProgressEventArgs : System.EventArgs
      {
         private ProgressChangedEventArgs e;

         public LoadProgressEventArgs( ProgressChangedEventArgs e )
         {
            this.e = e;
         }
         public bool Cancel { get; set; }
         //
         // Summary:
         //     Gets the asynchronous task progress percentage.
         //
         // Returns:
         //     A percentage value indicating the asynchronous task progress.
         public int ProgressPercentage { get { return this.e.ProgressPercentage; } }
         //
         // Summary:
         //     Gets a unique user state.
         //
         // Returns:
         //     A unique System.Object indicating the user state.
         public object UserState { get { return this.e.UserState; } }
         public LoadProgressException Exception { get; set; }
      }
      //
      [System.Serializable]
      public class LoadProgressException : System.Exception
      {
         public LoadProgressException() : base( ) { }

         public LoadProgressException( string message ) : base( message ) { }

         public LoadProgressException( string format, params object[ ] args )
             : base( string.Format( format, args ) ) { }

         public LoadProgressException( string message, System.Exception innerException )
             : base( message, innerException ) { }

         public LoadProgressException( string format, System.Exception innerException, params object[ ] args )
             : base( string.Format( format, args ), innerException ) { }

         protected LoadProgressException( System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context )
             : base( info, context ) { }
      }
      #endregion

      #region --- LoadCompleted EVENTS + HANDLERS + EXCEPTIONS ---
      public delegate void LoadCompletedEventHandler( object sender, LoadCompletedEventArgs ea );
      public event LoadCompletedEventHandler LoadCompletedEvent;
      public class LoadCompletedEventArgs : System.EventArgs
      {
         private RunWorkerCompletedEventArgs e;

         public LoadCompletedEventArgs( RunWorkerCompletedEventArgs e )
         {
            this.e = e;
            if( this.e.Error != null )
            {
               this.Exception = new LoadCompletedException( "", this.e.Error );
            }
         }

         public bool Cancelled { get { return this.e.Cancelled; } }
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
         public object Result { get { return this.e?.Result; } }
         //
         // Summary:
         //     Gets a value that represents the user state.
         //
         // Returns:
         //     An System.Object representing the user state.
         [Browsable( false )]
         [EditorBrowsable( EditorBrowsableState.Never )]
         public object UserState { get { return this.e?.UserState; } }
         public LoadCompletedException Exception { get; set; }
      }
      //
      [System.Serializable]
      public class LoadCompletedException : System.Exception
      {
         public LoadCompletedException() : base( ) { }

         public LoadCompletedException( string message ) : base( message ) { }

         public LoadCompletedException( string format, params object[ ] args )
             : base( string.Format( format, args ) ) { }

         public LoadCompletedException( string message, System.Exception innerException )
             : base( message, innerException ) { }

         public LoadCompletedException( string format, System.Exception innerException, params object[ ] args )
             : base( string.Format( format, args ), innerException ) { }

         protected LoadCompletedException( System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context )
             : base( info, context ) { }
      }
      #endregion

      #endregion

   }
}
