using System.Data;

namespace FrontEnd.ConfigurationSetting
{
   public static class Bootstrap
   {
      private static string filepath = @"D:\TEMP\SQLite\DSCOLL_PATHDIR\blade04\20180125-144413-7068846+1100.ChiNook.AqbQb.xml";
      private static string filepath2 = @"D:\TEMP\SQLite\DSCOLL_PATHDIR\blade04\20180125-144413-7068846+1100.ChiNook.DataSet.xml";
      private static string filepath3 = @"D:\TEMP\SQLite\DSCOLL_PATHDIR\blade04\20180125-144413-7068846+1100.ChiNook.DataSet.bin";
      private static System.Data.DataSet _ds;
      private static DataSet MyDataSet
      {
         get
         {
            if( _ds == null )
            {
               _ds = new System.Data.DataSet( "DataSet" );
            }
            return _ds;
         }
      }

      //public static void Init()
      //{
      //   Ds = new System.Data.DataSet( "X" );
      //   {
      //      DataSet.Tables.Add( CreateDataStoreConfigTable( ) );
      //      DataSet.Tables.Add( CreateDataStoreSnapshotFileTable( ) );
      //      DataSet.Tables.Add( CreateMetadataItemTable( ) );
      //   }
      //}

      public static System.Data.DataTable GetDataStoreConfigurationSetting( string name = DataStoreConfig_TblName )
      {
         if( string.IsNullOrWhiteSpace( name ) )
         {
            throw new System.ArgumentException( $"{nameof( name )} is null, empty or whitespaces only.", nameof( name ) );
         }
         if( MyDataSet.Tables.Contains( name ) )
         {
            return MyDataSet.Tables[ name ];
         }
         return null;
      }
      public static void LoadDataStoreConfigurationSetting( string name = DataStoreConfig_TblName )
      {
         if( string.IsNullOrWhiteSpace( name ) )
         {
            throw new System.ArgumentException( $"{nameof( name )} is null, empty or whitespaces only.", nameof( name ) );
         }
         if( MyDataSet.Tables.Contains( name ) )
         {
            MyDataSet.Tables.Remove( name );
         }
         MyDataSet.Tables.Add( CreateDataStoreConfigTable( name ) );
         LoadDataStoreTable( name );
      }

      private static void LoadDataStoreTable( string name )
      {
         if( string.IsNullOrWhiteSpace( name ) )
         {
            throw new System.ArgumentException( $"{nameof( name )} is null, empty or whitespaces only.", nameof( name ) );
         }

         DataPhilosophiaeSection dps = System.Configuration.ConfigurationManager.GetSection( nameof( DataPhilosophiaeSection ) ) as DataPhilosophiaeSection;
         System.Configuration.ConnectionStringSettingsCollection css = System.Configuration.ConfigurationManager.ConnectionStrings;
         if( dps == null )
         {
            throw new System.Exception( "[DataPhilosophiaeSection] section missing in app.config!!!" );
         }
         if( css == null )
         {
            throw new System.Exception( "[connectionStrings] section missing in app.config!!!" );
         }
         int iii = 0;
         System.Data.DataTable dscTbl = MyDataSet.Tables[ name ];
         //System.Data.DataTable dsssfTbl = ds.Tables[ DataStoreSnapshotFile_TblName ];
         foreach( DataStoreElement dse in dps.DataStores )
         {
            System.Configuration.ConnectionStringSettings cs = css[ dse.ConnectionStringName ];
            {
               System.Data.DataRow r = dscTbl.NewRow( );
               //r[ "ID" ] = i++;
               r[ "Tag" ] = dse;
               r[ "Name" ] = dse.Name;
               r[ "ConnectionStringName" ] = dse.ConnectionStringName;
               r[ "LoadDefaultDatabaseOnly" ] = dse.LoadDefaultDatabaseOnly == 1 ? true : false;
               r[ "LoadSystemObjects" ] = dse.LoadSystemObjects == 1 ? true : false;
               r[ "WithFields" ] = dse.WithFields == 1 ? true : false;
               r[ "StagePathDir" ] = string.IsNullOrWhiteSpace( dse.PathDir )
               ? System.IO.Path.Combine( dps.Stage.PathDir, dse.Name )
               : dse.PathDir;
               r[ "ConnectionString" ] = cs != null ? cs.ConnectionString : null;
               r[ "ProviderName" ] = cs != null ? cs.ProviderName : null;
               //
               System.IO.DirectoryInfo di = new System.IO.DirectoryInfo( (string) r[ "StagePathDir" ] );
               r[ IsValidStagePathDir_ColName ] = di.Exists;
               r[ "IsValidProviderName" ] = !string.IsNullOrWhiteSpace( cs != null ? cs.ProviderName : null );
               //
               dscTbl.Rows.Add( r );
            }
         }
      }

      private static System.IO.FileInfo[ ] GetFiles( System.IO.DirectoryInfo di )
      {
         System.IO.FileInfo[ ] files = di.GetFiles( "*.AqbQb.xml", System.IO.SearchOption.AllDirectories );
         System.IO.FileInfo[ ] files2 = di.GetFiles( "*.DsSs.xml", System.IO.SearchOption.AllDirectories );
         files2.CopyTo( files, 0 );
         return files;
      }

