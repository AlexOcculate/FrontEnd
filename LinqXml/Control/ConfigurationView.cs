using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LinqXml.Control
{
   public partial class ConfigurationView : DevExpress.XtraEditors.XtraUserControl
   {
      private Configuration cfg;

      public ConfigurationView()
      {
         this.InitializeComponent( );
         this.InitializeTreeView( this.treeView );
         this.AfterOpenFileEvent += this.ConfigurationView_AfterOpenFileEvent;
         this.AfterSaveAsFileEvent += this.ConfigurationView_AfterSaveAsFileEvent;
         this.AfterSaveFileEvent += this.ConfigurationView_AfterSaveFileEvent;
         //this.AddAllNodes( true );
         //this.LoadNodes( );
      }

      private string initialPath = string.Empty;
      private string defaultFileName = "cfg.xml";

      private void ConfigurationView_AfterOpenFileEvent( object sender, AfterOpenFileEventArgs ea )
      {
         this.defaultFileName = ea.args.OpenedFilename;
      }
      private void ConfigurationView_AfterSaveFileEvent( object sender, AfterSaveFileEventArgs ea )
      {
         this.defaultFileName = ea.args.SavedFilename;
      }
      private void ConfigurationView_AfterSaveAsFileEvent( object sender, AfterSaveAsFileEventArgs ea )
      {
         this.defaultFileName = ea.args.SavedFilename;
      }

      public void InitializeTreeView( TreeList treeView )
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

      private void treeView_FocusedNodeChanged( object sender, FocusedNodeChangedEventArgs e )
      {
         if( e.Node?.Tag == null )
         {
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
         }
         else if( node.Tag is ConnectionString )
         {
            FocusedConnectionStringChangedEventArgs args = new FocusedConnectionStringChangedEventArgs( );
            args.ConnectionString = node.Tag as ConnectionString;
            this.FocusedConnectionStringChangedEvent?.Invoke( this, args );
         }
      }

      private void treeView_CustomDrawNodeCell( object sender, CustomDrawNodeCellEventArgs e )
      {
         if( e.Node.Id == 1 )
         {
            e.Appearance.Font = new System.Drawing.Font( e.Appearance.Font, FontStyle.Bold );
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
         if( this.cfg == null ) return;
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
         foreach( ConnectionString cs in this.cfg.CsList )
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
      }

      private void AddAllNodes( bool showAll )
      {
         this.treeView.AppendNode( new object[ ]
         { "Solution \'VisualStudioInspiredUIDemo\' (1 project)" },
                                  -1,
                                  -1,
                                  -1,
                                  3 ); //0
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

      #region --- Before and After OpenFile EVENTS + HANDLERS + EXCEPTIONS ---
      public delegate void BeforeOpenFileEventHandler( object sender, BeforeOpenFileEventArgs ea );
      public event BeforeOpenFileEventHandler BeforeOpenFileEvent;
      public class BeforeOpenFileEventArgs : System.EventArgs
      {
         public bool Cancel { get; set; }
         public string SuggestedFilename { get; set; }
         public string OpenedFilename { get; set; }
         public OpenFileException Exception { get; set; }
      }
      //
      public delegate void AfterOpenFileEventHandler( object sender, AfterOpenFileEventArgs ea );
      public event AfterOpenFileEventHandler AfterOpenFileEvent;
      public class AfterOpenFileEventArgs : System.EventArgs
      {
         public BeforeOpenFileEventArgs args;
         public bool wasCanceled { get { return this.args == null ? false : this.args.Cancel; } }
         public bool hasException { get { return this.args.Exception != null; } }
         public bool isOk { get { return !this.wasCanceled && !this.hasException; } }
         public AfterOpenFileEventArgs( BeforeOpenFileEventArgs args1 )
         {
            this.args = args1;
         }
      }
      //
      [System.Serializable]
      public class OpenFileException : System.Exception
      {
         public OpenFileException() : base( ) { }

         public OpenFileException( string message ) : base( message ) { }

         public OpenFileException( string format, params object[ ] args )
             : base( string.Format( format, args ) ) { }

         public OpenFileException( string message, System.Exception innerException )
             : base( message, innerException ) { }

         public OpenFileException( string format, System.Exception innerException, params object[ ] args )
             : base( string.Format( format, args ), innerException ) { }

         protected OpenFileException( System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context )
             : base( info, context ) { }
      }
      //
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
      //
      private void OpenFileEvent( BeforeOpenFileEventArgs args )
      {
         try
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
      #endregion

      #region --- Before and After SaveFile EVENTS + HANDLERS + EXCEPTIONS ---
      public delegate void BeforeSaveFileEventHandler( object sender, BeforeSaveFileEventArgs ea );
      public event BeforeSaveFileEventHandler BeforeSaveFileEvent;
      public class BeforeSaveFileEventArgs : System.EventArgs
      {
         public bool Cancel { get; set; }
         public string SavedFilename { get; set; }
         public SaveFileException Exception { get; set; }
      }
      //
      public delegate void AfterSaveFileEventHandler( object sender, AfterSaveFileEventArgs ea );
      public event AfterSaveFileEventHandler AfterSaveFileEvent;
      public class AfterSaveFileEventArgs : System.EventArgs
      {
         public BeforeSaveFileEventArgs args;
         public bool wasCanceled { get { return this.args == null ? false : this.args.Cancel; } }
         public bool hasException { get { return this.args.Exception != null; } }
         public bool isOk { get { return !this.wasCanceled && !this.hasException; } }
         public AfterSaveFileEventArgs( BeforeSaveFileEventArgs args1 )
         {
            this.args = args1;
         }
      }
      //
      [System.Serializable]
      public class SaveFileException : System.Exception
      {
         public SaveFileException() : base( ) { }

         public SaveFileException( string message ) : base( message ) { }

         public SaveFileException( string format, params object[ ] args )
             : base( string.Format( format, args ) ) { }

         public SaveFileException( string message, System.Exception innerException )
             : base( message, innerException ) { }

         public SaveFileException( string format, System.Exception innerException, params object[ ] args )
             : base( string.Format( format, args ), innerException ) { }

         protected SaveFileException( System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context )
             : base( info, context ) { }
      }
      //
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
            args1.SavedFilename = this.defaultFileName;
         }
         this.BeforeSaveFileEvent?.Invoke( this, args1 );
         if( !args1.Cancel )
         {
            this.SaveFileEvent( args1 );
         }
         this.AfterSaveFileEvent?.Invoke( this, args2 );
      }
      //
      private void SaveFileEvent( BeforeSaveFileEventArgs args )
      {
         if( this.cfg == null ) return;
         try
         {
            this.x( ).Save( args.SavedFilename, SaveOptions.None );
         }
         catch( System.Exception ex )
         {
            args.Exception = new SaveFileException( null, ex );
         }
         finally
         {

         }
      }
      #endregion

      #region --- Before and After SaveAsFile EVENTS + HANDLERS + EXCEPTIONS ---
      public delegate void BeforeSaveAsFileEventHandler( object sender, BeforeSaveAsFileEventArgs ea );

      public event BeforeSaveAsFileEventHandler BeforeSaveAsFileEvent;

      public class BeforeSaveAsFileEventArgs : System.EventArgs
      {
         public bool Cancel
         {
            get; set;
         }

         public string SuggestedFilename
         {
            get; set;
         }

         public string SavedFilename
         {
            get; set;
         }

         public SaveAsFileException Exception
         {
            get; set;
         }
      }

      //
      public delegate void AfterSaveAsFileEventHandler( object sender, AfterSaveAsFileEventArgs ea );

      public event AfterSaveAsFileEventHandler AfterSaveAsFileEvent;

      public class AfterSaveAsFileEventArgs : System.EventArgs
      {
         public BeforeSaveAsFileEventArgs args;

         public bool wasCanceled
         {
            get
            {
               return this.args == null ? false : this.args.Cancel;
            }
         }

         public bool hasException
         {
            get
            {
               return this.args.Exception != null;
            }
         }

         public bool isOk
         {
            get
            {
               return !this.wasCanceled && !this.hasException;
            }
         }

         public string SavedFilename
         {
            get
            {
               return this.args.SavedFilename;
            }
         }

         public AfterSaveAsFileEventArgs( BeforeSaveAsFileEventArgs args1 )
         {
            this.args = args1;
         }
      }

      //
      [System.Serializable]
      public class SaveAsFileException : System.Exception
      {
         public SaveAsFileException() : base( )
         {
         }

         public SaveAsFileException( string message ) : base( message )
         {
         }

         public SaveAsFileException( string format, params object[ ] args ) : base( string.Format( format, args ) )
         {
         }

         public SaveAsFileException( string message, System.Exception innerException ) : base( message, innerException )
         {
         }

         public SaveAsFileException( string format, System.Exception innerException, params object[ ] args ) : base( string.Format( format,
                                                                                                                                args ),
                                                                                                                  innerException )
         {
         }

         protected SaveAsFileException( System.Runtime.Serialization.SerializationInfo info,
                                       System.Runtime.Serialization.StreamingContext context ) : base( info, context )
         {
         }
      }

      //
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

      //
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
      public delegate void BeforeCloseFileEventHandler( object sender, BeforeCloseFileEventArgs ea );
      public event BeforeCloseFileEventHandler BeforeCloseFileEvent;
      public class BeforeCloseFileEventArgs : System.EventArgs
      {
         public bool Cancel { get; set; }
         public string Filename { get; set; }
         public CloseFileException Exception { get; set; }
      }
      //
      public delegate void AfterCloseFileEventHandler( object sender, AfterCloseFileEventArgs ea );
      public event AfterCloseFileEventHandler AfterCloseFileEvent;
      public class AfterCloseFileEventArgs : System.EventArgs
      {
         public BeforeCloseFileEventArgs args;
         public bool wasCanceled { get { return this.args == null ? false : this.args.Cancel; } }
         public bool hasException { get { return this.args.Exception != null; } }
         public bool isOk { get { return !this.wasCanceled && !this.hasException; } }
         public AfterCloseFileEventArgs( BeforeCloseFileEventArgs args1 )
         {
            this.args = args1;
         }
      }
      //
      [System.Serializable]
      public class CloseFileException : System.Exception
      {
         public CloseFileException() : base( ) { }

         public CloseFileException( string message ) : base( message ) { }

         public CloseFileException( string format, params object[ ] args )
             : base( string.Format( format, args ) ) { }

         public CloseFileException( string message, System.Exception innerException )
             : base( message, innerException ) { }

         public CloseFileException( string format, System.Exception innerException, params object[ ] args )
             : base( string.Format( format, args ), innerException ) { }

         protected CloseFileException( System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context )
             : base( info, context ) { }
      }
      //
      public void CloseFile()
      {
         if( this.cfg == null ) return;
         BeforeCloseFileEventArgs args1 = new BeforeCloseFileEventArgs( );
         AfterCloseFileEventArgs args2 = new AfterCloseFileEventArgs( args1 );
         args1.Filename = this.defaultFileName;
         this.BeforeCloseFileEvent?.Invoke( this, args1 );
         if( !args1.Cancel )
         {
            this.CloseFileEvent( args1 );
         }
         this.AfterCloseFileEvent?.Invoke( this, args2 );
      }
      //
      private void CloseFileEvent( BeforeCloseFileEventArgs args )
      {
         try
         {
            //this.SaveFile( );
            this.treeView.BeginUpdate( );
            try
            {
               this.treeView.Nodes.Clear( );
            }
            finally
            {
               this.treeView.EndUpdate( );
            }
            this.cfg = null;
         }
         catch( System.Exception ex )
         {
            args.Exception = new CloseFileException( null, ex );
         }
         finally
         {

         }
      }
      #endregion

      // SetWorkingDirectorty

      #region --- FocusedDataStoreChanged EVENT + HANDLER + EXCEPTION ---
      public delegate void FocusedDataStoreChangedEventHandler( object sender, FocusedDataStoreChangedEventArgs ea );
      public event FocusedDataStoreChangedEventHandler FocusedDataStoreChangedEvent;
      public class FocusedDataStoreChangedEventArgs : System.EventArgs
      {
         public bool Cancel { get; set; }
         public DataStore DataStore { get; set; }
         public FocusedDataStoreChangedException Exception { get; set; }
      }
      //
      [System.Serializable]
      public class FocusedDataStoreChangedException : System.Exception
      {
         public FocusedDataStoreChangedException() : base( ) { }

         public FocusedDataStoreChangedException( string message ) : base( message ) { }

         public FocusedDataStoreChangedException( string format, params object[ ] args )
             : base( string.Format( format, args ) ) { }

         public FocusedDataStoreChangedException( string message, System.Exception innerException )
             : base( message, innerException ) { }

         public FocusedDataStoreChangedException( string format, System.Exception innerException, params object[ ] args )
             : base( string.Format( format, args ), innerException ) { }

         protected FocusedDataStoreChangedException( System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context )
             : base( info, context ) { }
      }
      //
      //         FocusedDataStoreChangedEventArgs args1 = new FocusedDataStoreChangedEventArgs( );
      //         args1.Filename = filename;
      //         this.FocusedDataStoreChangedEvent?.Invoke( this, args2 );
      //
      #endregion

      #region --- FocusedConnectionStringChanged EVENT + HANDLER + EXCEPTION ---
      public delegate void FocusedConnectionStringChangedEventHandler( object sender, FocusedConnectionStringChangedEventArgs ea );
      public event FocusedConnectionStringChangedEventHandler FocusedConnectionStringChangedEvent;
      public class FocusedConnectionStringChangedEventArgs : System.EventArgs
      {
         public bool Cancel { get; set; }
         public ConnectionString ConnectionString { get; set; }
         public FocusedConnectionStringChangedException Exception { get; set; }
      }
      //
      [System.Serializable]
      public class FocusedConnectionStringChangedException : System.Exception
      {
         public FocusedConnectionStringChangedException() : base( ) { }

         public FocusedConnectionStringChangedException( string message ) : base( message ) { }

         public FocusedConnectionStringChangedException( string format, params object[ ] args )
             : base( string.Format( format, args ) ) { }

         public FocusedConnectionStringChangedException( string message, System.Exception innerException )
             : base( message, innerException ) { }

         public FocusedConnectionStringChangedException( string format, System.Exception innerException, params object[ ] args )
             : base( string.Format( format, args ), innerException ) { }

         protected FocusedConnectionStringChangedException( System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context )
             : base( info, context ) { }
      }
      //
      //         FocusedConnectionStringChangedEventArgs args1 = new FocusedConnectionStringChangedEventArgs( );
      //         args1.Filename = filename;
      //         this.FocusedConnectionStringChangedEvent?.Invoke( this, args2 );
      //
      #endregion

   }
}

/*
      private string GetDefaultFilePath()
      {
         string x = "Data\\" + this.defaultFileName;
         return Path.GetDirectoryName( FilesHelper.FindingFileName( Application.StartupPath, x ) );
      }

      private void OpenItemClick()
      {
         using( XtraOpenFileDialog dialog = new XtraOpenFileDialog( ) )
         {
            dialog.InitialDirectory = this.initialPath;
            dialog.ShowDragDropConfirmation = true;
            dialog.AutoUpdateFilterDescription = false;
            dialog.Filter = "Text files (*.txt)|*.txt";
            DialogResult dialogResult = dialog.ShowDialog( );
            if( dialogResult == DialogResult.OK )
            {
               //this.SetMemoEditText( dialog.FileName );
            }
         }
      }

      private void SaveItemClick()
      {
         using( XtraSaveFileDialog dialog = new XtraSaveFileDialog( ) )
         {
            dialog.InitialDirectory = this.initialPath;
            dialog.ShowDragDropConfirmation = true;
            dialog.Filter = "Text files|*.txt";
            dialog.CreatePrompt = true;
            dialog.OverwritePrompt = true;
            DialogResult dialogResult = dialog.ShowDialog( );
            if( dialogResult == DialogResult.OK )
            {
               //System.IO.File.WriteAllText( dialog.FileName, this.mainModule.Text );
            }
         }
      }

      private void SetWorkingFolderItemClick()
      {
         using( XtraFolderBrowserDialog dialog = new XtraFolderBrowserDialog( ) )
         {
            dialog.SelectedPath = this.initialPath;
            if( dialog.ShowDialog( ) == DialogResult.OK )
            {
               this.initialPath = dialog.SelectedPath;
            }
         }
      }
*/
