using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace FrontEnd
{
   public partial class MetadataItemXtraUserControl : DevExpress.XtraEditors.XtraUserControl
   {
      public MetadataItemXtraUserControl()
      {
         InitializeComponent( );
         {
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsMenu.ShowFooterItem = true;
            this.gridView1.OptionsMenu.ShowConditionalFormattingItem = true;
            this.gridView1.OptionsMenu.ShowGroupSummaryEditorItem = true;
            this.gridView1.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.OptionsView.ShowFooter = true;
         }

      }
   }
}
