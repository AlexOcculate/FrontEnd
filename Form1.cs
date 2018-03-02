using System;
using System.Linq;
using System.Windows.Forms;

namespace FrontEnd
{
   public partial class Form1 : Form
   {
      public Form1()
      {
         this.InitializeComponent( );
         this.Icon = DevExpress.Utils.ResourceImageHelper.CreateIconFromResourcesEx( "FrontEnd.Resources.AppIcon.ico", typeof( Form1 ).Assembly );
         // Handling the QueryControl event that will populate all automatically generated Documents
         this.tabbedView1.QueryControl += this.tabbedView1_QueryControl;
         //
         this.dataStoresXtraUserControl1.LoadNodes( );
         this.dataStoresXtraUserControl1.PropertiesItemClick += this.DataStoresXtraUserControl1_PropertiesItemClick;
         // this.dataStoresXtraUserControl1.OnDataStoresProperties += this.DataStoresXtraUserControl1_OnDataStoresProperties;
         this.dataStoresXtraUserControl1.TreeViewItemClick += this.DataStoresXtraUserControl1_TreeViewItemClick;
         //
         //         this.solutionExplorerXtraUserControl1.LoadNodes( );
         this.solutionExplorerXtraUserControl1.PropertiesItemClick += this.SolutionExplorerXtraUserControl1_PropertiesItemClick;
         // this.solutionExplorerXtraUserControl1.OnDataStoresProperties += this.SolutionExplorerXtraUserControl1_OnDataStoresProperties;
         this.solutionExplorerXtraUserControl1.TreeViewItemClick += this.SolutionExplorerXtraUserControl1_TreeViewItemClick;
         //
         this.initialPath = GetDefaultFilePath( );
         //  this.SetMemoEditText( this.initialPath + "\\" + defaultFileName );
      }

      private void DataStoresXtraUserControl1_OnDataStoresProperties( object myObject, System.Data.DataRow row )
      {
         //         throw new NotImplementedException( );
         //this.verticalGridXtraUserControl.SetXXX( row );
      }

      private void DataStoresXtraUserControl1_TreeViewItemClick( object sender, EventArgs e )
      {
         //         throw new NotImplementedException( );
      }

      private void DataStoresXtraUserControl1_PropertiesItemClick( object sender, EventArgs e )
      {
         //         throw new NotImplementedException( );
         this.dataStorePropertiesXtraUserControl.SetXXX( sender );
      }

      private void SolutionExplorerXtraUserControl1_TreeViewItemClick( object sender, EventArgs e )
      {
         //         throw new NotImplementedException( );
      }

      private void SolutionExplorerXtraUserControl1_PropertiesItemClick( object sender, EventArgs e )
      {
         //         throw new NotImplementedException( );
         this.projectPropertiesXtraUserControl.SetXXX( sender );
      }

      private void Form1_Load( object sender, EventArgs e )
      {
         BeginInvoke( new MethodInvoker( this.InitDemo ) );
      }
      private void InitDemo()
      {
         DevExpress.XtraSplashScreen.SplashScreenManager.HideImage( 1000, this );
      }

      // Assigning a required content for each auto generated Document
      private void tabbedView1_QueryControl( object sender, DevExpress.XtraBars.Docking2010.Views.QueryControlEventArgs e )
      {
         if( e.Document == this.xtraUserControl1Document )
         {
            e.Control = new FrontEnd.XtraUserControl1( );
         }

         if( e.Document == this.metadataItemXtraUserControlDocument )
         {
            e.Control = new FrontEnd.MetadataItemXtraUserControl( );
         }

         if( e.Control == null )
         {
            e.Control = new System.Windows.Forms.Control( );
         }
      }

      private void dockPanel1_Click( object sender, EventArgs e )
      {

      }

      private void dockManager1_Docking( object sender, DevExpress.XtraBars.Docking.DockingEventArgs e )
      {

      }

      private void dockManager1_ClosedPanel( object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e )
      {
         string name = e.Panel.Name;
         if( e.Panel == this.solutionExplorerDockPanel )
         {
            switch( this.solutionExplorerDockPanel.Visibility )
            {
               case DevExpress.XtraBars.Docking.DockVisibility.Visible:
                  break;
               case DevExpress.XtraBars.Docking.DockVisibility.Hidden:
                  break;
               case DevExpress.XtraBars.Docking.DockVisibility.AutoHide:
                  break;
               default:
                  break;
            }
         }
      }

