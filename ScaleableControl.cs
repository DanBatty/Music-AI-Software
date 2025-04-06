using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_AI_Software.UI
{
    using Music_AI_Software.Interfaces;

    // Base scalable control
    public class ScalableControl : Control, IScalableControl
    {
        public void StoreOriginalDimensions()
    {
            throw new NotImplementedException();
        }
    }
}
