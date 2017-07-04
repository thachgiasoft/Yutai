﻿using ESRI.ArcGIS.Carto;
using System;
using Yutai.Pipeline.Config.Interfaces;
using Yutai.Plugins.Concrete;
using Yutai.Plugins.Enums;
using Yutai.Plugins.Interfaces;

namespace Yutai.Pipeline.Editor.Commands.Profession
{
    class CmdPointLineLinkage : YutaiTool
    {
        private PipelineEditorPlugin _plugin;
        private IPipelineConfig _config;
        private IFeatureLayer _pointFeatureLayer;
        private IFeatureLayer _lineFeatureLayer;
        private bool _isMove = false;

        public CmdPointLineLinkage(IAppContext context, PipelineEditorPlugin plugin)
        {
            OnCreate(context);
            _plugin = plugin;
        }

        public override void OnClick(object sender, EventArgs args)
        {
            OnClick();
        }

        public sealed override void OnCreate(object hook)
        {
            _context = hook as IAppContext;
            base.m_caption = "点线联动";
            base.m_category = "PipelineEditor";
            //base.m_bitmap = Properties.Resources.icon_valve;
            base.m_name = "PipelineEditor_PointLineLinkage";
            base._key = "PipelineEditor_PointLineLinkage";
            base.m_toolTip = "点线联动";
            base.m_checked = false;
            base.m_message = "点线联动";
            base.m_enabled = true;
            base._itemType = RibbonItemType.Tool;
        }

        public override void OnClick()
        {
            _context.SetCurrentTool(this);
        }

        public override void OnDblClick()
        {

        }

        public override void OnMouseDown(int button, int shift, int x, int y)
        {
            if (_isMove == false)
            {
                _context.FocusMap.ClearSelection();

            }
            else
            {
                
            }
        }
    }
}
