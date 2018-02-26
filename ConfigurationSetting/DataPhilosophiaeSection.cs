namespace FrontEnd.ConfigurationSetting
{
   public class DataPhilosophiaeSection : System.Configuration.ConfigurationSection
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
   public class DataStore
   {
      private DataStoreElement _dse;
      public DataStore( DataStoreElement dse )
      {
         if( dse == null )
         {
            throw new System.ArgumentNullException( nameof( dse ), $"{nameof( dse )} is null." );
         }
         this._dse = dse;
      }
      [System.ComponentModel.DisplayName( "DatStore Name" )]
      [System.ComponentModel.Description( "Name identifier for this datastore." )]
      [System.ComponentModel.Category( "Identifier" )]
      [System.ComponentModel.ReadOnly( true )]
      public string Name
      {
         get { return this._dse.Name; }
      }

      [System.ComponentModel.DisplayName( "Connection Name" )]
      [System.ComponentModel.Description( "Name identifier of the connection String used by this datastore." )]
      [System.ComponentModel.Category( "Identifier" )]
      [System.ComponentModel.ReadOnly( true )]
      public string ConnectionStringName
      {
         get { return this._dse.ConnectionStringName; }
      }

      [System.ComponentModel.DisplayName( "Only Default Database" )]
      [System.ComponentModel.Description( "Load only the user's default database" )]
      [System.ComponentModel.Category( "Load" )]
      [System.ComponentModel.ReadOnly( true )]
      public bool LoadDefaultDatabaseOnly
      {
         get { return this._dse.LoadDefaultDatabaseOnly == 1 ? true : false; }
      }

      [System.ComponentModel.DisplayName( "System Objects" )]
      [System.ComponentModel.Description( "Load any database's system objects." )]
      [System.ComponentModel.Category( "Load" )]
      [System.ComponentModel.ReadOnly( true )]
      public bool LoadSystemObjects
      {
         get { return this._dse.LoadSystemObjects == 1 ? true : false; }
      }

      [System.ComponentModel.DisplayName( "Objects Fields" )]
      [System.ComponentModel.Description( "Load objects' fields. This make the load time longer!" )]
      [System.ComponentModel.Category( "Load" )]
      [System.ComponentModel.ReadOnly( true )]
      public bool WithFields
      {
         get { return this._dse.WithFields == 1 ? true : false; }
      }

      [System.ComponentModel.DisplayName( "Path Dir" )]
      [System.ComponentModel.Description( "Path directory used as stage area for this datastore." )]
      [System.ComponentModel.ReadOnly( true )]
      public string PathDir
      {
         get { return this._dse.PathDir; }
      }
   }
}
