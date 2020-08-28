﻿using System.Windows.Forms;

namespace PCX
{
    class FlowPanelLeftScrollbar : FlowLayoutPanel
    {
        private const int WS_EX_LEFTSCROLLBAR = 0x00004000;
        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle = cp.ExStyle | WS_EX_LEFTSCROLLBAR;
                return cp;
            }
        }

    }
}
