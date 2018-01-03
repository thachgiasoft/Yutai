﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using Yutai.ArcGIS.Common;
using Yutai.ArcGIS.Common.BaseClasses;
using Array = System.Array;

namespace Yutai.ArcGIS.Carto.MapCartoTemplateLib
{
    partial class CustomLegendConfigPage
    {
        protected override void Dispose(bool bool_2)
        {
            if (bool_2 && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(bool_2);
        }

       
 private void InitializeComponent()
        {
            this.components = new Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomLegendConfigPage));
            this.txtLegend = new TextBox();
            this.labPoint = new Label();
            this.btnDele = new Button();
            this.butNewRow = new Button();
            this.imageList_0 = new ImageList(this.components);
            this.txtColumnNum = new TextBox();
            this.label1 = new Label();
            this.groupBox1 = new GroupBox();
            this.btnEdit = new Button();
            this.btnDeleteAll = new Button();
            this.btnMoveDown = new Button();
            this.btnMoveUp = new Button();
            this.chkItemHasBorder = new CheckBox();
            this.label8 = new Label();
            this.txtLabelSpace = new TextBox();
            this.label7 = new Label();
            this.label6 = new Label();
            this.label5 = new Label();
            this.txtHeight = new TextBox();
            this.label4 = new Label();
            this.txtWidth = new TextBox();
            this.label3 = new Label();
            this.renderInfoListView1 = new RenderInfoListView();
            this.columnHeader_0 = new ColumnHeader();
            this.columnHeader_1 = new ColumnHeader();
            this.txtRowSpace = new TextBox();
            this.label2 = new Label();
            this.chkHasBorder = new CheckBox();
            this.txtColumnSpace = new TextBox();
            this.label9 = new Label();
            this.button1 = new Button();
            this.button2 = new Button();
            this.label10 = new Label();
            this.label11 = new Label();
            this.btnOpen = new Button();
            this.chkDrawTable = new CheckBox();
            this.groupBox1.SuspendLayout();
            base.SuspendLayout();
            this.txtLegend.Location = new Point(67, 6);
            this.txtLegend.Name = "txtLegend";
            this.txtLegend.Size = new Size(301, 21);
            this.txtLegend.TabIndex = 34;
            this.txtLegend.TextChanged += new EventHandler(this.txtColumnSpace_TextChanged);
            this.labPoint.AutoSize = true;
            this.labPoint.Location = new Point(7, 9);
            this.labPoint.Name = "labPoint";
            this.labPoint.Size = new Size(59, 12);
            this.labPoint.TabIndex = 37;
            this.labPoint.Text = "图例标题:";
            this.btnDele.Location = new Point(160, 146);
            this.btnDele.Name = "btnDele";
            this.btnDele.Size = new Size(70, 23);
            this.btnDele.TabIndex = 43;
            this.btnDele.Text = "删除";
            this.btnDele.UseVisualStyleBackColor = true;
            this.btnDele.Click += new EventHandler(this.btnDele_Click);
            this.butNewRow.Location = new Point(8, 146);
            this.butNewRow.Name = "butNewRow";
            this.butNewRow.Size = new Size(70, 23);
            this.butNewRow.TabIndex = 44;
            this.butNewRow.Text = "添加";
            this.butNewRow.UseVisualStyleBackColor = true;
            this.butNewRow.Click += new EventHandler(this.butNewRow_Click);
            this.imageList_0.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            this.imageList_0.TransparentColor = Color.Transparent;
            this.imageList_0.Images.SetKeyName(0, "Buffer.ico");
            this.txtColumnNum.Location = new Point(67, 30);
            this.txtColumnNum.Name = "txtColumnNum";
            this.txtColumnNum.Size = new Size(117, 21);
            this.txtColumnNum.TabIndex = 49;
            this.txtColumnNum.TextChanged += new EventHandler(this.txtColumnSpace_TextChanged);
            this.label1.AutoSize = true;
            this.label1.Location = new Point(7, 33);
            this.label1.Name = "label1";
            this.label1.Size = new Size(59, 12);
            this.label1.TabIndex = 50;
            this.label1.Text = "图例列数:";
            this.groupBox1.Controls.Add(this.chkDrawTable);
            this.groupBox1.Controls.Add(this.btnEdit);
            this.groupBox1.Controls.Add(this.btnDeleteAll);
            this.groupBox1.Controls.Add(this.btnMoveDown);
            this.groupBox1.Controls.Add(this.btnMoveUp);
            this.groupBox1.Controls.Add(this.chkItemHasBorder);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtLabelSpace);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtHeight);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtWidth);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.renderInfoListView1);
            this.groupBox1.Controls.Add(this.butNewRow);
            this.groupBox1.Controls.Add(this.btnDele);
            this.groupBox1.Location = new Point(9, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(359, 177);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "图例项信息";
            this.btnEdit.Location = new Point(84, 146);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new Size(70, 23);
            this.btnEdit.TabIndex = 67;
            this.btnEdit.Text = "编辑";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new EventHandler(this.btnEdit_Click);
            this.btnDeleteAll.Location = new Point(230, 146);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new Size(69, 24);
            this.btnDeleteAll.TabIndex = 66;
            this.btnDeleteAll.Text = "删除全部";
            this.btnDeleteAll.Click += new EventHandler(this.btnDeleteAll_Click);
            this.btnMoveDown.Enabled = false;
            this.btnMoveDown.Image = (System.Drawing.Image)resources.GetObject("btnMoveDown.Image");
            this.btnMoveDown.Location = new Point(305, 94);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new Size(24, 24);
            this.btnMoveDown.TabIndex = 65;
            this.btnMoveDown.Click += new EventHandler(this.btnMoveDown_Click);
            this.btnMoveUp.Enabled = false;
            this.btnMoveUp.Image = (System.Drawing.Image)resources.GetObject("btnMoveUp.Image");
            this.btnMoveUp.Location = new Point(305, 64);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new Size(24, 24);
            this.btnMoveUp.TabIndex = 64;
            this.btnMoveUp.Text = "z";
            this.btnMoveUp.Click += new EventHandler(this.btnMoveUp_Click);
            this.chkItemHasBorder.AutoSize = true;
            this.chkItemHasBorder.Location = new Point(228, 42);
            this.chkItemHasBorder.Name = "chkItemHasBorder";
            this.chkItemHasBorder.Size = new Size(72, 16);
            this.chkItemHasBorder.TabIndex = 63;
            this.chkItemHasBorder.Text = "添加边框";
            this.chkItemHasBorder.UseVisualStyleBackColor = true;
            this.chkItemHasBorder.CheckedChanged += new EventHandler(this.chkItemHasBorder_CheckedChanged);
            this.label8.AutoSize = true;
            this.label8.Location = new Point(189, 43);
            this.label8.Name = "label8";
            this.label8.Size = new Size(29, 12);
            this.label8.TabIndex = 62;
            this.label8.Text = "厘米";
            this.txtLabelSpace.Location = new Point(99, 40);
            this.txtLabelSpace.Name = "txtLabelSpace";
            this.txtLabelSpace.Size = new Size(84, 21);
            this.txtLabelSpace.TabIndex = 60;
            this.txtLabelSpace.TextChanged += new EventHandler(this.txtColumnSpace_TextChanged);
            this.label7.AutoSize = true;
            this.label7.Location = new Point(6, 43);
            this.label7.Name = "label7";
            this.label7.Size = new Size(89, 12);
            this.label7.TabIndex = 61;
            this.label7.Text = "符号与说明间距";
            this.label6.AutoSize = true;
            this.label6.Location = new Point(232, 17);
            this.label6.Name = "label6";
            this.label6.Size = new Size(29, 12);
            this.label6.TabIndex = 59;
            this.label6.Text = "厘米";
            this.label5.AutoSize = true;
            this.label5.Location = new Point(97, 17);
            this.label5.Name = "label5";
            this.label5.Size = new Size(29, 12);
            this.label5.TabIndex = 58;
            this.label5.Text = "厘米";
            this.txtHeight.Location = new Point(161, 14);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new Size(65, 21);
            this.txtHeight.TabIndex = 56;
            this.txtHeight.TextChanged += new EventHandler(this.txtColumnSpace_TextChanged);
            this.label4.AutoSize = true;
            this.label4.Location = new Point(132, 17);
            this.label4.Name = "label4";
            this.label4.Size = new Size(23, 12);
            this.label4.TabIndex = 57;
            this.label4.Text = "高:";
            this.txtWidth.Location = new Point(35, 14);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new Size(60, 21);
            this.txtWidth.TabIndex = 54;
            this.txtWidth.TextChanged += new EventHandler(this.txtColumnSpace_TextChanged);
            this.label3.AutoSize = true;
            this.label3.Location = new Point(6, 17);
            this.label3.Name = "label3";
            this.label3.Size = new Size(23, 12);
            this.label3.TabIndex = 55;
            this.label3.Text = "宽:";
            this.renderInfoListView1.Columns.AddRange(new ColumnHeader[] { this.columnHeader_0, this.columnHeader_1 });
            this.renderInfoListView1.FullRowSelect = true;
            this.renderInfoListView1.Location = new Point(7, 64);
            this.renderInfoListView1.Name = "renderInfoListView1";
            this.renderInfoListView1.Size = new Size(292, 78);
            this.renderInfoListView1.TabIndex = 48;
            this.renderInfoListView1.UseCompatibleStateImageBehavior = false;
            this.renderInfoListView1.View = View.Details;
            this.renderInfoListView1.SelectedIndexChanged += new EventHandler(this.renderInfoListView1_SelectedIndexChanged);
            this.renderInfoListView1.OnValueChanged += new RenderInfoListView.OnValueChangedHandler(this.method_12);
            this.columnHeader_0.Text = "图例项符号";
            this.columnHeader_0.Width = 110;
            this.columnHeader_1.Text = "图例项说明";
            this.columnHeader_1.Width = 132;
            this.txtRowSpace.Location = new Point(67, 55);
            this.txtRowSpace.Name = "txtRowSpace";
            this.txtRowSpace.Size = new Size(84, 21);
            this.txtRowSpace.TabIndex = 52;
            this.txtRowSpace.TextChanged += new EventHandler(this.txtColumnSpace_TextChanged);
            this.label2.AutoSize = true;
            this.label2.Location = new Point(7, 58);
            this.label2.Name = "label2";
            this.label2.Size = new Size(47, 12);
            this.label2.TabIndex = 53;
            this.label2.Text = "行间距:";
            this.chkHasBorder.AutoSize = true;
            this.chkHasBorder.Location = new Point(218, 29);
            this.chkHasBorder.Name = "chkHasBorder";
            this.chkHasBorder.Size = new Size(120, 16);
            this.chkHasBorder.TabIndex = 64;
            this.chkHasBorder.Text = "图例是否添加边框";
            this.chkHasBorder.UseVisualStyleBackColor = true;
            this.chkHasBorder.CheckedChanged += new EventHandler(this.chkHasBorder_CheckedChanged);
            this.txtColumnSpace.Location = new Point(258, 55);
            this.txtColumnSpace.Name = "txtColumnSpace";
            this.txtColumnSpace.Size = new Size(75, 21);
            this.txtColumnSpace.TabIndex = 65;
            this.txtColumnSpace.TextChanged += new EventHandler(this.txtColumnSpace_TextChanged);
            this.label9.AutoSize = true;
            this.label9.Location = new Point(198, 58);
            this.label9.Name = "label9";
            this.label9.Size = new Size(47, 12);
            this.label9.TabIndex = 66;
            this.label9.Text = "列间距:";
            this.button1.Location = new Point(17, 263);
            this.button1.Name = "button1";
            this.button1.Size = new Size(70, 23);
            this.button1.TabIndex = 68;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new Point(298, 371);
            this.button2.Name = "button2";
            this.button2.Size = new Size(70, 23);
            this.button2.TabIndex = 67;
            this.button2.Text = "关闭";
            this.button2.UseVisualStyleBackColor = true;
            this.label10.AutoSize = true;
            this.label10.Location = new Point(155, 58);
            this.label10.Name = "label10";
            this.label10.Size = new Size(29, 12);
            this.label10.TabIndex = 69;
            this.label10.Text = "厘米";
            this.label11.AutoSize = true;
            this.label11.Location = new Point(339, 58);
            this.label11.Name = "label11";
            this.label11.Size = new Size(29, 12);
            this.label11.TabIndex = 70;
            this.label11.Text = "厘米";
            this.btnOpen.Location = new Point(286, 263);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new Size(70, 23);
            this.btnOpen.TabIndex = 71;
            this.btnOpen.Text = "加载";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new EventHandler(this.btnOpen_Click);
            this.chkDrawTable.AutoSize = true;
            this.chkDrawTable.Location = new Point(263, 16);
            this.chkDrawTable.Name = "chkDrawTable";
            this.chkDrawTable.Size = new Size(72, 16);
            this.chkDrawTable.TabIndex = 68;
            this.chkDrawTable.Text = "绘制网格";
            this.chkDrawTable.UseVisualStyleBackColor = true;
            this.chkDrawTable.CheckedChanged += new EventHandler(this.chkDrawTable_CheckedChanged);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.Controls.Add(this.btnOpen);
            base.Controls.Add(this.label11);
            base.Controls.Add(this.label10);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.button2);
            base.Controls.Add(this.txtColumnSpace);
            base.Controls.Add(this.label9);
            base.Controls.Add(this.chkHasBorder);
            base.Controls.Add(this.txtRowSpace);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.groupBox1);
            base.Controls.Add(this.txtColumnNum);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.txtLegend);
            base.Controls.Add(this.labPoint);
            base.Name = "CustomLegendConfigPage";
            base.Size = new Size(381, 308);
            base.Load += new EventHandler(this.CustomLegendConfigPage_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        void IPropertyPage.Hide()
        {
            base.Hide();
        }

       
        private Button btnDele;
        private Button btnDeleteAll;
        private Button btnEdit;
        private Button btnMoveDown;
        private Button btnMoveUp;
        private Button btnOpen;
        private Button butNewRow;
        private Button button1;
        private Button button2;
        private CheckBox chkDrawTable;
        private CheckBox chkHasBorder;
        private CheckBox chkItemHasBorder;
        private ColumnHeader columnHeader_0;
        private ColumnHeader columnHeader_1;
        private GroupBox groupBox1;
        private ImageList imageList_0;
        private Label label1;
        private Label label10;
        private Label label11;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label labPoint;
        private MapCartoTemplateLib.MapTemplateElement mapTemplateElement_0;
        private RenderInfoListView renderInfoListView1;
        private TextBox txtColumnNum;
        private TextBox txtColumnSpace;
        private TextBox txtHeight;
        private TextBox txtLabelSpace;
        private TextBox txtLegend;
        private TextBox txtRowSpace;
        private TextBox txtWidth;
    }
}