using System;
using System.ComponentModel;
using System.Linq;

namespace LinqXml
{
   public partial class SystemConnectionStringHandler : Component
   {
      public SystemConnectionStringHandler()
      {
         this.InitializeComponent( );
      }

      public SystemConnectionStringHandler( IContainer container )
      {
         container.Add( this );
         this.InitializeComponent( );
      }

      public void Load() { this.backgroundWorker.RunWorkerAsync( ); }
      public bool IsBusy { get { return this.backgroundWorker.IsBusy; } }
      public void Cancel()
      {
         if( this.IsBusy )
         {
            this.backgroundWorker.CancelAsync( );
         }
      }

      #region --- ProgressUpdate EVENTS + HANDLERS + EXCEPTIONS ---
      public delegate void ProgressUpdateEventHandler( object sender, ProgressUpdateEventArgs ea );
      public event ProgressUpdateEventHandler ProgressUpdateEvent;
      public class ProgressUpdateEventArgs : System.EventArgs
      {
         private ProgressChangedEventArgs e;

         public ProgressUpdateEventArgs( ProgressChangedEventArgs e )
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
         public ProgressUpdateException Exception { get; set; }
      }
      //
      [System.Serializable]
      public class ProgressUpdateException : System.Exception
      {
         public ProgressUpdateException() : base( ) { }

         public ProgressUpdateException( string message ) : base( message ) { }

         public ProgressUpdateException( string format, params object[ ] args )
             : base( string.Format( format, args ) ) { }

         public ProgressUpdateException( string message, System.Exception innerException )
             : base( message, innerException ) { }

         public ProgressUpdateException( string format, System.Exception innerException, params object[ ] args )
             : base( string.Format( format, args ), innerException ) { }

         protected ProgressUpdateException( System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context )
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

      #region --- BackgroundWorker Event Handlers... ---
      private void backgroundWorker_DoWork( object sender, DoWorkEventArgs e )
      {
         e.Cancel = true;
         this.backgroundWorker.ReportProgress( 0 );
         if( !this.backgroundWorker.CancellationPending )
         {
            System.Configuration.ConnectionStringSettingsCollection css = System.Configuration.ConfigurationManager.ConnectionStrings;
            System.Collections.Generic.List<ConnectionString> list = new System.Collections.Generic.List<ConnectionString>( );
            if( css != null )
            {
               for( int i = 0; i < css.Count; i++ )
               {
                  if( !this.backgroundWorker.CancellationPending )
                  {
                     ConnectionString o = new ConnectionString( )
                     {
                        Name = css[ i ].Name,
                        ProviderName = css[ i ].ProviderName,
                        String = css[ i ].ConnectionString
                     };
                     list.Add( o );
                     int value = (i + 1) * (100 / css.Count);
                     this.backgroundWorker.ReportProgress( value, css.Count );
                  }
                  else
                  {
                     this.backgroundWorker.ReportProgress( 0 );
                     return;
                  }
               }
               e.Result = list;
               e.Cancel = false;
            }
         }
      }

      private void backgroundWorker_ProgressChanged( object sender, ProgressChangedEventArgs e )
      {
         if( this.ProgressUpdateEvent == null )
            return;
         ProgressUpdateEventArgs args = new ProgressUpdateEventArgs( e );
         this.ProgressUpdateEvent?.Invoke( this, args );
      }

      private void backgroundWorker_RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e )
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
      #endregion
   }
}
