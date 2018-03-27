using LinqXml.Control;
using System;
using System.Linq;

namespace LinqXml
{
   public partial class ConfigurationTestForm : DevExpress.XtraEditors.XtraForm
   {
      #region --- Ctors ---
      public ConfigurationTestForm()
      {
         this.InitializeComponent();
         this.configurationView1.BeforeOpenFileEvent += this.ConfigurationView1_BeforeOpenFileEvent;
         this.configurationView1.AfterOpenFileEvent += this.ConfigurationView1_AfterOpenFileEvent;
         this.configurationView1.BeforeSaveAsFileEvent += this.ConfigurationView1_BeforeSaveAsFileEvent;
         this.configurationView1.AfterSaveAsFileEvent += this.ConfigurationView1_AfterSaveAsFileEvent;
         this.configurationView1.BeforeSaveFileEvent += this.ConfigurationView1_BeforeSaveFileEvent;
         this.configurationView1.AfterSaveFileEvent += this.ConfigurationView1_AfterSaveFileEvent;
         this.configurationView1.BeforeCloseFileEvent += this.ConfigurationView1_BeforeCloseFileEvent;
         this.configurationView1.AfterCloseFileEvent += this.ConfigurationView1_AfterCloseFileEvent;
         this.configurationView1.BeforeAddAppCSEvent += this.ConfigurationView1_BeforeAddAppCSEvent;
         this.configurationView1.AfterAddAppCSEvent += this.ConfigurationView1_AfterAddAppCSEvent;
         this.configurationView1.BeforeDelAppCSEvent += this.ConfigurationView1_BeforeDelAppCSEvent;
         this.configurationView1.AfterDelAppCSEvent += this.ConfigurationView1_AfterDelAppCSEvent;
         this.configurationView1.FocusedDataStoreChangedEvent += this.ConfigurationView1_FocusedDataStoreChangedEvent;
         this.configurationView1.FocusedAppCSChangedEvent += this.ConfigurationView1_FocusedConnectionStringChangedEvent;
         //
         this.configurationView1.AllowedNewFileEvent += this.ConfigurationView1_AllowedNewFileEvent;
         this.configurationView1.NotAllowedNewFileEvent += this.ConfigurationView1_NotAllowedNewFileEvent;
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
         this.configurationView1.SavedFileNameChangedEvent += this.ConfigurationView1_SavedFileNameChangedEvent;
         //
         this.configurationView1.AllowedAddAppCSEvent += this.ConfigurationView1_AllowedAddAppCSEvent;
         this.configurationView1.NotAllowedAddAppCSEvent += this.ConfigurationView1_NotAllowedAddAppCSEvent;
         //
         this.configurationView1.AllowedToCloneAppCSEvent += this.ConfigurationView1_AllowedToCloneAppCSEvent;
         this.configurationView1.NotAllowedToCloneAppCSEvent += this.ConfigurationView1_NotAllowedToCloneAppCSEvent;
         //
         this.configurationView1.AllowedDelAppCSEvent += this.ConfigurationView1_AllowedDelAppCSEvent;
         this.configurationView1.NotAllowedDelAppCSEvent += this.ConfigurationView1_NotAllowedDelAppCSEvent;
         //
         this.configurationView1.AllowedAddDataStoreEvent += this.ConfigurationView1_AllowedAddDataStoreEvent;
         this.configurationView1.NotAllowedAddDataStoreEvent += this.ConfigurationView1_NotAllowedAddDataStoreEvent;
         //
         this.configurationView1.AllowedToCloneDataStoreEvent += this.ConfigurationView1_AllowedToCloneDataStoreEvent;
         this.configurationView1.NotAllowedToCloneDataStoreEvent += this.ConfigurationView1_NotAllowedToCloneDataStoreEvent;
         //
         this.configurationView1.AllowedDelDataStoreEvent += this.ConfigurationView1_AllowedDelDataStoreEvent;
         this.configurationView1.NotAllowedDelDataStoreEvent += this.ConfigurationView1_NotAllowedDelDataStoreEvent;
      }

