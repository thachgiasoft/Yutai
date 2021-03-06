﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ESRI.ArcGIS.Geometry;
using Yutai.ArcGIS.Common.Helpers;

namespace Yutai.ArcGIS.Controls.Controls
{
    partial class ZDomainControl
    {
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

       
        private void InitializeComponent()
        {
            this.label5 = new Label();
            this.label3 = new Label();
            this.label1 = new Label();
            this.textBoxPrecision = new TextEdit();
            this.textBoxMaxValue = new TextEdit();
            this.textBoxMinValue = new TextEdit();
            this.textBoxPrecision.Properties.BeginInit();
            this.textBoxMaxValue.Properties.BeginInit();
            this.textBoxMinValue.Properties.BeginInit();
            base.SuspendLayout();
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 68);
            this.label5.Name = "label5";
            this.label5.Size = new Size(29, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "精度";
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(160, 36);
            this.label3.Name = "label3";
            this.label3.Size = new Size(42, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "最大值";
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 36);
            this.label1.Name = "label1";
            this.label1.Size = new Size(42, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "最小值";
            this.textBoxPrecision.EditValue = "";
            this.textBoxPrecision.Location = new System.Drawing.Point(56, 64);
            this.textBoxPrecision.Name = "textBoxPrecision";
            this.textBoxPrecision.Size = new Size(88, 23);
            this.textBoxPrecision.TabIndex = 26;
            this.textBoxPrecision.TextChanged += new EventHandler(this.textBoxPrecision_TextChanged);
            this.textBoxMaxValue.EditValue = "";
            this.textBoxMaxValue.Location = new System.Drawing.Point(208, 32);
            this.textBoxMaxValue.Name = "textBoxMaxValue";
            this.textBoxMaxValue.Size = new Size(88, 23);
            this.textBoxMaxValue.TabIndex = 25;
            this.textBoxMaxValue.TextChanged += new EventHandler(this.textBoxMaxValue_TextChanged);
            this.textBoxMinValue.EditValue = "";
            this.textBoxMinValue.Location = new System.Drawing.Point(56, 32);
            this.textBoxMinValue.Name = "textBoxMinValue";
            this.textBoxMinValue.Size = new Size(88, 23);
            this.textBoxMinValue.TabIndex = 24;
            this.textBoxMinValue.TextChanged += new EventHandler(this.textBoxMinValue_TextChanged);
            base.Controls.Add(this.textBoxPrecision);
            base.Controls.Add(this.textBoxMaxValue);
            base.Controls.Add(this.textBoxMinValue);
            base.Controls.Add(this.label5);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.label1);
            base.Name = "ZDomainControl";
            base.Size = new Size(304, 336);
            base.Load += new EventHandler(this.ZDomainControl_Load);
            this.textBoxPrecision.Properties.EndInit();
            this.textBoxMaxValue.Properties.EndInit();
            this.textBoxMinValue.Properties.EndInit();
            base.ResumeLayout(false);
        }

       
        private Container components = null;
        private Label label1;
        private Label label3;
        private Label label5;
        private ISpatialReference m_pSpatialRefrence;
        private TextEdit textBoxMaxValue;
        private TextEdit textBoxMinValue;
        private TextEdit textBoxPrecision;
    }
}