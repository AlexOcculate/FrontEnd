using System;
using System.Linq;

namespace LinqXml
{
   public partial class ConfigurationTestForm : DevExpress.XtraEditors.XtraForm
   {
      public ConfigurationTestForm()
      {
         this.InitializeComponent( );
         this.configurationView1.BeforeOpenFileEvent += this.ConfigurationView1_BeforeOpenFileEvent;
         this.configurationView1.AfterOpenFileEvent += this.ConfigurationView1_AfterOpenFileEvent;
         this.configurationView1.BeforeSaveAsFileEvent += this.ConfigurationView1_BeforeSaveAsFileEvent;
         this.configurationView1.AfterSaveAsFileEvent += this.ConfigurationView1_AfterSaveAsFileEvent;
         this.configurationView1.BeforeSaveFileEvent += this.ConfigurationView1_BeforeSaveFileEvent;
         this.configurationView1.AfterSaveFileEvent += this.ConfigurationView1_AfterSaveFileEvent;
         this.configurationView1.BeforeCloseFileEvent += this.ConfigurationView1_BeforeCloseFileEvent;
         this.configurationView1.AfterCloseFileEvent += this.ConfigurationView1_AfterCloseFileEvent;
         this.configurationView1.BeforeAddConnectionStringEvent += this.ConfigurationView1_BeforeAddConnectionStringEvent;
         this.configurationView1.AfterAddConnectionStringEvent += this.ConfigurationView1_AfterAddConnectionStringEvent;
         this.configurationView1.BeforeDelConnectionStringEvent += this.ConfigurationView1_BeforeDelConnectionStringEvent;
         this.configurationView1.AfterDelConnectionStringEvent += this.ConfigurationView1_AfterDelConnectionStringEvent;
         this.configurationView1.FocusedDataStoreChangedEvent += this.ConfigurationView1_FocusedDataStoreChangedEvent;
         this.configurationView1.FocusedConnectionStringChangedEvent += this.ConfigurationView1_FocusedConnectionStringChangedEvent;
         //
         this.configurationView1.SavedFileNameChangedEvent += this.ConfigurationView1_SavedFileNameChangedEvent;
         //
         this.configurationView1.AllowedAddAppCSEvent += this.ConfigurationView1_AllowedAddAppCSEvent;
         this.configurationView1.NotAllowedAddAppCSEvent += this.ConfigurationView1_NotAllowedAddAppCSEvent;
         //
         this.configurationView1.AllowedDelAppCSEvent += this.ConfigurationView1_AllowedDelAppCSEvent;
         this.configurationView1.NotAllowedDelAppCSEvent += this.ConfigurationView1_NotAllowedDelAppCSEvent;
         //
         this.configurationView1.AllowedAddDataStoreEvent += this.ConfigurationView1_AllowedAddDataStoreEvent;
         this.configurationView1.NotAllowedAddDataStoreEvent += this.ConfigurationView1_NotAllowedAddDataStoreEvent;
         //
         this.configurationView1.AllowedDelDataStoreEvent += this.ConfigurationView1_AllowedDelDataStoreEvent;
         this.configurationView1.NotAllowedDelDataStoreEvent += this.ConfigurationView1_NotAllowedDelDataStoreEvent;
         //
         this.configurationView1.AllowedToOpenFileEvent += this.ConfigurationView1_AllowedToOpenFileEvent;
         this.configurationView1.NotAllowedToOpenFileEvent += this.ConfigurationView1_NotAllowedToOpenFileEvent;
         //
         this.configurationView1.AllowedToSaveFileEvent += this.ConfigurationView1_AllowedToSaveFileEvent;
         this.configurationView1.NotAllowedToSaveFileEvent += this.ConfigurationView1_NotAllowedToSaveFileEvent;
         //
         this.configurationView1.AllowedToSaveAsFileEvent += this.ConfigurationView1_AllowedToSaveAsFileEvent;
         this.configurationView1.NotAllowedToSaveAsFileEvent += this.ConfigurationView1_NotAllowedToSaveAsFileEvent;
         //
         this.configurationView1.AllowedToCloseFileEvent += this.ConfigurationView1_AllowedToCloseFileEvent;
         this.configurationView1.NotAllowedToCloseFileEvent += this.ConfigurationView1_NotAllowedToCloseFileEvent;
         //
      }

