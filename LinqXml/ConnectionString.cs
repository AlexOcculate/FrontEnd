using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Linq;

namespace LinqXml
{

   public partial class ConnectionString : System.ComponentModel.INotifyPropertyChanged
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
      private string _nm;
      public string Name
      {
         get
         {
            if( this._nm == null || string.IsNullOrWhiteSpace( this._nm ) )
            {
               return null;
            }
            return this._nm.Trim( );
         }
         set
         {
            string val = null;
            if( !(value == null || string.IsNullOrWhiteSpace( value )) )
            {
               val = value.Trim( );
            }
            if( this._nm != val )
            {
               this._nm = val;
               this.OnPropertyChanged( nameof( this.Name ) );
            }
         }
      }
      private string _pn;
      public string ProviderName
      {
         get
         {
            if( this._pn == null || string.IsNullOrWhiteSpace( this._pn ) )
            {
               return null;
            }
            return this._pn.Trim( );
         }
         set
         {
            string val = null;
            if( !(value == null || string.IsNullOrWhiteSpace( value )) )
            {
               val = value.Trim( );
            }
            if( this._pn != val )
            {
               this._pn = val;
               this.OnPropertyChanged( nameof( this.ProviderName ) );
            }
         }
      }
      private string _str;
      public string String
      {
         get
         {
            if( this._str == null || string.IsNullOrWhiteSpace( this._str ) )
            {
               return null;
            }
            return this._str.Trim( );
         }
         set
         {
            string val = null;
            if( !(value == null || string.IsNullOrWhiteSpace( value )) )
            {
               val = value.Trim( );
            }
            if( this._str != val )
            {
               this._str = val;
               this.OnPropertyChanged( nameof( this.String ) );
            }
         }
      }
      #endregion
      //
      public System.Xml.Linq.XElement GetXElement()
      {
         if( this.Name == null )
         {
            return null;
         }
         System.Xml.Linq.XElement e =
            new System.Xml.Linq.XElement( "cs",
                new System.Xml.Linq.XAttribute( "nm", this.Name )
            );
         if( this.ProviderName != null )
         {
            e.Add( new System.Xml.Linq.XAttribute( "pn", this.ProviderName ) );
         }
         if( this.String != null )
         {
            e.Add( new System.Xml.Linq.XElement( "str",
                       new System.Xml.Linq.XCData( this.String ) )
            );
         }
         return e;
      }
      //
      public static ConnectionString GetPoco( System.Xml.Linq.XElement e )
      {
         if( e == null || e.Attribute( "nm" ) == null )
         {
            return null;
         }
         string nm = (string) e.Attribute( "nm" );
         string pn = (string) e.Attribute( "pn" ) ?? null;
         string str = e.Element( "str" ) != null ? e.Element( "str" ).Value : null;
         //
         ConnectionString cs = new ConnectionString( )
         {
            Name = nm,
            ProviderName = pn,
            String = str
         };
         return cs;
      }
      //
      public static List<ConnectionString> GetPocoList( XElement e )
      {
         List<ConnectionString> list =
            (
               from cs in e.Descendants( "cs" )
               select new ConnectionString
               {
                  Name = (string) cs.Attribute( "nm" ),
                  ProviderName = (string) cs.Attribute( "pn" ),
                  String = (string) cs.Element( "str" )
               }
            ).ToList( );
         return list;
      }

      //
      public static System.Collections.Generic.List<ConnectionString> LoadConnectionStringCollection()
      {
         System.Collections.Generic.List<ConnectionString> list = new System.Collections.Generic.List<ConnectionString>( );
         System.Configuration.ConnectionStringSettingsCollection css = System.Configuration.ConfigurationManager.ConnectionStrings;
         if( css == null )
         {
            return list;
         }
         foreach( System.Configuration.ConnectionStringSettings cs in css )
         {
            ConnectionString o = new ConnectionString( )
            {
               //isPrivate = false,
               Name = cs.Name,
               ProviderName = cs.ProviderName,
               String = cs.ConnectionString
            };
            list.Add( o );
         }
         return list;
      }
      public static System.Collections.Generic.List<ConnectionString> LoadConnectionStringCollection( System.Xml.Linq.XDocument doc )
      {
         System.Collections.Generic.List<ConnectionString> list =
            (
               from e in doc.Root.Element( "csColl" ).Descendants( "cs" )
               select new ConnectionString
               {
                  //isPrivate = true,
                  Name = (string) e.Attribute( "nm" ),
                  ProviderName = (string) e.Attribute( "pn" ),
                  String = (string) e.Element( "str" )
               }
            ).ToList( );
         return list;
      }
   }
}
