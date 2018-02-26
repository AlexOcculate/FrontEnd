﻿namespace FrontEnd
{
   public partial class TaskListXtraUserControl
   {
      /// <summary> 
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary> 
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose( bool disposing )
      {
         if( disposing && (this.components != null) )
         {
            this.components.Dispose( );
         }
         base.Dispose( disposing );
      }

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.gridControl1 = new DevExpress.XtraGrid.GridControl( );
         this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView( );
         this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn( );
         this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn( );
         this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn( );
         this.descriptionGridColumn = new DevExpress.XtraGrid.Columns.GridColumn( );
         ((System.ComponentModel.ISupportInitialize) (this.gridControl1)).BeginInit( );
         ((System.ComponentModel.ISupportInitialize) (this.gridView1)).BeginInit( );
         this.SuspendLayout( );
         // 
         // gridControl1
         // 
         this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.gridControl1.Location = new System.Drawing.Point( 0, 0 );
         this.gridControl1.MainView = this.gridView1;
         this.gridControl1.Name = "gridControl1";
         this.gridControl1.Size = new System.Drawing.Size( 628, 317 );
         this.gridControl1.TabIndex = 0;
         this.gridControl1.ViewCollection.AddRange( new DevExpress.XtraGrid.Views.Base.BaseView[ ] {
            this.gridView1} );
         // 
         // gridView1
         // 
         this.gridView1.Columns.AddRange( new DevExpress.XtraGrid.Columns.GridColumn[ ] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.descriptionGridColumn} );
         this.gridView1.GridControl = this.gridControl1;
         this.gridView1.Name = "gridView1";
         this.gridView1.OptionsCustomization.AllowFilter = false;
         this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
         this.gridView1.OptionsView.ShowGroupPanel = false;
         this.gridView1.OptionsView.ShowIndicator = false;
         // 
         // gridColumn1
         // 
         this.gridColumn1.Caption = "!";
         this.gridColumn1.Name = "gridColumn1";
         this.gridColumn1.Visible = true;
         this.gridColumn1.VisibleIndex = 0;
         this.gridColumn1.Width = 29;
         // 
         // gridColumn2
         // 
         this.gridColumn2.Name = "gridColumn2";
         this.gridColumn2.Visible = true;
         this.gridColumn2.VisibleIndex = 1;
         this.gridColumn2.Width = 29;
         // 
         // gridColumn3
         // 
         this.gridColumn3.Caption = "*";
         this.gridColumn3.Name = "gridColumn3";
         this.gridColumn3.Visible = true;
         this.gridColumn3.VisibleIndex = 2;
         this.gridColumn3.Width = 29;
         // 
         // gridColumn4
         // 
         this.descriptionGridColumn.Caption = "Description";
         this.descriptionGridColumn.Name = "descriptionGridColumn";
         this.descriptionGridColumn.Visible = true;
         this.descriptionGridColumn.VisibleIndex = 3;
         this.descriptionGridColumn.Width = 802;
         // 
         // TaskListXtraUserControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add( this.gridControl1 );
         this.Name = "TaskListXtraUserControl";
         this.Size = new System.Drawing.Size( 628, 317 );
         ((System.ComponentModel.ISupportInitialize) (this.gridControl1)).EndInit( );
         ((System.ComponentModel.ISupportInitialize) (this.gridView1)).EndInit( );
         this.ResumeLayout( false );

      }

      #endregion

      private DevExpress.XtraGrid.GridControl gridControl1;
      private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
      private DevExpress.XtraGrid.Columns.GridColumn descriptionGridColumn;
   }
}
