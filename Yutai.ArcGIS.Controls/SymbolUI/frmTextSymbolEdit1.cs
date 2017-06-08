﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using Yutai.ArcGIS.Common.SymbolLib;
using Yutai.ArcGIS.Common.SymbolUI;

namespace Yutai.ArcGIS.Controls.SymbolUI
{
    [Guid("F9680E83-DA0D-4738-92F3-ED156D55318F")]
    internal class frmTextSymbolEdit1 : Form
    {
        private SimpleButton btnCancel;
        private SimpleButton btnFixZoomIn;
        private SimpleButton btnFixZoomOut;
        private SimpleButton btnOK;
        private SimpleButton btnOnt2One;
        private ComboBoxEdit cboScale;
        private ComboBoxEdit cboTextType;
        private ComboBoxEdit cboUnit;
        private Container components = null;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label1;
        private Label label2;
        private bool m_CanDo = true;
        private double[] m_dblScaleRatio = new double[] { 0.25, 0.5, 1.0, 1.25, 2.0 };
        private MaskControl m_pMaskCtrl = new MaskControl();
        private ISymbol m_pOldSymbol;
        public IStyleGallery m_pSG;
        private TextGeneralControl m_pTextGeneralCtrl = new TextGeneralControl();
        private ITextSymbol m_pTextSymbol = null;
        private int m_ScaleIndex = 2;
        private TabPage pageGeneral;
        private TabPage pageMask;
        private double[] point_unit_to = new double[] { 1.0, 0.01388889, 0.0352777778, 0.352777778 };
        private SymbolItem symbolItem1;
        private TabControl tabControl1;

        public frmTextSymbolEdit1()
        {
            this.InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.m_pSG = null;
            base.Close();
        }

        private void btnFixZoomIn_Click(object sender, EventArgs e)
        {
            if (this.m_ScaleIndex != 0)
            {
                this.m_ScaleIndex--;
                this.symbolItem1.ScaleRatio = this.m_dblScaleRatio[this.m_ScaleIndex];
                this.m_CanDo = false;
                this.cboScale.SelectedIndex = this.m_ScaleIndex;
                this.m_CanDo = true;
                this.symbolItem1.Invalidate();
            }
        }

        private void btnFixZoomOut_Click(object sender, EventArgs e)
        {
            if (this.m_ScaleIndex != 4)
            {
                this.m_ScaleIndex++;
                this.symbolItem1.ScaleRatio = this.m_dblScaleRatio[this.m_ScaleIndex];
                this.m_CanDo = false;
                this.cboScale.SelectedIndex = this.m_ScaleIndex;
                this.m_CanDo = true;
                this.symbolItem1.Invalidate();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.m_pSG = null;
            base.Close();
        }

        private void btnOnt2One_Click(object sender, EventArgs e)
        {
            if (this.m_ScaleIndex != 2)
            {
                this.m_ScaleIndex = 2;
                this.symbolItem1.ScaleRatio = this.m_dblScaleRatio[this.m_ScaleIndex];
                this.m_CanDo = false;
                this.cboScale.SelectedIndex = this.m_ScaleIndex;
                this.m_CanDo = true;
                this.symbolItem1.Invalidate();
            }
        }

        private void cboFillType_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cboScale_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.m_CanDo)
            {
                this.m_ScaleIndex = this.cboScale.SelectedIndex;
                this.symbolItem1.ScaleRatio = this.m_dblScaleRatio[this.m_ScaleIndex];
                this.symbolItem1.Invalidate();
            }
        }

