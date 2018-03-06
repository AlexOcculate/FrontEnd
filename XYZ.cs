#define LOAD_DATASTORE
#define SAVE_DATASTORE
#define CREATE_DATASTORE
#define UPDATE_DATASTORE
#define DELETE_DATASTORE
#define EXPORT_DATASTORE
#define IMPORT_DATASTORE

namespace FrontEnd
{
   using System.Linq;


   // -------------------------------------------------------------------------

   public partial class XYZ
   {
#if LOAD_DATASTORE
      #region --- LOADING / LOADED EVENTS + HANDLERS ---
      /// <summary>
      /// Delegate for the LoadingDataStores event.
      /// </summary>
      public delegate void LoadingDataStoresHandler( object sender, LoadingDataStoresArgs ea );
      /// <summary>
      /// Arguments for the LoadingDataStores event.
      /// </summary>
      public class LoadingDataStoresArgs : System.EventArgs
      {
         public bool Cancel = false;
      }
      /// <summary>
      /// Delegate for the LoadedDataStores event.
      /// </summary>
      public delegate void LoadedDataStoresHandler( object sender, LoadedDataStoresArgs ea );
      /// <summary>
      /// Arguments for the LoadedDataStores event.
      /// </summary>
      public class LoadedDataStoresArgs : System.EventArgs
      {
         public bool Canceled = false;

         public LoadedDataStoresArgs( LoadingDataStoresArgs args1 )
         {
            this.Canceled = args1.Cancel;
         }
      }
      public event LoadingDataStoresHandler LoadingDataStores;
      public event LoadedDataStoresHandler LoadedDataStores;
      private void LOAD_DataStores()
      {
         LoadingDataStoresArgs args1 = new LoadingDataStoresArgs( );
         this.LoadingDataStores?.Invoke( this, args1 );
         if( !args1.Cancel )
         {

         }
         // LOADING...
         LoadedDataStoresArgs args2 = new LoadedDataStoresArgs( args1 );
         this.LoadedDataStores?.Invoke( this, args2 );
      }
      #endregion
#endif

#if SAVE_DATASTORE
      #region --- SAVING / SAVED EVENTS ---
      /// <summary>
      /// Delegate for the SavingDataStores event.
      /// </summary>
      public delegate void SavingDataStoresHandler( object sender, SavingDataStoresArgs ea );
      /// <summary>
      /// Arguments for the SavingDataStores event.
      /// </summary>
      public class SavingDataStoresArgs : System.EventArgs
      {
         public bool Cancel = false;
      }
      /// <summary>
      /// Delegate for the SavedDataStores event.
      /// </summary>
      public delegate void SavedDataStoresHandler( object sender, SavedDataStoresArgs ea );
      /// <summary>
      /// Arguments for the SavedDataStores event.
      /// </summary>
      public class SavedDataStoresArgs : System.EventArgs
      {
         public bool Canceled = false;

         public SavedDataStoresArgs( SavingDataStoresArgs args1 )
         {
            this.Canceled = args1.Cancel;
         }
      }
      public event SavingDataStoresHandler SavingDataStores;
      public event SavedDataStoresHandler SavedDataStores;
      private void SAVE_DataStores()
      {
         SavingDataStoresArgs args1 = new SavingDataStoresArgs( );
         this.SavingDataStores?.Invoke( this, args1 );
         if( !args1.Cancel )
         {

         }
         // SAVING...
         SavedDataStoresArgs args2 = new SavedDataStoresArgs( args1 );
         this.SavedDataStores?.Invoke( this, args2 );
      }
      #endregion
#endif

#if CREATE_DATASTORE
      #region --- CREATING / CREATED EVENTS ---
      /// <summary>
      /// Delegate for the CreatingDataStore event.
      /// </summary>
      public delegate void CreatingDataStoreHandler( object sender, CreatingDataStoreArgs ea );
      /// <summary>
      /// Arguments for the CreatingDataStore event.
      /// </summary>
      public class CreatingDataStoreArgs : System.EventArgs
      {
         public bool Cancel = false;
      }
      /// <summary>
      /// Delegate for the CreatedDataStore event.
      /// </summary>
      public delegate void CreatedDataStoreHandler( object sender, CreatedDataStoreArgs ea );
      /// <summary>
      /// Arguments for the CreatedDataStore event.
      /// </summary>
      public class CreatedDataStoreArgs : System.EventArgs
      {
         public bool Canceled = false;

