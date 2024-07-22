using Matrix3D.Inbuilt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix3D.src.Inbuilt.Animation.Tweening
{
    public enum EasingType
    {
        easeInSine,
        easeOutSine,
        easeInOutSine,
        easeInQuad,
        easeOutQuad,
        easeInOutQuad,
        easeInCubic,
        easeOutCubic,
        easeInOutCubic
    }
    class TweenConfig
    {
        public EasingType easingType;
        public float speed;


        public TweenConfig(EasingType easingType, float speed)
        {
            this.easingType = easingType;
            this.speed = speed;
        }
    }
}
