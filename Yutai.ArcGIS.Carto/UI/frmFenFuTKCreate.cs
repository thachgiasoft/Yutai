﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using Yutai.ArcGIS.Carto.DesignLib;

namespace Yutai.ArcGIS.Carto.UI
{
    internal class frmFenFuTKCreate : Form
    {
        private Button btnClose;
        private Button btnCoord;
        private Button btnSave;
        private Button btnSavee;
        private CheckBox chkLenged;
        private ComboBox cmbScale;
        public string connectStr = "";
        private FenFuMapClass fenFuMapClass_0 = new FenFuMapClass();
        private GroupBox groupBox1;
        private GroupBox groupBox10;
        private GroupBox groupBox11;
        private GroupBox groupBox12;
        private GroupBox groupBox14;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private GroupBox groupBox6;
        private GroupBox groupBox7;
        private GroupBox groupBox8;
        private GroupBox groupBox9;
        private IActiveView iactiveView_0 = null;
        private IContainer icontainer_0 = null;
        private Label lblLLowX;
        private Label lblLLowY;
        private Label lblLUpX;
        private Label lblLUpY;
        private Label lblRLowX;
        private Label lblRLowY;
        private Label lblRUpX;
        private Label lblRUpY;
        public string styleFile = "";
        private TextBox txtLeftLowTxt;
        private TextBox txtLeftLowX;
        private TextBox txtLeftLowY;
        private TextBox txtLeftUpX;
        private TextBox txtLeftUpY;
        private TextBox txtR1C1;
        private TextBox txtR1C2;
        private TextBox txtR1C3;
        private TextBox txtR2C1;
        private TextBox txtR2C2;
        private TextBox txtR2C3;
        private TextBox txtR3C1;
        private TextBox txtR3C2;
        private TextBox txtR3C3;
        private TextBox txtRightLowTxt;
        private TextBox txtRightLowX;
        private TextBox txtRightLowY;
        private TextBox txtRightUpTxt;
        private TextBox txtRightUpX;
        private TextBox txtRightUpY;
        private TextBox txtTH;
        private TextBox txtTM;
        private TextBox txtZTDW;

        public frmFenFuTKCreate()
        {
            this.InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.fenFuMapClass_0 = null;
            base.Close();
        }

