using System;


namespace Matrix3D.Inbuilt
{
    static class CameraController
    {
        public static Camera currentCamera;
        public static void SetCamera(Camera camera)
        {
            currentCamera = camera;
        }
        public static void UpdateCurrent()
        {
            currentCamera.UpdateCamera();
        }
    }
}