using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using System;
using System.Linq;
using System.Windows.Forms;

namespace FrontEnd
{
   public partial class DataStoresXtraUserControl : DevExpress.XtraEditors.XtraUserControl
   {
      private System.Data.DataTable _dsc;

      public DataStoresXtraUserControl()
      {
         this.InitializeComponent( );
         InitTreeView( this.treeView );
         this.treeView.CustomDrawNodeCell += this.treeView_CustomDrawNodeCell;
         this.treeView.AfterCollapse += this.treeView_AfterCollapse;
         this.treeView.AfterExpand += this.treeView_AfterExpand;
         if( !IsInDesignMode( ) )
         {
            this.LoadNodes( );
         }
         this.treeView_FocusedNodeChanged( null, new FocusedNodeChangedEventArgs( null, null ) );
      }
      //
      private bool IsInDesignMode()
      {
         if( base.DesignMode )
            return true;
         if( System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime
            || System.Diagnostics.Debugger.IsAttached )
         {
            using( var process = System.Diagnostics.Process.GetCurrentProcess( ) )
            {
               return process.ProcessName.ToLowerInvariant( ).Contains( "devenv" );
            }
         }
         return false;
      }
      private static void InitTreeView( DevExpress.XtraTreeList.TreeList treeView )
      {
         TreeListColumn column = treeView.Columns.Add( );
         column.Visible = true;
         treeView.OptionsView.ShowColumns = false;
         treeView.OptionsView.ShowIndicator = false;
         treeView.OptionsView.ShowVertLines = false;
         treeView.OptionsView.ShowHorzLines = false;
         treeView.OptionsBehavior.Editable = false;
         treeView.OptionsSelection.EnableAppearanceFocusedCell = false;
         treeView.OptionsFind.AllowIncrementalSearch = true;
         treeView.OptionsFind.AlwaysVisible = true;
         treeView.OptionsFind.ExpandNodesOnIncrementalSearch = true;
         treeView.OptionsMenu.ShowConditionalFormattingItem = true;
         treeView.OptionsPrint.PrintCheckBoxes = true;
         treeView.OptionsView.ShowAutoFilterRow = true;
         treeView.OptionsView.ShowCheckBoxes = true;
         treeView.OptionsView.ShowFilterPanelMode = DevExpress.XtraTreeList.ShowFilterPanelMode.ShowAlways;
         {
            TreeListColumn treeListColumn = treeView.Columns[ string.Empty ]; //[ 0 ];
            treeListColumn.Caption = nameof( Name );
            treeListColumn.FieldName = "colName";
            treeListColumn.Name = "treeListColumn";
            treeListColumn.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.String;
            treeListColumn.Visible = true;
            treeListColumn.VisibleIndex = 0;
         }
      }
      private TreeListColumn createNameColumn()
      {
         TreeListColumn o = new TreeListColumn( );
         {
            o.FieldName = nameof( Name );
            o.Name = "col" + o.FieldName;
            o.Visible = true;
            o.VisibleIndex = 0;
            o.Fixed = FixedStyle.None;
            // o.FieldNameSort = "";
            // o.SortIndex = 1;
            o.SortMode = DevExpress.XtraGrid.ColumnSortMode.Default;
            o.SortOrder = System.Windows.Forms.SortOrder.None;
            //this.treeList1.OptionsView.ShowSummaryFooter = true;
            o.SummaryFooter = SummaryItemType.Count;
            o.AllNodesSummary = true;
            o.RowFooterSummary = SummaryItemType.Count;
            //this.treeList1.OptionsView.ShowRowFooterSummary = true;
            {
               o.OptionsColumn.AllowEdit = true;
               o.OptionsColumn.AllowFocus = true;
               o.OptionsColumn.AllowMove = true;
               o.OptionsColumn.AllowMoveToCustomizationForm = true;
               o.OptionsColumn.AllowSize = true;
               o.OptionsColumn.AllowSort = true;
               //o.OptionsColumn.FixedWidth = true;
               o.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.True;
               o.OptionsColumn.ReadOnly = false;
               o.OptionsColumn.ShowInCustomizationForm = true;
               o.OptionsColumn.ShowInExpressionEditor = true;
               //
            }
         }
         return o;
      }
      private void treeView_CustomDrawNodeCell( object sender, CustomDrawNodeCellEventArgs e )
      {
         //if( e.Node.Id == 1 )
         //{
         //   e.Appearance.Font = new System.Drawing.Font( e.Appearance.Font, FontStyle.Bold );
         //}
      }
      private void treeView_AfterCollapse( object sender, DevExpress.XtraTreeList.NodeEventArgs e )
      {
         this.SetIndex( e.Node, 6, false );
         this.SetIndex( e.Node, 8, false );
      }
      private void treeView_AfterExpand( object sender, DevExpress.XtraTreeList.NodeEventArgs e )
      {
         this.SetIndex( e.Node, 7, true );
         this.SetIndex( e.Node, 9, true );
      }
      public void LoadNodes( bool showAll = false )
      {
         this.treeView.Nodes.Clear( );
         this.treeView.BeginUpdate( );
         try
         {
            this._dsc = ConfigurationSetting.DataStore.LoadDataStoreConfigurationSetting( );
            foreach( System.Data.DataRow row in this._dsc.Rows )
            {
               //
               // Summary:
               //     Adds a DevExpress.XtraTreeList.Nodes.TreeListNode containing the specified values
               //     to the XtraTreeList.
               //
               // Parameters:
               //
               //   nodeData:
               //     An array of values or a System.Data.DataRow object, used to initialize the created
               //     node's cells.
               //
               //   parentNodeId:
               //     An integer value specifying the identifier of the parent node.
               //
               //   imageIndex:
               //     A zero-based index of the image displayed within the node.
               //
               //   selectImageIndex:
               //     A zero-based index of the image displayed within the node when it is focused
               //     or selected.
               //
               //   stateImageIndex:
               //     An integer value that specifies the index of the node's state image.
               //
               //   checkState:
               //     The node's check state.
               //
               //   tag:
               //     An object that contains information associated with the Tree List node. This
               //     value is assigned to the DevExpress.XtraTreeList.Nodes.TreeListNode.Tag property.
               //
               // Returns:
               //     A DevExpress.XtraTreeList.Nodes.TreeListNode object or descendant representing
               //     the added node.
               //
               object[ ] o = new object[ ] { row[ ConfigurationSetting.DataStore.NAME_COLNAME ].ToString( ) };
               this.treeView.AppendNode( o, -1, 0, -1, 3, CheckState.Checked, row );
            }
            if( showAll )
            {
            }
            this.treeView.ExpandAll( );
         }
         finally
         {
            this.treeView.EndUpdate( );
         }
      }
      private void SetIndex( TreeListNode node, int index, bool expand )
      {
         int newIndex = expand ? index - 1 : index + 1;
         if( node.StateImageIndex == index )
         {
            node.StateImageIndex = newIndex;
         }
      }
      //
      private void iRefresh_ItemClick( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
      {
         this.LoadNodes( );
      }
      private void iShow_ItemClick( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
      {
         this.LoadNodes( ((DevExpress.XtraBars.BarButtonItem) e.Item).Down );
      }
      //
      // The delegate procedure we are assigning to our object
      //public delegate void DataStoresPropertiesHandlerHandler( object myObject, System.Data.DataRow row );
      //public event DataStoresPropertiesHandlerHandler OnDataStoresProperties;
      public event System.EventHandler PropertiesItemClick;
      private void iProperties_ItemClick( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
      {
         System.Data.DataRow row = this.GET_SELECTED_DATASTORE( );
         ShowDataStoreProperties( row );
      }
      //
      public event EventHandler TreeViewItemClick;
      private void treeView_MouseDoubleClick( object sender, MouseEventArgs e )
      {
         if( this.TreeViewItemClick != null )
         {
            // send a message to all external subscribers...
            this.TreeViewItemClick( sender, EventArgs.Empty );
         }
      }

      public event EventHandler FocusedNodeChanged;
      private void treeView_FocusedNodeChanged( object sender, FocusedNodeChangedEventArgs e )
      {
         System.Data.DataRow row = this.GET_SELECTED_DATASTORE( );
         if( this.FocusedNodeChanged != null )
         {
            // send a message to all external subscribers...
            this.FocusedNodeChanged( row, EventArgs.Empty );
         }
         ShowDataStoreProperties( row );
      }
      //
      private void ShowDataStoreProperties( System.Data.DataRow row )
      {
         if( this.PropertiesItemClick != null )
         {
            ConfigurationSetting.DataStore ds = row[ ConfigurationSetting.DataStore.TAG_COLNAME ] as ConfigurationSetting.DataStore;
            // send a message to all external subscribers...
            this.PropertiesItemClick( ds, EventArgs.Empty );
         }
      }

      public System.Data.DataRow GET_SELECTED_DATASTORE()
      {
         TreeListMultiSelection selection = this.treeView.Selection;
         if( selection == null || selection.Count == 0 )
         {
            return null;
         }
         TreeListNode treeListNode = selection[ 0 ];
         System.Data.DataRow row = treeListNode.Tag as System.Data.DataRow;
         return row;
      }

      #region --- LOAD DATA VALUE REAL OR DUMMY ---
#if false
      private void LoadDummyDataValues( bool showAll )
      {
         this.treeView.AppendNode( new object[ ] { "Solution \'VisualStudioInspiredUIDemo\' (1 project)" }, -1, -1, -1, 3 ); //0
         this.treeView.AppendNode( new object[ ] { "VisualStudioInspiredUIDemo" }, -1, -1, -1, 4 );//1
         this.treeView.AppendNode( new object[ ] { "Properties" }, 1, -1, -1, 2 );//2
         this.treeView.AppendNode( new object[ ] { "References" }, 1, -1, -1, 5 );//3
         this.treeView.AppendNode( new object[ ] { "System" }, 3, -1, -1, 5 );
         this.treeView.AppendNode( new object[ ] { "System.Drawing" }, 3, -1, -1, 5 );
         this.treeView.AppendNode( new object[ ] { "System.Windows.Forms" }, 3, -1, -1, 5 );
         this.treeView.AppendNode( new object[ ] { "DevExpress.Utils" }, 3, -1, -1, 5 );
         this.treeView.AppendNode( new object[ ] { "DevExpress.XtraBars" }, 3, -1, -1, 5 );
         this.treeView.AppendNode( new object[ ] { "DevExpress.XtraEditors" }, 3, -1, -1, 5 );
         if( showAll )
         {
            this.treeView.AppendNode( new object[ ] { "bin" }, 1, -1, -1, 9 ); //10
            this.treeView.AppendNode( new object[ ] { "Debug" }, 10, -1, -1, 9 );
            this.treeView.AppendNode( new object[ ] { "Release" }, 10, -1, -1, 9 );
            this.treeView.AppendNode( new object[ ] { "obj" }, 1, -1, -1, 9 );//13
            this.treeView.AppendNode( new object[ ] { "Debug" }, 13, -1, -1, 9 );
            this.treeView.AppendNode( new object[ ] { "Release" }, 13, -1, -1, 9 );
         }
         this.treeView.AppendNode( new object[ ] { "Modules" }, 1, -1, -1, 7 );//16/10
         this.treeView.AppendNode( new object[ ] { "Resources" }, 1, -1, -1, 7 );//17
         this.treeView.AppendNode( new object[ ] { "AssemblyInfo.cs" }, 2, -1, -1, 10 );
         this.treeView.AppendNode( new object[ ] { "frmMain.cs" }, 1, -1, -1, 11 );//19
         this.treeView.AppendNode( new object[ ] { "ucCodeEditor.cs" }, showAll ? 16 : 10, -1, -1, 12 ); //20
         this.treeView.AppendNode( new object[ ] { "ucSolutionExplorer.cs" }, showAll ? 16 : 10, -1, -1, 12 ); //21
         this.treeView.AppendNode( new object[ ] { "ucToolbox.cs" }, showAll ? 16 : 10, -1, -1, 12 ); //22
         if( showAll )
         {
            this.treeView.AppendNode( new object[ ] { "frmMain.resx" }, 19, -1, -1, 13 );
            this.treeView.AppendNode( new object[ ] { "ucCodeEditor.resx" }, 20, -1, -1, 13 );
            this.treeView.AppendNode( new object[ ] { "ucSolutionExplorer.resx" }, 21, -1, -1, 13 );
            this.treeView.AppendNode( new object[ ] { "ucToolbox.resx" }, 22, -1, -1, 13 );
         }
      }
#endif
      #endregion
   }
}
