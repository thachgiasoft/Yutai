﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using Syncfusion.Windows.Forms.Tools;
using Yutai.Plugins.Concrete;
using Yutai.Plugins.Enums;
using Yutai.Plugins.Identifer.Query;
using Yutai.Plugins.Interfaces;

namespace Yutai.Plugins.Identifer.Commands
{
    class CmdSetSelectRelation:YutaiCommand,ICommandComboBox
    {
        private IdentifierPlugin _plugin;
        private string _caption;
        private bool _showCaption;
        private int _layoutType;
        private string _selectedText;
        private object[] _items;
        private ToolStripComboBoxEx _linkCombo;

        public CmdSetSelectRelation(IAppContext context, BasePlugin plugin)
        {
            OnCreate(context);
            _plugin = plugin as IdentifierPlugin;
        }
        public override void OnClick(object sender, EventArgs args)
        {
            OnClick();
        }
        public override void OnClick()
        {

        }

        public ToolStripComboBoxEx LinkComboBox
        {
            get { return _linkCombo; }
            set { _linkCombo = value; }
        }

        public override void OnCreate(object hook)
        {
            _context = hook as IAppContext;
            base.m_caption = "选择方式：";
            base.m_category = "Query";
            base.m_bitmap = Properties.Resources.QueryAttribute;
            base.m_name = "Query.Setting.Panel.SetSeelctRelation";
            base._key = "Query.Setting.Panel.SetSeelctRelation";
            base.m_toolTip = "设置创建选择集的方式";
            base.m_checked = false;
            base.m_enabled = true;
            base._itemType = RibbonItemType.ComboBox;
            _layoutType = 0;
            _showCaption = true;
            
        }


        public string Caption
        {
            get { return base.m_caption; }
            set { base.m_caption = value; }
        }

        public bool ShowCaption
        {
            get { return _showCaption; }
            set { _showCaption = value; }
        }

        public int LayoutType
        {
            get { return _layoutType; }
            set { _layoutType = value; }
        }

        object[] ICommandComboBox.Items
        {
            get { return new object[] { "创建新的选择集", "添加到当前选择集中", "从当前选择集中移除", "从当前选择集中选择" }; }
            set { _items = value; }
        }

        
      

        public void SelectedIndexChanged(object sender, EventArgs args)
        {
            ToolStripComboBoxEx combo = sender as ToolStripComboBoxEx;
            if (combo.SelectedIndex < 0 || combo.SelectedIndex ==0)
            {
                _plugin.QuerySettings.SelectionEnvironment.CombinationMethod = esriSelectionResultEnum.esriSelectionResultNew;
            }
            else if (combo.SelectedIndex  ==1)
            {
                _plugin.QuerySettings.SelectionEnvironment.CombinationMethod = esriSelectionResultEnum.esriSelectionResultAdd;
            }
            else if (combo.SelectedIndex == 2)
            {
                _plugin.QuerySettings.SelectionEnvironment.CombinationMethod = esriSelectionResultEnum.esriSelectionResultSubtract;
            }
            else if (combo.SelectedIndex == 3)
            {
                _plugin.QuerySettings.SelectionEnvironment.CombinationMethod = esriSelectionResultEnum.esriSelectionResultAnd;
            }

        }

        public string SelectedText
        {
            get { return _selectedText; }
            set { _selectedText = value; }
        }
    }
}