      #endregion

      #region --- [External Events] Observed ---
      private void ConfigurationView1_AfterAddAppCSEvent(object sender, AfterAddAppCSEventArgs ea)
      {
      }

      private void ConfigurationView1_BeforeAddAppCSEvent(object sender, BeforeAddAppCSEventArgs ea)
      {
      }

      private void ConfigurationView1_SavedFileNameChangedEvent(object sender, SavedFileNameChangedEventArgs args)
      {
         string x = nameof(ConfigurationTestForm);
         this.Text = $"{x} [{args.NewFilename}]";
      }

      private void ConfigurationView1_AllowedToSaveAsFileEvent(object sender)
      {
         this.saveAsBarButtonItem.Enabled = true;
      }

      private void ConfigurationView1_NotAllowedToSaveAsFileEvent(object sender)
      {
         this.saveAsBarButtonItem.Enabled = false;
      }

      private void ConfigurationView1_NotAllowedToSaveFileEvent(object sender)
      {
         this.saveBarButtonItem.Enabled = false;
      }

      private void ConfigurationView1_AllowedToSaveFileEvent(object sender)
      {
         this.saveBarButtonItem.Enabled = true;
      }

      private void ConfigurationView1_AllowedNewFileEvent(object sender)
      {
         this.newBarButtonItem.Enabled = true;
      }

      private void ConfigurationView1_NotAllowedNewFileEvent(object sender)
      {
         this.newBarButtonItem.Enabled = false;
      }

      private void ConfigurationView1_NotAllowedToOpenFileEvent(object sender)
      {
         this.openBarButtonItem.Enabled = false;
      }

      private void ConfigurationView1_AllowedToOpenFileEvent(object sender)
      {
         this.openBarButtonItem.Enabled = true;
      }

      private void ConfigurationView1_NotAllowedToCloseFileEvent(object sender)
      {
         this.closeBarButtonItem.Enabled = false;
      }

      private void ConfigurationView1_AllowedToCloseFileEvent(object sender)
      {
         this.closeBarButtonItem.Enabled = true;
      }

      private void ConfigurationView1_NotAllowedDelDataStoreEvent(object sender)
      {
         this.delDataStoreBarButtonItem.Enabled = false;
      }

      private void ConfigurationView1_AllowedDelDataStoreEvent(object sender)
      {
         this.delDataStoreBarButtonItem.Enabled = true;
      }

      private void ConfigurationView1_NotAllowedAddDataStoreEvent(object sender)
      {
         this.addDataStoreBarButtonItem.Enabled = false;
      }

      private void ConfigurationView1_AllowedAddDataStoreEvent(object sender)
      {
         this.addDataStoreBarButtonItem.Enabled = true;
      }

      private void ConfigurationView1_NotAllowedDelAppCSEvent(object sender)
      {
         this.delAppCSBarButtonItem.Enabled = false;
      }

      private void ConfigurationView1_AllowedDelAppCSEvent(object sender)
      {
         this.delAppCSBarButtonItem.Enabled = true;
      }

      private void ConfigurationView1_AllowedAddAppCSEvent(object sender)
      {
         this.addAppCSBarButtonItem.Enabled = true;
      }

      private void ConfigurationView1_NotAllowedAddAppCSEvent(object sender)
      {
         this.addAppCSBarButtonItem.Enabled = false;
      }

      private void ConfigurationView1_AllowedToCloneDataStoreEvent( object sender )
      {
         this.cloneDSBarButtonItem.Enabled = true;
      }

      private void ConfigurationView1_NotAllowedToCloneDataStoreEvent( object sender )
      {
         this.cloneDSBarButtonItem.Enabled = false;
      }

      private void ConfigurationView1_AllowedToCloneAppCSEvent( object sender )
      {
         this.cloneAppCSBarButtonItem.Enabled = true;
      }

      private void ConfigurationView1_NotAllowedToCloneAppCSEvent( object sender )
      {
         this.cloneAppCSBarButtonItem.Enabled = false;
      }