      private void ConfigurationView1_AfterAddConnectionStringEvent( object sender, Control.ConfigurationView.AfterAddConnectionStringEventArgs ea )
      {
      }

      private void ConfigurationView1_BeforeAddConnectionStringEvent( object sender, Control.ConfigurationView.BeforeAddConnectionStringEventArgs ea )
      {
      }

      private void ConfigurationView1_SavedFileNameChangedEvent( object sender, Control.ConfigurationView.SavedFileNameChangedEventArgs args )
      {
         string x = nameof( ConfigurationTestForm );
         this.Text = $"{x} [{args.NewFilename}]";
      }

      private void ConfigurationView1_AllowedToSaveAsFileEvent( object sender )
      {
         this.saveAsBarButtonItem.Enabled = true;
      }

      private void ConfigurationView1_NotAllowedToSaveAsFileEvent( object sender )
      {
         this.saveAsBarButtonItem.Enabled = false;
      }

      private void ConfigurationView1_NotAllowedToSaveFileEvent( object sender )
      {
         this.saveBarButtonItem.Enabled = false;
      }

      private void ConfigurationView1_AllowedToSaveFileEvent( object sender )
      {
         this.saveBarButtonItem.Enabled = true;
      }

      private void ConfigurationView1_NotAllowedToOpenFileEvent( object sender )
      {
         this.openBarButtonItem.Enabled = false;
      }

      private void ConfigurationView1_AllowedToOpenFileEvent( object sender )
      {
         this.openBarButtonItem.Enabled = true;
      }

      private void ConfigurationView1_NotAllowedToCloseFileEvent( object sender )
      {
         this.closeBarButtonItem.Enabled = false;
      }

      private void ConfigurationView1_AllowedToCloseFileEvent( object sender )
      {
         this.closeBarButtonItem.Enabled = true;
      }

      private void ConfigurationView1_NotAllowedDelDataStoreEvent( object sender )
      {
         this.delDataStoreBarButtonItem.Enabled = false;
      }

      private void ConfigurationView1_AllowedDelDataStoreEvent( object sender )
      {
         this.delDataStoreBarButtonItem.Enabled = true;
      }

      private void ConfigurationView1_NotAllowedAddDataStoreEvent( object sender )
      {
         this.addDataStoreBarButtonItem.Enabled = false;
      }

      private void ConfigurationView1_AllowedAddDataStoreEvent( object sender )
      {
         this.addDataStoreBarButtonItem.Enabled = true;
      }

      private void ConfigurationView1_NotAllowedDelAppCSEvent( object sender )
      {
         this.delAppCSBarButtonItem.Enabled = false;
      }

      private void ConfigurationView1_AllowedDelAppCSEvent( object sender )
      {
         this.delAppCSBarButtonItem.Enabled = true;
      }

      private void ConfigurationView1_AllowedAddAppCSEvent( object sender )
      {
         this.addAppCSBarButtonItem.Enabled = true;
      }

      private void ConfigurationView1_NotAllowedAddAppCSEvent( object sender )
      {
         this.addAppCSBarButtonItem.Enabled = false;
      }

      //private void configurationView1_AllowedAddAppCSEvent( object sender )
      //{
      //   this.addAppCSBarButtonItem.Enabled = true;
      //}

      //private void configurationView1_NotAllowedAddAppCSEvent( object sender )
      //{
      //   this.addAppCSBarButtonItem.Enabled = false;
      //}

      private void ConfigurationView1_FocusedDataStoreChangedEvent( object sender, Control.ConfigurationView.FocusedDataStoreChangedEventArgs ea )
      {
         this.objnmStatusBarStaticItem.Caption = ea.DataStore.Name + " DataStore";
      }

