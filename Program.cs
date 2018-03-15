using System;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace FrontEnd
{
   internal static class Program
   {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      private static void Main()
      {
         DevExpress.UserSkins.BonusSkins.Register( );
         DevExpress.Skins.SkinManager.EnableFormSkins( );
         string skinStyle = "Visual Studio 2013 Blue"; // "Metropolis Dark";
         //if( true )
         //   skinStyle = "Office 2016 Colorful";
         //else
         //   skinStyle = "Visual Studio 2013 Blue";
         DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle( skinStyle );
         //
         Bitmap splashScreenImage = new Bitmap( CurrentAssembly.GetManifestResourceStream( "FrontEnd.Resources.splashScreen.png" ) );
         DevExpress.XtraSplashScreen.SplashScreenManager.ShowImage( splashScreenImage, true, false );
         //
         Application.EnableVisualStyles( );
         Application.SetCompatibleTextRenderingDefault( false );
         Application.Run( new Form1( ) );
         ///x( );
      }
      //
      private static Assembly currentAssemblyCore;
      private static Assembly CurrentAssembly
      {
         get
         {
            if( currentAssemblyCore == null )
            {
               currentAssemblyCore = Assembly.GetExecutingAssembly( );
            }
            return currentAssemblyCore;
         }
      }

      // -------------------------------------------------------

      private static void x()
      {
         FrontEnd.DataStore o = new DataStore( );
      }

      #region --- Active Query Builder ---
      public static bool TestAqbSqlContext4SQLiteConnection( string cs )
      {
         ActiveQueryBuilder.Core.SQLContext sc = new ActiveQueryBuilder.Core.SQLContext( )
         {
            SyntaxProvider = new ActiveQueryBuilder.Core.SQLiteSyntaxProvider( ),
            MetadataProvider = new ActiveQueryBuilder.Core.SQLiteMetadataProvider( )
            {
               Connection = new System.Data.SQLite.SQLiteConnection( )
               {
                  ConnectionString = cs
               }
            }
         };
         {
            // sc.MetadataContainer.LoadingOptions.OfflineMode = false;
            // sc.MetadataContainer.LoadingOptions.LoadSystemObjects = false;
            // sc.MetadataContainer.LoadingOptions.LoadDefaultDatabaseOnly = true;
            sc.LoadingOptions.OfflineMode = false;
            sc.LoadingOptions.LoadSystemObjects = false;
            sc.LoadingOptions.LoadDefaultDatabaseOnly = true;
            sc.MetadataContainer.LoadAll( false );
         }
         ActiveQueryBuilder.Core.MetadataList items = sc.MetadataContainer.Items;
         return items == null ? false : true;
      }
      public static ActiveQueryBuilder.Core.SQLContext CreateAqbSqlContext4SQLiteOffline( string filepath )
      {
         ActiveQueryBuilder.Core.SQLContext sc = new ActiveQueryBuilder.Core.SQLContext( )
         {
            SyntaxProvider = new ActiveQueryBuilder.Core.SQLiteSyntaxProvider( ),
            //MetadataProvider = new ActiveQueryBuilder.Core.SQLiteMetadataProvider( )
            //{
            //   Connection = new System.Data.SQLite.SQLiteConnection( )
            //   {
            //      ConnectionString = cs.ConnectionString
            //   }
            //}
         };
         {
            sc.MetadataContainer.LoadingOptions.OfflineMode = true;
            sc.MetadataContainer.ImportFromXML( filepath );
         }
         return sc;
      }
      public static ActiveQueryBuilder.Core.SQLContext CreateAqbSqlContext4SQLiteOnline( string cs )
      {
         ActiveQueryBuilder.Core.SQLContext sc = new ActiveQueryBuilder.Core.SQLContext( )
         {
            SyntaxProvider = new ActiveQueryBuilder.Core.SQLiteSyntaxProvider( ),
            MetadataProvider = new ActiveQueryBuilder.Core.SQLiteMetadataProvider( )
            {
               Connection = new System.Data.SQLite.SQLiteConnection( )
               {
                  ConnectionString = cs
               }
            }
         };
         //{
         //   sc.MetadataContainer.LoadAll( WithField );
         //   sc.MetadataContainer.LoadingOptions.OfflineMode = true;
         //   sc.MetadataContainer.ImportFromXML( filepath );
         //}
         return sc;
      }

      private class StackItem
      {
         public ActiveQueryBuilder.Core.MetadataList list;
         public int index;
         public int parentID;
         public int grandParentID;
      }

      public static void DrillDownAqbSqlContext(
         ActiveQueryBuilder.Core.SQLContext sc
         , System.Data.DataTable tbl
         , string dataStoreName
         )
      {
         ActiveQueryBuilder.Core.MetadataList items = sc.MetadataContainer.Items;
         //
         System.Collections.Generic.Stack<StackItem> stack = new System.Collections.Generic.Stack<StackItem>( );
         stack.Push( new StackItem { list = items, index = 0, parentID = -1, grandParentID = -1 } );
         do
         {
            StackItem si = stack.Pop( );
            ActiveQueryBuilder.Core.MetadataList actualMIList = si.list;
            int actualIndex = si.index;
            int actualParentID = si.grandParentID; // IMPORTANT!!!
            for( ; actualIndex < actualMIList.Count; actualIndex++ )
            {
               System.Data.DataRow row = tbl.NewRow( );
               row[ "DataStoreName" ] = dataStoreName;
               ExtractMetadataItem( row, actualMIList[ actualIndex ], actualParentID, tbl );
               tbl.Rows.Add( row );
               if( actualMIList[ actualIndex ].Items.Count > 0 ) // branch...
               {
                  int count = tbl.Rows.Count;
                  System.Data.DataRowCollection rows = tbl.Rows;
                  int parentId = (int) rows[ count - 1 ][ "ID" ];
                  // Push the "next" Item...
                  stack.Push( new StackItem
                  {
                     list = actualMIList,
                     index = actualIndex + 1,
                     parentID = parentId,
                     grandParentID = actualParentID
                  } );
                  // Reset the loop to process the "actual" Item...
                  actualParentID = parentId;
                  actualMIList = actualMIList[ actualIndex ].Items;
                  actualIndex = -1;
               }
            } // for(;;)...

         } while( stack.Count > 0 );
      }

      private static void ExtractMetadataItem(
         System.Data.DataRow row
         , ActiveQueryBuilder.Core.MetadataItem mi
         , int parentID
         , System.Data.DataTable tbl
         )
      {
         switch( mi.Type )
         {
            case ActiveQueryBuilder.Core.MetadataType.Database:
            case ActiveQueryBuilder.Core.MetadataType.Schema:
               ExtractNamespace( row, mi, parentID, tbl );
               break;
            case ActiveQueryBuilder.Core.MetadataType.Table:
            case ActiveQueryBuilder.Core.MetadataType.View:
               ExtractTable( row, mi, parentID, tbl );
               break;
            case ActiveQueryBuilder.Core.MetadataType.Procedure:
               ExtractProcedure( row, mi, parentID, tbl );
               break;
            case ActiveQueryBuilder.Core.MetadataType.Synonym:
               ExtractSynonym( row, mi, parentID, tbl );
               break;
            case ActiveQueryBuilder.Core.MetadataType.Field:
               ExtractField( row, mi, parentID, tbl );
               break;
            case ActiveQueryBuilder.Core.MetadataType.ForeignKey:
               ExtractForeignKey( row, mi, parentID, tbl );
               break;
            case ActiveQueryBuilder.Core.MetadataType.Root:
            case ActiveQueryBuilder.Core.MetadataType.Server:
            case ActiveQueryBuilder.Core.MetadataType.Package:
            case ActiveQueryBuilder.Core.MetadataType.Namespaces:
            case ActiveQueryBuilder.Core.MetadataType.ObjectMetadata:
            case ActiveQueryBuilder.Core.MetadataType.Objects:
            case ActiveQueryBuilder.Core.MetadataType.Aggregate:
            case ActiveQueryBuilder.Core.MetadataType.Parameter:
            case ActiveQueryBuilder.Core.MetadataType.UserQuery:
            case ActiveQueryBuilder.Core.MetadataType.UserField:
            case ActiveQueryBuilder.Core.MetadataType.All:
            default:
               ExtractItem( row, mi, parentID, tbl );
               break;
         }
      }

      private static void ExtractNamespace(
         System.Data.DataRow row
         , ActiveQueryBuilder.Core.MetadataItem mi
         , int parentID
         , System.Data.DataTable tbl
         )
      {
         if( mi == null )
         {
            return;
         }

         ExtractItem( row, mi, parentID, tbl );
         {
            //ActiveQueryBuilder.Core.MetadataNamespace m = mi as ActiveQueryBuilder.Core.MetadataNamespace;
         }
      }

      private static void ExtractProcedure(
         System.Data.DataRow row
         , ActiveQueryBuilder.Core.MetadataItem mi
         , int parentID
         , System.Data.DataTable tbl
         )
      {
         if( mi == null )
         {
            return;
         }

         ExtractItem( row, mi, parentID, tbl );
         {
            ActiveQueryBuilder.Core.MetadataObject m = mi as ActiveQueryBuilder.Core.MetadataObject;
         }
      }

      private static void ExtractSynonym(
         System.Data.DataRow row
         , ActiveQueryBuilder.Core.MetadataItem mi
         , int parentID
         , System.Data.DataTable tbl
         )
      {
         if( mi == null )
         {
            return;
         }

         ExtractItem( row, mi, parentID, tbl );
         {
            ActiveQueryBuilder.Core.MetadataObject m = mi as ActiveQueryBuilder.Core.MetadataObject;
            row[ "ReferencedObject" ] = m.ReferencedObject?.NameFull;
            //
            for( int i = 0; i < m.ReferencedObjectName.Count; i++ )
            {
               ActiveQueryBuilder.Core.MetadataQualifiedNamePart x = m.ReferencedObjectName[ i ];
               row[ "ReferencedObjectName" ] += "["
               + System.Enum.GetName( typeof( ActiveQueryBuilder.Core.MetadataType ), x.Type )
               + ":"
               + x.Name
               + "]"
            ;
            }
         }
      }

      private static void ExtractTable(
         System.Data.DataRow row
         , ActiveQueryBuilder.Core.MetadataItem mi
         , int parentID
         , System.Data.DataTable tbl
         )
      {
         if( mi == null )
         {
            return;
         }

         ExtractItem( row, mi, parentID, tbl );
         {
            //ActiveQueryBuilder.Core.MetadataObject m = mi as ActiveQueryBuilder.Core.MetadataObject;
         }
      }

      private static void ExtractField(
         System.Data.DataRow row
         , ActiveQueryBuilder.Core.MetadataItem mi
         , int parentID
         , System.Data.DataTable tbl
         )
      {
         if( mi == null )
         {
            return;
         }

         ExtractItem( row, mi, parentID, tbl );
         {
            ActiveQueryBuilder.Core.MetadataField m = mi as ActiveQueryBuilder.Core.MetadataField;
            row[ "Expression" ] = m.Expression;
            row[ "FieldType" ] = System.Enum.GetName( typeof( System.Data.DbType ), m.FieldType );
            row[ "FieldTypeName" ] = m.FieldTypeName;
            row[ "IsNullable" ] = m.Nullable;
            row[ "Precision" ] = m.Precision;
            row[ "Scale" ] = m.Scale;
            row[ nameof( Size ) ] = m.Size;
            row[ "IsPK" ] = m.PrimaryKey;
            row[ "IsRO" ] = m.ReadOnly;
         }
      }

      private static void ExtractForeignKey(
         System.Data.DataRow row
         , ActiveQueryBuilder.Core.MetadataItem mi
         , int parentID
         , System.Data.DataTable tbl
         )
      {
         if( mi == null )
         {
            return;
         }

         ExtractItem( row, mi, parentID, tbl );
         row[ "FieldType" ] = null;
         {
            ActiveQueryBuilder.Core.MetadataForeignKey m = mi as ActiveQueryBuilder.Core.MetadataForeignKey;
            row[ "ReferencedObject" ] = m.ReferencedObject.NameFull;
            //
            for( int i = 0; i < m.ReferencedObjectName.Count; i++ )
            {
               ActiveQueryBuilder.Core.MetadataQualifiedNamePart x = m.ReferencedObjectName[ i ];
               row[ "ReferencedObjectName" ] += "["
               + System.Enum.GetName( typeof( ActiveQueryBuilder.Core.MetadataType ), x.Type )
               + ":"
               + x.Name
               + "]"
            ;
            }
            //
            row[ "ReferencedFieldsCount" ] = m.ReferencedFields.Count;
            for( int i = 0; i < m.ReferencedFields.Count; i++ )
            {
               row[ "ReferencedFields" ] += "[" + m.ReferencedFields[ i ] + "]";
            }
            //
            row[ "ReferencedCardinality" ] = System.Enum.GetName( typeof( ActiveQueryBuilder.Core.MetadataForeignKeyCardinality ), m.ReferencedCardinality );
            //
            row[ "FieldsCount" ] = m.Fields.Count;
            for( int i = 0; i < m.Fields.Count; i++ )
            {
               row[ "Fields" ] += "[" + m.Fields[ i ] + "]"
            ;
            }
            //
            row[ "Cardinality" ] = System.Enum.GetName( typeof( ActiveQueryBuilder.Core.MetadataForeignKeyCardinality ), m.Cardinality );
         }
      }

      private static void ExtractItem(
         System.Data.DataRow row
         , ActiveQueryBuilder.Core.MetadataItem mi
         , int parentID
         , System.Data.DataTable tbl
         )

      {
         row[ "ID" ] = tbl.Rows.Count;
         row[ "ParentID" ] = parentID;
         row[ "MetadataProvider" ] = mi.SQLContext?.MetadataProvider?.Description;
         row[ "SyntaxProvider" ] = mi.SQLContext?.SyntaxProvider?.Description;
         if( mi.Parent != null )
         {
            row[ "ParentType" ] = System.Enum.GetName( typeof( ActiveQueryBuilder.Core.MetadataType ), mi.Parent.Type );
         }
         row[ nameof( Type ) ] = System.Enum.GetName( typeof( ActiveQueryBuilder.Core.MetadataType ), mi.Type );
         row[ "IsSystem" ] = mi.System;
         ////
         //string rootName = mi.Root?.Name;
         row[ "Server" ] = mi.Server?.Name;
         row[ "Database" ] = mi.Database?.Name;
         row[ "Schema" ] = mi.Schema?.Name;
         row[ "ObjectName" ] = mi.Object?.Name;
         ////
         row[ "NameFullQualified" ] = mi.NameFull + (mi.NameFull.EndsWith( "." ) ? "<?>" : string.Empty);
         row[ "NameQuoted" ] = mi.NameQuoted;
         row[ "AltName" ] = mi.AltName;
         row[ "Field" ] = mi.Name != null ? mi.Name : "<?>";
         ////
         row[ "HasDefault" ] = mi.Default;
         row[ "Description" ] = mi.Description;
         row[ "Tag" ] = mi.Tag;
         row[ "UserData" ] = mi.UserData;
      }
      #endregion

      #region --- DATASET ---
      public const string DataStoreConfig_TblName = "DataStoreConfig";
      public const string DataStoreSnapshotFile_TblName = "DataStoreSnapshotFiles";
      public const string MetadataItem_TblName = "MetadataItem";
      public static System.Data.DataTable CreateMetadataItemTable( string name = MetadataItem_TblName )
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
            c.ColumnName = nameof( Type );
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
            c.ColumnName = nameof( Size );
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
      #endregion

      // --------------------------------------

   }
}
