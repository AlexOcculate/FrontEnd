namespace LinqXml
{
   partial class ConfigurationTestForm
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

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.components = new System.ComponentModel.Container();
         this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
         this.bar1 = new DevExpress.XtraBars.Bar();
         this.bar2 = new DevExpress.XtraBars.Bar();
         this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
         this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
         this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
         this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
         this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
         this.bar3 = new DevExpress.XtraBars.Bar();
         this.labelStatusBarStaticItem = new DevExpress.XtraBars.BarStaticItem();
         this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
         this.configurationView1 = new LinqXml.Control.ConfigurationView();
         this.objnmStatusBarStaticItem = new DevExpress.XtraBars.BarStaticItem();
         ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
         this.SuspendLayout();
         // 
         // barManager1
         // 
         this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar2,
            this.bar3});
         this.barManager1.DockControls.Add(this.barDockControlTop);
         this.barManager1.DockControls.Add(this.barDockControlBottom);
         this.barManager1.DockControls.Add(this.barDockControlLeft);
         this.barManager1.DockControls.Add(this.barDockControlRight);
         this.barManager1.Form = this;
         this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barButtonItem4,
            this.barButtonItem5,
            this.labelStatusBarStaticItem,
            this.objnmStatusBarStaticItem});
         this.barManager1.MainMenu = this.bar2;
         this.barManager1.MaxItemId = 7;
         this.barManager1.StatusBar = this.bar3;
         // 
         // bar1
         // 
         this.bar1.BarName = "Tools";
         this.bar1.DockCol = 0;
         this.bar1.DockRow = 1;
         this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
         this.bar1.Text = "Tools";
         // 
         // bar2
         // 
         this.bar2.BarName = "Main menu";
         this.bar2.DockCol = 0;
         this.bar2.DockRow = 0;
         this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
         this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem3),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem4),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem5)});
         this.bar2.OptionsBar.MultiLine = true;
         this.bar2.OptionsBar.UseWholeRow = true;
         this.bar2.Text = "Main menu";
         // 
         // barButtonItem1
         // 
         this.barButtonItem1.Caption = "Open";
         this.barButtonItem1.Id = 0;
         this.barButtonItem1.Name = "barButtonItem1";
         this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
         // 
         // barButtonItem2
         // 
         this.barButtonItem2.Caption = "Save";
         this.barButtonItem2.Id = 1;
         this.barButtonItem2.Name = "barButtonItem2";
         this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
         // 
         // barButtonItem3
         // 
         this.barButtonItem3.Caption = "Save As";
         this.barButtonItem3.Id = 2;
         this.barButtonItem3.Name = "barButtonItem3";
         this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
         // 
         // barButtonItem4
         // 
         this.barButtonItem4.Caption = "Close";
         this.barButtonItem4.Id = 3;
         this.barButtonItem4.Name = "barButtonItem4";
         this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem4_ItemClick);
         // 
         // barButtonItem5
         // 
         this.barButtonItem5.Caption = "Set Working Directory";
         this.barButtonItem5.Id = 4;
         this.barButtonItem5.Name = "barButtonItem5";
         // 
         // bar3
         // 
         this.bar3.BarName = "Status bar";
         this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
         this.bar3.DockCol = 0;
         this.bar3.DockRow = 0;
         this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
         this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.labelStatusBarStaticItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.objnmStatusBarStaticItem)});
         this.bar3.OptionsBar.AllowQuickCustomization = false;
         this.bar3.OptionsBar.DrawDragBorder = false;
         this.bar3.OptionsBar.UseWholeRow = true;
         this.bar3.Text = "Status bar";
         // 
         // labelStatusBarStaticItem
         // 
         this.labelStatusBarStaticItem.Id = 5;
         this.labelStatusBarStaticItem.Name = "labelStatusBarStaticItem";
         // 
         // barDockControlTop
         // 
         this.barDockControlTop.CausesValidation = false;
         this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
         this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
         this.barDockControlTop.Manager = this.barManager1;
         this.barDockControlTop.Size = new System.Drawing.Size(759, 51);
         // 
         // barDockControlBottom
         // 
         this.barDockControlBottom.CausesValidation = false;
         this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.barDockControlBottom.Location = new System.Drawing.Point(0, 683);
         this.barDockControlBottom.Manager = this.barManager1;
         this.barDockControlBottom.Size = new System.Drawing.Size(759, 25);
         // 
         // barDockControlLeft
         // 
         this.barDockControlLeft.CausesValidation = false;
         this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
         this.barDockControlLeft.Location = new System.Drawing.Point(0, 51);
         this.barDockControlLeft.Manager = this.barManager1;
         this.barDockControlLeft.Size = new System.Drawing.Size(0, 632);
         // 
         // barDockControlRight
         // 
         this.barDockControlRight.CausesValidation = false;
         this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
         this.barDockControlRight.Location = new System.Drawing.Point(759, 51);
         this.barDockControlRight.Manager = this.barManager1;
         this.barDockControlRight.Size = new System.Drawing.Size(0, 632);
         // 
         // configurationView1
         // 
         this.configurationView1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.configurationView1.Location = new System.Drawing.Point(0, 51);
         this.configurationView1.Name = "configurationView1";
         this.configurationView1.Size = new System.Drawing.Size(759, 632);
         this.configurationView1.TabIndex = 4;
         // 
         // barStaticItem1
         // 
         this.objnmStatusBarStaticItem.Caption = "barStaticItem1";
         this.objnmStatusBarStaticItem.Id = 6;
         this.objnmStatusBarStaticItem.Name = "barStaticItem1";
         // 
         // ConfigurationTestForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(759, 708);
         this.Controls.Add(this.configurationView1);
         this.Controls.Add(this.barDockControlLeft);
         this.Controls.Add(this.barDockControlRight);
         this.Controls.Add(this.barDockControlBottom);
         this.Controls.Add(this.barDockControlTop);
         this.Name = "ConfigurationTestForm";
         this.Text = "ConfigurationTestForm";
         ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private DevExpress.XtraBars.BarManager barManager1;
      private DevExpress.XtraBars.Bar bar1;
      private DevExpress.XtraBars.Bar bar2;
      private DevExpress.XtraBars.BarButtonItem barButtonItem1;
      private DevExpress.XtraBars.BarButtonItem barButtonItem2;
      private DevExpress.XtraBars.BarButtonItem barButtonItem3;
      private DevExpress.XtraBars.BarButtonItem barButtonItem4;
      private DevExpress.XtraBars.BarButtonItem barButtonItem5;
      private DevExpress.XtraBars.Bar bar3;
      private DevExpress.XtraBars.BarDockControl barDockControlTop;
      private DevExpress.XtraBars.BarDockControl barDockControlBottom;
      private DevExpress.XtraBars.BarDockControl barDockControlLeft;
      private DevExpress.XtraBars.BarDockControl barDockControlRight;
      private DevExpress.XtraBars.BarStaticItem labelStatusBarStaticItem;
      private Control.ConfigurationView configurationView1;
      private DevExpress.XtraBars.BarStaticItem objnmStatusBarStaticItem;
   }
}