      //private void configurationView1_AllowedAddAppCSEvent( object sender )
      //{
      //   this.addAppCSBarButtonItem.Enabled = true;
      //}

      //private void configurationView1_NotAllowedAddAppCSEvent( object sender )
      //{
      //   this.addAppCSBarButtonItem.Enabled = false;
      //}

      private void ConfigurationView1_FocusedDataStoreChangedEvent(object sender, FocusedDataStoreChangedEventArgs ea)
      {
         this.objnmStatusBarStaticItem.Caption = ea.DataStore.Name + " DataStore";
      }

      private void ConfigurationView1_FocusedConnectionStringChangedEvent(object sender, FocusedAppCSChangedEventArgs ea)
      {
         this.objnmStatusBarStaticItem.Caption = ea.ConnectionString.Name + " ConnectionString";
      }

      private void ConfigurationView1_BeforeOpenFileEvent(object sender, BeforeOpenFileEventArgs ea)
      {
         this.labelStatusBarStaticItem.Caption = ea.SuggestedFilename + " Opening...";
      }

      private void ConfigurationView1_AfterOpenFileEvent(object sender, AfterOpenFileEventArgs ea)
      {
         this.labelStatusBarStaticItem.Caption = ea.args.OpenedFilename;
         if(ea.isOk)
         {
            this.objnmStatusBarStaticItem.Caption = " OPENED";
         } else if(ea.hasException)
         {
            this.objnmStatusBarStaticItem.Caption = ea.args.Exception.InnerException.Message;
         }
      }

      private void ConfigurationView1_BeforeCloseFileEvent(object sender, BeforeCloseFileEventArgs ea)
      {
         this.labelStatusBarStaticItem.Caption = "Closing...";
      }

      private void ConfigurationView1_AfterCloseFileEvent(object sender, AfterCloseFileEventArgs ea)
      {
         this.labelStatusBarStaticItem.Caption = "CLOSED";
      }

      private void ConfigurationView1_BeforeSaveFileEvent(object sender, BeforeSaveFileEventArgs ea)
      {
      }

      private void ConfigurationView1_AfterSaveFileEvent(object sender, AfterSaveFileEventArgs ea)
      {
         this.labelStatusBarStaticItem.Caption = ea.args.SavedFilename + " SAVED";
      }

      private void ConfigurationView1_BeforeSaveAsFileEvent(object sender, BeforeSaveAsFileEventArgs ea)
      {
         this.labelStatusBarStaticItem.Caption = ea.SavedFilename + " Saving As...";
      }

      private void ConfigurationView1_AfterSaveAsFileEvent(object sender, AfterSaveAsFileEventArgs ea)
      {
         this.labelStatusBarStaticItem.Caption = ea.args.SavedFilename + " SAVED AS";
      }

      private void ConfigurationView1_BeforeDelAppCSEvent(object sender, BeforeDelAppCSEventArgs ea)
      {
      }

      private void ConfigurationView1_AfterDelAppCSEvent(object sender, AfterDelAppCSEventArgs ea)
      {
      }
      #endregion

      #region --- [Local Events] Handlers ---
      private void ConfigurationTestForm_Load(object sender, EventArgs e)
      {
         this.configurationView1.Initialize();
      }

      private void newBarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.configurationView1.NewFile();
      }

      private void openBarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.configurationView1.OpenFile();
      }

      private void saveBarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.configurationView1.SaveFile();
      }

      private void saveAsBarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.configurationView1.SaveAsFile();
      }

      private void closeBarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.configurationView1.CloseFile();
      }

      private void setWorkingDirectoryBarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
      }

      private void addAppCSBarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.configurationView1.AddAppCS();
      }

      private void delAppCsBarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.configurationView1.DelAppCS();
      }

      private void addDataStoreBarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.configurationView1.AddDataStore();
      }

      private void delDataStoreBarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
      }

      private void cloneAppCSBarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.configurationView1.CloneAppCS();
      }

      private void cloneDSBarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.configurationView1.CloneDataStore();
      }

      #endregion
   }
}