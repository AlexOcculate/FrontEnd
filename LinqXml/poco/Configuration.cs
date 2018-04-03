using LinqXml.Control.Configuration.AddAppCS;
using LinqXml.Control.Configuration.AddDataStore;
using LinqXml.Control.Configuration.DelAppCS;
using LinqXml.Control.Configuration.DelDataStore;
using LinqXml.Events.CloneAppCS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Linq;

namespace LinqXml
{
   public class Configuration
   {
      #region --- OnPropertyChanged EVENTS + HANDLERS + EXCEPTIONS --- 
      public event PropertyChangedEventHandler PropertyChanged;

      protected void OnPropertyChanged( PropertyChangedEventArgs e )
      {
         this.PropertyChanged?.Invoke( this, e );
      }

      protected void OnPropertyChanged( string propertyName )
      {
         this.IsDirty = true;
         this.OnPropertyChanged( new PropertyChangedEventArgs( propertyName ) );
      }
      #endregion

      #region --- PROPERTIES + BACKFIELDS ---
      public bool IsDirty
      {
         get; set;
      }

      private string _stgDir;

      public string StageDirPath
      {
         get
         {
            if( this._stgDir == null || string.IsNullOrWhiteSpace( this._stgDir ) )
            {
               return null;
            }
            return this._stgDir.Trim( );
         }
         set
         {
            string val = null;
            if( !(value == null || string.IsNullOrWhiteSpace( value )) )
            {
               val = value.Trim( );
            }
            if( this._stgDir != val )
            {
               this._stgDir = val;
               this.OnPropertyChanged( nameof( this.StageDirPath ) );
            }
         }
      }

      private List<DataStore> _dsList;

      public List<DataStore> DsList
      {
         get
         {
            if( this._dsList == null )
            {
               this._dsList = new List<DataStore>( );
            }
            return this._dsList;
         }
         set
         {
            if( this._dsList != value )
            {
               this._dsList = value;
               this.OnPropertyChanged( nameof( this.DsList ) );
            }
         }
      }

      private List<ConnectionString> _appCsList;

      public List<ConnectionString> AppCsList
      {
         get
         {
            if( this._appCsList == null )
            {
               this._appCsList = new List<ConnectionString>( );
            }
            return this._appCsList;
         }
         set
         {
            if( this._appCsList != value )
            {
               this._appCsList = value;
               this.OnPropertyChanged( nameof( this.AppCsList ) );
            }
         }
      }

      private List<ConnectionString> _sysCsList;

      public List<ConnectionString> SysCsList
      {
         get
         {
            if( this._sysCsList == null )
            {
               this._sysCsList = new List<ConnectionString>( );
            }
            return this._sysCsList;
         }
         set
         {
            if( this._sysCsList != value )
            {
               this._sysCsList = value;
               this.OnPropertyChanged( nameof( this.SysCsList ) );
            }
         }
      }
      #endregion

      public event AllowedAddAppCSEventHandler AllowedAddAppCSEvent;

      public event NotAllowedAddAppCSEventHandler NotAllowedAddAppCSEvent;
      //
      public event AllowedToCloneAppCSEventHandler AllowedToCloneAppCSEvent;

      public event NotAllowedToCloneAppCSEventHandler NotAllowedToCloneAppCSEvent;
      //
      public event AllowedDelAppCSEventHandler AllowedDelAppCSEvent;

      public event NotAllowedDelAppCSEventHandler NotAllowedDelAppCSEvent;
      //
      public event AllowedAddDataStoreEventHandler AllowedAddDataStoreEvent;

      public event NotAllowedAddDataStoreEventHandler NotAllowedAddDataStoreEvent;
      //
      public event AllowedDelDataStoreEventHandler AllowedDelDataStoreEvent;

      public event NotAllowedDelDataStoreEventHandler NotAllowedDelDataStoreEvent;

      public System.Xml.Linq.XElement GetXElement()
      {
         //new XElement( "cfg",
         //   new XElement( "dsCfg",
         //      new XElement( "stgDir", "./../.." ), // StagePathDir
         //      new XElement( "dsColl",
         //         new XElement( "ds",
         //            new XAttribute( "nm", "Patrick Hines" ),
         //            new XAttribute( "csNm", "144" ),
         //            new XAttribute( "lddo", true ), // LoadDefaultDatabaseOnly
         //            new XAttribute( "lso", true ), // LoadSystemObjects
         //            new XAttribute( "wf", true ), // WithFields
         //            new XElement( "stgDir", "./../.." ) // stage path dir
         //         ),
         //      )
         //   ),
         //   new XElement( "csColl",
         //      new XElement( "cs",
         //         new XAttribute( "pvt", true ), // isPrivate
         //         new XAttribute( "nm", "x144" ),
         //         new XAttribute( "pn", "System.Data.SqlClient" ), // ProviderName
         //         new XElement( "str", "sql:url.qwerty" ) // ConnectionString
         //      )
         //   )
         //)
         XElement dsCfg = new XElement( "dsCfg" );
         if( this.StageDirPath != null )
         {
            dsCfg.Add( new XElement( "stgDir", this.StageDirPath ) );
         }
         //
         XElement dsColl = new XElement( "dsCol" );
         for( int i = 0; i < this.DsList.Count; i++ )
         {
            DataStore dataStore = this.DsList[ i ];
            XElement ds = dataStore.GetXElement( );
            dsColl.Add( ds );
         }
         dsCfg.Add( dsColl );
         //
         XElement csColl = new XElement( "csCol" );
         for( int i = 0; i < this.AppCsList.Count; i++ )
         {
            ConnectionString connectionString = this.AppCsList[ i ];
            XElement cs = connectionString.GetXElement( );
            csColl.Add( cs );
         }
         dsCfg.Add( csColl );
         //
         XElement cfg = new XElement( "cfg", dsCfg );
         return cfg;
      }

