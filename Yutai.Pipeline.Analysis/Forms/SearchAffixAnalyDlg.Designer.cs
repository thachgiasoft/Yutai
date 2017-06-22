﻿using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.SystemUI;
using stdole;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Yutai.PipeConfig;
using Yutai.Pipeline.Analysis.Classes;
using Yutai.Pipeline.Analysis.Helpers;
using Yutai.Plugins.Interfaces;

namespace Yutai.Pipeline.Analysis.Forms
{
	    partial class SearchAffixAnalyDlg
    {
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

	
	private void InitializeComponent()
		{
			this.RevBut = new Button();
			this.NoneBut = new Button();
			this.groupBox1 = new GroupBox();
			this.chkBoxSet = new CheckBox();
			this.txBoxY = new TextBox();
			this.label4 = new Label();
			this.label2 = new Label();
			this.txBoxX = new TextBox();
			this.label1 = new Label();
			this.LayerBox = new ComboBox();
			this.lable = new Label();
			this.AllBut = new Button();
			this.CloseBut = new Button();
			this.groupBox2 = new GroupBox();
			this.checAnaPipeline = new CheckBox();
			this.ValueBox = new CheckedListBox();
			this.label3 = new Label();
			this.txBoxRadius = new TextBox();
			this.btnAnalyse = new Button();
			this.checkReView = new CheckBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			base.SuspendLayout();
			this.RevBut.Location = new System.Drawing.Point(200, 163);
			this.RevBut.Name = "RevBut";
			this.RevBut.Size = new Size(76, 23);
			this.RevBut.TabIndex = 3;
			this.RevBut.Text = "反选(&I)";
			this.RevBut.UseVisualStyleBackColor = true;
			this.RevBut.Click += new EventHandler(this.RevBut_Click);
			this.NoneBut.Location = new System.Drawing.Point(200, 118);
			this.NoneBut.Name = "NoneBut";
			this.NoneBut.Size = new Size(76, 23);
			this.NoneBut.TabIndex = 2;
			this.NoneBut.Text = "全不选(&N)";
			this.NoneBut.UseVisualStyleBackColor = true;
			this.NoneBut.Click += new EventHandler(this.NoneBut_Click);
			this.groupBox1.Controls.Add(this.chkBoxSet);
			this.groupBox1.Controls.Add(this.txBoxY);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txBoxX);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(8, 233);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(298, 51);
			this.groupBox1.TabIndex = 12;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "查找设置";
			this.chkBoxSet.Appearance = Appearance.Button;
			this.chkBoxSet.AutoSize = true;
			this.chkBoxSet.Location = new System.Drawing.Point(237, 16);
			this.chkBoxSet.Name = "chkBoxSet";
			this.chkBoxSet.Size = new Size(39, 22);
			this.chkBoxSet.TabIndex = 4;
			this.chkBoxSet.Text = "设置";
			this.chkBoxSet.UseVisualStyleBackColor = true;
			this.txBoxY.Location = new System.Drawing.Point(129, 16);
			this.txBoxY.Name = "txBoxY";
			this.txBoxY.Size = new Size(72, 21);
			this.txBoxY.TabIndex = 3;
			this.txBoxY.TextChanged += new EventHandler(this.txBoxY_TextChanged);
			this.txBoxY.KeyPress += new KeyPressEventHandler(this.txBoxY_KeyPress);
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(128, 60);
			this.label4.Name = "label4";
			this.label4.Size = new Size(17, 12);
			this.label4.TabIndex = 20;
			this.label4.Text = "米";
			this.label4.Click += new EventHandler(this.label4_Click);
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(112, 20);
			this.label2.Name = "label2";
			this.label2.Size = new Size(17, 12);
			this.label2.TabIndex = 2;
			this.label2.Text = "Y:";
			this.txBoxX.Location = new System.Drawing.Point(32, 16);
			this.txBoxX.Name = "txBoxX";
			this.txBoxX.Size = new Size(74, 21);
			this.txBoxX.TabIndex = 1;
			this.txBoxX.KeyPress += new KeyPressEventHandler(this.txBoxX_KeyPress);
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(11, 20);
			this.label1.Name = "label1";
			this.label1.Size = new Size(17, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "X:";
			this.LayerBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.LayerBox.FormattingEnabled = true;
			this.LayerBox.Location = new System.Drawing.Point(56, 18);
			this.LayerBox.Name = "LayerBox";
			this.LayerBox.Size = new Size(148, 20);
			this.LayerBox.TabIndex = 17;
			this.LayerBox.SelectedIndexChanged += new EventHandler(this.LayerBox_SelectedIndexChanged);
			this.lable.AutoSize = true;
			this.lable.Location = new System.Drawing.Point(6, 22);
			this.lable.Name = "lable";
			this.lable.Size = new Size(41, 12);
			this.lable.TabIndex = 16;
			this.lable.Text = "管点层";
			this.AllBut.Location = new System.Drawing.Point(200, 73);
			this.AllBut.Name = "AllBut";
			this.AllBut.Size = new Size(76, 23);
			this.AllBut.TabIndex = 1;
			this.AllBut.Text = "全选(&A)";
			this.AllBut.UseVisualStyleBackColor = true;
			this.AllBut.Click += new EventHandler(this.AllBut_Click);
			this.CloseBut.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CloseBut.Location = new System.Drawing.Point(224, 292);
			this.CloseBut.Name = "CloseBut";
			this.CloseBut.Size = new Size(60, 23);
			this.CloseBut.TabIndex = 15;
			this.CloseBut.Text = "关闭(&C)";
			this.CloseBut.UseVisualStyleBackColor = true;
			this.CloseBut.Click += new EventHandler(this.CloseBut_Click);
			this.groupBox2.Controls.Add(this.checAnaPipeline);
			this.groupBox2.Controls.Add(this.RevBut);
			this.groupBox2.Controls.Add(this.NoneBut);
			this.groupBox2.Controls.Add(this.AllBut);
			this.groupBox2.Controls.Add(this.ValueBox);
			this.groupBox2.Controls.Add(this.LayerBox);
			this.groupBox2.Controls.Add(this.lable);
			this.groupBox2.Location = new System.Drawing.Point(8, 1);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new Size(298, 226);
			this.groupBox2.TabIndex = 13;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "选择查找对象";
			this.groupBox2.Enter += new EventHandler(this.groupBox2_Enter);
			this.checAnaPipeline.AutoSize = true;
			this.checAnaPipeline.Checked = true;
			this.checAnaPipeline.CheckState = CheckState.Checked;
			this.checAnaPipeline.Location = new System.Drawing.Point(216, 17);
			this.checAnaPipeline.Name = "checAnaPipeline";
			this.checAnaPipeline.Size = new Size(72, 16);
			this.checAnaPipeline.TabIndex = 18;
			this.checAnaPipeline.Text = "分析管线";
			this.checAnaPipeline.UseVisualStyleBackColor = true;
			this.ValueBox.CheckOnClick = true;
			this.ValueBox.FormattingEnabled = true;
			this.ValueBox.Items.AddRange(new object[]
			{
				"sdfsfsfs",
				"sdsdf",
				"sfdsdf"
			});
			this.ValueBox.Location = new System.Drawing.Point(13, 53);
			this.ValueBox.Name = "ValueBox";
			this.ValueBox.Size = new Size(166, 164);
			this.ValueBox.Sorted = true;
			this.ValueBox.TabIndex = 0;
			this.ValueBox.SelectedIndexChanged += new EventHandler(this.ValueBox_SelectedIndexChanged);
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(20, 296);
			this.label3.Name = "label3";
			this.label3.Size = new Size(65, 12);
			this.label3.TabIndex = 18;
			this.label3.Text = "查找半径：";
			this.txBoxRadius.Location = new System.Drawing.Point(86, 293);
			this.txBoxRadius.Name = "txBoxRadius";
			this.txBoxRadius.Size = new Size(123, 21);
			this.txBoxRadius.TabIndex = 19;
			this.txBoxRadius.Text = "50";
			this.txBoxRadius.KeyPress += new KeyPressEventHandler(this.txBoxRadius_KeyPress);
			this.btnAnalyse.Location = new System.Drawing.Point(224, 320);
			this.btnAnalyse.Name = "btnAnalyse";
			this.btnAnalyse.Size = new Size(60, 23);
			this.btnAnalyse.TabIndex = 22;
			this.btnAnalyse.Text = "分析(&A)";
			this.btnAnalyse.UseVisualStyleBackColor = true;
			this.btnAnalyse.Click += new EventHandler(this.btnAnalyse_Click);
			this.checkReView.AutoSize = true;
			this.checkReView.Checked = true;
			this.checkReView.CheckState = CheckState.Checked;
			this.checkReView.Location = new System.Drawing.Point(21, 323);
			this.checkReView.Name = "checkReView";
			this.checkReView.Size = new Size(120, 16);
			this.checkReView.TabIndex = 24;
			this.checkReView.Text = "关闭清除分析结果";
			this.checkReView.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new Size(309, 347);
			base.Controls.Add(this.checkReView);
			base.Controls.Add(this.btnAnalyse);
			base.Controls.Add(this.txBoxRadius);
			base.Controls.Add(this.CloseBut);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.groupBox2);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "SearchAffixAnalyDlg";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			this.Text = "设施搜索";
			base.TopMost = true;
			base.FormClosing += new FormClosingEventHandler(this.SearchAffixAnalyDlg_FormClosing);
			base.Load += new EventHandler(this.SearchAffixAnalyDlg_Load);
			base.HelpRequested += new HelpEventHandler(this.SearchAffixAnalyDlg_HelpRequested);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	
		private IFeatureLayer ifeatureLayer_0;
		private IFields ifields_0;
		private string string_0;
		private IField ifield_0;
		private Button RevBut;
		private Button NoneBut;
		private GroupBox groupBox1;
		private ComboBox LayerBox;
		private Label lable;
		private Button AllBut;
		private Button CloseBut;
		private GroupBox groupBox2;
		private CheckedListBox ValueBox;
		private TextBox txBoxY;
		private Label label2;
		private TextBox txBoxX;
		private Label label1;
		private Label label3;
		private TextBox txBoxRadius;
		private Label label4;
		private Button btnAnalyse;
		private CheckBox chkBoxSet;
		private CheckBox checkReView;
		private CheckBox checAnaPipeline;
    }
}