         public CreatedDataStoreArgs( CreatingDataStoreArgs args1 )
         {
            this.Canceled = args1.Cancel;
         }
      }
      public event CreatingDataStoreHandler CreatingDataStore;
      public event CreatedDataStoreHandler CreatedDataStore;
      private void CREATE_DataStore()
      {
         CreatingDataStoreArgs args1 = new CreatingDataStoreArgs( );
         this.CreatingDataStore?.Invoke( this, args1 );
         if( !args1.Cancel )
         {

         }
         // Creating...
         CreatedDataStoreArgs args2 = new CreatedDataStoreArgs( args1 );
         this.CreatedDataStore?.Invoke( this, args2 );
      }
      #endregion
#endif

#if UPDATE_DATASTORE
      #region --- UPDATING / UPDATE EVENTS ---
      /// <summary>
      /// Delegate for the UpdatingDataStore event.
      /// </summary>
      public delegate void UpdatingDataStoreHandler( object sender, UpdatingDataStoreArgs ea );
      /// <summary>
      /// Arguments for the UpdatingDataStore event.
      /// </summary>
      public class UpdatingDataStoreArgs : System.EventArgs
      {
         public bool Cancel = false;
      }
      /// <summary>
      /// Delegate for the UpdatedDataStore event.
      /// </summary>
      public delegate void UpdatedDataStoreHandler( object sender, UpdatedDataStoreArgs ea );
      /// <summary>
      /// Arguments for the UpdatedDataStore event.
      /// </summary>
      public class UpdatedDataStoreArgs : System.EventArgs
      {
         public bool Canceled = false;

         public UpdatedDataStoreArgs( UpdatingDataStoreArgs args1 )
         {
            this.Canceled = args1.Cancel;
         }
      }
      public event UpdatingDataStoreHandler UpdatingDataStore;
      public event UpdatedDataStoreHandler UpdatedDataStore;
      private void UPDATE_DataStore()
      {
         UpdatingDataStoreArgs args1 = new UpdatingDataStoreArgs( );
         this.UpdatingDataStore?.Invoke( this, args1 );
         if( !args1.Cancel )
         {

         }
         // Creating...
         UpdatedDataStoreArgs args2 = new UpdatedDataStoreArgs( args1 );
         this.UpdatedDataStore?.Invoke( this, args2 );
      }
      #endregion
#endif

#if DELETE_DATASTORE
      #region --- DELETING / DELETED EVENTS ---
      /// <summary>
      /// Delegate for the DeletingDataStore event.
      /// </summary>
      public delegate void DeletingDataStoreHandler( object sender, DeletingDataStoreArgs ea );
      /// <summary>
      /// Arguments for the DeletingDataStore event.
      /// </summary>
      public class DeletingDataStoreArgs : System.EventArgs
      {
         public bool Cancel = false;
      }
      /// <summary>
      /// Delegate for the DeletedDataStore event.
      /// </summary>
      public delegate void DeletedDataStoreHandler( object sender, DeletedDataStoreArgs ea );
      /// <summary>
      /// Arguments for the DeletedDataStore event.
      /// </summary>
      public class DeletedDataStoreArgs : System.EventArgs
      {
         public bool Canceled = false;

         public DeletedDataStoreArgs( DeletingDataStoreArgs args1 )
         {
            this.Canceled = args1.Cancel;
         }
      }
      public event DeletingDataStoreHandler DeletingDataStore;
      public event DeletedDataStoreHandler DeletedDataStore;
      private void DELETE_DataStore()
      {
         DeletingDataStoreArgs args1 = new DeletingDataStoreArgs( );
         this.DeletingDataStore?.Invoke( this, args1 );
         if( !args1.Cancel )
         {

         }
         // Creating...
         DeletedDataStoreArgs args2 = new DeletedDataStoreArgs( args1 );
         this.DeletedDataStore?.Invoke( this, args2 );
      }
      #endregion
#endif

#if EXPORT_DATASTORE
      #region --- EXPORTING / EXPORTED EVENTS ---
      /// <summary>
      /// Delegate for the ExportingDataStore event.
      /// </summary>
      public delegate void ExportingDataStoreHandler( object sender, ExportingDataStoreArgs ea );
      /// <summary>
      /// Arguments for the ExportingDataStore event.
      /// </summary>
      public class ExportingDataStoreArgs : System.EventArgs
      {
         public bool Cancel = false;
      }

      /// <summary>
      /// Delegate for the ExportedDataStore event.
      /// </summary>
      public delegate void ExportedDataStoreHandler( object sender, ExportedDataStoreArgs ea );
      /// <summary>
      /// Arguments for the ExportedDataStore event.
      /// </summary>
      public class ExportedDataStoreArgs : System.EventArgs
      {
         public bool Canceled = false;

         public ExportedDataStoreArgs( ExportingDataStoreArgs args1 )
         {
            this.Canceled = args1.Cancel;
         }
      }
      #endregion
#endif

      public XYZ()
      {
      }
      public void Trigger()
      {
         this.LOAD_DataStores( );
         this.SAVE_DataStores( );
         this.CREATE_DataStore( );
         this.UPDATE_DataStore( );
         this.DELETE_DataStore( );
      }

   }
}
