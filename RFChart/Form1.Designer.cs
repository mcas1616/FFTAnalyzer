namespace RFChart
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
            this.scottPlotUC1 = new ScottPlot.ScottPlotUC();
            this.tbBitData = new System.Windows.Forms.TextBox();
            this.tbByteData = new System.Windows.Forms.TextBox();
            this.btnGetData = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // scottPlotUC1
            // 
            this.scottPlotUC1.Location = new System.Drawing.Point(13, 13);
            this.scottPlotUC1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.scottPlotUC1.Name = "scottPlotUC1";
            this.scottPlotUC1.Size = new System.Drawing.Size(1892, 455);
            this.scottPlotUC1.TabIndex = 0;
            // 
            // tbBitData
            // 
            this.tbBitData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBitData.Location = new System.Drawing.Point(13, 716);
            this.tbBitData.Multiline = true;
            this.tbBitData.Name = "tbBitData";
            this.tbBitData.ReadOnly = true;
            this.tbBitData.Size = new System.Drawing.Size(844, 226);
            this.tbBitData.TabIndex = 2;
            // 
            // tbByteData
            // 
            this.tbByteData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbByteData.Location = new System.Drawing.Point(863, 716);
            this.tbByteData.Multiline = true;
            this.tbByteData.Name = "tbByteData";
            this.tbByteData.ReadOnly = true;
            this.tbByteData.Size = new System.Drawing.Size(844, 226);
            this.tbByteData.TabIndex = 2;
            // 
            // btnGetData
            // 
            this.btnGetData.Location = new System.Drawing.Point(1714, 716);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(191, 71);
            this.btnGetData.TabIndex = 3;
            this.btnGetData.Text = "GenerateData";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // panelMain
            // 
            this.panelMain.Location = new System.Drawing.Point(13, 468);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1892, 232);
            this.panelMain.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1918, 954);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.tbByteData);
            this.Controls.Add(this.tbBitData);
            this.Controls.Add(this.scottPlotUC1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ScottPlot.ScottPlotUC scottPlotUC1;
        private System.Windows.Forms.TextBox tbBitData;
        private System.Windows.Forms.TextBox tbByteData;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.Panel panelMain;
    }
}

