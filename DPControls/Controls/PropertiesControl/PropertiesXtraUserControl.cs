using System;
using System.Linq;
using System.Windows.Forms;

namespace FrontEnd
{
   public partial class PropertiesXtraUserControl : DevExpress.XtraEditors.XtraUserControl
   {
      public PropertiesXtraUserControl()
      {
         this.InitializeComponent( );
         this.propertyGridControl.AutoGenerateRows = true;
         this.AddControls( this, this.comboBoxEdit );
         this.comboBoxEdit.SelectedIndex = 0;
         {
            this.propertyGridControl.FindPanelVisible = true;
            this.propertyGridControl.OptionsFind.ShowCloseButton = false;
            this.propertyGridControl.OptionsFind.Visibility = DevExpress.XtraVerticalGrid.FindPanelVisibility.Always;
            this.propertyGridControl.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            this.propertyGridControl.OptionsView.ShowFilterPanelMode = DevExpress.XtraVerticalGrid.ShowFilterPanelMode.ShowAlways;
         }
         {
            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ri = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
            {
               CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
            };
            this.propertyGridControl.DefaultEditors.Add( typeof( Boolean ), ri );
         }
      }
      private void comboBox_SelectedIndexChanged( object sender, System.EventArgs e )
      {
         this.propertyGridControl.SelectedObject = this.comboBoxEdit.SelectedItem;
      }
      private void AddControls( Control container, DevExpress.XtraEditors.ComboBoxEdit cb )
      {
         foreach( object obj in container.Controls )
         {
            cb.Properties.Items.Add( obj );
            if( obj is Control )
            {
               this.AddControls( obj as Control, cb );
            }
         }
      }
      public void SetXXX( object sender )
      {
         this.propertyGridControl.SelectedObject = sender;
      }
   }
}
