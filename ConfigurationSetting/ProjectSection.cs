using FrontEnd.ConfigurationSetting;
using System;

namespace FrontEnd.ProjectSetting
{
   public partial class ProjectSection : System.Configuration.ConfigurationSection
   {
      [System.Configuration.ConfigurationProperty( nameof( Name ), IsRequired = true )]
      [System.Configuration.StringValidator( InvalidCharacters = "*?\"<>|" )]
      public string Name
      {
         get { return (string) this[ nameof( this.Name ) ]; }
         set { this[ nameof( this.Name ) ] = value; }
      }

      [System.Configuration.ConfigurationProperty( nameof( Stage ), IsRequired = true )]
      public DataStage Stage
      {
         get { return (DataStage) this[ nameof( this.Stage ) ]; }
         set { this[ nameof( this.Stage ) ] = value; }
      }

      [System.Configuration.ConfigurationProperty( "", IsDefaultCollection = true )]
      public DataStoreCollection DataStores
      {
         get
         {
            DataStoreCollection dsCollection = (DataStoreCollection) base[ string.Empty ];
            return dsCollection;
         }
      }

      // -------------------------------------------------------------------------

      public static ProjectSection GetSection( string filename )
      {
         if( string.IsNullOrWhiteSpace( filename ) )
         {
            return null;
         }
         System.Configuration.ExeConfigurationFileMap configMap = new System.Configuration.ExeConfigurationFileMap( );
         configMap.ExeConfigFilename = filename;
         System.Configuration.Configuration config = System.Configuration.ConfigurationManager
            .OpenMappedExeConfiguration( configMap, System.Configuration.ConfigurationUserLevel.None );
         ProjectSetting.ProjectSection ps = config.GetSection( nameof( ProjectSetting.ProjectSection ) ) as ProjectSetting.ProjectSection;
         //
         System.Data.DataTable dt = ConfigurationSetting.DataStore.LoadDataStoreConfigurationSetting( );
         ps.LinkDataStores( dt );
         ps.VerifySnapshots( );
         return ps;
      }
      public void LinkDataStores( System.Data.DataTable dt )
      {
         foreach( DataStoreElement dse in this.DataStores )
         {
            dse.Found = false;
            foreach( System.Data.DataRow dr in dt.Rows )
            {
               ConfigurationSetting.DataStore ds = dr[ ConfigurationSetting.DataStore.TAG_COLNAME ] as ConfigurationSetting.DataStore;
               if( dse.Name == ds.Name )
               {
                  dse.Found = true;
                  dse.DataStore = ds;
                  break;
               }
            }
         }
      }
      public void VerifySnapshots()
      {
         foreach( DataStoreElement dse in this.DataStores )
         {
            if( dse.IS_FIXED( ) )
            {
               // PATH = PROJ_STAGE_PATH + PROJ_NAME + DS_NAME + SNAPSHOT_NAME
               string ssp = System.IO.Path.Combine( this.Stage.PathDir, this.Name, dse.Name, dse.SnapshotFile );
               bool exists = System.IO.File.Exists( ssp );
               if( exists )
               {
                  dse.Ssp = ssp;
               }
               else
               {
                  if( dse.Found )
                  {
                     // PATH = DS_STAGE_PATH + DS_NAME + SNAPSHOT_NAME
                     ssp = System.IO.Path.Combine( (string) dse.DataStore.StagePathDir, dse.Name, dse.SnapshotFile );
                     exists = System.IO.File.Exists( ssp );
                     if( exists )
                     {
                        // COPY TO ps.Stage.PathDir
                        dse.Ssp = ssp;
                     }
                     else
                     {
                        dse.Ssp = "[" + dse.SnapshotFile + "]";
                     }
                  }
                  else
                  {
                     dse.Ssp = "[" + dse.SnapshotFile + "]";
                  }
               }
            }
            else
            {
               string ssp;
               bool exists;
               // DYNAMIC SNAPSHOT (MOST UP-TO-DATE)...
               if( dse.Found )
               {
                  // PATH = DS_STAGE_PATH + DS_NAME + *.config"
                  ssp = dse.DataStore.StagePathDir;
                  exists = System.IO.Directory.Exists( ssp );
                  if( exists )
                  {
                     string[ ] filePaths = System.IO.Directory.GetFiles( ssp, "*.config", System.IO.SearchOption.AllDirectories );
                     if( filePaths.Length > 0 )
                     {
                        int ii = 0;
                        for( int i = 0; i < filePaths.Length; i++ )
                        {
                           bool x = System.IO.File.GetLastWriteTimeUtc( filePaths[ i ] ) > System.IO.File.GetLastWriteTimeUtc( filePaths[ ii ] );
                           if( x )
                           {
                              ii = i;
                           }
                        }
                        // THE MOST RECENT...
                        string filename = System.IO.Path.GetFileName( filePaths[ ii ] );
                        dse.Ssp = filePaths[ ii ];
                     }
                     else
                     {
                        dse.Ssp = "[" + "DataStore's Stage Area empty!" + "]";
                     }
                  }
                  else
                  {
                     dse.Ssp = "[" + "No DataStore's Stage Area!" + "]";
                  }
               }
               else
               {
                  dse.Ssp = "[" + "No DataStore!" + "]";
               }
            }
         }
      }

