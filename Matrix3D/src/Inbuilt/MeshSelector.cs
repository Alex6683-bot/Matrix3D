using Matrix3D.GL_SetUp;
using Matrix3D.Rendering;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

namespace Matrix3D.Inbuilt
{
    class MeshSelector
    {
        FBO selectionBuffer;

        public MeshSelector()
        {
            selectionBuffer = new FBO();
        }
        public Mesh? GetObjectOnSelection(Vector2 mouseCoords)
        {
            RenderToSelectionTexture();

            selectionBuffer.Bind();

            float[] pixel = new float[3];
            GL.ReadPixels((int)mouseCoords.X, (int)(WindowConfig.height - mouseCoords.Y), 1, 1, PixelFormat.Rgb, PixelType.Float, pixel);

            int ID = ConvertRGBToID(new Vector3(pixel[0] * 255, pixel[1] * 255, pixel[2] * 255));
            IEnumerable<Mesh>? mesh = MeshManager.meshes.Where(x => x.ID == ID);

            selectionBuffer.Unbind();
            return mesh == null ? null : mesh.FirstOrDefault();
        }


        private void RenderToSelectionTexture()
        {
            selectionBuffer.Bind();
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            for (int i = 0; i < MeshManager.meshes.Count; i++)
            {
                MeshManager.meshes[i].lightingEnabled = false;
                MeshManager.meshes[i].renderColor = ConvertIDToRGB(MeshManager.meshes[i].ID);
            }
            MeshManager.RenderMeshes();
            selectionBuffer.Unbind();
        }

        private Vector3 ConvertIDToRGB(int ID)
        {
            float B = ID % 256;
            float G = (ID - B) / 256 % 256;
            float R = (ID - B) / 256 * 256 - G / 256;

            return new Vector3(R, G, B) / 255;
        }

        private int ConvertRGBToID(Vector3 color)
        {
            return (int)(color.X * (256 * 256) + color.Y * (256 * 256) + color.Z);
        }
    }
}