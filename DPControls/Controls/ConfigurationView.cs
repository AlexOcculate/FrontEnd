﻿using DataPhilosophiae.Delegates;
using DataPhilosophiae.Delegates.AppCS;
using DataPhilosophiae.Delegates.DS;
using DataPhilosophiae.Delegates.File;
using DataPhilosophiae.Events.AppCS;
using DataPhilosophiae.Events.DS;
using DataPhilosophiae.Events.File;
using DataPhilosophiae.Exceptions.AppCS;
using DataPhilosophiae.Exceptions.DS;
using DataPhilosophiae.Exceptions.File;
using DataPhilosophiae.Model;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DataPhilosophiae.Control
{
   public partial class ConfigurationView : DevExpress.XtraEditors.XtraUserControl
   {
      #region --- Properties and Backing Fields... ---
      private Configuration cfg;
      private string initialPath = string.Empty;

      private string _defaultFileName = "cfg.xml";

      public string DefaultFileName
      {
         get => this._defaultFileName;
         set
         {
            if( string.Compare( this._defaultFileName, value, StringComparison.Ordinal ) != 0 )
            {
               SavedFileNameChangedEventArgs args = new SavedFileNameChangedEventArgs( );
               args.OldFilename = this._defaultFileName;
               args.NewFilename = value;
               this._defaultFileName = value;
               this.SavedFileNameChangedEvent?.Invoke( this, args );
               this.NotAllowedToSaveFileEvent?.Invoke( this );
            }
         }
      }
      #endregion

      #region --- Ctors() ---
      public ConfigurationView()
      {
         this.InitializeComponent( );
         this.InitializeTreeView( this.treeView );
         this.AfterNewFileEvent += this.AfterNewFileEventPostStatuses;
         this.AfterOpenFileEvent += this.AfterOpenFileEventPostStatuses;
         this.AfterSaveAsFileEvent += this.AfterSaveAsFileEventPostStatuses;
         this.AfterSaveFileEvent += this.AfterSaveFileEventPostStatuses;
         this.AfterCloseFileEvent += this.AfterCloseFileEventPostStatuses;
         //
         this.AfterAddAppCSEvent += this.AfterAddAppCSEventPostStatuses;
         this.AfterCloneAppCSEvent += this.AfterCloneAppCSEventPostStatuses;
         this.AfterDelAppCSEvent += this.AfterDelAppCSEventPostStatuses;
         //
         this.AfterAddDataStoreEvent += this.AfterAddDataStoreEventPostStatuses;
         this.AfterCloneDataStoreEvent += this.AfterCloneDataStoreEventPostStatuses;
         this.AfterDelDataStoreEvent += this.AfterDelDataStoreEventPostStatuses;
         //
         // this.AddAllNodes( true );
         //this.LoadNodes( );
      }

      public void Initialize()
      {
         this.AllowedNewFileEvent?.Invoke( this );
         this.AllowedToOpenFileEvent?.Invoke( this );
         this.NotAllowedToSaveFileEvent?.Invoke( this );
         this.NotAllowedToSaveAsFileEvent?.Invoke( this );
         this.NotAllowedToCloseFileEvent?.Invoke( this );
         //
         this.NotAllowedAddAppCSEvent?.Invoke( this );
         this.NotAllowedToCloneAppCSEvent?.Invoke( this );
         this.NotAllowedDelAppCSEvent?.Invoke( this );
         //
         this.NotAllowedAddDataStoreEvent?.Invoke( this );
         this.NotAllowedToCloneDataStoreEvent?.Invoke( this );
         this.NotAllowedDelDataStoreEvent?.Invoke( this );
      }
      #endregion

      #region --- TreeView (TreeList) ---
      private void InitializeTreeView( TreeList treeView )
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
         //
         treeView.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler( this.treeView_FocusedNodeChanged );
         // treeView.CustomDrawNodeCell += this.treeView_CustomDrawNodeCell;
         // treeView.AfterCollapse += this.treeView_AfterCollapse;
         // treeView.AfterExpand += this.treeView_AfterExpand;
      }

      private void treeView_CustomDrawEmptyArea( object sender, CustomDrawEmptyAreaEventArgs e )
      {
         if( this.treeView.Nodes.Count > 1 )
         {
            return;
         }

         string s = "No Records Available";
         e.Graphics.DrawString( s, new Font( "Tahoma", 10, FontStyle.Bold ), new SolidBrush( Color.Black ), e.Bounds );
         e.Handled = true;
      }

      private void treeView_CustomDrawNodeCell( object sender, CustomDrawNodeCellEventArgs e )
      {
         if( e.Node.Id == 1 )
         {
            e.Appearance.Font = new System.Drawing.Font( e.Appearance.Font, FontStyle.Bold );
         }
      }

      private void treeView_FocusedNodeChanged( object sender, FocusedNodeChangedEventArgs e )
      {
         TreeListNode oldNode = e.OldNode;
         TreeListNode newNode = e.Node;

         //         newNode = newNode == null ? oldNode : newNode;
         if( newNode != null/* && newNode.Expanded*/)
         {
            this.xxxyyyzzz( newNode );
            this.NotAllowedToExpandAllEvent?.Invoke( this );
            this.NotAllowedToExpandNodeEvent?.Invoke( this );
            this.NotAllowedToExpandChildrenEvent?.Invoke( this );
            //
            this.AllowedToCollapseAllEvent?.Invoke( this );
            this.AllowedToCollapseNodeEvent?.Invoke( this );
            string cellText = newNode[ 0 ] as string;
         }
         else
         {
            this.xxxyyyzzz( oldNode );
            this.AllowedToExpandAllEvent?.Invoke( this );
            this.AllowedToExpandAllEvent?.Invoke( this );
            this.AllowedToExpandChildrenEvent?.Invoke( this );
            //
            this.NotAllowedToCollapseAllEvent?.Invoke( this );
            this.NotAllowedToCollapseNodeEvent?.Invoke( this );
         }
         if( newNode?.Tag == null )
         {
            this.NotAllowedToCloneAppCSEvent?.Invoke( this );
            this.NotAllowedDelAppCSEvent?.Invoke( this );
            //
            this.NotAllowedToCloneDataStoreEvent?.Invoke( this );
            this.NotAllowedDelDataStoreEvent?.Invoke( this );
            return;
         }
      }

      private void xxxyyyzzz( TreeListNode newNode )
      {
         if( newNode.Tag is DataStore )
         {
            FocusedDataStoreChangedEventArgs args = new FocusedDataStoreChangedEventArgs( );
            args.DataStore = newNode.Tag as DataStore;
            this.FocusedDataStoreChangedEvent?.Invoke( this, args );
            //
            this.NotAllowedToCloneAppCSEvent?.Invoke( this );
            this.NotAllowedDelAppCSEvent?.Invoke( this );
            this.AllowedToCloneDataStoreEvent?.Invoke( this );
            this.AllowedDelDataStoreEvent?.Invoke( this );
         }
         else if( newNode.Tag is ConnectionString )
         {
            FocusedAppCSChangedEventArgs args = new FocusedAppCSChangedEventArgs( );
            args.ConnectionString = newNode.Tag as ConnectionString;
            this.FocusedAppCSChangedEvent?.Invoke( this, args );
            //
            if( args.ConnectionString.IsSys )
            {
               this.NotAllowedDelAppCSEvent?.Invoke( this );
            }
            else
            {
               this.AllowedDelAppCSEvent?.Invoke( this );
            }
            this.AllowedToCloneAppCSEvent?.Invoke( this );
            this.NotAllowedDelDataStoreEvent?.Invoke( this );
            this.NotAllowedToCloneDataStoreEvent?.Invoke( this );
         }
         else
         {
            this.NotAllowedToCloneAppCSEvent?.Invoke( this );
            this.NotAllowedDelAppCSEvent?.Invoke( this );
            //
            this.NotAllowedToCloneDataStoreEvent?.Invoke( this );
            this.NotAllowedDelDataStoreEvent?.Invoke( this );
         }
      }

      private void treeView_AfterCollapse( object sender, NodeEventArgs e )
      {
         this.SetIndex( e.Node, 6, false );
         this.SetIndex( e.Node, 8, false );
      }

      private void treeView_AfterExpand( object sender, NodeEventArgs e )
      {
         this.SetIndex( e.Node, 7, true );
         this.SetIndex( e.Node, 9, true );
      }

      private void SetIndex( TreeListNode node, int index, bool expand )
      {
         int newIndex = expand ? index - 1 : index + 1;
         if( node.StateImageIndex == index )
         {
            node.StateImageIndex = newIndex;
         }
      }

      private void LoadNodes( bool showAll = false )
      {
         if( this.cfg == null )
         {
            return;
         }

         this.treeView.BeginUpdate( );
         try
         {
            this.treeView.Nodes.Clear( );
            this.LoadTreeListNodes( this.treeView );
            this.treeView.ExpandAll( );
         }
         catch( Exception ex )
         {
            string message = ex.Message;
         }
         finally
         {
            this.treeView.EndUpdate( );
         }
      }

      private TreeListNode dsNode;
      private TreeListNode csNode;
      private TreeListNode appcsNode;

      private void LoadTreeListNodes( TreeList treeView )
      {
         //XDocument doc = LinqXmlTest.GetDsCfgDoc( );
         //this.cfg = Configuration.GetPoco( doc.Root );
         // nodedata, parentId, imgIdx, selectImgIdx, stateImgIdx, chkState, tag
         this.dsNode = this.treeView.AppendNode( new object[ ] { "DataStores" }, -1 );
         this.csNode = this.treeView.AppendNode( new object[ ] { nameof( ConnectionString ) }, -1 );
         this.appcsNode = this.treeView.AppendNode( new object[ ] { nameof( Application ) }, this.csNode );
         TreeListNode syscsNode = this.treeView.AppendNode( new object[ ] { "System" }, this.csNode );
         //
         this.dsNode.ImageIndex = -1; this.dsNode.SelectImageIndex = -1; this.dsNode.StateImageIndex = -1;
         this.csNode.ImageIndex = -1; this.csNode.SelectImageIndex = -1; this.csNode.StateImageIndex = -1;
         this.appcsNode.ImageIndex = -1; this.appcsNode.SelectImageIndex = -1; this.appcsNode.StateImageIndex = -1;
         syscsNode.ImageIndex = -1; syscsNode.SelectImageIndex = -1; syscsNode.StateImageIndex = -1;
         //
         foreach( DataStore ds in this.cfg.DsList )
         {
            TreeListNode node = this.treeView.AppendNode( new object[ ] { ds.Name }, this.dsNode );
            node.ImageIndex = node.SelectImageIndex = 0; node.StateImageIndex = 0;
            node.Tag = ds;
         }
         foreach( ConnectionString cs in this.cfg.AppCsList )
         {
            TreeListNode node = this.treeView.AppendNode( new object[ ] { cs.Name }, this.appcsNode );
            node.ImageIndex = node.SelectImageIndex = 0; node.StateImageIndex = 0;
            node.Tag = cs;
         }
         foreach( ConnectionString cs in this.cfg.SysCsList )
         {
            TreeListNode node = this.treeView.AppendNode( new object[ ] { cs.Name }, syscsNode );
            node.ImageIndex = node.SelectImageIndex = 0; node.StateImageIndex = 0;
            node.Tag = cs;
         }
         //         this.cfg.VerifyWhatIsAllowed( );
      }
      #endregion

      #region --- [External Events] Observed ---
      private void Cfg_PropertyChanged( object sender, System.ComponentModel.PropertyChangedEventArgs e )
      { //@#$%
         // this.LoadNodes( );
      }

      private void Cfg_NotAllowedDelAppCSEvent( object sender )
      {
         this.NotAllowedDelAppCSEvent?.Invoke( this );
      }

      private void Cfg_AllowedDelAppCSEvent( object sender )
      {
         this.AllowedDelAppCSEvent?.Invoke( this );
      }

      private void Cfg_NotAllowedAddAppCSEvent( object sender )
      {
         this.NotAllowedAddAppCSEvent?.Invoke( this );
      }

      private void Cfg_AllowedAddAppCSEvent( object sender )
      {
         this.AllowedAddAppCSEvent?.Invoke( this );
      }

      private void Cfg_NotAllowedAddDataStoreEvent( object sender )
      {
         this.NotAllowedAddDataStoreEvent?.Invoke( this );
      }

      private void Cfg_AllowedAddDataStoreEvent( object sender )
      {
         this.AllowedAddDataStoreEvent?.Invoke( this );
      }

      private void Cfg_NotAllowedDelDataStoreEvent( object sender )
      {
         this.NotAllowedDelDataStoreEvent?.Invoke( this );
      }

      private void Cfg_AllowedDelDataStoreEvent( object sender )
      {
         this.AllowedDelDataStoreEvent?.Invoke( this );
      }
      #endregion

      #region --- [Local Events] Handlers ---
      [Browsable( true )]
      [CategoryAttribute( "00001-File-New" )]
      [Description( "Gets or sets whether the \"Remove\" button is visible." )]
      public event AllowedNewFileEventHandler AllowedNewFileEvent;
      [Browsable( true )]
      [CategoryAttribute( "00001-File-New" )] public event NotAllowedNewFileEventHandler NotAllowedNewFileEvent;
      [Browsable( true )]
      [CategoryAttribute( "00001-File-New" )] public event BeforeNewFileEventHandler BeforeNewFileEvent;
      [Browsable( true )]
      [CategoryAttribute( "00001-File-New" )] public event AfterNewFileEventHandler AfterNewFileEvent;

      // -----
      [Browsable( true )]
      [CategoryAttribute( "00002-File-Open" )] public event AllowedToOpenFileEventHandler AllowedToOpenFileEvent;
      [Browsable( true )]
      [CategoryAttribute( "00002-File-Open" )] public event NotAllowedToOpenFileEventHandler NotAllowedToOpenFileEvent;
      [Browsable( true )]
      [CategoryAttribute( "00002-File-Open" )] public event BeforeOpenFileEventHandler BeforeOpenFileEvent;
      [Browsable( true )]
      [CategoryAttribute( "00002-File-Open" )] public event AfterOpenFileEventHandler AfterOpenFileEvent;

      // -----
      [Browsable( true )]
      [CategoryAttribute( "00003-File-Save" )] public event AllowedToSaveFileEventHandler AllowedToSaveFileEvent;

      [Browsable( true )]
      [CategoryAttribute( "00003-File-Save" )] public event NotAllowedToSaveFileEventHandler NotAllowedToSaveFileEvent;

      [Browsable( true )]
      [CategoryAttribute( "00003-File-Save" )] public event BeforeSaveFileEventHandler BeforeSaveFileEvent;

      [Browsable( true )]
      [CategoryAttribute( "00003-File-Save" )] public event AfterSaveFileEventHandler AfterSaveFileEvent;

      // -----
      [Browsable( true )]
      [CategoryAttribute( "00004-File-SaveAs" )] public event AllowedToSaveAsFileEventHandler AllowedToSaveAsFileEvent;

      [Browsable( true )]
      [CategoryAttribute( "00004-File-SaveAs" )] public event NotAllowedToSaveAsFileEventHandler NotAllowedToSaveAsFileEvent;

      [Browsable( true )]
      [CategoryAttribute( "00004-File-SaveAs" )] public event BeforeSaveAsFileEventHandler BeforeSaveAsFileEvent;

      [Browsable( true )]
      [CategoryAttribute( "00004-File-SaveAs" )] public event AfterSaveAsFileEventHandler AfterSaveAsFileEvent;

      // -----
      [Browsable( true )]
      [CategoryAttribute( "00004-File-SaveAs" )] public event SavedFileNameChangedEventHandler SavedFileNameChangedEvent;

      // -----
      [Browsable( true )]
      [CategoryAttribute( "00005-File-Close" )] public event AllowedToCloseFileEventHandler AllowedToCloseFileEvent;

      [Browsable( true )]
      [CategoryAttribute( "00005-File-Close" )] public event NotAllowedToCloseFileEventHandler NotAllowedToCloseFileEvent;

      [Browsable( true )]
      [CategoryAttribute( "00005-File-Close" )] public event BeforeCloseFileEventHandler BeforeCloseFileEvent;

      [Browsable( true )]
      [CategoryAttribute( "00005-File-Close" )] public event AfterCloseFileEventHandler AfterCloseFileEvent;
      //-------------------------------------------------------------------
      [Browsable( true )]
      [CategoryAttribute( "00000-Tree-Expand" )] public event AllowedToExpandAllEventHandler AllowedToExpandAllEvent;

      [Browsable( true )]
      [CategoryAttribute( "00000-Tree-Expand" )] public event NotAllowedToExpandAllEventHandler NotAllowedToExpandAllEvent;

      //
      [Browsable( true )]
      [CategoryAttribute( "00000-Tree-Expand" )] public event AllowedToExpandNodeEventHandler AllowedToExpandNodeEvent;

      [Browsable( true )]
      [CategoryAttribute( "00000-Tree-Expand" )] public event NotAllowedToExpandNodeEventHandler NotAllowedToExpandNodeEvent;

      //
      [Browsable( true )]
      [CategoryAttribute( "00000-Tree-Expand" )] public event AllowedToExpandChildrenEventHandler AllowedToExpandChildrenEvent;

      [Browsable( true )]
      [CategoryAttribute( "00000-Tree-Expand" )] public event NotAllowedToExpandChildrenEventHandler NotAllowedToExpandChildrenEvent;

      //
      [Browsable( true )]
      [CategoryAttribute( "00000-Tree-Collapse" )] public event AllowedToCollapseAllEventHandler AllowedToCollapseAllEvent;

      [Browsable( true )]
      [CategoryAttribute( "00000-Tree-Collapse" )] public event NotAllowedToCollapseAllEventHandler NotAllowedToCollapseAllEvent;

      //
      [Browsable( true )]
      [CategoryAttribute( "00000-Tree-Collapse" )] public event AllowedToCollapseNodeEventHandler AllowedToCollapseNodeEvent;

      [Browsable( true )]
      [CategoryAttribute( "00000-Tree-Collapse" )] public event NotAllowedToCollapseNodeEventHandler NotAllowedToCollapseNodeEvent;

      //-------------------------------------------------------------------
      [Browsable( true )]
      [CategoryAttribute( "00000-Obj-AppCS-Add" )] public event AllowedAddAppCSEventHandler AllowedAddAppCSEvent;

      [Browsable( true )]
      [CategoryAttribute( "00000-Obj-AppCS-Add" )] public event NotAllowedAddAppCSEventHandler NotAllowedAddAppCSEvent;

      [Browsable( true )]
      [CategoryAttribute( "00000-Obj-AppCS-Add" )] public event BeforeAddAppCSEventHandler BeforeAddAppCSEvent;

      [Browsable( true )]
      [CategoryAttribute( "00000-Obj-AppCS-Add" )] public event AfterAddAppCSEventHandler AfterAddAppCSEvent;

      // -----
      [Browsable( true )]
      [CategoryAttribute( "00000-Obj-AppCS-Clone" )] public event AllowedToCloneAppCSEventHandler AllowedToCloneAppCSEvent;

      [Browsable( true )]
      [CategoryAttribute( "00000-Obj-AppCS-Clone" )] public event NotAllowedToCloneAppCSEventHandler NotAllowedToCloneAppCSEvent;

      [Browsable( true )]
      [CategoryAttribute( "00000-Obj-AppCS-Clone" )] public event BeforeCloneAppCSEventHandler BeforeCloneAppCSEvent;

      [Browsable( true )]
      [CategoryAttribute( "00000-Obj-AppCS-Clone" )] public event AfterCloneAppCSEventHandler AfterCloneAppCSEvent;

      // -----
      [Browsable( true )]
      [CategoryAttribute( "00000-Obj-AppCS-Del" )] public event AllowedDelAppCSEventHandler AllowedDelAppCSEvent;

      [Browsable( true )]
      [CategoryAttribute( "00000-Obj-AppCS-Del" )] public event NotAllowedDelAppCSEventHandler NotAllowedDelAppCSEvent;

      [Browsable( true )]
      [CategoryAttribute( "00000-Obj-AppCS-Del" )] public event BeforeDelAppCSEventHandler BeforeDelAppCSEvent;

      [Browsable( true )]
      [CategoryAttribute( "00000-Obj-AppCS-Del" )] public event AfterDelAppCSEventHandler AfterDelAppCSEvent;

      // -----
      [Browsable( true )]
      [CategoryAttribute( "00000-Obj-AppCS-Focused" )] public event FocusedAppCSChangedEventHandler FocusedAppCSChangedEvent;

      //-------------------------------------------------------------------
      [Browsable( true )]
      [CategoryAttribute( "00000-Obj-DataStore-Add" )] public event AllowedAddDataStoreEventHandler AllowedAddDataStoreEvent;

      [Browsable( true )]
      [CategoryAttribute( "00000-Obj-DataStore-Add" )] public event NotAllowedAddDataStoreEventHandler NotAllowedAddDataStoreEvent;

      [Browsable( true )]
      [CategoryAttribute( "00000-Obj-DataStore-Add" )] public event BeforeAddDataStoreEventHandler BeforeAddDataStoreEvent;

      [Browsable( true )]
      [CategoryAttribute( "00000-Obj-DataStore-Add" )] public event AfterAddDataStoreEventHandler AfterAddDataStoreEvent;

      // -----
      [Browsable( true )]
      [CategoryAttribute( "00000-Obj-DataStore-Clone" )] public event AllowedToCloneDataStoreEventHandler AllowedToCloneDataStoreEvent;

      [Browsable( true )]
      [CategoryAttribute( "00000-Obj-DataStore-Clone" )] public event NotAllowedToCloneDataStoreEventHandler NotAllowedToCloneDataStoreEvent;

      [Browsable( true )]
      [CategoryAttribute( "00000-Obj-DataStore-Clone" )] public event BeforeCloneDataStoreEventHandler BeforeCloneDataStoreEvent;

      [Browsable( true )]
      [CategoryAttribute( "00000-Obj-DataStore-Clone" )] public event AfterCloneDataStoreEventHandler AfterCloneDataStoreEvent;

      // -----
      [Browsable( true )]
      [CategoryAttribute( "00000-Obj-DataStore-Del" )] public event AllowedDelDataStoreEventHandler AllowedDelDataStoreEvent;

      [Browsable( true )]
      [CategoryAttribute( "00000-Obj-DataStore-Del" )] public event NotAllowedDelDataStoreEventHandler NotAllowedDelDataStoreEvent;

      [Browsable( true )]
      [CategoryAttribute( "00000-Obj-DataStore-Del" )] public event BeforeDelDataStoreEventHandler BeforeDelDataStoreEvent;

      [Browsable( true )]
      [CategoryAttribute( "00000-Obj-DataStore-Del" )] public event AfterDelDataStoreEventHandler AfterDelDataStoreEvent;

      //-------------------------------------------------------------------
      [Browsable( true )]
      [CategoryAttribute( "00000-Obj-DataStore-Focused" )] public event FocusedDataStoreChangedEventHandler FocusedDataStoreChangedEvent;

      //-------------------------------------------------------------------
      #endregion

      #region --- Before and After NewFile EVENTS + HANDLERS + EXCEPTIONS ---
      private const string NEW_FILENAME = "[NewFile]";

      public void NewFile()
      {
         BeforeNewFileEventArgs args1 = new BeforeNewFileEventArgs( );
         AfterNewFileEventArgs args2 = new AfterNewFileEventArgs( args1 );
         args1.Filename = NEW_FILENAME;
         this.BeforeNewFileEvent?.Invoke( this, args1 );
         if( !args1.Cancel )
         {
            this.NewFileEvent( args1 );
         }
         this.AfterNewFileEvent?.Invoke( this, args2 );
      }

      private void NewFileEvent( BeforeNewFileEventArgs args )
      {
         try
         {
            if( this.VerifySavingStatus( ) )
            {
               this.cfg = Configuration.GetPoco( );
               this.LoadNodes( );
            }
         }
         catch( System.Exception ex )
         {
            args.Exception = new NewFileException( null, ex );
         }
         finally
         {
         }
      }

      private void AfterNewFileEventPostStatuses( object sender, AfterNewFileEventArgs ea )
      {
         if( !ea.isOk )
         {
            return;
         }

         this.AllowedToSaveAsFileEvent?.Invoke( this );
         this.AllowedToCloseFileEvent?.Invoke( this );
         //
         this.AllowedAddAppCSEvent?.Invoke( this );
         this.AllowedAddDataStoreEvent?.Invoke( this );
         //
         this.NotAllowedDelAppCSEvent?.Invoke( this );
         this.NotAllowedDelDataStoreEvent?.Invoke( this );
         this.DefaultFileName = ea.args.Filename;
      }
      #endregion

      #region --- Before and After OpenFile EVENTS + HANDLERS + EXCEPTIONS ---
      public void OpenFile( string filename = null )
      {
         BeforeOpenFileEventArgs args1 = new BeforeOpenFileEventArgs( );
         AfterOpenFileEventArgs args2 = new AfterOpenFileEventArgs( args1 );
         args1.SuggestedFilename = filename;
         this.BeforeOpenFileEvent?.Invoke( this, args1 );
         if( !args1.Cancel )
         {
            this.OpenFileEvent( args1 );
         }
         this.AfterOpenFileEvent?.Invoke( this, args2 );
      }

      private void OpenFileEvent( BeforeOpenFileEventArgs args )
      {
         try
         {
            if( this.VerifySavingStatus( ) )
            {
               using( XtraOpenFileDialog dialog = new DevExpress.XtraEditors.XtraOpenFileDialog( ) )
               {
                  dialog.InitialDirectory = this.initialPath;
                  dialog.ShowDragDropConfirmation = true;
                  dialog.AutoUpdateFilterDescription = false;
                  dialog.Filter = "cfg files|*.xml";
                  dialog.FileName = args.SuggestedFilename;
                  DialogResult dialogResult = dialog.ShowDialog( );
                  if( dialogResult == DialogResult.OK )
                  {
                     args.OpenedFilename = dialog.FileName;
                     XDocument doc = XDocument.Load( args.OpenedFilename, LoadOptions.None );
                     this.cfg = Configuration.GetPoco( doc.Root );
                     this.LoadNodes( );
                  }
                  else
                  {
                     args.Cancel = true;
                  }
               }
            }
         }
         catch( System.Exception ex )
         {
            args.Exception = new OpenFileException( null, ex );
         }
         finally
         {
         }
      }

      //@#$%
      private void AfterOpenFileEventPostStatuses( object sender, AfterOpenFileEventArgs ea )
      {
         this.DefaultFileName = ea.args.OpenedFilename;
         if( !ea.isOk )
         {
            return;
         }
         this.cfg.PropertyChanged += this.Cfg_PropertyChanged;
         //
         this.cfg.AllowedAddDataStoreEvent += this.Cfg_AllowedAddDataStoreEvent;
         this.cfg.NotAllowedAddDataStoreEvent += this.Cfg_NotAllowedAddDataStoreEvent;
         //
         this.cfg.AllowedDelDataStoreEvent += this.Cfg_AllowedDelDataStoreEvent;
         this.cfg.NotAllowedDelDataStoreEvent += this.Cfg_NotAllowedDelDataStoreEvent;
         //
         this.cfg.AllowedAddAppCSEvent += this.Cfg_AllowedAddAppCSEvent;
         this.cfg.NotAllowedAddAppCSEvent += this.Cfg_NotAllowedAddAppCSEvent;
         //
         this.cfg.AllowedDelAppCSEvent += this.Cfg_AllowedDelAppCSEvent;
         this.cfg.NotAllowedDelAppCSEvent += this.Cfg_NotAllowedDelAppCSEvent;
         //
         this.cfg.VerifyWhatIsAllowed( );
         //
         this.AllowedToOpenFileEvent?.Invoke( this );
         this.AllowedToSaveFileEvent?.Invoke( this );
         this.AllowedToSaveAsFileEvent?.Invoke( this );
         this.AllowedToCloseFileEvent?.Invoke( this );
         //@#$% Mandrake!!!
         this.NotAllowedDelAppCSEvent?.Invoke( this );
         this.NotAllowedDelDataStoreEvent?.Invoke( this );
      }
      #endregion

      #region --- Before and After SaveFile EVENTS + HANDLERS + EXCEPTIONS ---

      public void SaveFile( string filename = null )
      {
         BeforeSaveFileEventArgs args1 = new BeforeSaveFileEventArgs( );
         AfterSaveFileEventArgs args2 = new AfterSaveFileEventArgs( args1 );
         if( filename != null && string.IsNullOrWhiteSpace( filename ) )
         {
            args1.SavedFilename = filename.Trim( );
         }
         else
         {
            args1.SavedFilename = this.DefaultFileName;
         }
         this.BeforeSaveFileEvent?.Invoke( this, args1 );
         if( !args1.Cancel )
         {
            this.SaveFileEvent( args1 );
         }
         this.AfterSaveFileEvent?.Invoke( this, args2 );
      }

      private void SaveFileEvent( BeforeSaveFileEventArgs args )
      {
         if( this.cfg == null )
         {
            return;
         }

         try
         {
            this.x( ).Save( args.SavedFilename, SaveOptions.None );
            this.cfg.IsDirty = false;
         }
         catch( System.Exception ex )
         {
            args.Exception = new SaveFileException( null, ex );
         }
         finally
         {
         }
      }

      private void AfterSaveFileEventPostStatuses( object sender, AfterSaveFileEventArgs ea )
      {
         if( !ea.isOk )
         {
            return;
         }

         this.DefaultFileName = ea.args.SavedFilename;
         this.NotAllowedToSaveFileEvent.Invoke( this );
      }

      private bool VerifySavingStatus()
      {
         try
         {
            if( this.cfg != null && this.cfg.IsDirty )
            {
               // DIALOG COFIRMATION
               string msg = "Save File" + this.DefaultFileName + " before?";
               DialogResult dialogResult = XtraMessageBox.Show( msg, "Warning", MessageBoxButtons.YesNoCancel );
               switch( dialogResult )
               {
                  case DialogResult.Yes:
                     this.SaveAsFile( this.DefaultFileName );
                     return true; ;
                  case DialogResult.No:
                     return true;
                  default:
                     return false;
               }
            }
            return true;
         }
         catch( System.Exception ex )
         {
         }
         finally
         {
         }
         return false;
      }
      #endregion

      #region --- Before and After SaveAsFile EVENTS + HANDLERS + EXCEPTIONS ---
      public void SaveAsFile( string filename = null )
      {
         BeforeSaveAsFileEventArgs args1 = new BeforeSaveAsFileEventArgs( );
         AfterSaveAsFileEventArgs args2 = new AfterSaveAsFileEventArgs( args1 );
         args1.SuggestedFilename = filename;
         this.BeforeSaveAsFileEvent?.Invoke( this, args1 );
         if( !args1.Cancel )
         {
            this.SaveAsFileEvent( args1 );
         }
         this.AfterSaveAsFileEvent?.Invoke( this, args2 );
      }

      private void SaveAsFileEvent( BeforeSaveAsFileEventArgs args )
      {
         if( this.cfg == null )
         {
            return;
         }
         try
         {
            using( XtraSaveFileDialog dialog = new XtraSaveFileDialog( ) )
            {
               dialog.InitialDirectory = this.initialPath;
               dialog.ShowDragDropConfirmation = true;
               dialog.Filter = "cfg files|*.xml";
               dialog.CreatePrompt = true;
               dialog.OverwritePrompt = true;
               dialog.FileName = args.SuggestedFilename;
               DialogResult dialogResult = dialog.ShowDialog( );
               if( dialogResult == DialogResult.OK )
               {
                  args.SavedFilename = dialog.FileName;
                  this.x( ).Save( args.SavedFilename, SaveOptions.None );
                  //System.IO.File.WriteAllText( dialog.FileName, this.mainModule.Text );
               }
               else
               {
                  args.SuggestedFilename = NEW_FILENAME;
               }
            }
         }
         catch( System.Exception ex )
         {
            args.Exception = new SaveAsFileException( null, ex );
         }
         finally
         {
         }
      }

      private void AfterSaveAsFileEventPostStatuses( object sender, AfterSaveAsFileEventArgs ea )
      {
         this.DefaultFileName = ea.args.SavedFilename;
         this.NotAllowedToSaveFileEvent.Invoke( this );
      }

      private XDocument x()
      {
         XDocument doc =
            new XDocument(
               new XDeclaration( "1.0", "utf-8", "yes" ),
               new XComment( "LINQ to XML Contacts XML Example" ),
               new XProcessingInstruction( "MyApp", "123-44-4444" ),
               this.cfg.GetXElement( )
           );
         return doc;
      }
      #endregion

      #region --- Before and After CloseFile EVENTS + HANDLERS + EXCEPTIONS ---
      public void CloseFile()
      {
         if( this.cfg == null )
         {
            return;
         }

         BeforeCloseFileEventArgs args1 = new BeforeCloseFileEventArgs( );
         AfterCloseFileEventArgs args2 = new AfterCloseFileEventArgs( args1 );
         args1.Filename = this.DefaultFileName;
         this.BeforeCloseFileEvent?.Invoke( this, args1 );
         if( !args1.Cancel )
         {
            this.CloseFileEvent( args1 );
         }
         this.AfterCloseFileEvent?.Invoke( this, args2 );
      }

      private void CloseFileEvent( BeforeCloseFileEventArgs args )
      {
         try
         {
            if( this.VerifySavingStatus( ) )
            {
               this.treeView.BeginUpdate( );
               try
               {
                  this.treeView.Nodes.Clear( );
               }
               finally
               {
                  this.treeView.EndUpdate( );
               }
            }
         }
         catch( System.Exception ex )
         {
            args.Exception = new CloseFileException( null, ex );
         }
         finally
         {
         }
      }

      private void AfterCloseFileEventPostStatuses( object sender, AfterCloseFileEventArgs ea )
      {
         if( !ea.isOk )
         {
            return;
         }
         this.cfg.VerifyWhatIsAllowed( );
         this.cfg = null;
         this.AllowedToOpenFileEvent?.Invoke( this );
         this.NotAllowedToSaveFileEvent?.Invoke( this );
         this.NotAllowedToSaveAsFileEvent?.Invoke( this );
         this.NotAllowedToCloseFileEvent?.Invoke( this );
         //
         this.NotAllowedAddDataStoreEvent?.Invoke( this );
         this.NotAllowedDelDataStoreEvent?.Invoke( this );
         this.NotAllowedAddAppCSEvent?.Invoke( this );
         this.NotAllowedDelAppCSEvent?.Invoke( this );
      }

      #endregion

      // SetWorkingDirectorty

      #region --- Expand and Collapse ---
      public void ExpandAll()
      {
         this.treeView.ExpandAll( );
      }

      public void ExpandNode()
      {
         TreeListMultiSelection selection = this.treeView.Selection;
         if( selection.Count > 0 )
         {
            TreeListNode node = selection[ 0 ];
            node.Expand( );
         }
      }

      public void ExpandChildren()
      {
         TreeListMultiSelection selection = this.treeView.Selection;
         if( selection.Count > 0 )
         {
            TreeListNode node = selection[ 0 ];
            node.ExpandAll( );
         }
      }

      public void CollapseAll()
      {
         this.treeView.CollapseAll( );
      }

      public void CollapseNode()
      {
         TreeListMultiSelection selection = this.treeView.Selection;
         if( selection.Count > 0 )
         {
            TreeListNode node = selection[ 0 ];
            node.Collapse( );
         }
      }
      #endregion

      #region --- Before and After AddAppCS EVENTS + HANDLERS + EXCEPTIONS ---
      public void AddAppCS()
      {
         BeforeAddAppCSEventArgs args1 = new BeforeAddAppCSEventArgs( );
         AfterAddAppCSEventArgs args2 = new AfterAddAppCSEventArgs( args1 );
         this.BeforeAddAppCSEvent?.Invoke( this, args1 );
         if( !args1.Cancel )
         {
            this.AddAppCSEvent( args1 );
         }
         this.AfterAddAppCSEvent?.Invoke( this, args2 );
      }

      private void AddAppCSEvent( BeforeAddAppCSEventArgs args )
      {
         try
         {
            this.AddAppCSCore( args );
         }
         catch( System.Exception ex )
         {
            args.Exception = new AddAppCSException( null, ex );
         }
         finally
         {
         }
      }

      private void AddAppCSCore( BeforeAddAppCSEventArgs args )
      {
         if( this.cfg == null )
         {
            args.Cancel = true;
            args.Exception = new AddAppCSException( "cfg is null!" );
            return;
         }

         string defaultName = $"CS{this.cfg.AppCsList.Count + 1:00000}";
         string rtn = XtraInputBox.Show( "Enter a new unique name for it!", "New AppCS", defaultName );
         if( string.IsNullOrWhiteSpace( rtn ) )
         {
            args.Cancel = true;
            args.Exception = new AddAppCSException( "name cannot be null!" );
            return;
         }
         string newName = rtn.Trim( );
         //
         bool foundAtSysCS = this.cfg.ContainsSysCS( newName );
         bool foundAtAppCS = this.cfg.ContainsAppCS( newName );
         if( foundAtAppCS )
         {
            XtraMessageBox.Show( "Duplicate AppCS name, try again!", "Error", MessageBoxButtons.OK );
            args.Cancel = true;
            args.Exception = new AddAppCSException( "name must be unique!" );
            return;
         }
         if( foundAtSysCS )
         {
            DialogResult dialogResult = XtraMessageBox.Show( "This name hides another SysCS name!", "Warning", MessageBoxButtons.OKCancel );
            switch( dialogResult )
            {
               case DialogResult.OK:
                  break;
               case DialogResult.Cancel:
               default:
                  args.Cancel = true;
                  return;
            }
         }
         this.cfg.AddAppCS( new ConnectionString( newName ) );
         this.LoadNodes( );
      }

      private void AfterAddAppCSEventPostStatuses( object sender, AfterAddAppCSEventArgs ea )
      {
         if( !ea.isOk )
         {
            return;
         }
         if( string.Compare( this.DefaultFileName, NEW_FILENAME, StringComparison.Ordinal ) == 0 )
         {
            this.AllowedToSaveAsFileEvent?.Invoke( this );
         }
         else
         {
            this.AllowedToSaveFileEvent?.Invoke( this );
         }
      }
      #endregion

      #region --- Before and After CloneAppCS EVENTS + HANDLERS + EXCEPTIONS ---
      public void CloneAppCS()
      {
         // VERIFY IF THE APPCS IS USED BY ANYONE OR IF EXISTS A SYSCS WITH THE SAME NAME!!!
         TreeListMultiSelection selection = this.treeView.Selection;
         if( selection.Count > 0 )
         {
            TreeListNode origNode = selection[ 0 ];
            ConnectionString appCS = origNode.Tag as ConnectionString;
            AfterCloneAppCSEventArgs args = this.CloneAppCS( appCS );
            if( args.isOk )
            {
               TreeListNode newNode = this.treeView.AppendNode( new object[ ] { args.args.NewCS.Name }, this.appcsNode );
               newNode.ImageIndex = newNode.SelectImageIndex = 0; newNode.StateImageIndex = 0;
               newNode.Tag = args.args.NewCS;
               //newNode.TreeList.SetFocusedNode( newNode );
               this.treeView.SetFocusedNode( newNode );
            }
            return;
         }
         XtraMessageBox.Show( "Some AppCS or SysCS need to be selected first!", "Error", MessageBoxButtons.OK );
      }

      public AfterCloneAppCSEventArgs CloneAppCS( ConnectionString appCS )
      {
         BeforeCloneAppCSEventArgs args1 = new BeforeCloneAppCSEventArgs( );
         AfterCloneAppCSEventArgs args2 = new AfterCloneAppCSEventArgs( args1 );
         args1.OrigCS = appCS;
         this.BeforeCloneAppCSEvent?.Invoke( this, args1 );
         if( !args1.Cancel )
         {
            this.CloneAppCSEvent( args1 );
         }
         this.AfterCloneAppCSEvent?.Invoke( this, args2 );
         return args2;
      }

      private void CloneAppCSEvent( BeforeCloneAppCSEventArgs args )
      {
         try
         {
            ConnectionString o = args.OrigCS.Clone( );
            bool containsAppCS = this.cfg.ContainsAppCS( o.Name );
            o.Name = containsAppCS ? o.Name + "_Copy" : o.Name;
            this.cfg.AddAppCS( o );
            args.NewCS = o;
         }
         catch( System.Exception ex )
         {
            args.Exception = new CloneAppCSException( null, ex );
         }
         finally
         {
         }
      }

      private void AfterCloneAppCSEventPostStatuses( object sender, AfterCloneAppCSEventArgs ea )
      {
         if( ea.isOk )
         {
            return;
         }
      }
      #endregion

      #region --- Before and After DelAppCSEvent EVENTS + HANDLERS + EXCEPTIONS ---
      public void DelAppCS()
      {
         // VERIFY IF THE APPCS IS USED BY ANYONE OR IF EXISTS A SYSCS WITH THE SAME NAME!!!
         TreeListMultiSelection selection = this.treeView.Selection;
         if( selection.Count > 0 )
         {
            TreeListNode node = selection[ 0 ];
            ConnectionString appCS = node.Tag as ConnectionString;
            AfterDelAppCSEventArgs args = this.DelAppCSEvent( appCS );
            if( args.isOk )
            {
               if( node.NextNode != null )
               {
                  node.NextNode.TreeList.SetFocusedNode( node.NextNode );
               }
               else if( node.PrevNode != null )
               {
                  node.PrevNode.TreeList.SetFocusedNode( node.PrevNode );
               }
               node.Remove( );
            }
            return;
         }
         XtraMessageBox.Show( "Some ConnectionString need to be selected first!", "Error", MessageBoxButtons.OK );
      }

      public AfterDelAppCSEventArgs DelAppCSEvent( ConnectionString appCS )
      {
         BeforeDelAppCSEventArgs args1 = new BeforeDelAppCSEventArgs( );
         AfterDelAppCSEventArgs args2 = new AfterDelAppCSEventArgs( args1 );
         args1.AppCS = appCS;
         this.BeforeDelAppCSEvent?.Invoke( this, args1 );
         if( !args1.Cancel )
         {
            this.DelAppCSEvent( args1 );
         }
         this.AfterDelAppCSEvent?.Invoke( this, args2 );
         return args2;
      }

      private void DelAppCSEvent( BeforeDelAppCSEventArgs args )
      {
         try
         {
            //@#$% VERIFY REFERENTIAL INTEGRITY APPCS+SYSCS -->> DATASTORE
            // DIALOG COFIRMATION
            bool isBeingReferenced = this.cfg.IsBeingReferenced( args.AppCS );
            bool containsSysCS = this.cfg.ContainsSysCS( args.AppCS.Name );
            string msg = $"Your are about to delete AppCS \"{args.AppCS.Name}\"...";
            if( isBeingReferenced && containsSysCS )
            {
               msg += "\nBy remove this AppCS, all references will be point to SysCS";
            }
            else if( isBeingReferenced && !containsSysCS )
            {
               msg = "You are not allowed to remove this AppCS!"
                  + "\nTo avoid dangling references from DataStores!"
                  ;
               XtraMessageBox.Show( msg, "Error", MessageBoxButtons.OK );
               args.Cancel = true;
               args.Exception = new DelAppCSException( msg );
               return;
            }
            else if( !isBeingReferenced && containsSysCS )
            {
               msg += "\nBy remove this you will unhide the existent SysCS!";
            }
            else if( !isBeingReferenced && !containsSysCS )
            {
            }
            msg += "\nAre you sure?";
            DialogResult dialogResult = XtraMessageBox.Show( msg, "Warning", MessageBoxButtons.YesNoCancel );
            switch( dialogResult )
            {
               case DialogResult.Yes:
                  break;
               default:
                  args.Cancel = true;
                  return;
            }
            // BEFORE DEL
            ConnectionString delAppCS = this.cfg.DelAppCS( args.AppCS.Name );
         }
         catch( System.Exception ex )
         {
            args.Exception = new DelAppCSException( null, ex );
         }
         finally
         {
         }
      }

      private void AfterDelAppCSEventPostStatuses( object sender, AfterDelAppCSEventArgs ea )
      {
         if( !ea.isOk )
         {
            return;
         }
         if( string.Compare( this.DefaultFileName, NEW_FILENAME, StringComparison.Ordinal ) == 0 )
         {
            this.AllowedToSaveAsFileEvent?.Invoke( this );
         }
         else
         {
            this.AllowedToSaveFileEvent?.Invoke( this );
         }
      }
      #endregion

      #region --- Before and After AddDataStore EVENTS + HANDLERS + EXCEPTIONS ---
      public void AddDataStore()
      {
         BeforeAddDataStoreEventArgs args1 = new BeforeAddDataStoreEventArgs( );
         AfterAddDataStoreEventArgs args2 = new AfterAddDataStoreEventArgs( args1 );
         this.BeforeAddDataStoreEvent?.Invoke( this, args1 );
         if( !args1.Cancel )
         {
            this.AddDataStoreEvent( args1 );
         }
         this.AfterAddDataStoreEvent?.Invoke( this, args2 );
      }

      private void AddDataStoreEvent( BeforeAddDataStoreEventArgs args )
      {
         if( this.cfg == null )
         {
            args.Cancel = true;
            args.Exception = new AddDataStoreException( "cfg is null!" );
            return;
         }
         try
         {
            string defaultName = $"DS{this.cfg.DsList.Count + 1:00000}";
            string rtn = XtraInputBox.Show( "Enter a new unique name for it!", "New DataStore", defaultName );
            if( string.IsNullOrWhiteSpace( rtn ) )
            {
               args.Cancel = true;
               args.Exception = new AddDataStoreException( "name cannot be null!" );
               return;
            }
            string newName = rtn.Trim( );
            //
            bool foundDataStore = this.cfg.ContainsDataStore( newName );
            if( foundDataStore )
            {
               XtraMessageBox.Show( "Duplicate DataStore name, try again!", "Error", MessageBoxButtons.OK );
               args.Cancel = true;
               args.Exception = new AddDataStoreException( "name must be unique!" );
               return;
            }
            DataStore newDS = new DataStore( newName );
            this.cfg.AddDataStore( newDS );
            TreeListNode newNode = this.treeView.AppendNode( new object[ ] { newDS.Name }, this.dsNode );
            newNode.ImageIndex = newNode.SelectImageIndex = 0; newNode.StateImageIndex = 0;
            newNode.Tag = newDS;
            //newNode.TreeList.SetFocusedNode( newNode );
            this.treeView.SetFocusedNode( newNode );
         }
         catch( System.Exception ex )
         {
            args.Exception = new AddDataStoreException( null, ex );
         }
         finally
         {
         }
      }

      private void AfterAddDataStoreEventPostStatuses( object sender, AfterAddDataStoreEventArgs ea )
      {
         if( ea.isOk )
         {
            return;
         }
      }
      #endregion

      #region --- Before and After CloneDataStore EVENTS + HANDLERS + EXCEPTIONS ---
      public void CloneDataStore()
      {
         // VERIFY IF THE APPCS IS USED BY ANYONE OR IF EXISTS A SYSCS WITH THE SAME NAME!!!
         TreeListMultiSelection selection = this.treeView.Selection;
         if( selection.Count > 0 )
         {
            TreeListNode origNode = selection[ 0 ];
            DataStore ds = origNode.Tag as DataStore;
            AfterCloneDataStoreEventArgs args = this.CloneDataStore( ds );
            if( args.isOk )
            {
               TreeListNode newNode = this.treeView.AppendNode( new object[ ] { args.args.NewDS.Name }, this.dsNode );
               newNode.ImageIndex = newNode.SelectImageIndex = 0; newNode.StateImageIndex = 0;
               newNode.Tag = args.args.NewDS;
               //newNode.TreeList.SetFocusedNode( newNode );
               this.treeView.SetFocusedNode( newNode );
            }
            return;
         }
         XtraMessageBox.Show( "Some DataStore need to be selected first!", "Error", MessageBoxButtons.OK );
      }

      public AfterCloneDataStoreEventArgs CloneDataStore( DataStore ds )
      {
         BeforeCloneDataStoreEventArgs args1 = new BeforeCloneDataStoreEventArgs( );
         AfterCloneDataStoreEventArgs args2 = new AfterCloneDataStoreEventArgs( args1 );
         args1.OrigDS = ds;
         this.BeforeCloneDataStoreEvent?.Invoke( this, args1 );
         if( !args1.Cancel )
         {
            this.CloneDataStoreEvent( args1 );
         }
         this.AfterCloneDataStoreEvent?.Invoke( this, args2 );
         return args2;
      }

      private void CloneDataStoreEvent( BeforeCloneDataStoreEventArgs args )
      {
         try
         {
            DataStore o = args.OrigDS.Clone( );
            bool contains = this.cfg.ContainsDataStore( o.Name );
            o.Name = contains ? o.Name + "_Copy" : o.Name;
            this.cfg.AddDataStore( o );
            args.NewDS = o;
         }
         catch( System.Exception ex )
         {
            args.Exception = new CloneDataStoreException( null, ex );
         }
         finally
         {
         }
      }

      private void AfterCloneDataStoreEventPostStatuses( object sender, AfterCloneDataStoreEventArgs ea )
      {
         if( ea.isOk )
         {
            return;
         }
      }

      // this.AfterCloneDataStoreEvent += this.AfterCloneDataStoreEventPostStatuses;
      #endregion

      #region --- Before and After DelDataStore EVENTS + HANDLERS + EXCEPTIONS ---

      public void DelDataStore()
      {
         // VERIFY IF THE APPCS IS USED BY ANYONE OR IF EXISTS A SYSCS WITH THE SAME NAME!!!
         TreeListMultiSelection selection = this.treeView.Selection;
         if( selection.Count > 0 )
         {
            TreeListNode node = selection[ 0 ];
            DataStore ds = node.Tag as DataStore;
            AfterDelDataStoreEventArgs args = this.DelDataStore( ds );
            if( args.isOk )
            {
               if( node.NextNode != null )
               {
                  node.NextNode.TreeList.SetFocusedNode( node.NextNode );
               }
               else if( node.PrevNode != null )
               {
                  node.PrevNode.TreeList.SetFocusedNode( node.PrevNode );
               }
               node.Remove( );
            }
            return;
         }
         XtraMessageBox.Show( "Some DataStore need to be selected first!", "Error", MessageBoxButtons.OK );
      }

      public AfterDelDataStoreEventArgs DelDataStore( DataStore ds )
      {
         BeforeDelDataStoreEventArgs args1 = new BeforeDelDataStoreEventArgs( );
         AfterDelDataStoreEventArgs args2 = new AfterDelDataStoreEventArgs( args1 );
         args1.DataStore = ds;
         this.BeforeDelDataStoreEvent?.Invoke( this, args1 );
         if( !args1.Cancel )
         {
            this.DelDataStoreEvent( args1 );
         }
         this.AfterDelDataStoreEvent?.Invoke( this, args2 );
         return args2;
      }
      //
      private void DelDataStoreEvent( BeforeDelDataStoreEventArgs args )
      {
         try
         {
            DataStore delDS = this.cfg.DelDataStore( args.DataStore.Name );
         }
         catch( System.Exception ex )
         {
            args.Exception = new DelDataStoreException( null, ex );
         }
         finally
         {

         }
      }
      //
      private void AfterDelDataStoreEventPostStatuses( object sender, AfterDelDataStoreEventArgs ea )
      {
         if( ea.isOk )
         {
            return;
         }
         if( string.Compare( this.DefaultFileName, NEW_FILENAME, StringComparison.Ordinal ) == 0 )
         {
            this.AllowedToSaveAsFileEvent?.Invoke( this );
         }
         else
         {
            this.AllowedToSaveFileEvent?.Invoke( this );
         }
      }
      // this.AfterDelDataStoreEvent += this.AfterDelDataStoreEventPostStatuses;
      #endregion

   }
}
