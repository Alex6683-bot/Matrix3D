using Matrix3D.GL_SetUp;
using OpenTK.Graphics.ES11;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;
using Matrix3D.Rendering;
using Matrix3D.Inbuilt;

namespace Matrix3D.src
{
    class Client : GameWindow
    {
        Viewport viewport;

        public static float deltaTime;
        public Client(int width, int height, string title) : base(GameWindowSettings.Default, new NativeWindowSettings()
        {
            Size = (width, height),
            Title = title
        })
        { }

        protected override void OnLoad()
        {
            base.OnLoad();
            GL.ClearColor(0.05f, 0.05f, 0.05f, 1.0f);
            //Initialize
            viewport = new Viewport();
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            viewport.RenderViewPort();

            SwapBuffers();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            deltaTime = (float)e.Time;

            base.OnUpdateFrame(e);

            viewport.UpdateViewport();
            viewport.Input(MouseState, KeyboardState);
        }

    }
}
