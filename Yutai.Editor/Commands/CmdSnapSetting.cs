﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yutai.Plugins.Concrete;
using Yutai.Plugins.Enums;
using Yutai.Plugins.Interfaces;

namespace Yutai.Plugins.Editor.Commands
{
    class CmdSnapSetting : YutaiCommand
    {
        public CmdSnapSetting(IAppContext context)
        {
            OnCreate(context);
        }

        public override bool Enabled
        {
            get { return true; }
        }


        public override void OnClick(object sender, EventArgs args)
        {
            OnClick();
        }

        public override void OnCreate(object hook)
        {
            base.m_caption = "捕捉设置";
            base.m_category = "Edit";
            base.m_bitmap = Properties.Resources.icon_snap_setting;
            base.m_name = "Edit_Snap_SnapSetting";
            base._key = "Edit_Snap_SnapSetting";
            base.m_toolTip = "捕捉设置";
            base.m_checked = false;
            base.m_enabled = true;
            base._itemType = RibbonItemType.Button;
            DisplayStyleYT = DisplayStyleYT.ImageAndText;
            TextImageRelationYT = TextImageRelationYT.ImageAboveText;
            _context = hook as IAppContext;
        }


        public void OnClick()
        {
            _context.RunConfigPage("Snap");
         
        }
    }
}