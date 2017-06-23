﻿using System;
using Yutai.Pipeline.Analysis.Menu;
using Yutai.Pipeline.Config.Interfaces;
using Yutai.Plugins.Catalog;
using Yutai.Plugins.Catalog.Menu;
using Yutai.Plugins.Concrete;
using Yutai.Plugins.Interfaces;
using Yutai.Plugins.Mef;
using Yutai.Plugins.Mvp;

namespace Yutai.Pipeline.Analysis
{
    [YutaiPlugin()]
    public class PipelineAnalysisPlugin : BasePlugin
    {
        private IAppContext _context;
        private MenuGenerator _menuGenerator;
        private IPipelineConfig _config;
        
      public event EventHandler<QueryResultArgs>QueryResultChanged;

        protected override void RegisterServices(IApplicationContainer container)
        {
            CompositionRoot.Compose(container);
        }

        public override void Initialize(IAppContext context)
        {
            _context = context;
            _menuGenerator = context.Container.GetInstance<MenuGenerator>();
            _config = context.Container.GetSingleton<IPipelineConfig>();
            //_menuListener = context.Container.GetInstance<MenuListener>();
            //_mapListener = context.Container.GetInstance<MapListener>();
            // _dockPanelService = context.Container.GetInstance<TemplateDockPanelService>();
        }

        private void FireEvent<T>(EventHandler<T> handler, T args)
        {
            if (handler != null)
            {
                handler(this, args);
            }
        }

        public IPipelineConfig PipeConfig
        {
            get { return _config;}
        }
        public void FireQueryResultChanged(QueryResultArgs e)
        {
            FireEvent(QueryResultChanged, e);
        }
    }
}