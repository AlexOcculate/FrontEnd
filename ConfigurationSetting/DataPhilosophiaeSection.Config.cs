namespace FrontEnd.ConfigurationSetting
{
   public partial class DataPhilosophiaeSection : System.Configuration.ConfigurationSection
   {
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

      [System.Configuration.ConfigurationProperty( "csName", IsRequired = true )]
      [System.Configuration.StringValidator( InvalidCharacters = "*?\"<>|" )]
      public string ConnectionStringName
      {
         get { return (string) this[ "csName" ]; }
         set { this[ "csName" ] = value; }
      }

      [System.Configuration.ConfigurationProperty( nameof( LoadDefaultDatabaseOnly ), IsRequired = false, DefaultValue = 0 )]
      [System.Configuration.IntegerValidator( MinValue = 0, MaxValue = 1 )]
      public int LoadDefaultDatabaseOnly
      {
         get { return (int) this[ nameof( this.LoadDefaultDatabaseOnly ) ]; }
         set { this[ nameof( this.LoadDefaultDatabaseOnly ) ] = value; }
      }

      [System.Configuration.ConfigurationProperty( nameof( LoadSystemObjects ), IsRequired = false, DefaultValue = 0 )]
      [System.Configuration.IntegerValidator( MinValue = 0, MaxValue = 1 )]
      public int LoadSystemObjects
      {
         get { return (int) this[ nameof( this.LoadSystemObjects ) ]; }
         set { this[ nameof( this.LoadSystemObjects ) ] = value; }
      }

      [System.Configuration.ConfigurationProperty( nameof( WithFields ), IsRequired = false, DefaultValue = 0 )]
      [System.Configuration.IntegerValidator( MinValue = 0, MaxValue = 1 )]
      public int WithFields
      {
         get { return (int) this[ nameof( this.WithFields ) ]; }
         set { this[ nameof( this.WithFields ) ] = value; }
      }

      [System.Configuration.ConfigurationProperty( nameof( PathDir ), IsRequired = false )]
      [System.Configuration.StringValidator( InvalidCharacters = "*?\"<>|" )]
      public string PathDir
      {
         get { return (string) this[ nameof( this.PathDir ) ]; }
         set { this[ nameof( this.PathDir ) ] = value; }
      }
   }

   public partial class DataStore
   {
      public const string DATA_STORE_CONFIG_TBLNAME = "DataStoreConfig";
      //
      public static string IS_VALID_STAGE_PATHDIR_COLNAME = "IsValidStagePathDir";
      public static string IS_VALID_PROVIDER_NNAME_COLNAME = "IsValidProviderName";
      public static string CONNECTION_STRING_NAME_COLNAME = "ConnectionStringName";
      public static string CONNECTION_STRING_COLNAME = "ConnectionString";
      public static string PROVIDER_NAME_COLNAME = "ProviderName";
      public static string STAGE_PATHDIR_COLNAME = "StagePathDir";
      public static string LOAD_DEFAULT_DATABASE_ONLY_COLNAME = "LoadDefaultDatabaseOnly";
      public static string LOAD_DEFAULT_SYSTEM_OBJECTS_COLNAME = "LoadSystemObjects";
      public static string WITH_FIELDS_COLNAME = "WithFields";
      public static string NAME_COLNAME = "Name";
      public static string TAG_COLNAME = "Tag";
      //
      private DataPhilosophiaeSection _dps;
      private DataStoreElement _dse;
      private System.Configuration.ConnectionStringSettings _css;

      #region --- FIELDS... ---
      [System.ComponentModel.DisplayName( "DataStore Name" )]
      [System.ComponentModel.Category( "Identifier" )]
      [System.ComponentModel.Description( "Name identifier for this datastore." )]
      [System.ComponentModel.Browsable( true )]
      [System.ComponentModel.ReadOnly( true )]
      public string Name
      {
         get { return this._dse.Name; }
      }

      [System.ComponentModel.DisplayName( "Connection Name" )]
      [System.ComponentModel.Category( "Identifier" )]
      [System.ComponentModel.Description( "Name identifier of the connection String used by this datastore." )]
      [System.ComponentModel.Browsable( true )]
      [System.ComponentModel.ReadOnly( true )]
      public string ConnectionStringName
      {
         get { return this._dse.ConnectionStringName; }
      }

      [System.ComponentModel.DisplayName( "Only Default Database" )]
      [System.ComponentModel.Category( "Load" )]
      [System.ComponentModel.Description( "Load only the user's default database" )]
      [System.ComponentModel.Browsable( true )]
      [System.ComponentModel.ReadOnly( true )]
      public bool LoadDefaultDatabaseOnly
      {
         get { return this._dse.LoadDefaultDatabaseOnly == 1 ? true : false; }
      }

      [System.ComponentModel.DisplayName( "System Objects" )]
      [System.ComponentModel.Category( "Load" )]
      [System.ComponentModel.Description( "Load any database's system objects." )]
      [System.ComponentModel.Browsable( true )]
      [System.ComponentModel.ReadOnly( true )]
      public bool LoadSystemObjects
      {
         get { return this._dse.LoadSystemObjects == 1 ? true : false; }
      }

      [System.ComponentModel.DisplayName( "Objects Fields" )]
      [System.ComponentModel.Category( "Load" )]
      [System.ComponentModel.Description( "Load objects' fields. This make the load time longer!" )]
      [System.ComponentModel.Browsable( true )]
      [System.ComponentModel.ReadOnly( true )]
      public bool WithFields
      {
         get { return this._dse.WithFields == 1 ? true : false; }
      }

      [System.ComponentModel.DisplayName( "Stage Path Dir" )]
      [System.ComponentModel.Category( "Directory" )]
      [System.ComponentModel.Description( "Path directory used as stage area for this datastore." )]
      [System.ComponentModel.Browsable( true )]
      [System.ComponentModel.ReadOnly( true )]
      public string StagePathDir
      {
         get
         {
            return string.IsNullOrWhiteSpace( this._dse.PathDir )
               ? System.IO.Path.Combine( this._dps.Stage.PathDir, this._dse.Name )
               : this._dse.PathDir;
         }
      }

      [System.ComponentModel.DisplayName( "Connection String" )]
      [System.ComponentModel.Category( "Identifier" )]
      [System.ComponentModel.Description( "" )]
      [System.ComponentModel.Browsable( false )]
      [System.ComponentModel.ReadOnly( true )]
      [System.ComponentModel.PasswordPropertyText( true )]
      public string ConnectionString
      {
         get
         {
            return this._css != null ? this._css.ConnectionString : null;
         }
      }

      [System.ComponentModel.DisplayName( "Provider Name" )]
      [System.ComponentModel.Category( "Identifier" )]
      [System.ComponentModel.Description( "" )]
      [System.ComponentModel.Browsable( true )]
      [System.ComponentModel.ReadOnly( true )]
      public string ProviderName
      {
         get
         {
            return this._css != null ? this._css.ProviderName : null;
         }
      }

      [System.ComponentModel.DisplayName( "Valid StagePathDir" )]
      [System.ComponentModel.Category( "Directory" )]
      [System.ComponentModel.Description( "" )]
      [System.ComponentModel.Browsable( true )]
      [System.ComponentModel.ReadOnly( true )]
      public bool IsValidStagePathDir
      {
         get
         {
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo( this.StagePathDir );
            return di.Exists;
         }
      }

      [System.ComponentModel.DisplayName( "Valid Provider Name" )]
      [System.ComponentModel.Category( "Identifier" )]
      [System.ComponentModel.Description( "" )]
      [System.ComponentModel.Browsable( true )]
      [System.ComponentModel.ReadOnly( true )]
      public bool IsValidProviderName
      {
         get
         {
            return !string.IsNullOrWhiteSpace( this._css != null ? this._css.ProviderName : null );
         }
      }
      #endregion

      #region --- CTOR() ---
      public DataStore( DataPhilosophiaeSection dps, DataStoreElement dse, System.Configuration.ConnectionStringSettings css )
      {
         if( dps == null )
         {
            throw new System.ArgumentNullException( nameof( dps ), $"{nameof( dps )} is null." );
         }
         if( dse == null )
         {
            throw new System.ArgumentNullException( nameof( dse ), $"{nameof( dse )} is null." );
         }
         this._dps = dps;
         this._dse = dse;
         this._css = css;
      }
      #endregion

      private static System.Data.DataTable CreateDataStoreConfigTable( string name = DATA_STORE_CONFIG_TBLNAME )
      {
         System.Data.DataTable t = new System.Data.DataTable( name );
         {
            //System.Data.DataColumn c = new System.Data.DataColumn( );
            //c.DataType = typeof( System.Int32 );
            //c.ColumnName = "ID";
            //c.Caption = "Id";
            //c.ReadOnly = true;
            //c.Unique = false;
            //t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.String );
            c.ColumnName = NAME_COLNAME;
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.Boolean );
            c.ColumnName = "IsActive";
            c.ReadOnly = false;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.String );
            c.ColumnName = CONNECTION_STRING_NAME_COLNAME;
            c.ReadOnly = false;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.Boolean );
            c.ColumnName = LOAD_DEFAULT_DATABASE_ONLY_COLNAME;
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.Boolean );
            c.ColumnName = LOAD_DEFAULT_SYSTEM_OBJECTS_COLNAME;
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.Boolean );
            c.ColumnName = WITH_FIELDS_COLNAME;
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.String );
            c.ColumnName = STAGE_PATHDIR_COLNAME;
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.String );
            c.ColumnName = CONNECTION_STRING_COLNAME;
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.String );
            c.ColumnName = PROVIDER_NAME_COLNAME;
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.Boolean );
            c.ColumnName = IS_VALID_STAGE_PATHDIR_COLNAME;
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.Boolean );
            c.ColumnName = IS_VALID_PROVIDER_NNAME_COLNAME;
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.Object );
            c.ColumnName = TAG_COLNAME;
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         return t;
      }

      public System.Data.DataRow GetAsDataRow( System.Data.DataRow r )
      {
         {
            //r[ "ID" ] = i++;
            r[ TAG_COLNAME ] = this;
            r[ NAME_COLNAME ] = this.Name;
            r[ CONNECTION_STRING_NAME_COLNAME ] = this.ConnectionStringName;
            r[ LOAD_DEFAULT_DATABASE_ONLY_COLNAME ] = this.LoadDefaultDatabaseOnly;
            r[ LOAD_DEFAULT_SYSTEM_OBJECTS_COLNAME ] = this.LoadSystemObjects;
            r[ WITH_FIELDS_COLNAME ] = this.WithFields;
            r[ STAGE_PATHDIR_COLNAME ] = this.StagePathDir;
            r[ CONNECTION_STRING_COLNAME ] = this.ConnectionString;
            r[ PROVIDER_NAME_COLNAME ] = this.ProviderName;
            //
            r[ IS_VALID_STAGE_PATHDIR_COLNAME ] = this.IsValidStagePathDir;
            r[ IS_VALID_PROVIDER_NNAME_COLNAME ] = this.IsValidProviderName;
         }
         return r;
      }

   }
}
