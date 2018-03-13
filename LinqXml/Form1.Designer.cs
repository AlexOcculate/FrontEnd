namespace LinqXml
{
   partial class Form1
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
         this.sysConnectionStringHandler = new LinqXml.SystemConnectionStringHandler(this.components);
         this.connectionStringHandler = new LinqXml.ConnectionStringHandler(this.components);
         this.dataStoreConfigurationHandler = new LinqXml.DataStoreConfigurationHandler(this.components);
         this.SuspendLayout();
         // 
         // sysConnectionStringHandler
         // 
         this.sysConnectionStringHandler.LoadProgressEvent += new LinqXml.SystemConnectionStringHandler.LoadProgressEventHandler(this.systemConnectionStringHandler_ProgressUpdateEvent);
         this.sysConnectionStringHandler.LoadCompletedEvent += new LinqXml.SystemConnectionStringHandler.LoadCompletedEventHandler(this.systemConnectionStringHandler_LoadCompletedEvent);
         // 
         // connectionStringHandler
         // 
         this.connectionStringHandler.LoadProgressEvent += new LinqXml.ConnectionStringHandler.LoadProgressEventHandler(this.connectionStringHandler_LoadProgressEvent);
         this.connectionStringHandler.LoadCompletedEvent += new LinqXml.ConnectionStringHandler.LoadCompletedEventHandler(this.connectionStringHandler_LoadCompletedEvent);
         // 
         // dataStoreConfigurationHandler
         // 
         this.dataStoreConfigurationHandler.LoadProgressEvent += new LinqXml.DataStoreConfigurationHandler.LoadProgressEventHandler(this.dataStoreConfigurationHandler_LoadProgressEvent);
         this.dataStoreConfigurationHandler.LoadCompletedEvent += new LinqXml.DataStoreConfigurationHandler.LoadCompletedEventHandler(this.dataStoreConfigurationHandler_LoadCompletedEvent);
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(284, 261);
         this.Name = "Form1";
         this.Text = "Form1";
         this.Load += new System.EventHandler(this.Form1_Load);
         this.ResumeLayout(false);

      }

      #endregion

      private SystemConnectionStringHandler sysConnectionStringHandler;
      private ConnectionStringHandler connectionStringHandler;
      private DataStoreConfigurationHandler dataStoreConfigurationHandler;
   }
}

