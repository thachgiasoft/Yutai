﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using ESRI.ArcGIS.Analyst3D;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
using Yutai.ArcGIS.Common.SymbolUI;

namespace Yutai.ArcGIS.Controls.SymbolUI
{
    internal class SimpleMarker3DSymbolCtrl : UserControl, CommonInterface
    {
        private AxSceneControl axSceneControl1;
        private ComboBoxEdit cboStyle;
        private CheckEdit chkMaintainAspectRatio;
        private ColorEdit colorEdit1;
        private Container components = null;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label2;
        private Label label4;
        private Label label6;
        private Label label7;
        private Label label8;
        private bool m_CanDo = false;
        public ISimpleMarker3DSymbol m_pSimpleMarker3DSymbol = null;
        public double m_unit = 1.0;
        private SpinEdit txtDepth1;
        private SpinEdit txtSize;
        private SpinEdit txtWidth;

        public event ValueChangedHandler ValueChanged;

        public SimpleMarker3DSymbolCtrl()
        {
            this.InitializeComponent();
            Marker3DEvent.Marker3DChanged += new Marker3DEvent.Marker3DChangedHandler(this.Marker3DEvent_Marker3DChanged);
        }

        private void cboStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.m_CanDo)
            {
                this.m_pSimpleMarker3DSymbol.Style = (esriSimple3DMarkerStyle) this.cboStyle.SelectedIndex;
                this.refresh(e);
            }
        }

        public void ChangeUnit(double newunit)
        {
            this.m_CanDo = false;
            this.txtSize.Value = (decimal) ((((double) this.txtSize.Value) / this.m_unit) * newunit);
            this.txtDepth1.Value = (decimal) ((((double) this.txtDepth1.Value) / this.m_unit) * newunit);
            this.txtWidth.Value = (decimal) ((((double) this.txtWidth.Value) / this.m_unit) * newunit);
            this.m_unit = newunit;
            this.m_CanDo = true;
        }

        private void chkMaintainAspectRatio_CheckedChanged(object sender, EventArgs e)
        {
            if (this.m_CanDo)
            {
                (this.m_pSimpleMarker3DSymbol as IMarker3DPlacement).MaintainAspectRatio = this.chkMaintainAspectRatio.Checked;
                this.refresh(e);
            }
        }

        private void colorEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (this.m_CanDo)
            {
                IColor pColor = (this.m_pSimpleMarker3DSymbol as IMarkerSymbol).Color;
                this.UpdateColorFromColorEdit(this.colorEdit1, pColor);
                (this.m_pSimpleMarker3DSymbol as IMarkerSymbol).Color = pColor;
                this.axSceneControl1.SceneGraph.RefreshViewers();
                this.refresh(e);
            }
        }

        public void DisplaySymbol()
        {
            IGraphicsLayer layer;
            if (this.axSceneControl1.SceneGraph.Scene.LayerCount == 0)
            {
                layer = new GraphicsLayer3DClass();
                this.axSceneControl1.SceneGraph.Scene.AddLayer(layer as ILayer, false);
            }
            else
            {
                layer = this.axSceneControl1.SceneGraph.Scene.get_Layer(0) as IGraphicsLayer;
            }
            try
            {
            }
            catch
            {
            }
            IGraphicsContainer3D containerd = layer as IGraphicsContainer3D;
            containerd.DeleteAllElements();
            if (this.m_pSimpleMarker3DSymbol != null)
            {
                IPoint point = new PointClass();
                IZAware aware = point as IZAware;
                aware.ZAware = true;
                point.X = 0.0;
                point.Y = 0.0;
                point.Z = 0.0;
                IElement element = new MarkerElementClass();
                IMarkerElement element2 = element as IMarkerElement;
                element2.Symbol = this.m_pSimpleMarker3DSymbol as IMarkerSymbol;
                element.Geometry = point;
                containerd.AddElement(element);
            }
            this.axSceneControl1.Navigate = true;
            this.axSceneControl1.SceneGraph.RefreshViewers();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void GetRGB(uint rgb, out int r, out int g, out int b)
        {
            uint num = rgb & 0xff0000;
            b = (int) (num >> 0x10);
            num = rgb & 0xff00;
            g = (int) (num >> 8);
            num = rgb & 0xff;
            r = (int) num;
        }

        public void InitControl()
        {
            this.m_CanDo = false;
            this.txtSize.Value = (decimal) ((this.m_pSimpleMarker3DSymbol as IMarkerSymbol).Size * this.m_unit);
            this.txtDepth1.Value = (decimal) ((this.m_pSimpleMarker3DSymbol as IMarker3DPlacement).Depth * this.m_unit);
            this.txtWidth.Value = (decimal) ((this.m_pSimpleMarker3DSymbol as IMarker3DPlacement).Width * this.m_unit);
            this.cboStyle.SelectedIndex = (int) this.m_pSimpleMarker3DSymbol.Style;
            this.chkMaintainAspectRatio.Checked = (this.m_pSimpleMarker3DSymbol as IMarker3DPlacement).MaintainAspectRatio;
            this.SetColorEdit(this.colorEdit1, (this.m_pSimpleMarker3DSymbol as IMarkerSymbol).Color);
            this.DisplaySymbol();
            this.m_CanDo = true;
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimpleMarker3DSymbolCtrl));
            this.groupBox2 = new GroupBox();
            this.axSceneControl1 = new AxSceneControl();
            this.groupBox1 = new GroupBox();
            this.chkMaintainAspectRatio = new CheckEdit();
            this.txtDepth1 = new SpinEdit();
            this.label4 = new Label();
            this.txtWidth = new SpinEdit();
            this.txtSize = new SpinEdit();
            this.label6 = new Label();
            this.label7 = new Label();
            this.colorEdit1 = new ColorEdit();
            this.label8 = new Label();
            this.cboStyle = new ComboBoxEdit();
            this.label2 = new Label();
            this.groupBox2.SuspendLayout();
            this.axSceneControl1.BeginInit();
            this.groupBox1.SuspendLayout();
            this.chkMaintainAspectRatio.Properties.BeginInit();
            this.txtDepth1.Properties.BeginInit();
            this.txtWidth.Properties.BeginInit();
            this.txtSize.Properties.BeginInit();
            this.colorEdit1.Properties.BeginInit();
            this.cboStyle.Properties.BeginInit();
            base.SuspendLayout();
            this.groupBox2.Controls.Add(this.axSceneControl1);
            this.groupBox2.Location = new System.Drawing.Point(0xcc, 0x58);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0xb0, 160);
            this.groupBox2.TabIndex = 0x54;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "3D预览";
            this.axSceneControl1.Location = new System.Drawing.Point(6, 20);
            this.axSceneControl1.Name = "axSceneControl1";
            this.axSceneControl1.OcxState = (AxHost.State) resources.GetObject("axSceneControl1.OcxState");
            this.axSceneControl1.Size = new Size(0xa4, 0x80);
            this.axSceneControl1.TabIndex = 1;
            this.groupBox1.Controls.Add(this.chkMaintainAspectRatio);
            this.groupBox1.Controls.Add(this.txtDepth1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtWidth);
            this.groupBox1.Controls.Add(this.txtSize);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(0x1c, 0x58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x98, 0x98);
            this.groupBox1.TabIndex = 0x53;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "尺寸";
            this.chkMaintainAspectRatio.Location = new System.Drawing.Point(0x10, 80);
            this.chkMaintainAspectRatio.Name = "chkMaintainAspectRatio";
            this.chkMaintainAspectRatio.Properties.Caption = "保持长宽比";
            this.chkMaintainAspectRatio.Size = new Size(0x68, 0x13);
            this.chkMaintainAspectRatio.TabIndex = 0x55;
            this.chkMaintainAspectRatio.CheckedChanged += new EventHandler(this.chkMaintainAspectRatio_CheckedChanged);
            int[] bits = new int[4];
            this.txtDepth1.EditValue = new decimal(bits);
            this.txtDepth1.Location = new System.Drawing.Point(0x38, 0x70);
            this.txtDepth1.Name = "txtDepth1";
            this.txtDepth1.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            this.txtDepth1.Properties.DisplayFormat.FormatType = FormatType.Numeric;
            this.txtDepth1.Properties.EditFormat.FormatType = FormatType.Numeric;
            bits = new int[4];
            bits[0] = 100;
            this.txtDepth1.Properties.MaxValue = new decimal(bits);
            bits = new int[4];
            bits[0] = 100;
            bits[3] = -2147483648;
            this.txtDepth1.Properties.MinValue = new decimal(bits);
            this.txtDepth1.Size = new Size(0x48, 0x15);
            this.txtDepth1.TabIndex = 0x54;
            this.txtDepth1.EditValueChanged += new EventHandler(this.txtDepth1_EditValueChanged);
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0x10, 120);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x1d, 12);
            this.label4.TabIndex = 0x53;
            this.label4.Text = "深度";
            bits = new int[4];
            this.txtWidth.EditValue = new decimal(bits);
            this.txtWidth.Location = new System.Drawing.Point(0x38, 0x30);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            this.txtWidth.Properties.DisplayFormat.FormatType = FormatType.Numeric;
            this.txtWidth.Properties.EditFormat.FormatType = FormatType.Numeric;
            bits = new int[4];
            bits[0] = 360;
            this.txtWidth.Properties.MaxValue = new decimal(bits);
            bits = new int[4];
            bits[0] = 360;
            bits[3] = -2147483648;
            this.txtWidth.Properties.MinValue = new decimal(bits);
            this.txtWidth.Size = new Size(0x40, 0x15);
            this.txtWidth.TabIndex = 0x52;
            this.txtWidth.EditValueChanged += new EventHandler(this.txtWidth_EditValueChanged);
            bits = new int[4];
            this.txtSize.EditValue = new decimal(bits);
            this.txtSize.Location = new System.Drawing.Point(0x38, 0x18);
            this.txtSize.Name = "txtSize";
            this.txtSize.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            this.txtSize.Properties.DisplayFormat.FormatType = FormatType.Numeric;
            this.txtSize.Properties.EditFormat.FormatType = FormatType.Numeric;
            bits = new int[4];
            bits[0] = 100;
            this.txtSize.Properties.MaxValue = new decimal(bits);
            this.txtSize.Size = new Size(0x40, 0x15);
            this.txtSize.TabIndex = 0x51;
            this.txtSize.EditValueChanged += new EventHandler(this.txtSize_EditValueChanged);
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(0x10, 0x18);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x1d, 12);
            this.label6.TabIndex = 80;
            this.label6.Text = "大小";
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(0x10, 0x38);
            this.label7.Name = "label7";
            this.label7.Size = new Size(0x23, 12);
            this.label7.TabIndex = 0x4f;
            this.label7.Text = "宽度:";
            this.colorEdit1.EditValue = Color.Empty;
            this.colorEdit1.Location = new System.Drawing.Point(0x40, 8);
            this.colorEdit1.Name = "colorEdit1";
            this.colorEdit1.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.colorEdit1.Size = new Size(0x30, 0x15);
            this.colorEdit1.TabIndex = 0x52;
            this.colorEdit1.EditValueChanged += new EventHandler(this.colorEdit1_EditValueChanged);
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(0x18, 8);
            this.label8.Name = "label8";
            this.label8.Size = new Size(0x1d, 12);
            this.label8.TabIndex = 0x51;
            this.label8.Text = "颜色";
            this.cboStyle.EditValue = "";
            this.cboStyle.Location = new System.Drawing.Point(0x40, 40);
            this.cboStyle.Name = "cboStyle";
            this.cboStyle.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.cboStyle.Properties.Items.AddRange(new object[] { "四面体", "立方体", "锥体", "圆柱体", "棱形", "球体", "SphereFrame" });
            this.cboStyle.Size = new Size(80, 0x15);
            this.cboStyle.TabIndex = 0x56;
            this.cboStyle.SelectedIndexChanged += new EventHandler(this.cboStyle_SelectedIndexChanged);
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0x18, 0x2d);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x1d, 12);
            this.label2.TabIndex = 0x55;
            this.label2.Text = "样式";
            base.Controls.Add(this.cboStyle);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.groupBox1);
            base.Controls.Add(this.colorEdit1);
            base.Controls.Add(this.label8);
            base.Name = "SimpleMarker3DSymbolCtrl";
            base.Size = new Size(0x198, 0x128);
            base.Load += new EventHandler(this.SimpleMarker3DSymbolCtrl_Load);
            this.groupBox2.ResumeLayout(false);
            this.axSceneControl1.EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.chkMaintainAspectRatio.Properties.EndInit();
            this.txtDepth1.Properties.EndInit();
            this.txtWidth.Properties.EndInit();
            this.txtSize.Properties.EndInit();
            this.colorEdit1.Properties.EndInit();
            this.cboStyle.Properties.EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void Marker3DEvent_Marker3DChanged(object sender)
        {
            if (sender != this)
            {
                this.DisplaySymbol();
            }
        }

        private void refresh(EventArgs e)
        {
            this.DisplaySymbol();
            if (this.ValueChanged != null)
            {
                this.ValueChanged(this, e);
            }
            Marker3DEvent.Marker3DChangeH(this);
        }

        private int RGB(int r, int g, int b)
        {
            uint num = 0;
            num |= (uint) b;
            num = num << 8;
            num |= (uint) g;
            num = num << 8;
            num |= (uint) r;
            return (int) num;
        }

        private void SetColorEdit(ColorEdit colorEdit, IColor pColor)
        {
            if (pColor.NullColor)
            {
                colorEdit.Color = Color.Empty;
            }
            else
            {
                int num;
                int num2;
                int num3;
                int rGB = pColor.RGB;
                this.GetRGB((uint) rGB, out num, out num2, out num3);
                colorEdit.Color = Color.FromArgb(pColor.Transparency, num, num2, num3);
            }
        }

        private void SimpleMarker3DSymbolCtrl_Load(object sender, EventArgs e)
        {
        }

        private void txtDepth1_EditValueChanged(object sender, EventArgs e)
        {
            if (this.m_CanDo)
            {
                if (this.txtDepth1.Value <= 0M)
                {
                    this.txtDepth1.ForeColor = Color.Red;
                }
                else
                {
                    this.txtDepth1.ForeColor = SystemColors.WindowText;
                    (this.m_pSimpleMarker3DSymbol as IMarker3DPlacement).Depth = ((double) this.txtDepth1.Value) / this.m_unit;
                    this.refresh(e);
                }
            }
        }

        private void txtSize_EditValueChanged(object sender, EventArgs e)
        {
            if (this.m_CanDo)
            {
                if (this.txtSize.Value <= 0M)
                {
                    this.txtSize.ForeColor = Color.Red;
                }
                else
                {
                    this.txtSize.ForeColor = SystemColors.WindowText;
                    (this.m_pSimpleMarker3DSymbol as IMarkerSymbol).Size = ((double) this.txtSize.Value) / this.m_unit;
                    this.refresh(e);
                }
            }
        }

        private void txtWidth_EditValueChanged(object sender, EventArgs e)
        {
            if (this.m_CanDo)
            {
                if (this.txtWidth.Value <= 0M)
                {
                    this.txtWidth.ForeColor = Color.Red;
                }
                else
                {
                    this.txtWidth.ForeColor = SystemColors.WindowText;
                    (this.m_pSimpleMarker3DSymbol as IMarker3DPlacement).Width = ((double) this.txtWidth.Value) / this.m_unit;
                    this.refresh(e);
                }
            }
        }

        private void UpdateColorFromColorEdit(ColorEdit colorEdit, IColor pColor)
        {
            pColor.NullColor = colorEdit.Color.IsEmpty;
            if (!colorEdit.Color.IsEmpty)
            {
                pColor.Transparency = colorEdit.Color.A;
                pColor.RGB = this.RGB(colorEdit.Color.R, colorEdit.Color.G, colorEdit.Color.B);
            }
        }
    }
}

