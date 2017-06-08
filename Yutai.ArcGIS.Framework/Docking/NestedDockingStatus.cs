﻿using System.Drawing;

namespace Yutai.ArcGIS.Framework.Docking
{
    public sealed class NestedDockingStatus
    {
        private DockAlignment m_alignment = DockAlignment.Left;
        private DockAlignment m_displayingAlignment = DockAlignment.Left;
        private DockPane m_displayingPreviousPane = null;
        private double m_displayingProportion = 0.5;
        private DockPane m_dockPane = null;
        private bool m_isDisplaying = false;
        private Rectangle m_logicalBounds = Rectangle.Empty;
        private NestedPaneCollection m_nestedPanes = null;
        private Rectangle m_paneBounds = Rectangle.Empty;
        private DockPane m_previousPane = null;
        private double m_proportion = 0.5;
        private Rectangle m_splitterBounds = Rectangle.Empty;

        internal NestedDockingStatus(DockPane pane)
        {
            this.m_dockPane = pane;
        }

        internal void SetDisplayingBounds(Rectangle logicalBounds, Rectangle paneBounds, Rectangle splitterBounds)
        {
            this.m_logicalBounds = logicalBounds;
            this.m_paneBounds = paneBounds;
            this.m_splitterBounds = splitterBounds;
        }

        internal void SetDisplayingStatus(bool isDisplaying, DockPane displayingPreviousPane, DockAlignment displayingAlignment, double displayingProportion)
        {
            this.m_isDisplaying = isDisplaying;
            this.m_displayingPreviousPane = displayingPreviousPane;
            this.m_displayingAlignment = displayingAlignment;
            this.m_displayingProportion = displayingProportion;
        }

        internal void SetStatus(NestedPaneCollection nestedPanes, DockPane previousPane, DockAlignment alignment, double proportion)
        {
            this.m_nestedPanes = nestedPanes;
            this.m_previousPane = previousPane;
            this.m_alignment = alignment;
            this.m_proportion = proportion;
        }

        public DockAlignment Alignment
        {
            get
            {
                return this.m_alignment;
            }
        }

        public DockAlignment DisplayingAlignment
        {
            get
            {
                return this.m_displayingAlignment;
            }
        }

        public DockPane DisplayingPreviousPane
        {
            get
            {
                return this.m_displayingPreviousPane;
            }
        }

        public double DisplayingProportion
        {
            get
            {
                return this.m_displayingProportion;
            }
        }

        public DockPane DockPane
        {
            get
            {
                return this.m_dockPane;
            }
        }

        public bool IsDisplaying
        {
            get
            {
                return this.m_isDisplaying;
            }
        }

        public Rectangle LogicalBounds
        {
            get
            {
                return this.m_logicalBounds;
            }
        }

        public NestedPaneCollection NestedPanes
        {
            get
            {
                return this.m_nestedPanes;
            }
        }

        public Rectangle PaneBounds
        {
            get
            {
                return this.m_paneBounds;
            }
        }

        public DockPane PreviousPane
        {
            get
            {
                return this.m_previousPane;
            }
        }

        public double Proportion
        {
            get
            {
                return this.m_proportion;
            }
        }

        public Rectangle SplitterBounds
        {
            get
            {
                return this.m_splitterBounds;
            }
        }
    }
}

