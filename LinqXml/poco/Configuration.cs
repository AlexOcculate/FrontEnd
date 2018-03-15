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

      private List<ConnectionString> _csList;

      public List<ConnectionString> CsList
      {
         get
         {
            if( this._csList == null )
            {
               this._csList = new List<ConnectionString>( );
            }
            return this._csList;
         }
         set
         {
            if( this._csList != value )
            {
               this._csList = value;
               this.OnPropertyChanged( nameof( this.CsList ) );
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
         for( int i = 0; i < this.CsList.Count; i++ )
         {
            ConnectionString connectionString = this.CsList[ i ];
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
            CsList = csList,
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
         if( this.CsList.Contains( cs ) )
         {
            return;
         }
         this.CsList.Add( cs );
         this.OnPropertyChanged( nameof( this.CsList ) );
      }
   }
}
