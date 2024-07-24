using Matrix3D.GL_SetUp;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using Matrix3D.Inbuilt;
using Matrix3D.Rendering;
using Matrix3D.Structures;
using Matrix3D.src.Inbuilt;

namespace Matrix3D.Inbuilt
{
    class Viewport
    {
        #region INITIALIZATION
        ViewportInputHandler input;
        public Viewport()
        {
            Plane.GeneratePlane(100, 100, 1, out Vertex[] vertices, out uint[] indices);
            Mesh mesh = new Mesh(vertices, indices, ShaderStorage.planeShader);
            mesh.position = new Vector3(0, 10, 0);
            mesh.lightingEnabled = true;
            mesh.size = new Vector3(0.1f, 1, 0.1f);
            //mesh.rotation = new Vector3(90, 0, 0);
            MeshManager.meshes.Add(mesh);
            //MeshManager.meshes.Add(new Mesh(PrimitiveMeshType.Cube));
            InitializeViewport();
        }


        GridPlane gridPlane;
        public void InitializeViewport()
        {
            CameraController.SetCamera(new Camera(new Vector3(0, 0, 0)));
            CameraController.currentCamera.center = MeshManager.meshes[0].position;

            gridPlane = new GridPlane();
            input = new ViewportInputHandler();
        }
        #endregion

        #region UPDATE
        public void RenderViewPort()
        {
            MeshManager.RenderMeshes();
            gridPlane.RenderPlane();
        }

        public void UpdateViewport(MouseState mouse, KeyboardState keyboard) 
        {
            input.UpdateInput(mouse, keyboard);
        }
        #endregion
    }
}