      private void dockManager1_Collapsed( object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e )
      {

      }

      #region Utils
      private string initialPath = string.Empty;

      private void SetMemoEditText( string filePath )
      {
         if( System.IO.File.Exists( filePath ) )
         {
            // this.mainModule.Text = System.IO.File.ReadAllText( filePath );
         }
      }
      private string OpenItemClick( string filter )
      {
         using( DevExpress.XtraEditors.XtraOpenFileDialog dialog = new DevExpress.XtraEditors.XtraOpenFileDialog( ) )
         {
            dialog.InitialDirectory = this.initialPath;
            dialog.ShowDragDropConfirmation = true;
            dialog.AutoUpdateFilterDescription = false;
            dialog.Filter = filter;
            DialogResult dialogResult = dialog.ShowDialog( );
            if( dialogResult == DialogResult.OK )
            {
               return dialog.FileName;
            }
         }
         return null;
      }
      private void SaveItemClick( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
      {
         using( DevExpress.XtraEditors.XtraSaveFileDialog dialog = new DevExpress.XtraEditors.XtraSaveFileDialog( ) )
         {
            dialog.InitialDirectory = this.initialPath;
            dialog.ShowDragDropConfirmation = true;
            dialog.Filter = "Text files|*.txt";
            dialog.CreatePrompt = true;
            dialog.OverwritePrompt = true;
            DialogResult dialogResult = dialog.ShowDialog( );
            if( dialogResult == DialogResult.OK )
            {
               // System.IO.File.WriteAllText( dialog.FileName, this.mainModule.Text );
            }
         }
      }
      private void SetWorkingFolderItemClick( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
      {
         using( DevExpress.XtraEditors.XtraFolderBrowserDialog dialog = new DevExpress.XtraEditors.XtraFolderBrowserDialog( ) )
         {
            dialog.SelectedPath = this.initialPath;
            if( dialog.ShowDialog( ) == DialogResult.OK )
            {
               this.initialPath = dialog.SelectedPath;
            }
         }
      }

      private static string GetDefaultFilePath()
      {
         //return System.IO.Path.GetDirectoryName(
         //   DevExpress.Utils.FilesHelper.FindingFileName(
         //      Application.StartupPath, "", true
         //      ) );
         return Application.StartupPath;
      }
      #endregion

      #region --- DATA STORE ITEM CLICK HANDLERS ---
      private void refreshDataStoreBarButtonItem_ItemClick( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
      {
      }

      private void openDataStoreBarButtonItem_ItemClick( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
      {
      }

      private void closeDataStoreBarButtonItem_ItemClick( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
      {
      }

      private void importDataStoreBarButtonItem_ItemClick( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
      {
      }

      private void exportDataStoreBarButtonItem_ItemClick( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
      {
      }

      private void newDataStoreBarButtonItem_ItemClick( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
      {
      }

      private void deleteDataStoreBarButtonItem_ItemClick( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
      {
      }
      #endregion

      #region --- SOLUTION EXPLORER ITEM CLICK HANDLERS ---
      private string solutionFileName = @"SampleSolution.dusln";

      private void newSolutionBarButtonItem_ItemClick( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
      {
      }
      private void openSolutionBarButtonItem_ItemClick( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
      {
         this.solutionFileName = this.OpenItemClick( "Data Understand Solution (*.dusln)|*.dusln" );
         this.solutionExplorerXtraUserControl1.LoadSolution( false, this.solutionFileName );
      }
      private void saveSolutionBarButtonItem_ItemClick( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
      {
      }
      private void saveAsSolutionBarButtonItem_ItemClick( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
      {
      }
      private void saveAllSolutionBarButtonItem_ItemClick( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
      {
      }

      private void closeSolutionBarButtonItem_ItemClick( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
      {
         this.solutionExplorerXtraUserControl1.CloseSolution( );
      }

      #endregion

      private void newProjectBarButtonItem_ItemClick( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
      {

      }
   }
}
