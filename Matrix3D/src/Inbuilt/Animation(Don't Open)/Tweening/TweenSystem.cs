using Matrix3D.src.Inbuilt.Animation.Tweening;
using OpenTK.Mathematics;
using System.Runtime.InteropServices;

namespace Matrix3D.Inbuilt
{
    class TweenSystem
    {
        private TweenConfig _tweenConfig;
        private bool _isTweenRunning = false;


        private float _progressionF;

        private Vector3 _progressionV3;
        private Vector2 _progressionV2;
        public TweenConfig tweenConfig { get => _tweenConfig; }
        public bool isTweenRunning { get => _isTweenRunning; }

        public TweenSystem(TweenConfig config)
        {
            _tweenConfig = config;
        }

        public void Start() => _isTweenRunning = true;
        public void Update(ref float value, float start, float end)
        {
            if (_isTweenRunning)
            {
                _progressionF = float.Lerp(start, end, _tweenConfig.speed);
                value = Ease(_progressionF, tweenConfig.easingType);

                _isTweenRunning = !((end - value) <= 0.1);
            }
        }
        public void Update(ref Vector3 value, Vector3 start, Vector3 end)
        {
            if (_isTweenRunning)
            {
                _progressionV3 = Vector3.Lerp(start, end, _tweenConfig.speed);

                float x = Ease(_progressionV3.X, tweenConfig.easingType);
                float y = Ease(_progressionV3.Y, tweenConfig.easingType);
                float z = Ease(_progressionV3.X, tweenConfig.easingType);

                _isTweenRunning = !((end - value).Length <= 0);
                value = new Vector3(x, y, z);
                //value = _progressionV3;
            }
        }
        public void Update(ref Vector2 value, Vector2 start, Vector2 end)
        {
            if (_isTweenRunning)
            {
                _progressionV2 = Vector2.Lerp(start, end, _tweenConfig.speed);
                float x = Ease(_progressionV2.X, tweenConfig.easingType);
                float y = Ease(_progressionV2.Y, tweenConfig.easingType);

                _isTweenRunning = !((end - value).Length <= 0.1);
                value = new Vector2(x, y);
            }
        }

        public float Ease(float progression, EasingType easingType)
        {
            return easingType switch
            {
                EasingType.easeInSine => easeInSine(progression),
                EasingType.easeOutSine => easeOutSine(progression),
                EasingType.easeInOutSine => easeInOutSine(progression),
                EasingType.easeInQuad => easeInQuad(progression),
                EasingType.easeOutQuad => easeOutQuad(progression),
                EasingType.easeInOutQuad => easeInOutQuad(progression),
                EasingType.easeInCubic => easeInCubic(progression),
                EasingType.easeOutCubic => easeOutCubic(progression),
                EasingType.easeInOutCubic => easeInOutCubic(progression),

            };
        }

        #region EASING FUNCTIONS
        float easeInSine(float x) => (float)(1 - Math.Cos((x * Math.PI) / 2));
        float easeOutSine(float x) => (float)(Math.Sin((x * Math.PI) / 2));
        float easeInOutSine(float x) => (float)(-(Math.Cos(Math.PI * x) - 1) / 2);
        float easeInQuad(float x) => (float)(x * x);
        float easeOutQuad(float x) => (float)(1 - (1 - x) * (1 - x));
        float easeInOutQuad(float x) => (float)(x < 0.5 ? 2 * x * x : 1 - Math.Pow(-2 * x + 2, 2) / 2);
        float easeInCubic(float x) => (float)(x * x * x);
        float easeOutCubic(float x) => (float)(1 - Math.Pow(1 - x, 3));
        float easeInOutCubic(float x) => (float)(x < 0.5 ? 4 * x * x * x : 1 - Math.Pow(-2 * x + 2, 3) / 2);
        #endregion
}
}
