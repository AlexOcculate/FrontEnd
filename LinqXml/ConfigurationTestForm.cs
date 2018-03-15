using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace LinqXml
{
   public partial class ConfigurationTestForm : DevExpress.XtraEditors.XtraForm
   {
      public ConfigurationTestForm()
      {
         InitializeComponent( );
         this.configurationView1.BeforeOpenFileEvent += this.ConfigurationView1_BeforeOpenFileEvent;
         this.configurationView1.AfterOpenFileEvent += this.ConfigurationView1_AfterOpenFileEvent;
         this.configurationView1.BeforeSaveAsFileEvent += this.ConfigurationView1_BeforeSaveAsFileEvent;
         this.configurationView1.AfterSaveAsFileEvent += this.ConfigurationView1_AfterSaveAsFileEvent;
         this.configurationView1.BeforeSaveFileEvent += this.ConfigurationView1_BeforeSaveFileEvent;
         this.configurationView1.AfterSaveFileEvent += this.ConfigurationView1_AfterSaveFileEvent;
         this.configurationView1.BeforeCloseFileEvent += this.ConfigurationView1_BeforeCloseFileEvent;
         this.configurationView1.AfterCloseFileEvent += this.ConfigurationView1_AfterCloseFileEvent;
         this.configurationView1.FocusedDataStoreChangedEvent += this.ConfigurationView1_FocusedDataStoreChangedEvent;
         this.configurationView1.FocusedConnectionStringChangedEvent += this.ConfigurationView1_FocusedConnectionStringChangedEvent;
      }

      private void ConfigurationView1_FocusedDataStoreChangedEvent( object sender, Control.ConfigurationView.FocusedDataStoreChangedEventArgs ea )
      {
         this.objnmStatusBarStaticItem.Caption = ea.DataStore.Name + " DataStore";
      }
      private void ConfigurationView1_FocusedConnectionStringChangedEvent( object sender, Control.ConfigurationView.FocusedConnectionStringChangedEventArgs ea )
      {
         this.objnmStatusBarStaticItem.Caption = ea.ConnectionString.Name + " ConnectionString";
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

      private void ConfigurationView1_BeforeOpenFileEvent( object sender, Control.ConfigurationView.BeforeOpenFileEventArgs ea )
      {
         this.labelStatusBarStaticItem.Caption = ea.SuggestedFilename + " Opening...";
      }
      private void ConfigurationView1_AfterOpenFileEvent( object sender, Control.ConfigurationView.AfterOpenFileEventArgs ea )
      {
         this.labelStatusBarStaticItem.Caption = ea.args.OpenedFilename + " OPENED";
      }

      private void ConfigurationView1_BeforeSaveAsFileEvent( object sender, Control.ConfigurationView.BeforeSaveAsFileEventArgs ea )
      {
         this.labelStatusBarStaticItem.Caption = ea.SavedFilename + " Saving As...";
      }
      private void ConfigurationView1_AfterSaveAsFileEvent( object sender, Control.ConfigurationView.AfterSaveAsFileEventArgs ea )
      {
         this.labelStatusBarStaticItem.Caption = ea.args.SavedFilename + " SAVED AS";
      }


      private void barButtonItem1_ItemClick( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
      {
         this.configurationView1.OpenFile( );
      }
      private void barButtonItem2_ItemClick( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
      {
         this.configurationView1.SaveFile( );
      }
      private void barButtonItem3_ItemClick( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
      {
         this.configurationView1.SaveAsFile( );
      }

      private void barButtonItem4_ItemClick( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
      {
         this.configurationView1.CloseFile( );
      }
   }
}