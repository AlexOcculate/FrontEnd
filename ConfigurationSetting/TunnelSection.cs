namespace FrontEnd.ConfigurationSetting
{
   public class TunnelSection : System.Configuration.ConfigurationSection
   {
      [System.Configuration.ConfigurationProperty( "", IsDefaultCollection = true )]
      public HostCollection Tunnels
      {
         get
         {
            HostCollection hostCollection = (HostCollection) base[ string.Empty ];
            return hostCollection;
         }
      }
   }

   public class HostCollection : System.Configuration.ConfigurationElementCollection
   {
      public HostCollection()
      {
         HostConfigElement details = (HostConfigElement) this.CreateNewElement( );
         if( details.SSHServerHostname != string.Empty )
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
         return new HostConfigElement( );
      }

      protected override object GetElementKey( System.Configuration.ConfigurationElement element )
      {
         return ((HostConfigElement) element).SSHServerHostname;
      }

      public HostConfigElement this[ int index ]
      {
         get
         {
            return (HostConfigElement) BaseGet( index );
         }
         set
         {
            if( BaseGet( index ) != null )
            {
               BaseRemoveAt( index );
            }
            this.BaseAdd( index, value );
         }
      }

      public new HostConfigElement this[ string name ]
      {
         get
         {
            return (HostConfigElement) BaseGet( name );
         }
      }

      public int IndexOf( HostConfigElement details )
      {
         return BaseIndexOf( details );
      }

      public void Add( HostConfigElement details )
      {
         this.BaseAdd( details );
      }
      protected override void BaseAdd( System.Configuration.ConfigurationElement element )
      {
         this.BaseAdd( element, false );
      }

      public void Remove( HostConfigElement details )
      {
         if( BaseIndexOf( details ) >= 0 )
         {
            BaseRemove( details.SSHServerHostname );
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
         get { return "host"; }
      }
   }

   public class HostConfigElement : System.Configuration.ConfigurationElement
   {
      [System.Configuration.ConfigurationProperty( nameof( SSHServerHostname ), IsRequired = true, IsKey = true )]
      [System.Configuration.StringValidator( InvalidCharacters = "  ~!@#$%^&*()[]{}/;’\"|\\" )]
      public string SSHServerHostname
      {
         get { return (string) this[ nameof( this.SSHServerHostname ) ]; }
         set { this[ nameof( this.SSHServerHostname ) ] = value; }
      }

      [System.Configuration.ConfigurationProperty( "username", IsRequired = true )]
      [System.Configuration.StringValidator( InvalidCharacters = "  ~!@#$%^&*()[]{}/;’\"|\\" )]
      public string Username
      {
         get { return (string) this[ "username" ]; }
         set { this[ "username" ] = value; }
      }
      [System.Configuration.ConfigurationProperty( "SSHport", IsRequired = true, DefaultValue = 22 )]
      [System.Configuration.IntegerValidator( MinValue = 1, MaxValue = 65536 )]
      public int SSHPort
      {
         get { return (int) this[ "SSHport" ]; }
         set { this[ "SSHport" ] = value; }
      }

      [System.Configuration.ConfigurationProperty( "password", IsRequired = false )]
      public string Password
      {
         get { return (string) this[ "password" ]; }
         set { this[ "password" ] = value; }
      }

      [System.Configuration.ConfigurationProperty( "privatekey", IsRequired = false )]
      public string Privatekey
      {
         get { return (string) this[ "privatekey" ]; }
         set { this[ "privatekey" ] = value; }
      }

      [System.Configuration.ConfigurationProperty( "privatekeypassphrase", IsRequired = false )]
      public string Privatekeypassphrase
      {
         get { return (string) this[ "privatekeypassphrase" ]; }
         set { this[ "privatekeypassphrase" ] = value; }
      }

      [System.Configuration.ConfigurationProperty( "tunnels", IsDefaultCollection = false )]
      public TunnelCollection Tunnels
      {
         get { return (TunnelCollection) base[ "tunnels" ]; }

      }
   }

   public class TunnelCollection : System.Configuration.ConfigurationElementCollection
   {
      public new TunnelConfigElement this[ string name ]
      {
         get
         {
            if( this.IndexOf( name ) < 0 )
            {
               return null;
            }

            return (TunnelConfigElement) BaseGet( name );
         }
      }

      public TunnelConfigElement this[ int index ]
      {
         get { return (TunnelConfigElement) BaseGet( index ); }
      }

      public int IndexOf( string name )
      {
         name = name.ToLower( );

         for( int idx = 0; idx < base.Count; idx++ )
         {
            if( this[ idx ].Name.ToLower( ) == name )
            {
               return idx;
            }
         }
         return -1;
      }

      public override System.Configuration.ConfigurationElementCollectionType CollectionType
      {
         get { return System.Configuration.ConfigurationElementCollectionType.BasicMap; }
      }

      protected override System.Configuration.ConfigurationElement CreateNewElement()
      {
         return new TunnelConfigElement( );
      }

      protected override object GetElementKey( System.Configuration.ConfigurationElement element )
      {
         return ((TunnelConfigElement) element).Name;
      }

      protected override string ElementName
      {
         get { return "tunnel"; }
      }
   }

   public class TunnelConfigElement : System.Configuration.ConfigurationElement
   {
      public TunnelConfigElement()
      {
      }

      public TunnelConfigElement( string name, int localport, int remoteport, string destinationserver )
      {

         this.DestinationServer = destinationserver;
         this.RemotePort = remoteport;
         this.LocalPort = localport;
         this.Name = name;
      }

      [System.Configuration.ConfigurationProperty( "name", IsRequired = true, IsKey = true, DefaultValue = "" )]
      public string Name
      {
         get { return (string) this[ "name" ]; }
         set { this[ "name" ] = value; }
      }

      [System.Configuration.ConfigurationProperty( "localport", IsRequired = true, DefaultValue = 1 )]
      [System.Configuration.IntegerValidator( MinValue = 1, MaxValue = 65536 )]
      public int LocalPort
      {
         get { return (int) this[ "localport" ]; }
         set { this[ "localport" ] = value; }
      }

      [System.Configuration.ConfigurationProperty( "remoteport", IsRequired = true, DefaultValue = 1 )]
      [System.Configuration.IntegerValidator( MinValue = 1, MaxValue = 65536 )]
      public int RemotePort
      {
         get { return (int) this[ "remoteport" ]; }
         set { this[ "remoteport" ] = value; }
      }

      [System.Configuration.ConfigurationProperty( "destinationserver", IsRequired = true )]
      [System.Configuration.StringValidator( InvalidCharacters = "  ~!@#$%^&*()[]{}/;’\"|\\" )]
      public string DestinationServer
      {
         get { return (string) this[ "destinationserver" ]; }
         set { this[ "destinationserver" ] = value; }
      }
   }

}