      private void ConfigurationView1_FocusedConnectionStringChangedEvent( object sender, Control.ConfigurationView.FocusedConnectionStringChangedEventArgs ea )
      {
         this.objnmStatusBarStaticItem.Caption = ea.ConnectionString.Name + " ConnectionString";
      }

      private void ConfigurationView1_BeforeOpenFileEvent( object sender, Control.ConfigurationView.BeforeOpenFileEventArgs ea )
      {
         this.labelStatusBarStaticItem.Caption = ea.SuggestedFilename + " Opening...";
      }

      private void ConfigurationView1_AfterOpenFileEvent( object sender, Control.ConfigurationView.AfterOpenFileEventArgs ea )
      {
         this.labelStatusBarStaticItem.Caption = ea.args.OpenedFilename;
         if( ea.isOk )
         {
            this.objnmStatusBarStaticItem.Caption = " OPENED";
         }
         else
         {
            this.objnmStatusBarStaticItem.Caption = ea.args.Exception.InnerException.Message;
         }
      }

      private void ConfigurationView1_BeforeCloseFileEvent( object sender, Control.ConfigurationView.BeforeCloseFileEventArgs ea )
      {
         this.labelStatusBarStaticItem.Caption = "Closing...";
      }

      private void ConfigurationView1_AfterCloseFileEvent( object sender, Control.ConfigurationView.AfterCloseFileEventArgs ea )
      {
         this.labelStatusBarStaticItem.Caption = "CLOSED";
      }

      private void ConfigurationView1_BeforeSaveFileEvent( object sender, Control.ConfigurationView.BeforeSaveFileEventArgs ea )
      {
      }

      private void ConfigurationView1_AfterSaveFileEvent( object sender, Control.ConfigurationView.AfterSaveFileEventArgs ea )
      {
         this.labelStatusBarStaticItem.Caption = ea.args.SavedFilename + " SAVED";
      }

      private void ConfigurationView1_BeforeSaveAsFileEvent( object sender, Control.ConfigurationView.BeforeSaveAsFileEventArgs ea )
      {
         this.labelStatusBarStaticItem.Caption = ea.SavedFilename + " Saving As...";
      }

      private void ConfigurationView1_AfterSaveAsFileEvent( object sender, Control.ConfigurationView.AfterSaveAsFileEventArgs ea )
      {
         this.labelStatusBarStaticItem.Caption = ea.args.SavedFilename + " SAVED AS";
      }

      private void ConfigurationView1_BeforeDelConnectionStringEvent( object sender, Control.ConfigurationView.BeforeDelConnectionStringEventArgs ea )
      {
      }

      private void ConfigurationView1_AfterDelConnectionStringEvent( object sender, Control.ConfigurationView.AfterDelConnectionStringEventArgs ea )
      {
      }

      private void newBarButtonItem_ItemClick( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
      {
         this.configurationView1.NewFile( "[UnSavedFile]" );
      }

      private void openBarButtonItem_ItemClick( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
      {
         this.configurationView1.OpenFile( );
      }

      private void saveBarButtonItem_ItemClick( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
      {
         this.configurationView1.SaveFile( );
      }

      private void saveAsBarButtonItem_ItemClick( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
      {
         this.configurationView1.SaveAsFile( );
      }

      private void closeBarButtonItem_ItemClick( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
      {
         this.configurationView1.CloseFile( );
      }

      private void addDataStoreBarButtonItem_ItemClick( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
      {
         this.configurationView1.AddDataStore( );
      }

      private void addAppCSBarButtonItem_ItemClick( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
      {
         this.configurationView1.AddConnectionString( );
      }

      private void setWorkingDirectoryBarButtonItem_ItemClick( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
      {
      }

      private void delDataStoreBarButtonItem_ItemClick( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
      {
      }

      private void delAppCsBarButtonItem_ItemClick( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
      {
         this.configurationView1.DelConnectionString( );
      }
   }
}