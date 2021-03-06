﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using Yutai.Shared;

namespace Yutai.ArcGIS.Catalog.Geodatabase.UI
{
    partial class frmCreateTopologySet
    {
        protected override void Dispose(bool bool_0)
        {
            if (bool_0 && (this.container_0 != null))
            {
                this.container_0.Dispose();
            }
            base.Dispose(bool_0);
        }

       
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreateTopologySet));
            this.chkListBoxFeatureClass = new CheckedListBox();
            this.lblTopoName = new Label();
            this.txtTopologyName = new TextBox();
            this.lblLimit = new Label();
            this.txtLimiteValue = new TextBox();
            this.lblSelFeatureClass = new Label();
            this.listRule = new ListView();
            this.groupBox1 = new GroupBox();
            this.btnPrevious = new Button();
            this.btnNext = new Button();
            this.btnCancel = new Button();
            this.lblRule = new Label();
            this.btnSelectAllFeatureClass = new Button();
            this.btnClearAllFeatureClass = new Button();
            this.btnAddRule = new Button();
            this.btnClearRule = new Button();
            this.btnClearAllRule = new Button();
            this.lblUnit = new Label();
            this.lblPriRang = new Label();
            this.txtMaxPri = new TextBox();
            this.lblPri = new Label();
            this.btnZ = new Button();
            this.listViewPri = new ListView();
            this.btnAddRule1 = new Button();
            base.SuspendLayout();
            this.chkListBoxFeatureClass.Location = new System.Drawing.Point(8, 40);
            this.chkListBoxFeatureClass.Name = "chkListBoxFeatureClass";
            this.chkListBoxFeatureClass.Size = new Size(288, 228);
            this.chkListBoxFeatureClass.TabIndex = 0;
            this.chkListBoxFeatureClass.ThreeDCheckBoxes = true;
            this.chkListBoxFeatureClass.Visible = false;
            this.chkListBoxFeatureClass.SelectedIndexChanged += new EventHandler(this.chkListBoxFeatureClass_SelectedIndexChanged);
            this.chkListBoxFeatureClass.ItemCheck += new ItemCheckEventHandler(this.chkListBoxFeatureClass_ItemCheck);
            this.chkListBoxFeatureClass.SelectedValueChanged += new EventHandler(this.chkListBoxFeatureClass_SelectedValueChanged);
            this.lblTopoName.AutoSize = true;
            this.lblTopoName.Location = new System.Drawing.Point(8, 16);
            this.lblTopoName.Name = "lblTopoName";
            this.lblTopoName.Size = new Size(77, 12);
            this.lblTopoName.TabIndex = 1;
            this.lblTopoName.Text = "拓扑关系名称";
            this.txtTopologyName.Location = new System.Drawing.Point(96, 8);
            this.txtTopologyName.Name = "txtTopologyName";
            this.txtTopologyName.Size = new Size(184, 21);
            this.txtTopologyName.TabIndex = 2;
            this.txtTopologyName.KeyPress += new KeyPressEventHandler(this.txtTopologyName_KeyPress);
            this.lblLimit.AutoSize = true;
            this.lblLimit.Location = new System.Drawing.Point(16, 48);
            this.lblLimit.Name = "lblLimit";
            this.lblLimit.Size = new Size(41, 12);
            this.lblLimit.TabIndex = 3;
            this.lblLimit.Text = "容限值";
            this.txtLimiteValue.Location = new System.Drawing.Point(96, 40);
            this.txtLimiteValue.Name = "txtLimiteValue";
            this.txtLimiteValue.Size = new Size(104, 21);
            this.txtLimiteValue.TabIndex = 4;
            this.txtLimiteValue.KeyPress += new KeyPressEventHandler(this.txtLimiteValue_KeyPress);
            this.txtLimiteValue.TextChanged += new EventHandler(this.txtLimiteValue_TextChanged);
            this.lblSelFeatureClass.AutoSize = true;
            this.lblSelFeatureClass.Location = new System.Drawing.Point(8, 8);
            this.lblSelFeatureClass.Name = "lblSelFeatureClass";
            this.lblSelFeatureClass.Size = new Size(161, 12);
            this.lblSelFeatureClass.TabIndex = 5;
            this.lblSelFeatureClass.Text = "选择要参与拓扑关系的要素类";
            this.lblSelFeatureClass.Visible = false;
            this.listRule.Location = new System.Drawing.Point(8, 40);
            this.listRule.Name = "listRule";
            this.listRule.Size = new Size(320, 240);
            this.listRule.TabIndex = 6;
            this.listRule.UseCompatibleStateImageBehavior = false;
            this.listRule.View = View.Details;
            this.listRule.Visible = false;
            this.listRule.SelectedIndexChanged += new EventHandler(this.listRule_SelectedIndexChanged);
            this.groupBox1.Location = new System.Drawing.Point(8, 288);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(384, 8);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.btnPrevious.Location = new System.Drawing.Point(160, 312);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new Size(72, 24);
            this.btnPrevious.TabIndex = 8;
            this.btnPrevious.Text = "<上一步";
            this.btnPrevious.Click += new EventHandler(this.btnPrevious_Click);
            this.btnNext.Location = new System.Drawing.Point(248, 312);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new Size(64, 24);
            this.btnNext.TabIndex = 9;
            this.btnNext.Text = "下一步>";
            this.btnNext.Click += new EventHandler(this.btnNext_Click);
            this.btnCancel.Location = new System.Drawing.Point(328, 312);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(64, 24);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            this.lblRule.AutoSize = true;
            this.lblRule.Location = new System.Drawing.Point(16, 8);
            this.lblRule.Name = "lblRule";
            this.lblRule.Size = new Size(77, 12);
            this.lblRule.TabIndex = 11;
            this.lblRule.Text = "定义拓扑规则";
            this.lblRule.Visible = false;
            this.btnSelectAllFeatureClass.Location = new System.Drawing.Point(320, 72);
            this.btnSelectAllFeatureClass.Name = "btnSelectAllFeatureClass";
            this.btnSelectAllFeatureClass.Size = new Size(64, 24);
            this.btnSelectAllFeatureClass.TabIndex = 12;
            this.btnSelectAllFeatureClass.Text = "全选";
            this.btnSelectAllFeatureClass.Visible = false;
            this.btnSelectAllFeatureClass.Click += new EventHandler(this.btnSelectAllFeatureClass_Click);
            this.btnClearAllFeatureClass.Location = new System.Drawing.Point(320, 104);
            this.btnClearAllFeatureClass.Name = "btnClearAllFeatureClass";
            this.btnClearAllFeatureClass.Size = new Size(64, 24);
            this.btnClearAllFeatureClass.TabIndex = 13;
            this.btnClearAllFeatureClass.Text = "全部清除";
            this.btnClearAllFeatureClass.Visible = false;
            this.btnClearAllFeatureClass.Click += new EventHandler(this.btnClearAllFeatureClass_Click);
            this.btnAddRule.Location = new System.Drawing.Point(336, 40);
            this.btnAddRule.Name = "btnAddRule";
            this.btnAddRule.Size = new Size(118, 24);
            this.btnAddRule.TabIndex = 14;
            this.btnAddRule.Text = "由要素类添加规则";
            this.btnAddRule.Visible = false;
            this.btnAddRule.Click += new EventHandler(this.btnAddRule_Click);
            this.btnClearRule.Location = new System.Drawing.Point(336, 72);
            this.btnClearRule.Name = "btnClearRule";
            this.btnClearRule.Size = new Size(118, 24);
            this.btnClearRule.TabIndex = 15;
            this.btnClearRule.Text = "删除";
            this.btnClearRule.Visible = false;
            this.btnClearRule.Click += new EventHandler(this.btnClearRule_Click);
            this.btnClearAllRule.Location = new System.Drawing.Point(336, 104);
            this.btnClearAllRule.Name = "btnClearAllRule";
            this.btnClearAllRule.Size = new Size(118, 24);
            this.btnClearAllRule.TabIndex = 16;
            this.btnClearAllRule.Text = "删除全部";
            this.btnClearAllRule.Visible = false;
            this.lblUnit.Location = new System.Drawing.Point(216, 40);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new Size(88, 16);
            this.lblUnit.TabIndex = 17;
            this.lblPriRang.AutoSize = true;
            this.lblPriRang.Location = new System.Drawing.Point(8, 8);
            this.lblPriRang.Name = "lblPriRang";
            this.lblPriRang.Size = new Size(137, 12);
            this.lblPriRang.TabIndex = 18;
            this.lblPriRang.Text = "输入优先级的数字(1-50)";
            this.txtMaxPri.Location = new System.Drawing.Point(168, 8);
            this.txtMaxPri.Name = "txtMaxPri";
            this.txtMaxPri.Size = new Size(80, 21);
            this.txtMaxPri.TabIndex = 19;
            this.txtMaxPri.Text = "5";
            this.txtMaxPri.TextChanged += new EventHandler(this.txtMaxPri_TextChanged);
            this.lblPri.AutoSize = true;
            this.lblPri.Location = new System.Drawing.Point(16, 40);
            this.lblPri.Name = "lblPri";
            this.lblPri.Size = new Size(197, 12);
            this.lblPri.TabIndex = 20;
            this.lblPri.Text = "点击优先级列，输入要素类的优先级";
            this.btnZ.Location = new System.Drawing.Point(256, 8);
            this.btnZ.Name = "btnZ";
            this.btnZ.Size = new Size(72, 24);
            this.btnZ.TabIndex = 21;
            this.btnZ.Text = "Z属性";
            this.btnZ.Visible = false;
            this.listViewPri.Location = new System.Drawing.Point(8, 40);
            this.listViewPri.Name = "listViewPri";
            this.listViewPri.Size = new Size(320, 240);
            this.listViewPri.TabIndex = 22;
            this.listViewPri.UseCompatibleStateImageBehavior = false;
            this.listViewPri.View = View.Details;
            this.listViewPri.MouseDown += new MouseEventHandler(this.listViewPri_MouseDown);
            this.listViewPri.Click += new EventHandler(this.listViewPri_Click);
            this.btnAddRule1.Location = new System.Drawing.Point(334, 146);
            this.btnAddRule1.Name = "btnAddRule1";
            this.btnAddRule1.Size = new Size(120, 24);
            this.btnAddRule1.TabIndex = 23;
            this.btnAddRule1.Text = "添加规则";
            this.btnAddRule1.Visible = false;
            this.btnAddRule1.Click += new EventHandler(this.btnAddRule1_Click);
            this.AutoScaleBaseSize = new Size(6, 14);
            base.ClientSize = new Size(455, 349);
            base.Controls.Add(this.btnAddRule1);
            base.Controls.Add(this.listViewPri);
            base.Controls.Add(this.btnZ);
            base.Controls.Add(this.lblPri);
            base.Controls.Add(this.txtMaxPri);
            base.Controls.Add(this.lblPriRang);
            base.Controls.Add(this.lblUnit);
            base.Controls.Add(this.btnClearAllRule);
            base.Controls.Add(this.btnClearRule);
            base.Controls.Add(this.btnAddRule);
            base.Controls.Add(this.btnClearAllFeatureClass);
            base.Controls.Add(this.btnSelectAllFeatureClass);
            base.Controls.Add(this.lblRule);
            base.Controls.Add(this.lblSelFeatureClass);
            base.Controls.Add(this.txtLimiteValue);
            base.Controls.Add(this.lblLimit);
            base.Controls.Add(this.txtTopologyName);
            base.Controls.Add(this.lblTopoName);
            base.Controls.Add(this.btnCancel);
            base.Controls.Add(this.btnNext);
            base.Controls.Add(this.btnPrevious);
            base.Controls.Add(this.groupBox1);
            base.Controls.Add(this.listRule);
            base.Controls.Add(this.chkListBoxFeatureClass);
            
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmCreateTopologySet";
            this.Text = "新建拓扑设置";
            base.Load += new EventHandler(this.frmCreateTopologySet_Load);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

       
        private Button btnAddRule;
        private Button btnAddRule1;
        private Button btnCancel;
        private Button btnClearAllFeatureClass;
        private Button btnClearAllRule;
        private Button btnClearRule;
        private Button btnNext;
        private Button btnPrevious;
        private Button btnSelectAllFeatureClass;
        private Button btnZ;
        private CheckedListBox chkListBoxFeatureClass;
        private GroupBox groupBox1;
        private int int_1;
        private Label lblLimit;
        private Label lblPri;
        private Label lblPriRang;
        private Label lblRule;
        private Label lblSelFeatureClass;
        private Label lblTopoName;
        private Label lblUnit;
        private ListView listRule;
        private ListView listViewPri;
        private TextBox txtLimiteValue;
        private TextBox txtMaxPri;
        private TextBox txtTopologyName;
    }
}