        private void cboUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.m_CanDo)
            {
                for (int i = 0; i < this.tabControl1.TabPages.Count; i++)
                {
                    CommonInterface interface2 = this.tabControl1.TabPages[i].Controls[0] as CommonInterface;
                    if (interface2 != null)
                    {
                        interface2.ChangeUnit(this.point_unit_to[this.cboUnit.SelectedIndex]);
                    }
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void frmFillSymbolEdit_Load(object sender, EventArgs e)
        {
            this.m_CanDo = false;
            this.cboUnit.SelectedIndex = 0;
            this.cboScale.SelectedIndex = this.m_ScaleIndex;
            this.m_CanDo = true;
            this.m_pTextGeneralCtrl.m_pTextSymbol = this.m_pTextSymbol;
            this.m_pMaskCtrl.m_pMask = this.m_pTextSymbol as IMask;
            this.m_pMaskCtrl.m_pSG = this.m_pSG;
            this.m_pTextGeneralCtrl.ValueChanged += new ValueChangedHandler(this.ValueChanged);
            this.m_pMaskCtrl.ValueChanged += new ValueChangedHandler(this.ValueChanged);
            this.m_pTextGeneralCtrl.Dock = DockStyle.Fill;
            this.m_pMaskCtrl.Dock = DockStyle.Fill;
            this.pageGeneral.Controls.Add(this.m_pTextGeneralCtrl);
            this.pageMask.Controls.Add(this.m_pMaskCtrl);
            this.symbolItem1.Symbol = this.m_pTextSymbol as ISymbol;
            this.m_CanDo = true;
        }

        public ISymbol GetSymbol()
        {
            return (this.m_pTextSymbol as ISymbol);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTextSymbolEdit));
            this.groupBox1 = new GroupBox();
            this.tabControl1 = new TabControl();
            this.pageGeneral = new TabPage();
            this.pageMask = new TabPage();
            this.cboUnit = new ComboBoxEdit();
            this.cboTextType = new ComboBoxEdit();
            this.label2 = new Label();
            this.label1 = new Label();
            this.groupBox2 = new GroupBox();
            this.cboScale = new ComboBoxEdit();
            this.btnOnt2One = new SimpleButton();
            this.btnFixZoomOut = new SimpleButton();
            this.btnFixZoomIn = new SimpleButton();
            this.symbolItem1 = new SymbolItem();
            this.btnCancel = new SimpleButton();
            this.btnOK = new SimpleButton();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.cboUnit.Properties.BeginInit();
            this.cboTextType.Properties.BeginInit();
            this.groupBox2.SuspendLayout();
            this.cboScale.Properties.BeginInit();
            base.SuspendLayout();
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Controls.Add(this.cboUnit);
            this.groupBox1.Controls.Add(this.cboTextType);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new Point(0x110, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x198, 0x158);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "属性";
            this.tabControl1.Controls.Add(this.pageGeneral);
            this.tabControl1.Controls.Add(this.pageMask);
            this.tabControl1.Location = new Point(0x10, 0x30);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new Size(0x180, 0x120);
            this.tabControl1.TabIndex = 11;
            this.pageGeneral.Location = new Point(4, 0x15);
            this.pageGeneral.Name = "pageGeneral";
            this.pageGeneral.Size = new Size(0x178, 0x107);
            this.pageGeneral.TabIndex = 0;
            this.pageGeneral.Text = "常规";
            this.pageMask.Location = new Point(4, 0x15);
            this.pageMask.Name = "pageMask";
            this.pageMask.Size = new Size(0x178, 0x107);
            this.pageMask.TabIndex = 1;
            this.pageMask.Text = "掩模";
            this.cboUnit.EditValue = "点";
            this.cboUnit.Location = new Point(240, 0x13);
            this.cboUnit.Name = "cboUnit";
            this.cboUnit.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.cboUnit.Properties.Items.AddRange(new object[] { "点", "英寸", "厘米", "毫米" });
            this.cboUnit.Size = new Size(0x90, 0x15);
            this.cboUnit.TabIndex = 10;
            this.cboUnit.SelectedIndexChanged += new EventHandler(this.cboUnit_SelectedIndexChanged);
            this.cboTextType.EditValue = "文本符号";
            this.cboTextType.Location = new Point(0x38, 0x12);
            this.cboTextType.Name = "cboTextType";
            this.cboTextType.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.cboTextType.Properties.Items.AddRange(new object[] { "文本符号", "分式注记" });
            this.cboTextType.Size = new Size(0x80, 0x15);
            this.cboTextType.TabIndex = 9;
            this.cboTextType.SelectedIndexChanged += new EventHandler(this.cboFillType_SelectedIndexChanged);
            this.label2.AutoSize = true;
            this.label2.Location = new Point(200, 0x18);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x1d, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "单位";
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0x10, 0x18);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x1d, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "类型";
            this.groupBox2.Controls.Add(this.cboScale);
            this.groupBox2.Controls.Add(this.btnOnt2One);
            this.groupBox2.Controls.Add(this.btnFixZoomOut);
            this.groupBox2.Controls.Add(this.btnFixZoomIn);
            this.groupBox2.Controls.Add(this.symbolItem1);
            this.groupBox2.Location = new Point(8, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0xf8, 0x158);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "预览";
            this.cboScale.EditValue = "";
            this.cboScale.Location = new Point(120, 0x128);
            this.cboScale.Name = "cboScale";
            this.cboScale.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.cboScale.Properties.Items.AddRange(new object[] { "400%", "200%", "100%", "75%", "50%" });
            this.cboScale.Size = new Size(0x48, 0x15);
            this.cboScale.TabIndex = 0x18;
            this.cboScale.SelectedIndexChanged += new EventHandler(this.cboScale_SelectedIndexChanged);
            this.btnOnt2One.Image = (Image) resources.GetObject("btnOnt2One.Image");
            this.btnOnt2One.Location = new Point(0x58, 0x128);
            this.btnOnt2One.Name = "btnOnt2One";
            this.btnOnt2One.Size = new Size(0x16, 0x16);
            this.btnOnt2One.TabIndex = 0x17;
            this.btnOnt2One.Click += new EventHandler(this.btnOnt2One_Click);
            this.btnFixZoomOut.Image = (Image) resources.GetObject("btnFixZoomOut.Image");
            this.btnFixZoomOut.Location = new Point(0x40, 0x128);
            this.btnFixZoomOut.Name = "btnFixZoomOut";
            this.btnFixZoomOut.Size = new Size(0x16, 0x16);
            this.btnFixZoomOut.TabIndex = 0x16;
            this.btnFixZoomOut.Click += new EventHandler(this.btnFixZoomOut_Click);
            this.btnFixZoomIn.Image = (Image) resources.GetObject("btnFixZoomIn.Image");
            this.btnFixZoomIn.Location = new Point(0x20, 0x128);
            this.btnFixZoomIn.Name = "btnFixZoomIn";
            this.btnFixZoomIn.Size = new Size(0x16, 0x16);
            this.btnFixZoomIn.TabIndex = 0x15;
            this.btnFixZoomIn.Click += new EventHandler(this.btnFixZoomIn_Click);
            this.symbolItem1.BackColor = SystemColors.ControlLight;
            this.symbolItem1.Location = new Point(0x10, 0x18);
            this.symbolItem1.Name = "symbolItem1";
            this.symbolItem1.Size = new Size(0xd0, 0x100);
            this.symbolItem1.Symbol = null;
            this.symbolItem1.TabIndex = 1;
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.btnCancel.Location = new Point(560, 0x165);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(0x38, 0x18);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            this.btnOK.DialogResult = DialogResult.OK;
            this.btnOK.Location = new Point(0x1e8, 0x165);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new Size(0x38, 0x18);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new EventHandler(this.btnOK_Click);
            this.AutoScaleBaseSize = new Size(6, 14);
            base.ClientSize = new Size(690, 0x187);
            base.Controls.Add(this.btnCancel);
            base.Controls.Add(this.btnOK);
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.groupBox1);
            base.FormBorderStyle = FormBorderStyle.FixedSingle;
            
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmTextSymbolEdit";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "文本符号编辑器";
            base.Load += new EventHandler(this.frmFillSymbolEdit_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.cboUnit.Properties.EndInit();
            this.cboTextType.Properties.EndInit();
            this.groupBox2.ResumeLayout(false);
            this.cboScale.Properties.EndInit();
            base.ResumeLayout(false);
        }

        public void SetSymbol(ISymbol pSym)
        {
            this.m_pOldSymbol = pSym;
            this.m_pTextSymbol = (pSym as IClone).Clone() as ITextSymbol;
        }

        private void ValueChanged(object sender, EventArgs e)
        {
            this.symbolItem1.Invalidate();
        }
    }
}