      public int GET_PS_ICON() { return 4; }

      public void GET_TREE( DevExpress.XtraTreeList.TreeList treeView )
      {
         treeView.AppendNode( new object[ ] { "Solution \'VisualStudioInspiredUIDemo\' (1 project)" }, -1, -1, -1, 3 ); //0
         object[ ] o = new object[ ] { this.Name };
         DevExpress.XtraTreeList.Nodes.TreeListNode prjNode = treeView.AppendNode( o, -1, -1, -1, 4, this.GET_PS_ICON( ) ); //0

         //int icon;
         foreach( ProjectSetting.DataStoreElement dse in this.DataStores )
         {
            #region --- REMARKS ---
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
            #endregion
            dse.ADD_TRENODE( treeView, prjNode );
         }
         prjNode.Expand( );
      }
   }

   public class DataStage : System.Configuration.ConfigurationElement
   {
      [System.Configuration.ConfigurationProperty( nameof( PathDir ), IsRequired = true )]
      [System.Configuration.StringValidator( InvalidCharacters = "*?\"<>|" )]
      public string PathDir
      {
         get { return (string) this[ nameof( this.PathDir ) ]; }
         set { this[ nameof( this.PathDir ) ] = value; }
      }
   }

   public class DataStoreCollection : System.Configuration.ConfigurationElementCollection
   {
      public DataStoreCollection()
      {
         DataStoreElement details = (DataStoreElement) this.CreateNewElement( );
         if( details.Name != string.Empty )
         {
            this.Add( details );
         }
      }

      public override System.Configuration.ConfigurationElementCollectionType CollectionType
      {
         get
         {
            return System.Configuration.ConfigurationElementCollectionType.BasicMap;
         }
      }

      protected override System.Configuration.ConfigurationElement CreateNewElement()
      {
         return new DataStoreElement( );
      }

      protected override object GetElementKey( System.Configuration.ConfigurationElement element )
      {
         return ((DataStoreElement) element).Name;
      }

      public DataStoreElement this[ int index ]
      {
         get
         {
            return (DataStoreElement) BaseGet( index );
         }
         set
         {
            if( BaseGet( index ) != null )
            {
               BaseRemoveAt( index );
            }
            BaseAdd( index, value );
         }
      }

      public new DataStoreElement this[ string name ]
      {
         get
         {
            return (DataStoreElement) BaseGet( name );
         }
      }

      public int IndexOf( DataStoreElement details )
      {
         return BaseIndexOf( details );
      }

      public void Add( DataStoreElement details )
      {
         this.BaseAdd( details );
      }
      protected override void BaseAdd( System.Configuration.ConfigurationElement element )
      {
         BaseAdd( element, false );
      }

