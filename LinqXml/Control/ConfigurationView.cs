using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using LinqXml.Control.Configuration.AddAppCS;
using LinqXml.Control.Configuration.AddDataStore;
using LinqXml.Control.Configuration.CloseFile;
using LinqXml.Control.Configuration.DelAppCS;
using LinqXml.Control.Configuration.DelDataStore;
using LinqXml.Control.Configuration.NewFile;
using LinqXml.Control.Configuration.OpenFile;
using LinqXml.Control.SaveAs;
using LinqXml.Control.SaveFile;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LinqXml.Control
{
   public partial class ConfigurationView : DevExpress.XtraEditors.XtraUserControl
   {
      #region --- Properties and Backing Fields... ---
      private LinqXml.Configuration cfg;
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
         this.AfterAddConnectionStringEvent += this.AfterAddConnectionStringEventPostStatuses;
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
         this.NotAllowedDelAppCSEvent?.Invoke( this );
         //
         this.NotAllowedAddDataStoreEvent?.Invoke( this );
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
         if( e.Node?.Tag == null )
         {  //@#$% Is not working...
            this.NotAllowedDelAppCSEvent?.Invoke( this );
            this.NotAllowedDelDataStoreEvent?.Invoke( this );
            return;
         }
         TreeListNode oldNode = e.OldNode;
         TreeListNode node = e.Node;
         string cellText = node[ 0 ] as string;
         if( node.Tag is DataStore )
         {
            FocusedDataStoreChangedEventArgs args = new FocusedDataStoreChangedEventArgs( );
            args.DataStore = node.Tag as DataStore;
            this.FocusedDataStoreChangedEvent?.Invoke( this, args );
            //
            this.NotAllowedDelAppCSEvent?.Invoke( this );
            this.AllowedDelDataStoreEvent?.Invoke( this );
         }
         else if( node.Tag is ConnectionString )
         {
            FocusedConnectionStringChangedEventArgs args = new FocusedConnectionStringChangedEventArgs( );
            args.ConnectionString = node.Tag as ConnectionString;
            this.FocusedConnectionStringChangedEvent?.Invoke( this, args );
            //
            if( args.ConnectionString.IsSys )
            {
               this.NotAllowedDelAppCSEvent?.Invoke( this );
            }
            else
            {
               this.AllowedDelAppCSEvent?.Invoke( this );
            }
            this.NotAllowedDelDataStoreEvent?.Invoke( this );
         }
         else
         {
            this.NotAllowedDelAppCSEvent?.Invoke( this );
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
         finally
         {
            this.treeView.EndUpdate( );
         }
      }

      private void LoadTreeListNodes( TreeList treeView )
      {
         //XDocument doc = LinqXmlTest.GetDsCfgDoc( );
         //this.cfg = Configuration.GetPoco( doc.Root );
         // nodedata, parentId, imgIdx, selectImgIdx, stateImgIdx, chkState, tag
         TreeListNode dsNode = this.treeView.AppendNode( new object[ ] { "DataStores" }, -1 );
         TreeListNode csNode = this.treeView.AppendNode( new object[ ] { nameof( ConnectionString ) }, -1 );
         TreeListNode appcsNode = this.treeView.AppendNode( new object[ ] { nameof( Application ) }, csNode );
         TreeListNode syscsNode = this.treeView.AppendNode( new object[ ] { "System" }, csNode );
         //
         dsNode.ImageIndex = -1; dsNode.SelectImageIndex = -1; dsNode.StateImageIndex = -1;
         csNode.ImageIndex = -1; csNode.SelectImageIndex = -1; csNode.StateImageIndex = -1;
         appcsNode.ImageIndex = -1; appcsNode.SelectImageIndex = -1; appcsNode.StateImageIndex = -1;
         syscsNode.ImageIndex = -1; syscsNode.SelectImageIndex = -1; syscsNode.StateImageIndex = -1;
         //
         foreach( DataStore ds in this.cfg.DsList )
         {
            TreeListNode node = this.treeView.AppendNode( new object[ ] { ds.Name }, dsNode );
            node.ImageIndex = node.SelectImageIndex = 0; node.StateImageIndex = 0;
            node.Tag = ds;
         }
         foreach( ConnectionString cs in this.cfg.AppCsList )
         {
            TreeListNode node = this.treeView.AppendNode( new object[ ] { cs.Name }, appcsNode );
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
         this.LoadNodes( );
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
      public event AllowedNewFileEventHandler AllowedNewFileEvent;

      public event NotAllowedNewFileEventHandler NotAllowedNewFileEvent;

      public event BeforeNewFileEventHandler BeforeNewFileEvent;

      public event AfterNewFileEventHandler AfterNewFileEvent;

      public event AllowedToOpenFileEventHandler AllowedToOpenFileEvent;

      public event NotAllowedToOpenFileEventHandler NotAllowedToOpenFileEvent;

      public event BeforeOpenFileEventHandler BeforeOpenFileEvent;

      public event AfterOpenFileEventHandler AfterOpenFileEvent;

      public event AllowedToSaveFileEventHandler AllowedToSaveFileEvent;

      public event NotAllowedToSaveFileEventHandler NotAllowedToSaveFileEvent;

      public event BeforeSaveFileEventHandler BeforeSaveFileEvent;

      public event AfterSaveFileEventHandler AfterSaveFileEvent;

      public event AllowedToSaveAsFileEventHandler AllowedToSaveAsFileEvent;

      public event NotAllowedToSaveAsFileEventHandler NotAllowedToSaveAsFileEvent;

      public event BeforeSaveAsFileEventHandler BeforeSaveAsFileEvent;

      public event AfterSaveAsFileEventHandler AfterSaveAsFileEvent;

      public event SavedFileNameChangedEventHandler SavedFileNameChangedEvent;

      public event AllowedToCloseFileEventHandler AllowedToCloseFileEvent;

      public event NotAllowedToCloseFileEventHandler NotAllowedToCloseFileEvent;

      public event BeforeCloseFileEventHandler BeforeCloseFileEvent;

      public event AfterCloseFileEventHandler AfterCloseFileEvent;

      public event AllowedAddAppCSEventHandler AllowedAddAppCSEvent;

      public event NotAllowedAddAppCSEventHandler NotAllowedAddAppCSEvent;

      public event BeforeAddAppCSEventHandler BeforeAddConnectionStringEvent;

      public event AfterAddAppCSEventHandler AfterAddConnectionStringEvent;

      public event AllowedDelAppCSEventHandler AllowedDelAppCSEvent;

      public event NotAllowedDelAppCSEventHandler NotAllowedDelAppCSEvent;

      public event BeforeDelAppCSEventHandler BeforeDelConnectionStringEvent;

      public event AfterDelAppCSEventHandler AfterDelConnectionStringEvent;

      public event AllowedAddDataStoreEventHandler AllowedAddDataStoreEvent;

      public event NotAllowedAddDataStoreEventHandler NotAllowedAddDataStoreEvent;

      public event BeforeAddDataStoreEventHandler BeforeAddDataStoreEvent;

      public event AfterAddDataStoreEventHandler AfterAddDataStoreEvent;

      public event AllowedDelDataStoreEventHandler AllowedDelDataStoreEvent;

      public event NotAllowedDelDataStoreEventHandler NotAllowedDelDataStoreEvent;

      public event FocusedDataStoreChangedEventHandler FocusedDataStoreChangedEvent;

      public event FocusedAppCSChangedEventHandler FocusedConnectionStringChangedEvent;

      #region --- Before and After NewFile EVENTS + HANDLERS + EXCEPTIONS ---
      public void NewFile( string filename )
      {
         BeforeNewFileEventArgs args1 = new BeforeNewFileEventArgs( );
         AfterNewFileEventArgs args2 = new AfterNewFileEventArgs( args1 );
         args1.Filename = filename;
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
               this.cfg = LinqXml.Configuration.GetPoco( );
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
                     this.cfg = LinqXml.Configuration.GetPoco( doc.Root );
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

      #region --- Before and After AddConnectionString EVENTS + HANDLERS + EXCEPTIONS ---
      public void AddConnectionString()
      {
         BeforeAddAppCSEventArgs args1 = new BeforeAddAppCSEventArgs( );
         AfterAddAppCSEventArgs args2 = new AfterAddAppCSEventArgs( args1 );
         this.BeforeAddConnectionStringEvent?.Invoke( this, args1 );
         if( !args1.Cancel )
         {
            this.AddConnectionStringEvent( args1 );
         }
         this.AfterAddConnectionStringEvent?.Invoke( this, args2 );
      }

      private void AddConnectionStringEvent( BeforeAddAppCSEventArgs args )
      {
         try
         {
            this.AddConnectionStringCore( args );
         }
         catch( System.Exception ex )
         {
            args.Exception = new AddAppCSException( null, ex );
         }
         finally
         {
         }
      }

      private void AddConnectionStringCore( BeforeAddAppCSEventArgs args )
      {
         if( this.cfg == null )
         {
            args.Cancel = true;
            args.Exception = new AddAppCSException( "cfg is null!" );
            return;
         }

         string defaultName = $"CS{this.cfg.AppCsList.Count + 1:00000}";
         string rtn = XtraInputBox.Show( "Enter a new unique name for it!", "New ConnectionString", defaultName );
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
            XtraMessageBox.Show( "Duplicate Application ConnectionString name, try again!", "Error", MessageBoxButtons.OK );
            args.Cancel = true;
            args.Exception = new AddAppCSException( "name must be unique!" );
            return;
         }
         if( foundAtSysCS )
         {
            DialogResult dialogResult = XtraMessageBox.Show( "This name hides another System ConnectionString name!", "Warning", MessageBoxButtons.OKCancel );
            switch( dialogResult )
            {
               case DialogResult.OK:
                  break;
               case DialogResult.Cancel:
               default:
                  args.Cancel = true;
                  return;
            }
            return;
         }
         this.cfg.AddConnectionString( new ConnectionString( newName ) );
         this.LoadNodes( );
      }

      private void AfterAddConnectionStringEventPostStatuses( object sender, AfterAddAppCSEventArgs ea )
      {
         if( !ea.isOk )
         {
            return;
         }

         this.AllowedToSaveFileEvent?.Invoke( this );
      }
      #endregion

      #region --- Before and After DelConnectionString EVENTS + HANDLERS + EXCEPTIONS ---
      public void DelConnectionString( ConnectionString appCS )
      {
         BeforeDelAppCSEventArgs args1 = new BeforeDelAppCSEventArgs( );
         AfterDelAppCSEventArgs args2 = new AfterDelAppCSEventArgs( args1 );
         args1.AppCS = appCS;
         this.BeforeDelConnectionStringEvent?.Invoke( this, args1 );
         if( !args1.Cancel )
         {
            this.DelConnectionStringEvent( args1 );
         }
         this.AfterDelConnectionStringEvent?.Invoke( this, args2 );
      }

      public void DelConnectionStringXXX()
      {
         // VERIFY IF THE APPCS IS USED BY ANYONE OR IF EXISTS A SYSCS WITH THE SAME NAME!!!
         TreeListMultiSelection selection = this.treeView.Selection;
         if( selection.Count > 0 )
         {
            TreeListNode node = selection[ 0 ];
            if( node.NextNode != null )
            {
               node.NextNode.TreeList.SetFocusedNode( node.NextNode );
            }
            else if( node.PrevNode != null )
            {
               node.PrevNode.TreeList.SetFocusedNode( node.PrevNode );
            }
            ConnectionString appCS = node.Tag as ConnectionString;
            this.DelConnectionString( appCS );
            this.AllowedToSaveFileEvent?.Invoke( this );
            return;
         }
         XtraMessageBox.Show( "Some ConnectionString need to be selected first!", "Error", MessageBoxButtons.OK );
      }

      private void DelConnectionStringEvent( BeforeDelAppCSEventArgs args )
      {
         try
         {
            // DIALOG COFIRMATION
            DialogResult dialogResult = XtraMessageBox.Show( "Are you sure?", "Warning", MessageBoxButtons.YesNoCancel );
            switch( dialogResult )
            {
               case DialogResult.Yes:
                  break;
               default:
                  args.Cancel = true;
                  return;
            }
            // BEFORE DEL
            ConnectionString delAppCS = this.cfg.DelConnectionString( args.AppCS.Name );
         }
         catch( System.Exception ex )
         {
            args.Exception = new DelAppCSException( null, ex );
         }
         finally
         {
         }
      }
      #endregion

      #region --- Before and After AddDataStore EVENTS + HANDLERS + EXCEPTIONS ---
      public void AddDataStore( string filename )
      {
         BeforeAddDataStoreEventArgs args1 = new BeforeAddDataStoreEventArgs( );
         AfterAddDataStoreEventArgs args2 = new AfterAddDataStoreEventArgs( args1 );
         args1.Filename = filename;
         this.BeforeAddDataStoreEvent?.Invoke( this, args1 );
         if( !args1.Cancel )
         {
            this.AddDataStoreEvent( args1 );
         }
         this.AfterAddDataStoreEvent?.Invoke( this, args2 );
      }

      public void AddDataStoreXXX()
      {
         LoginUserControl myControl = new LoginUserControl( );
         if( DevExpress.XtraEditors.XtraDialog.Show( myControl, "Sign in", MessageBoxButtons.OKCancel ) == DialogResult.OK )
         {
            // do something 
         }
         this.AllowedToSaveFileEvent?.Invoke( this );
      }


      private void AddDataStoreEvent( BeforeAddDataStoreEventArgs args )
      {
         try
         {
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

      // this.AfterAddDataStoreEvent += this.AfterAddDataStoreEventPostStatuses;
      #endregion

      public void DelDataStore()
      {
         string name = null;
         DataStore delDS = this.cfg.DelDataStore( name );
         this.AllowedToSaveFileEvent?.Invoke( this );
      }

      #endregion
   }
}
