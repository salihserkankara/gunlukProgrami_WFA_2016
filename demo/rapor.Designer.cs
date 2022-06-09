namespace demo
{
    partial class rapor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.gunlukBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.veritabaniDataSet2 = new demo.veritabaniDataSet2();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.gunlukTableAdapter = new demo.veritabaniDataSet1TableAdapters.gunlukTableAdapter();
            this.gunlukTableAdapter1 = new demo.veritabaniDataSet2TableAdapters.gunlukTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.gunlukBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.veritabaniDataSet2)).BeginInit();
            this.SuspendLayout();
            // 
            // gunlukBindingSource1
            // 
            this.gunlukBindingSource1.DataMember = "gunluk";
            this.gunlukBindingSource1.DataSource = this.veritabaniDataSet2;
            // 
            // veritabaniDataSet2
            // 
            this.veritabaniDataSet2.DataSetName = "veritabaniDataSet2";
            this.veritabaniDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "veriseti";
            reportDataSource1.Value = this.gunlukBindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "demo.Report3.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(13, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(989, 483);
            this.reportViewer1.TabIndex = 0;
            // 
            // gunlukTableAdapter
            // 
            this.gunlukTableAdapter.ClearBeforeFill = true;
            // 
            // gunlukTableAdapter1
            // 
            this.gunlukTableAdapter1.ClearBeforeFill = true;
            // 
            // rapor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 508);
            this.Controls.Add(this.reportViewer1);
            this.MaximizeBox = false;
            this.Name = "rapor";
            this.Text = "yardim";
            this.Load += new System.EventHandler(this.yardim_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gunlukBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.veritabaniDataSet2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private veritabaniDataSet1TableAdapters.gunlukTableAdapter gunlukTableAdapter;
        private veritabaniDataSet2 veritabaniDataSet2;
        private System.Windows.Forms.BindingSource gunlukBindingSource1;
        private veritabaniDataSet2TableAdapters.gunlukTableAdapter gunlukTableAdapter1;
    }
}