      public static Configuration GetPoco()
      {
         List<ConnectionString> syscsList = ConnectionString.GetPocoList( );

         Configuration configuration = new Configuration( )
         {
            SysCsList = syscsList,
            IsDirty = true
         };

         return configuration;
      }

      public static Configuration GetPoco( XElement e )
      {
         XElement dsCfgElement = e.Element( "dsCfg" );
         if( dsCfgElement == null )
         {
            throw new InvalidDataStoreConfigurationException( "ERROR: Invalid file!" );
         }
         //
         XElement stgDirElement = dsCfgElement.Element( "stgDir" );
         string stgDir = stgDirElement?.Value;
         //
         List<DataStore> dsList = DataStore.GetPocoList( dsCfgElement );
         //
         XElement csCollElement = dsCfgElement.Element( "csCol" );
         List<ConnectionString> csList = ConnectionString.GetPocoList( csCollElement );
         //
         //List<ConnectionString> syscsList = ConnectionString.GetPocoList( );

         Configuration o = GetPoco( );
         {
            o.StageDirPath = normalizestring( stgDir );
            o.DsList = dsList;
            o.AppCsList = csList;
            o.IsDirty = false;
         }

         return o;
      }

      private static string normalizestring( string str )
      {
         if( str == null || string.IsNullOrWhiteSpace( str ) )
         {
            return null;
         }
         string str2 = str.Trim( );
         return str2;
      }

      public void AddAppCS( ConnectionString cs )
      {
         if( cs == null )
         {
            return;
         }
         if( this.AppCsList.Contains( cs ) )
         {
            return;
         }
         this.AppCsList.Add( cs );
         this.OnPropertyChanged( nameof( this.AppCsList ) );
      }

      public void AddDataStore( DataStore ds )
      {
         if( ds == null )
         {
            return;
         }
         if( this.DsList.Contains( ds ) )
         {
            return;
         }
         this.DsList.Add( ds );
         this.OnPropertyChanged( nameof( this.DsList ) );
         this.IsDirty = true;
      }

      public bool ContainsAppCS( string name )
      {
         string nm = normalizestring( name );
         if( nm == null )
         {
            return false;
         }

         foreach( ConnectionString item in this.AppCsList )
         {
            if( string.Compare( item.Name, nm, StringComparison.Ordinal ) == 0 )
            {
               return true;
            }
         }
         return false;
      }

      public bool ContainsSysCS( string name )
      {
         string nm = normalizestring( name );
         if( nm == null )
         {
            return false;
         }

         foreach( ConnectionString item in this.SysCsList )
         {
            if( string.Compare( item.Name, nm, StringComparison.Ordinal ) == 0 )
            {
               return true;
            }
         }
         return false;
      }

      public bool IsBeingReferenced( ConnectionString appCS )
      {
         foreach( DataStore ds in this.DsList )
         {
            if( string.Compare( ds.ConnectionStringName, appCS.Name, StringComparison.Ordinal ) == 0 )
            {
               return true;
            }
         }
         return false;
      }

      public bool ContainsDataStore( string name )
      {
         string nm = normalizestring( name );
         if( nm == null )
         {
            return false;
         }

         foreach( DataStore item in this.DsList )
         {
            if( string.Compare( item.Name, nm, StringComparison.Ordinal ) == 0 )
            {
               return true;
            }
         }
         return false;
      }

      public ConnectionString DelAppCS( string cs )
      {
         string name = normalizestring( cs );
         if( name != null )
         {
            if( this.ContainsAppCS( name ) )
            {
               foreach( ConnectionString item in this.AppCsList )
               {
                  if( string.Compare( item.Name, cs, StringComparison.Ordinal ) == 0 )
                  {
                     bool removed = this.AppCsList.Remove( item );
                     this.OnPropertyChanged( nameof( this.AppCsList ) );
                     return item;
                  }
               }
            }
         }
         return null;
      }

      public DataStore DelDataStore( string ds )
      {
         string nm = normalizestring( ds );
         if( nm != null )
         {
            if( this.ContainsDataStore( nm ) )
            {
               foreach( DataStore item in this.DsList )
               {
                  if( string.Compare( item.Name, nm, StringComparison.Ordinal ) == 0 )
                  {
                     bool removed = this.DsList.Remove( item );
                     this.OnPropertyChanged( nameof( this.DsList ) );
                     return item;
                  }
               }
            }
         }
         return null;
      }

      public void VerifyWhatIsAllowed()
      {
         if( this.DsList.Count <= 0 )
         {
            this.NotAllowedDelDataStoreEvent?.Invoke( this );
         }
         else
         {
            this.AllowedDelDataStoreEvent?.Invoke( this );
         }
         this.AllowedAddDataStoreEvent?.Invoke( this );
         //
         if( this.AppCsList.Count <= 0 )
         {
            this.NotAllowedDelAppCSEvent?.Invoke( this );
         }
         else
         {
            this.AllowedDelAppCSEvent?.Invoke( this );
         }
         this.AllowedAddAppCSEvent?.Invoke( this );
      }
   }
}