        private void btnCoord_Click(object sender, EventArgs e)
        {
            if (this.txtTH.Text.Trim() == "")
            {
                MessageBox.Show("请先输入图幅号");
            }
            else
            {
                IList<IPoint> list = null;
                IPoint point = null;
                THTools tools = null;
                if (this.txtTH.Text.Trim() != "")
                {
                    tools = new THTools();
                    bool flag = false;
                    list = tools.GetProjectCoord(this.txtTH.Text.Trim(), true, true, 0, ref flag);
                    if (flag)
                    {
                        if ((list != null) && (list.Count == 4))
                        {
                            point = list[0];
                            if (!point.IsEmpty)
                            {
                                this.txtLeftUpX.Text = point.Y.ToString();
                                this.txtLeftUpY.Text = point.X.ToString();
                            }
                            point = list[1];
                            if (!point.IsEmpty)
                            {
                                this.txtRightUpX.Text = point.Y.ToString();
                                this.txtRightUpY.Text = point.X.ToString();
                            }
                            point = list[2];
                            if (!point.IsEmpty)
                            {
                                this.txtRightLowX.Text = point.Y.ToString();
                                this.txtRightLowY.Text = point.X.ToString();
                            }
                            point = list[3];
                            if (!point.IsEmpty)
                            {
                                this.txtLeftLowX.Text = point.Y.ToString();
                                this.txtLeftLowY.Text = point.X.ToString();
                            }
                        }
                        else
                        {
                            MessageBox.Show("请检查图幅号是否正确。");
                        }
                    }
                    else
                    {
                        MessageBox.Show("请检查图幅号是否正确。");
                    }
                }
                if (list != null)
                {
                    tools = null;
                    point = null;
                    list.Clear();
                    list = null;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            double x = 0.0;
            double y = 0.0;
            double num3 = 0.0;
            double num4 = 0.0;
            double num5 = 0.0;
            double num6 = 0.0;
            double num7 = 0.0;
            double num8 = 0.0;
            IPoint point = new PointClass();
            IPoint point2 = new PointClass();
            IPoint point3 = new PointClass();
            IPoint point4 = new PointClass();
            if (this.txtTH.Text.Trim() == "")
            {
                MessageBox.Show("图号不能为空");
            }
            else
            {
                try
                {
                    x = double.Parse(this.txtLeftUpX.Text.Trim());
                    y = double.Parse(this.txtLeftUpY.Text.Trim());
                    num3 = double.Parse(this.txtRightUpX.Text.Trim());
                    num4 = double.Parse(this.txtRightUpY.Text.Trim());
                    num5 = double.Parse(this.txtRightLowX.Text.Trim());
                    num6 = double.Parse(this.txtRightLowY.Text.Trim());
                    num7 = double.Parse(this.txtLeftLowX.Text.Trim());
                    num8 = double.Parse(this.txtLeftLowY.Text.Trim());
                    point.PutCoords(x, y);
                    point2.PutCoords(num3, num4);
                    point3.PutCoords(num5, num6);
                    point4.PutCoords(num7, num8);
                }
                catch (Exception)
                {
                    MessageBox.Show("请检查坐标是否正确。");
                    return;
                }
                try
                {
                    this.fenFuMapClass_0.LeftUp = point;
                    this.fenFuMapClass_0.RightUp = point2;
                    this.fenFuMapClass_0.RightLow = point3;
                    this.fenFuMapClass_0.LeftLow = point4;
                    this.fenFuMapClass_0.MapTM = this.txtTM.Text.Trim();
                    this.fenFuMapClass_0.MapTH = this.txtTH.Text.Trim();
                    this.fenFuMapClass_0.MapRightUpText = this.txtRightUpTxt.Text.Trim();
                    this.fenFuMapClass_0.MapRightLowTex = this.txtRightLowTxt.Text.Trim();
                    this.fenFuMapClass_0.MapLeftLowText = this.txtLeftLowTxt.Text.Trim();
                    this.fenFuMapClass_0.MapLeftBorderOutText = this.txtZTDW.Text.Trim();
                    this.fenFuMapClass_0.MapScaleText = this.cmbScale.Text.Trim();
                    this.fenFuMapClass_0.MapRow1Col1Text = this.txtR1C1.Text.Trim();
                    this.fenFuMapClass_0.MapRow2Col1Text = this.txtR2C1.Text.Trim();
                    this.fenFuMapClass_0.MapRow3Col1Text = this.txtR3C1.Text.Trim();
                    this.fenFuMapClass_0.MapRow1Col2Text = this.txtR1C2.Text.Trim();
                    this.fenFuMapClass_0.MapRow3Col2Text = this.txtR3C2.Text.Trim();
                    this.fenFuMapClass_0.MapRow1Col3Text = this.txtR1C3.Text.Trim();
                    this.fenFuMapClass_0.MapRow2Col3Text = this.txtR2C3.Text.Trim();
                    this.fenFuMapClass_0.MapRow3Col3Text = this.txtR3C3.Text.Trim();
                    if (this.chkLenged.Checked)
                    {
                        this.fenFuMapClass_0.NeedLegend = true;
                    }
                    else
                    {
                        this.fenFuMapClass_0.NeedLegend = false;
                    }
                    this.fenFuMapClass_0.ActiveView = this.iactiveView_0;
                    this.fenFuMapClass_0.Draw();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private void btnSavee_Click(object sender, EventArgs e)
        {
            this.fenFuMapClass_0.Save();
        }

        private void cmbScale_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected override void Dispose(bool bool_0)
        {
            if (bool_0 && (this.icontainer_0 != null))
            {
                this.icontainer_0.Dispose();
            }
            base.Dispose(bool_0);
        }

        private void frmFenFuTKCreate_Load(object sender, EventArgs e)
        {
            this.cmbScale.Items.Add("1:5000");
            this.cmbScale.Items.Add("1:10000");
            this.cmbScale.SelectedIndex = 1;
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFenFuTKCreate));
            this.groupBox4 = new GroupBox();
            this.txtRightLowTxt = new TextBox();
            this.groupBox11 = new GroupBox();
            this.txtLeftLowTxt = new TextBox();
            this.groupBox10 = new GroupBox();
            this.txtTM = new TextBox();
            this.groupBox14 = new GroupBox();
            this.txtRightUpTxt = new TextBox();
            this.groupBox1 = new GroupBox();
            this.cmbScale = new ComboBox();
            this.groupBox2 = new GroupBox();
            this.groupBox7 = new GroupBox();
            this.txtRightLowY = new TextBox();
            this.txtRightLowX = new TextBox();
            this.lblRLowX = new Label();
            this.lblRLowY = new Label();
            this.groupBox6 = new GroupBox();
            this.txtLeftLowY = new TextBox();
            this.txtLeftLowX = new TextBox();
            this.lblLLowX = new Label();
            this.lblLLowY = new Label();
            this.groupBox5 = new GroupBox();
            this.txtRightUpY = new TextBox();
            this.txtRightUpX = new TextBox();
            this.lblRUpX = new Label();
            this.lblRUpY = new Label();
            this.groupBox3 = new GroupBox();
            this.txtLeftUpY = new TextBox();
            this.txtLeftUpX = new TextBox();
            this.lblLUpX = new Label();
            this.lblLUpY = new Label();
            this.groupBox8 = new GroupBox();
            this.txtR3C3 = new TextBox();
            this.txtR2C3 = new TextBox();
            this.txtR1C3 = new TextBox();
            this.txtR3C2 = new TextBox();
            this.txtR2C2 = new TextBox();
            this.txtR1C2 = new TextBox();
            this.txtR2C1 = new TextBox();
            this.txtR3C1 = new TextBox();
            this.txtR1C1 = new TextBox();
            this.groupBox9 = new GroupBox();
            this.btnCoord = new Button();
            this.txtTH = new TextBox();
            this.chkLenged = new CheckBox();
            this.btnSave = new Button();
            this.btnClose = new Button();
            this.groupBox12 = new GroupBox();
            this.txtZTDW = new TextBox();
            this.btnSavee = new Button();
            this.groupBox4.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox12.SuspendLayout();
            base.SuspendLayout();
            this.groupBox4.Controls.Add(this.txtRightLowTxt);
            this.groupBox4.Location = new System.Drawing.Point(0x1b5, 0xf4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new Size(0xf4, 0x69);
            this.groupBox4.TabIndex = 0x37;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "外图框右下角注释";
            this.txtRightLowTxt.Location = new System.Drawing.Point(8, 0x13);
            this.txtRightLowTxt.Multiline = true;
            this.txtRightLowTxt.Name = "txtRightLowTxt";
            this.txtRightLowTxt.Size = new Size(0xe3, 0x4d);
            this.txtRightLowTxt.TabIndex = 4;
            this.groupBox11.Controls.Add(this.txtLeftLowTxt);
            this.groupBox11.Location = new System.Drawing.Point(0x1b5, 0x83);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new Size(0xf6, 0x69);
            this.groupBox11.TabIndex = 0x34;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "外图框左下角注释";
            this.txtLeftLowTxt.Location = new System.Drawing.Point(8, 0x13);
            this.txtLeftLowTxt.Multiline = true;
            this.txtLeftLowTxt.Name = "txtLeftLowTxt";
            this.txtLeftLowTxt.Size = new Size(0xe5, 0x4d);
            this.txtLeftLowTxt.TabIndex = 4;
            this.groupBox10.Controls.Add(this.txtTM);
            this.groupBox10.Location = new System.Drawing.Point(10, 0);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new Size(0xb8, 0x39);
            this.groupBox10.TabIndex = 0x33;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "图名";
            this.txtTM.Location = new System.Drawing.Point(6, 0x17);
            this.txtTM.Name = "txtTM";
            this.txtTM.Size = new Size(0x9d, 0x15);
            this.txtTM.TabIndex = 3;
            this.groupBox14.Controls.Add(this.txtRightUpTxt);
            this.groupBox14.Location = new System.Drawing.Point(0x1b5, 0x44);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new Size(0xf6, 0x39);
            this.groupBox14.TabIndex = 0x35;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "外图框右上角注释";
            this.txtRightUpTxt.Location = new System.Drawing.Point(6, 0x1b);
            this.txtRightUpTxt.Name = "txtRightUpTxt";
            this.txtRightUpTxt.Size = new Size(0xe7, 0x15);
            this.txtRightUpTxt.TabIndex = 4;
            this.groupBox1.Controls.Add(this.cmbScale);
            this.groupBox1.Location = new System.Drawing.Point(0x1b5, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0xf4, 0x33);
            this.groupBox1.TabIndex = 0x36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "";
            this.groupBox1.Text = "比例尺";
            this.cmbScale.FormattingEnabled = true;
            this.cmbScale.Location = new System.Drawing.Point(14, 20);
            this.cmbScale.Name = "cmbScale";
            this.cmbScale.Size = new Size(0xd5, 20);
            this.cmbScale.TabIndex = 0;
            this.cmbScale.SelectedIndexChanged += new EventHandler(this.cmbScale_SelectedIndexChanged);
            this.groupBox2.Controls.Add(this.groupBox7);
            this.groupBox2.Controls.Add(this.groupBox6);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Location = new System.Drawing.Point(10, 0x43);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0x19c, 0xce);
            this.groupBox2.TabIndex = 0x38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "图廓范围";
            this.groupBox7.Controls.Add(this.txtRightLowY);
            this.groupBox7.Controls.Add(this.txtRightLowX);
            this.groupBox7.Controls.Add(this.lblRLowX);
            this.groupBox7.Controls.Add(this.lblRLowY);
            this.groupBox7.Location = new System.Drawing.Point(0xd1, 0x73);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new Size(0xc3, 0x55);
            this.groupBox7.TabIndex = 5;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "右下角";
            this.txtRightLowY.Location = new System.Drawing.Point(0x15, 0x35);
            this.txtRightLowY.Name = "txtRightLowY";
            this.txtRightLowY.Size = new Size(0xa8, 0x15);
            this.txtRightLowY.TabIndex = 3;
            this.txtRightLowX.Location = new System.Drawing.Point(0x15, 0x19);
            this.txtRightLowX.Name = "txtRightLowX";
            this.txtRightLowX.Size = new Size(0xa8, 0x15);
            this.txtRightLowX.TabIndex = 2;
            this.lblRLowX.AutoSize = true;
            this.lblRLowX.Location = new System.Drawing.Point(7, 0x1a);
            this.lblRLowX.Name = "lblRLowX";
            this.lblRLowX.Size = new Size(0x11, 12);
            this.lblRLowX.TabIndex = 0;
            this.lblRLowX.Text = "X:";
            this.lblRLowY.AutoSize = true;
            this.lblRLowY.Location = new System.Drawing.Point(7, 0x3e);
            this.lblRLowY.Name = "lblRLowY";
            this.lblRLowY.Size = new Size(0x11, 12);
            this.lblRLowY.TabIndex = 1;
            this.lblRLowY.Text = "Y:";
            this.groupBox6.Controls.Add(this.txtLeftLowY);
            this.groupBox6.Controls.Add(this.txtLeftLowX);
            this.groupBox6.Controls.Add(this.lblLLowX);
            this.groupBox6.Controls.Add(this.lblLLowY);
            this.groupBox6.Location = new System.Drawing.Point(6, 0x73);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new Size(190, 0x55);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "左下角";
            this.txtLeftLowY.Location = new System.Drawing.Point(0x17, 0x36);
            this.txtLeftLowY.Name = "txtLeftLowY";
            this.txtLeftLowY.Size = new Size(0x9b, 0x15);
            this.txtLeftLowY.TabIndex = 3;
            this.txtLeftLowX.Location = new System.Drawing.Point(0x17, 0x19);
            this.txtLeftLowX.Name = "txtLeftLowX";
            this.txtLeftLowX.Size = new Size(0x9b, 0x15);
            this.txtLeftLowX.TabIndex = 2;
            this.lblLLowX.AutoSize = true;
            this.lblLLowX.Location = new System.Drawing.Point(7, 0x1a);
            this.lblLLowX.Name = "lblLLowX";
            this.lblLLowX.Size = new Size(0x11, 12);
            this.lblLLowX.TabIndex = 0;
            this.lblLLowX.Text = "X:";
            this.lblLLowY.AutoSize = true;
            this.lblLLowY.Location = new System.Drawing.Point(7, 0x3e);
            this.lblLLowY.Name = "lblLLowY";
            this.lblLLowY.Size = new Size(0x11, 12);
            this.lblLLowY.TabIndex = 1;
            this.lblLLowY.Text = "Y:";
            this.groupBox5.Controls.Add(this.txtRightUpY);
            this.groupBox5.Controls.Add(this.txtRightUpX);
            this.groupBox5.Controls.Add(this.lblRUpX);
            this.groupBox5.Controls.Add(this.lblRUpY);
            this.groupBox5.Location = new System.Drawing.Point(0xd1, 20);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new Size(0xc3, 0x55);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "右上角";
            this.txtRightUpY.Location = new System.Drawing.Point(0x15, 0x36);
            this.txtRightUpY.Name = "txtRightUpY";
            this.txtRightUpY.Size = new Size(0xa8, 0x15);
            this.txtRightUpY.TabIndex = 3;
            this.txtRightUpX.Location = new System.Drawing.Point(0x15, 0x19);
            this.txtRightUpX.Name = "txtRightUpX";
            this.txtRightUpX.Size = new Size(0xa8, 0x15);
            this.txtRightUpX.TabIndex = 2;
            this.lblRUpX.AutoSize = true;
            this.lblRUpX.Location = new System.Drawing.Point(7, 0x1a);
            this.lblRUpX.Name = "lblRUpX";
            this.lblRUpX.Size = new Size(0x11, 12);
            this.lblRUpX.TabIndex = 0;
            this.lblRUpX.Text = "X:";
            this.lblRUpY.AutoSize = true;
            this.lblRUpY.Location = new System.Drawing.Point(7, 0x3e);
            this.lblRUpY.Name = "lblRUpY";
            this.lblRUpY.Size = new Size(0x11, 12);
            this.lblRUpY.TabIndex = 1;
            this.lblRUpY.Text = "Y:";
            this.groupBox3.Controls.Add(this.txtLeftUpY);
            this.groupBox3.Controls.Add(this.txtLeftUpX);
            this.groupBox3.Controls.Add(this.lblLUpX);
            this.groupBox3.Controls.Add(this.lblLUpY);
            this.groupBox3.Location = new System.Drawing.Point(6, 20);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new Size(190, 0x55);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "左上角";
            this.txtLeftUpY.Location = new System.Drawing.Point(0x17, 0x36);
            this.txtLeftUpY.Name = "txtLeftUpY";
            this.txtLeftUpY.Size = new Size(0x9b, 0x15);
            this.txtLeftUpY.TabIndex = 3;
            this.txtLeftUpX.Location = new System.Drawing.Point(0x17, 0x19);
            this.txtLeftUpX.Name = "txtLeftUpX";
            this.txtLeftUpX.Size = new Size(0x9b, 0x15);
            this.txtLeftUpX.TabIndex = 2;
            this.lblLUpX.AutoSize = true;
            this.lblLUpX.Location = new System.Drawing.Point(7, 0x1a);
            this.lblLUpX.Name = "lblLUpX";
            this.lblLUpX.Size = new Size(0x11, 12);
            this.lblLUpX.TabIndex = 0;
            this.lblLUpX.Text = "X:";
            this.lblLUpY.AutoSize = true;
            this.lblLUpY.Location = new System.Drawing.Point(7, 0x3e);
            this.lblLUpY.Name = "lblLUpY";
            this.lblLUpY.Size = new Size(0x11, 12);
            this.lblLUpY.TabIndex = 1;
            this.lblLUpY.Text = "Y:";
            this.groupBox8.Controls.Add(this.txtR3C3);
            this.groupBox8.Controls.Add(this.txtR2C3);
            this.groupBox8.Controls.Add(this.txtR1C3);
            this.groupBox8.Controls.Add(this.txtR3C2);
            this.groupBox8.Controls.Add(this.txtR2C2);
            this.groupBox8.Controls.Add(this.txtR1C2);
            this.groupBox8.Controls.Add(this.txtR2C1);
            this.groupBox8.Controls.Add(this.txtR3C1);
            this.groupBox8.Controls.Add(this.txtR1C1);
            this.groupBox8.Location = new System.Drawing.Point(10, 0x119);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new Size(0x160, 0x73);
            this.groupBox8.TabIndex = 0x39;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "接图表信息";
            this.txtR3C3.Location = new System.Drawing.Point(0xeb, 80);
            this.txtR3C3.Name = "txtR3C3";
            this.txtR3C3.Size = new Size(0x65, 0x15);
            this.txtR3C3.TabIndex = 11;
            this.txtR2C3.Location = new System.Drawing.Point(0xeb, 0x35);
            this.txtR2C3.Name = "txtR2C3";
            this.txtR2C3.Size = new Size(0x65, 0x15);
            this.txtR2C3.TabIndex = 10;
            this.txtR1C3.Location = new System.Drawing.Point(0xeb, 0x17);
            this.txtR1C3.Name = "txtR1C3";
            this.txtR1C3.Size = new Size(0x65, 0x15);
            this.txtR1C3.TabIndex = 9;
            this.txtR3C2.Location = new System.Drawing.Point(0x80, 80);
            this.txtR3C2.Name = "txtR3C2";
            this.txtR3C2.Size = new Size(0x65, 0x15);
            this.txtR3C2.TabIndex = 8;
            this.txtR2C2.BackColor = SystemColors.InactiveBorder;
            this.txtR2C2.Enabled = false;
            this.txtR2C2.Location = new System.Drawing.Point(0x80, 0x35);
            this.txtR2C2.Name = "txtR2C2";
            this.txtR2C2.Size = new Size(0x65, 0x15);
            this.txtR2C2.TabIndex = 7;
            this.txtR1C2.Location = new System.Drawing.Point(0x80, 0x17);
            this.txtR1C2.Name = "txtR1C2";
            this.txtR1C2.Size = new Size(0x65, 0x15);
            this.txtR1C2.TabIndex = 6;
            this.txtR2C1.Location = new System.Drawing.Point(0x15, 0x35);
            this.txtR2C1.Name = "txtR2C1";
            this.txtR2C1.Size = new Size(0x65, 0x15);
            this.txtR2C1.TabIndex = 5;
            this.txtR3C1.Location = new System.Drawing.Point(0x15, 80);
            this.txtR3C1.Name = "txtR3C1";
            this.txtR3C1.Size = new Size(0x65, 0x15);
            this.txtR3C1.TabIndex = 4;
            this.txtR1C1.Location = new System.Drawing.Point(0x15, 0x17);
            this.txtR1C1.Name = "txtR1C1";
            this.txtR1C1.Size = new Size(0x65, 0x15);
            this.txtR1C1.TabIndex = 3;
            this.groupBox9.Controls.Add(this.btnCoord);
            this.groupBox9.Controls.Add(this.txtTH);
            this.groupBox9.Location = new System.Drawing.Point(200, 6);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new Size(0xde, 0x33);
            this.groupBox9.TabIndex = 0x3a;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "图号";
            this.btnCoord.Font = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.btnCoord.Location = new System.Drawing.Point(0x99, 15);
            this.btnCoord.Name = "btnCoord";
            this.btnCoord.Size = new Size(0x3d, 0x17);
            this.btnCoord.TabIndex = 4;
            this.btnCoord.Text = "坐标计算";
            this.btnCoord.UseVisualStyleBackColor = true;
            this.btnCoord.Click += new EventHandler(this.btnCoord_Click);
            this.txtTH.Location = new System.Drawing.Point(7, 0x12);
            this.txtTH.Name = "txtTH";
            this.txtTH.Size = new Size(140, 0x15);
            this.txtTH.TabIndex = 3;
            this.chkLenged.AutoSize = true;
            this.chkLenged.Location = new System.Drawing.Point(0x1b5, 380);
            this.chkLenged.Name = "chkLenged";
            this.chkLenged.Size = new Size(0x30, 0x10);
            this.chkLenged.TabIndex = 0x3b;
            this.chkLenged.Text = "图例";
            this.chkLenged.UseVisualStyleBackColor = true;
            this.btnSave.Location = new System.Drawing.Point(0x1bd, 0x1b6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(0x45, 0x1a);
            this.btnSave.TabIndex = 60;
            this.btnSave.Text = "生成";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            this.btnClose.Location = new System.Drawing.Point(0x25b, 0x1b6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new Size(0x45, 0x1a);
            this.btnClose.TabIndex = 0x3d;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new EventHandler(this.btnClose_Click);
            this.groupBox12.Controls.Add(this.txtZTDW);
            this.groupBox12.Location = new System.Drawing.Point(12, 0x19b);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new Size(0x160, 0x2b);
            this.groupBox12.TabIndex = 0x3e;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "制图单位";
            this.txtZTDW.Location = new System.Drawing.Point(0x12, 0x10);
            this.txtZTDW.Name = "txtZTDW";
            this.txtZTDW.Size = new Size(0x13b, 0x15);
            this.txtZTDW.TabIndex = 5;
            this.btnSavee.Location = new System.Drawing.Point(0x210, 0x1b6);
            this.btnSavee.Name = "btnSavee";
            this.btnSavee.Size = new Size(0x45, 0x1a);
            this.btnSavee.TabIndex = 0x3f;
            this.btnSavee.Text = "保存";
            this.btnSavee.UseVisualStyleBackColor = true;
            this.btnSavee.Click += new EventHandler(this.btnSavee_Click);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x2c0, 0x1da);
            base.Controls.Add(this.btnSavee);
            base.Controls.Add(this.groupBox9);
            base.Controls.Add(this.groupBox12);
            base.Controls.Add(this.btnSave);
            base.Controls.Add(this.btnClose);
            base.Controls.Add(this.chkLenged);
            base.Controls.Add(this.groupBox8);
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.groupBox4);
            base.Controls.Add(this.groupBox11);
            base.Controls.Add(this.groupBox10);
            base.Controls.Add(this.groupBox14);
            base.Controls.Add(this.groupBox1);
            base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.Icon = ((System.Drawing.Icon)resources.GetObject("$Icon"));
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmFenFuTKCreate";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "分幅图生成";
            base.Load += new EventHandler(this.frmFenFuTKCreate_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        public IActiveView ActiveView
        {
            set
            {
                this.iactiveView_0 = value;
            }
        }

        internal bool IsAdminSys
        {
            get
            {
                return false;
            }
            set
            {
            }
        }
    }
}

