using System;
using System.Collections.Generic;
using System.Linq;
using OpenTK.Mathematics;
using System.Text;
using System.Threading.Tasks;
using Matrix3D.GL_SetUp;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Matrix3D.Inbuilt
{
    class Camera
    {
        public bool isCameraTweening = false;

        public float FOV = 45.0f;
        public Vector3 position = new Vector3(0.0f, 0.0f, 0.0f);
        public Vector3 center = new Vector3(0, 0, 0);
        public Vector3 tweenCameraTarget;

        public float tweenSpeed = 0.02f;

        Vector3 front;
        public Vector3 up = Vector3.UnitY;
        public Vector3 right = new Vector3(1, 0, 0);

        Matrix4 projection;
        Matrix4 view;

        public float xAngle = 0;
        public float yAngle = 45;
        public float radius = 10;
        public Vector2 rotationSpeedFactor = new Vector2(0.2f, 0.2f);
        public float zoomSpeedFactor = 1;
        public float panningSpeedFactor = 0.01f;
        public Camera(Vector3 _center)
        {
            UpdateCamera();
            OrbitAroundTarget();
            center = _center;
            front = center - position;
        }

        public void UpdateCamera()
        {
            projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(FOV), WindowConfig.width / (float)WindowConfig.height, 0.1f, 10000f);
            view = Matrix4.LookAt(position, position + front, new Vector3(0, 1, 0));

            OrbitAroundTarget();
            front = center - position;

            CalculateLocalCameraAxes();
        }

        public void SetUpEyeSpace(Shader shader)
        {
            shader.SetUniformMatrix4("viewMatrix", view);
            shader.SetUniformMatrix4("projectionMatrix", projection);
            shader.SetUniformVector3("cameraPosition", CameraController.currentCamera.position);
        }

        public void OrbitAroundTarget()
        {
            position.X = center.X + (float)MathHelper.Cos(MathHelper.DegreesToRadians(yAngle)) * (float)MathHelper.Cos(MathHelper.DegreesToRadians(xAngle)) * radius;
            position.Y = center.Y + (float)MathHelper.Sin(MathHelper.DegreesToRadians(yAngle)) * radius;
            position.Z = center.Z + (float)MathHelper.Cos(MathHelper.DegreesToRadians(yAngle)) * (float)MathHelper.Sin(MathHelper.DegreesToRadians(xAngle)) * radius;
        }
        private void CalculateLocalCameraAxes()
        {
            right = Vector3.Normalize(Vector3.Cross(Vector3.UnitY, front));
            up = Vector3.Normalize(Vector3.Cross(right, front));
        }


        public void Input(MouseState mouse, KeyboardState keyboard)
        {
            if (!isCameraTweening)
            {
                //Mouse
                if (mouse.IsButtonDown(MouseButton.Left))
                {
                    xAngle += mouse.Delta.X * rotationSpeedFactor.Y;
                    yAngle += mouse.Delta.Y * rotationSpeedFactor.X;

                    yAngle = MathF.Max(MathF.Min(yAngle, 90 - 0.001f), -90 + 0.001f); //range from 0 to 90, epsilon to avoid flipping
                }
                if (mouse.IsButtonDown(MouseButton.Right))
                {
                    center += right * mouse.Delta.X * panningSpeedFactor;
                    center -= up * mouse.Delta.Y * panningSpeedFactor;
                }
                radius -= mouse.ScrollDelta.Y * zoomSpeedFactor;
            }
            else
            {
                center = Vector3.Lerp(center, tweenCameraTarget, tweenSpeed);

                if ((center - tweenCameraTarget).Length < 0.1) isCameraTweening = false;
            }
            UpdateCamera();
        }
        public void TweenCamera(Vector3 targetPos)
        {
            isCameraTweening = true;
            tweenCameraTarget = targetPos;
        }
    }
}
