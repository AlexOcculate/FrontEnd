namespace FrontEnd
{
   partial class VerticalPropertiesXtraUserControl
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
         if( disposing && (components != null) )
         {
            components.Dispose( );
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
         this.vGridControl = new DevExpress.XtraVerticalGrid.VGridControl();
         ((System.ComponentModel.ISupportInitialize)(this.vGridControl)).BeginInit();
         this.SuspendLayout();
         // 
         // vGridControl1
         // 
         this.vGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
         this.vGridControl.Location = new System.Drawing.Point(0, 0);
         this.vGridControl.Name = "vGridControl1";
         this.vGridControl.Size = new System.Drawing.Size(434, 680);
         this.vGridControl.TabIndex = 0;
         // 
         // VerticalPropertiesXtraUserControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.vGridControl);
         this.Name = "VerticalPropertiesXtraUserControl";
         this.Size = new System.Drawing.Size(434, 680);
         ((System.ComponentModel.ISupportInitialize)(this.vGridControl)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private DevExpress.XtraVerticalGrid.VGridControl vGridControl;
   }
}
