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
         this.OnPropertyChanged( new PropertyChangedEventArgs( propertyName ) );
      }
      #endregion

      #region --- PROPERTIES + BACKFIELDS ---
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
         List<ConnectionString> syscsList = ConnectionString.GetPocoList( );

         Configuration configuration = new Configuration( )
         {
            StageDirPath = stgDir,
            DsList = dsList,
            AppCsList = csList,
            SysCsList = syscsList
         };

         return configuration;
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
      }
      public void AddConnectionString( ConnectionString cs )
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
      public bool ContainsAppCS( string name )
      {
         foreach( ConnectionString item in this.AppCsList )
         {
            if( string.Compare( item.Name, name, StringComparison.Ordinal ) == 0 )
            {
               return true;
            }
         }
         return false;
      }
      public bool ContainsSysCS( string name )
      {
         foreach( ConnectionString item in this.SysCsList )
         {
            if( string.Compare( item.Name, name, StringComparison.Ordinal ) == 0 )
            {
               return true;
            }
         }
         return false;
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
      //
      #region --- AllowedAddAppCS EVENT + HANDLER + EXCEPTION ---
      public delegate void AllowedAddAppCSEventHandler( object sender );
      public event AllowedAddAppCSEventHandler AllowedAddAppCSEvent;
      #endregion
      //
      #region --- NotAllowedAddAppCS EVENT + HANDLER + EXCEPTION ---
      public delegate void NotAllowedAddAppCSEventHandler( object sender );
      public event NotAllowedAddAppCSEventHandler NotAllowedAddAppCSEvent;
      #endregion
      //
      #region --- AllowedDelAppCS EVENT + HANDLER + EXCEPTION ---
      public delegate void AllowedDelAppCSEventHandler( object sender );
      public event AllowedDelAppCSEventHandler AllowedDelAppCSEvent;
      #endregion
      //
      #region --- NotAllowedDelAppCS EVENT + HANDLER + EXCEPTION ---
      public delegate void NotAllowedDelAppCSEventHandler( object sender );
      public event NotAllowedDelAppCSEventHandler NotAllowedDelAppCSEvent;
      #endregion
      //
      #region --- AllowedAddDataStore EVENT + HANDLER + EXCEPTION ---
      public delegate void AllowedAddDataStoreEventHandler( object sender );
      public event AllowedAddDataStoreEventHandler AllowedAddDataStoreEvent;
      #endregion
      //
      #region --- NotAllowedAddDataStore EVENT + HANDLER + EXCEPTION ---
      public delegate void NotAllowedAddDataStoreEventHandler( object sender );
      public event NotAllowedAddDataStoreEventHandler NotAllowedAddDataStoreEvent;
      #endregion
      //
      #region --- AllowedDelDataStore EVENT + HANDLER + EXCEPTION ---
      public delegate void AllowedDelDataStoreEventHandler( object sender );
      public event AllowedDelDataStoreEventHandler AllowedDelDataStoreEvent;
      #endregion
      //
      #region --- NotAllowedDelDataStore EVENT + HANDLER + EXCEPTION ---
      public delegate void NotAllowedDelDataStoreEventHandler( object sender );
      public event NotAllowedDelDataStoreEventHandler NotAllowedDelDataStoreEvent;
      #endregion
   }
   //
   #region --- InvalidDataStoreConfiguration EVENT + HANDLER + EXCEPTION ---
   [System.Serializable]
   public class InvalidDataStoreConfigurationException : System.Exception
   {
      public InvalidDataStoreConfigurationException() : base( ) { }

      public InvalidDataStoreConfigurationException( string message ) : base( message ) { }

      public InvalidDataStoreConfigurationException( string format, params object[ ] args )
          : base( string.Format( format, args ) ) { }

      public InvalidDataStoreConfigurationException( string message, System.Exception innerException )
          : base( message, innerException ) { }

      public InvalidDataStoreConfigurationException( string format, System.Exception innerException, params object[ ] args )
          : base( string.Format( format, args ), innerException ) { }

      protected InvalidDataStoreConfigurationException( System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context )
          : base( info, context ) { }
   }
   //
   //         InvalidDataStoreConfigurationEventArgs args1 = new InvalidDataStoreConfigurationEventArgs( );
   //         args1.Filename = filename;
   //         this.InvalidDataStoreConfigurationEvent?.Invoke( this, args2 );
   //
   #endregion

}
