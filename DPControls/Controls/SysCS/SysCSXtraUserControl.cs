using DataPhilosophiae.Delegates.SysCS;
using DataPhilosophiae.Model;
using GridDataPhilosophiae.Events.SysCS;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace DataPhilosophiae.Control
{
   public partial class SysCSXtraUserControl : DevExpress.XtraEditors.XtraUserControl
   {
      #region --- FocusedSysCSChanged EVENT + HANDLER + EXCEPTION ---
      public event FocusedSysCSChangedEventHandler FocusedSysCSChangedEvent;
      #endregion

      public SysCSXtraUserControl()
      {
         this.InitializeComponent( );
         this.gridControl1.DataSource = this.GetSysConnectionStringList( );
      }

      private List<SysConnectionString> _list;

      private List<SysConnectionString> GetSysConnectionStringList()
      {
         if( this._list != null )
         {
            return this._list;
         }

         ConnectionStringSettingsCollection css = ConfigurationManager.ConnectionStrings;
         this._list = new List<SysConnectionString>( );
         if( css != null )
         {
            for( int i = 0; i < css.Count; i++ )
            {
               SysConnectionString o = new SysConnectionString( css[ i ].Name, css[ i ].ProviderName, css[ i ].ConnectionString );
               //SysConnectionString o = new SysConnectionString( )
               //{
               //   Name = css[ i ].Name,
               //   ProviderName = css[ i ].ProviderName,
               //   ConnectionString = css[ i ].ConnectionString,
               //   IsSys = true
               //};
               this._list.Add( o );
            }
         }
         return this._list;
      }

      private void gridView1_FocusedRowObjectChanged( object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e )
      {
         if( e.FocusedRowHandle == -2147483648 )
         {
            return;
         }
         if( e.FocusedRowHandle == -2147483646 )
         {
            return;
         }
         if( e.FocusedRowHandle < 0 )
         {
            return;
         }
         if( this._list == null )
         {
            return;
         }
         int dataSourceRowIndex = this.gridView1.GetDataSourceRowIndex( e.FocusedRowHandle );
         SysConnectionString sysCS = this._list[ dataSourceRowIndex ];
         FocusedSysCSChangedEventArgs args = new FocusedSysCSChangedEventArgs( );
         args.FocusedRowHandle = e.FocusedRowHandle;
         args.FocusedSysCS = sysCS;
         this.FocusedSysCSChangedEvent?.Invoke( this, args );
      }

      private void refreshBarButtonItem_ItemClick( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
      {
         this._list = null;
         this.gridControl1.DataSource = this.GetSysConnectionStringList( );
      }

      private void showAllFieldsBarButtonItem_ItemClick( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
      {
         this.colIsSys.Visible = !this.colIsSys.Visible;
         this.colProviderName.Visible = !this.colProviderName.Visible;
         this.colConnectionString.Visible = !this.colConnectionString.Visible;
         if( this.colIsSys.Visible )
         {
            this.colName.VisibleIndex = 0;
            this.colIsSys.VisibleIndex = 1;
            this.colProviderName.VisibleIndex = 2;
            this.colConnectionString.VisibleIndex = 3;
         }
      }

      private void showPreviewBarButtonItem_ItemClick( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
      {
         this.gridView1.OptionsView.ShowPreview = !this.gridView1.OptionsView.ShowPreview;
      }

      private void findPanelBarButtonItem_ItemClick( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
      {
         this.gridView1.OptionsFind.AlwaysVisible = !this.gridView1.OptionsFind.AlwaysVisible;
      }

      private void showAutoFilterRowBarButtonItem_ItemClick( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
      {
         this.gridView1.OptionsView.ShowAutoFilterRow = !this.gridView1.OptionsView.ShowAutoFilterRow;
      }

      private void showFilterPanelModeBarButtonItem_ItemClick( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
      {
         switch( this.gridView1.OptionsView.ShowFilterPanelMode )
         {
            case DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways:
               this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
               break;
            default:
               this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
               break;
         }
      }

      private void useEmbeddedNavigatorBarButtonItem_ItemClick( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
      {
         this.gridControl1.UseEmbeddedNavigator = !this.gridControl1.UseEmbeddedNavigator;
      }

      private void testConnectionBarButtonItem_ItemClick( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
      {

      }
   }
}
