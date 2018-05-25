namespace FFTAnalyzer
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.scottPlotUC3 = new ScottPlot.ScottPlotUC();
            this.scottPlotUC1 = new ScottPlot.ScottPlotUC();
            this.scottPlotUC2 = new ScottPlot.ScottPlotUC();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1851, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 46);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // scottPlotUC3
            // 
            this.scottPlotUC3.Location = new System.Drawing.Point(13, 624);
            this.scottPlotUC3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.scottPlotUC3.Name = "scottPlotUC3";
            this.scottPlotUC3.Size = new System.Drawing.Size(1962, 343);
            this.scottPlotUC3.TabIndex = 2;
            // 
            // scottPlotUC1
            // 
            this.scottPlotUC1.Location = new System.Drawing.Point(13, 62);
            this.scottPlotUC1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.scottPlotUC1.Name = "scottPlotUC1";
            this.scottPlotUC1.Size = new System.Drawing.Size(1978, 552);
            this.scottPlotUC1.TabIndex = 1;
            // 
            // scottPlotUC2
            // 
            this.scottPlotUC2.Location = new System.Drawing.Point(26, 526);
            this.scottPlotUC2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.scottPlotUC2.Name = "scottPlotUC2";
            this.scottPlotUC2.Size = new System.Drawing.Size(480, 375);
            this.scottPlotUC2.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2020, 981);
            this.Controls.Add(this.scottPlotUC3);
            this.Controls.Add(this.scottPlotUC1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private ScottPlot.ScottPlotUC scottPlotUC1;
        private ScottPlot.ScottPlotUC scottPlotUC2;
        private ScottPlot.ScottPlotUC scottPlotUC3;
    }
}

