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
   }
}
