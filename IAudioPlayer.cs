using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_AI_Software.Interfaces
{
    public interface IAudioPlayer
    {

    }

    // UI Scaling interface
    public interface IScalableControl
    {
        void StoreOriginalDimensions();
        void Scale(float widthRatio, float heightRatio);
    }
}

