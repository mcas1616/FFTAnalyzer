﻿namespace Spectrum
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelWaterFall = new System.Windows.Forms.Panel();
            this.tbBitData = new System.Windows.Forms.TextBox();
            this.tbByteData = new System.Windows.Forms.TextBox();
            this.btnRandomData = new System.Windows.Forms.Button();
            this.lbPowerMax = new System.Windows.Forms.Label();
            this.lbPowerMin = new System.Windows.Forms.Label();
            this.lbFrequectMin = new System.Windows.Forms.Label();
            this.lbFrequencyMax = new System.Windows.Forms.Label();
            this.panelWaterFallGuide = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbBitLength = new System.Windows.Forms.TextBox();
            this.zoomIn = new System.Windows.Forms.Button();
            this.zoomOut = new System.Windows.Forms.Button();
            this.tbZoom = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbByte = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Location = new System.Drawing.Point(85, 13);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1880, 395);
            this.panelMain.TabIndex = 0;
            // 
            // panelWaterFall
            // 
            this.panelWaterFall.Location = new System.Drawing.Point(85, 447);
            this.panelWaterFall.Name = "panelWaterFall";
            this.panelWaterFall.Size = new System.Drawing.Size(1880, 241);
            this.panelWaterFall.TabIndex = 1;
            // 
            // tbBitData
            // 
            this.tbBitData.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBitData.Location = new System.Drawing.Point(13, 695);
            this.tbBitData.Multiline = true;
            this.tbBitData.Name = "tbBitData";
            this.tbBitData.ReadOnly = true;
            this.tbBitData.Size = new System.Drawing.Size(845, 257);
            this.tbBitData.TabIndex = 2;
            // 
            // tbByteData
            // 
            this.tbByteData.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbByteData.Location = new System.Drawing.Point(864, 695);
            this.tbByteData.Multiline = true;
            this.tbByteData.Name = "tbByteData";
            this.tbByteData.ReadOnly = true;
            this.tbByteData.Size = new System.Drawing.Size(634, 257);
            this.tbByteData.TabIndex = 2;
            // 
            // btnRandomData
            // 
            this.btnRandomData.Location = new System.Drawing.Point(1715, 799);
            this.btnRandomData.Name = "btnRandomData";
            this.btnRandomData.Size = new System.Drawing.Size(252, 71);
            this.btnRandomData.TabIndex = 3;
            this.btnRandomData.Text = "RandomData";
            this.btnRandomData.UseVisualStyleBackColor = true;
            this.btnRandomData.Click += new System.EventHandler(this.btnRandomData_Click);
            // 
            // lbPowerMax
            // 
            this.lbPowerMax.AutoSize = true;
            this.lbPowerMax.Location = new System.Drawing.Point(4, 13);
            this.lbPowerMax.Name = "lbPowerMax";
            this.lbPowerMax.Size = new System.Drawing.Size(48, 25);
            this.lbPowerMax.TabIndex = 4;
            this.lbPowerMax.Text = "255";
            // 
            // lbPowerMin
            // 
            this.lbPowerMin.AutoSize = true;
            this.lbPowerMin.Location = new System.Drawing.Point(4, 383);
            this.lbPowerMin.Name = "lbPowerMin";
            this.lbPowerMin.Size = new System.Drawing.Size(24, 25);
            this.lbPowerMin.TabIndex = 5;
            this.lbPowerMin.Text = "0";
            // 
            // lbFrequectMin
            // 
            this.lbFrequectMin.AutoSize = true;
            this.lbFrequectMin.Location = new System.Drawing.Point(61, 411);
            this.lbFrequectMin.Name = "lbFrequectMin";
            this.lbFrequectMin.Size = new System.Drawing.Size(0, 25);
            this.lbFrequectMin.TabIndex = 5;
            // 
            // lbFrequencyMax
            // 
            this.lbFrequencyMax.AutoSize = true;
            this.lbFrequencyMax.Location = new System.Drawing.Point(1923, 411);
            this.lbFrequencyMax.Name = "lbFrequencyMax";
            this.lbFrequencyMax.Size = new System.Drawing.Size(0, 25);
            this.lbFrequencyMax.TabIndex = 5;
            // 
            // panelWaterFallGuide
            // 
            this.panelWaterFallGuide.Location = new System.Drawing.Point(9, 447);
            this.panelWaterFallGuide.Name = "panelWaterFallGuide";
            this.panelWaterFallGuide.Size = new System.Drawing.Size(36, 241);
            this.panelWaterFallGuide.TabIndex = 6;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(1715, 876);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(250, 76);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1715, 710);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "BitLength :";
            // 
            // tbBitLength
            // 
            this.tbBitLength.Location = new System.Drawing.Point(1840, 710);
            this.tbBitLength.Name = "tbBitLength";
            this.tbBitLength.Size = new System.Drawing.Size(100, 31);
            this.tbBitLength.TabIndex = 9;
            this.tbBitLength.Text = "32768";
            this.tbBitLength.TextChanged += new System.EventHandler(this.tbBitLength_TextChanged);
            // 
            // zoomIn
            // 
            this.zoomIn.Location = new System.Drawing.Point(1530, 710);
            this.zoomIn.Name = "zoomIn";
            this.zoomIn.Size = new System.Drawing.Size(71, 46);
            this.zoomIn.TabIndex = 10;
            this.zoomIn.Text = "+";
            this.zoomIn.UseVisualStyleBackColor = true;
            this.zoomIn.Click += new System.EventHandler(this.zoomIn_Click);
            // 
            // zoomOut
            // 
            this.zoomOut.Location = new System.Drawing.Point(1607, 710);
            this.zoomOut.Name = "zoomOut";
            this.zoomOut.Size = new System.Drawing.Size(73, 46);
            this.zoomOut.TabIndex = 11;
            this.zoomOut.Text = "-";
            this.zoomOut.UseVisualStyleBackColor = true;
            this.zoomOut.Click += new System.EventHandler(this.zoomOut_Click);
            // 
            // tbZoom
            // 
            this.tbZoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbZoom.Location = new System.Drawing.Point(1530, 762);
            this.tbZoom.Name = "tbZoom";
            this.tbZoom.Size = new System.Drawing.Size(71, 38);
            this.tbZoom.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1608, 762);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 49);
            this.button1.TabIndex = 13;
            this.button1.Text = "↵";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1715, 762);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "Byte :";
            // 
            // tbByte
            // 
            this.tbByte.Location = new System.Drawing.Point(1840, 756);
            this.tbByte.Name = "tbByte";
            this.tbByte.Size = new System.Drawing.Size(100, 31);
            this.tbByte.TabIndex = 9;
            this.tbByte.Text = "4096";
            this.tbByte.TextChanged += new System.EventHandler(this.tbByte_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1993, 964);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbZoom);
            this.Controls.Add(this.zoomOut);
            this.Controls.Add(this.zoomIn);
            this.Controls.Add(this.tbByte);
            this.Controls.Add(this.tbBitLength);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.panelWaterFallGuide);
            this.Controls.Add(this.lbFrequencyMax);
            this.Controls.Add(this.lbFrequectMin);
            this.Controls.Add(this.lbPowerMin);
            this.Controls.Add(this.lbPowerMax);
            this.Controls.Add(this.btnRandomData);
            this.Controls.Add(this.tbByteData);
            this.Controls.Add(this.tbBitData);
            this.Controls.Add(this.panelWaterFall);
            this.Controls.Add(this.panelMain);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelWaterFall;
        private System.Windows.Forms.TextBox tbBitData;
        private System.Windows.Forms.TextBox tbByteData;
        private System.Windows.Forms.Button btnRandomData;
        private System.Windows.Forms.Label lbPowerMax;
        private System.Windows.Forms.Label lbPowerMin;
        private System.Windows.Forms.Label lbFrequectMin;
        private System.Windows.Forms.Label lbFrequencyMax;
        private System.Windows.Forms.Panel panelWaterFallGuide;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbBitLength;
        private System.Windows.Forms.Button zoomIn;
        private System.Windows.Forms.Button zoomOut;
        private System.Windows.Forms.TextBox tbZoom;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbByte;
    }
}