      public const string DataStoreConfig_TblName = "DataStoreConfig";
      public const string DataStoreSnapshotFile_TblName = "DataStoreSnapshotFiles";
      public const string MetadataItem_TblName = "MetadataItem";
      //
      public static string IsValidStagePathDir_ColName = "IsValidStagePathDir";
      public static string IsValidProviderName_ColName = "IsValidProviderName";
      public static string ConnectionStringName_ColName = "ConnectionStringName";
      public static string ConnectionString_ColName = "ConnectionString";
      public static string ProviderName_ColName = "ProviderName";
      public static string StagePathDir_ColName = "StagePathDir";

      private static System.Data.DataTable CreateDataStoreConfigTable( string name = DataStoreConfig_TblName )
      {
         System.Data.DataTable t = new System.Data.DataTable( name );
         {
            //System.Data.DataColumn c = new System.Data.DataColumn( );
            //c.DataType = System.Type.GetType( "System.Int32" );
            //c.ColumnName = "ID";
            //c.Caption = "Id";
            //c.ReadOnly = true;
            //c.Unique = false;
            //t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = System.Type.GetType( "System.String" );
            c.ColumnName = "Name";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = System.Type.GetType( "System.Boolean" );
            c.ColumnName = "IsActive";
            c.ReadOnly = false;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = System.Type.GetType( "System.String" );
            c.ColumnName = ConnectionStringName_ColName;
            c.ReadOnly = false;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = System.Type.GetType( "System.Boolean" );
            c.ColumnName = "LoadDefaultDatabaseOnly";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = System.Type.GetType( "System.Boolean" );
            c.ColumnName = "LoadSystemObjects";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = System.Type.GetType( "System.Boolean" );
            c.ColumnName = "WithFields";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = System.Type.GetType( "System.String" );
            c.ColumnName = StagePathDir_ColName;
            c.Caption = "StagePathDir";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = System.Type.GetType( "System.String" );
            c.ColumnName = ConnectionString_ColName;
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = System.Type.GetType( "System.String" );
            c.ColumnName = ProviderName_ColName;
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = System.Type.GetType( "System.Boolean" );
            c.ColumnName = IsValidStagePathDir_ColName;
            c.Caption = IsValidStagePathDir_ColName;
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = System.Type.GetType( "System.Boolean" );
            c.ColumnName = IsValidProviderName_ColName;
            c.Caption = "IsValidProviderName";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.Object );
            c.ColumnName = "Tag";
            c.Caption = "Tag";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         return t;
      }
      private static System.Data.DataTable CreateDataStoreSnapshotFileTable( string name = DataStoreSnapshotFile_TblName )
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
            c.DataType = typeof( string );
            c.ColumnName = "Name";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( bool );
            c.ColumnName = "IsActive";
            c.ReadOnly = false;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( string ); // typeof( System.IO.FileInfo );
            c.ColumnName = "SnapshotFile";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.DateTime );
            c.ColumnName = "LastWriteTimeUtc";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         return t;
      }
      private static System.Data.DataTable CreateMetadataItemTable( string name = MetadataItem_TblName )
      {
         System.Data.DataTable t = new System.Data.DataTable( name );
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( int );
            c.ColumnName = "ID";
            c.Caption = "Id";
            c.ReadOnly = true;
            c.Unique = false;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( string );
            c.ColumnName = "DataStoreName";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( string ); // typeof( System.IO.FileInfo );
            c.ColumnName = "SnapshotFile";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.DateTime );
            c.ColumnName = "LastWriteTimeUtc";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( string );
            c.ColumnName = "MetadataProvider";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( string );
            c.ColumnName = "SyntaxProvider";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( int );
            c.ColumnName = "ParentID";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( bool );
            c.ColumnName = "IsSystem";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( string );
            c.ColumnName = "Type";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( string );
            c.ColumnName = "ParentType";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( string );
            c.ColumnName = "Cardinality";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( int );
            c.ColumnName = "FieldsCount";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( string );
            c.ColumnName = "Fields";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( string );
            c.ColumnName = "ReferencedCardinality";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( string );
            c.ColumnName = "ReferencedObject";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( string );
            c.ColumnName = "ReferencedObjectName";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( int );
            c.ColumnName = "ReferencedFieldsCount";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( string );
            c.ColumnName = "ReferencedFields";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( string );
            c.ColumnName = "Server";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( string );
            c.ColumnName = "Database";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( string );
            c.ColumnName = "Schema";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( string );
            c.ColumnName = "ObjectName";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( string );
            c.ColumnName = "NameFullQualified";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( string );
            c.ColumnName = "NameQuoted";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( string );
            c.ColumnName = "AltName";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( string );
            c.ColumnName = "Field";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( bool );
            c.ColumnName = "HasDefault";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( string );
            c.ColumnName = "Expression";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( string );
            c.ColumnName = "FieldType";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( string );
            c.ColumnName = "FieldTypeName";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( bool );
            c.ColumnName = "IsNullable";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( int );
            c.ColumnName = "Precision";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( int );
            c.ColumnName = "Scale";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( int );
            c.ColumnName = "Size";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( bool );
            c.ColumnName = "IsPK";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( bool );
            c.ColumnName = "IsRO";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( string );
            c.ColumnName = "Description";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( object );
            c.ColumnName = "Tag";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( string );
            c.ColumnName = "UserData";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         return t;
      }
   }
}
