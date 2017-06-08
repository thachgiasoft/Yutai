﻿using System;
using Yutai.Plugins.Concrete;
using Yutai.Plugins.Enums;
using Yutai.Plugins.Interfaces;

namespace Yutai.Plugins.Editor.Commands
{
    public class CmdSnapIntersectPoint : YutaiCommand
    {
        public CmdSnapIntersectPoint(IAppContext context)
        {
            OnCreate(context);
        }

        public override void OnCreate(object hook)
        {
            this.m_bitmap = Properties.Resources.icon_snap_intersect;
            this.m_caption = "交点捕捉";
            this.m_category = "Edit";
            this.m_message = "交点捕捉";
            this.m_name = "Edit_Snap_Config_SnapIntersectPoint";
            this._key = "Edit_Snap_Config_SnapIntersectPoint";
            this.m_toolTip = "交点捕捉";
            _context = hook as IAppContext;
            DisplayStyleYT = DisplayStyleYT.Image;
            base.TextImageRelationYT = TextImageRelationYT.ImageBeforeText;
            base.ToolStripItemImageScalingYT = ToolStripItemImageScalingYT.None;
            //base._needUpdateEvent = true;
        }

        public override bool Enabled
        {
            get { return true; }
        }

        public override bool Checked
        {
            get { return _context.Config.IsSnapIntersectionPoint; }
        }

        public override void OnClick(object sender, EventArgs args)
        {
            OnClick();
            if (sender != null && base._needUpdateEvent)
            {
                _context.UpdateUI();
            }
        }

        public override void OnClick()
        {
            _context.Config.IsSnapIntersectionPoint = !_context.Config.IsSnapIntersectionPoint;
        }
    }
}