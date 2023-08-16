using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BasicFacebookFeatures
{
    public class FormDesigner    
    {
        private Form m_FormToDesign;
        public FormDesigner(Form i_FormToDesign)
        {
            this.m_FormToDesign = i_FormToDesign;
        }
        public void UpdateBackColor(Color i_Color)
        {
            this.m_FormToDesign.BackColor = i_Color;
        }
        public void UpdateFont(Font i_Font)
        {
            SetAllControlsFont(m_FormToDesign.Controls, i_Font);

        }
        public void SetAllControlsFont(Control.ControlCollection ctrls, Font i_Font)
        {
            foreach (Control ctrl in ctrls)
            {
                if (ctrl.Controls != null)
                {
                    SetAllControlsFont(ctrl.Controls, i_Font);
                }
                ctrl.Font = i_Font;
            }
        }

    }
}