      public void Remove( DataStoreElement details )
      {
         if( BaseIndexOf( details ) >= 0 )
         {
            BaseRemove( details.Name );
         }
      }

      public void RemoveAt( int index )
      {
         BaseRemoveAt( index );
      }

      public void Remove( string name )
      {
         BaseRemove( name );
      }

      public void Clear()
      {
         BaseClear( );
      }

      protected override string ElementName
      {
         get { return "datastore"; }
      }
   }

   public class DataStoreElement : System.Configuration.ConfigurationElement
   {
      [System.Configuration.ConfigurationProperty( nameof( Name ), IsRequired = true, IsKey = true )]
      [System.Configuration.StringValidator( InvalidCharacters = "  ~!@#$%^&*()[]{}/;’\"|\\" )]
      public string Name
      {
         get { return (string) this[ nameof( this.Name ) ]; }
         set { this[ nameof( this.Name ) ] = value; }
      }

      [System.Configuration.ConfigurationProperty( nameof( SnapshotFile ), IsRequired = false )]
      [System.Configuration.StringValidator( InvalidCharacters = "*?\"<>|" )]
      public string SnapshotFile
      {
         get { return (string) this[ nameof( this.SnapshotFile ) ]; }
         set { this[ nameof( this.SnapshotFile ) ] = value; }
      }

      // -------------------------------------------------------------------------
      public void ADD_TRENODE( DevExpress.XtraTreeList.TreeList treeView, DevExpress.XtraTreeList.Nodes.TreeListNode prjNode )
      {
         object[ ] oo = new object[ ] { this.Name };
         DevExpress.XtraTreeList.Nodes.TreeListNode dsNode = treeView.AppendNode( oo, prjNode.Id, -1, -1, this.GET_DS_ICON( ), this );
         if( this.IS_FIXED( ) )
         {
            // FIXED SNAPSHOT...
            object[ ] ooo = new object[ ] { this.SnapshotFile };
            DevExpress.XtraTreeList.Nodes.TreeListNode child = treeView.AppendNode( ooo, dsNode.Id, -1, -1, this.GET_SS_ICON( ), this );
            dsNode.Expand( );
         }
         else
         {
            // DYNAMIC SNAPSHOT...
            object[ ] ooo = new object[ ] { this.GET_SSP_FILENAME() };
            DevExpress.XtraTreeList.Nodes.TreeListNode child = treeView.AppendNode( ooo, dsNode.Id, -1, -1, this.GET_SS_ICON( ) );
            dsNode.Collapse( );
         }
      }
      internal bool Found { get; set; }
      public bool GET_FOUND() { return this.Found; }
      internal string Ssp { get; set; }
      public string GET_SSP() { return this.Ssp; }
      public string GET_SSP_FILENAME() { return System.IO.File.Exists( this.GET_SSP( ) ) ? System.IO.Path.GetFileName( this.GET_SSP( ) ) : this.GET_SSP( ); }
      public bool IS_FIXED() { return !string.IsNullOrWhiteSpace( this.SnapshotFile ); }
      internal DataStore DataStore { get; set; }

      public int GET_DS_ICON()
      {
         int icon = this.GET_FOUND( ) ? 5 : 6;
         // DATA FOUND BUT SNAPSHOT NOT FOUND!...
         if( this.GET_FOUND( ) && (!System.IO.File.Exists( this.GET_SSP( ) )) )
         {
            icon = 7;
         }
         return icon;
      }
      public int GET_SS_ICON()
      {
         if( this.IS_FIXED( ) )
         {
            if( System.IO.File.Exists( this.GET_SSP( ) ) )
            {
               return 8;
            }
            return 9;
         }
         else
         {
            if( System.IO.File.Exists( this.GET_SSP( ) ) )
            {
               return 10;
            }
            return 11;
         }
      }

      // -------------------------------------------------------------------------
   }
}
