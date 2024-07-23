using Matrix3D.GL_SetUp;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using Matrix3D.Inbuilt;
using Matrix3D.Rendering;
using Matrix3D.Structures;

namespace Matrix3D.Inbuilt
{
    class Viewport
    {
        MeshSelector meshSelector;

        #region INITIALIZATION
        public Viewport()
        {
            /*Mesh mesh = new Mesh(PrimitiveMeshType.Cube);
            mesh.position = new Vector3(1, 0, 0);
            mesh.rotation = new Vector3(0, 40, 0);
            MeshManager.meshes.Add(mesh);*/

            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    Random rand = new Random();
                    Mesh mesh = new Mesh(PrimitiveMeshType.Cube);
                    mesh.position = new Vector3(x * 2, 0, y * 2);
                    mesh.color = new Vector3((float)rand.NextDouble(), (float)rand.NextDouble(), (float)rand.NextDouble());
                    MeshManager.meshes.Add(mesh);
                }
            }

            InitializeViewport();
        }


        GridPlane gridPlane;
        public void InitializeViewport()
        {
            CameraController.SetCamera(new Camera(new Vector3(0, 0, 0)));
            CameraController.currentCamera.center = MeshManager.meshes[0].position;

            gridPlane = new GridPlane();
            meshSelector = new MeshSelector();
        }
        #endregion

        #region UPDATE
        public void RenderViewPort()
        {
            MeshManager.RenderMeshes();
            gridPlane.RenderPlane();
            MeshManager.meshes[0].color = new Vector3(1, 1, 0);
        }

        public void UpdateViewport() { }
        #endregion

        #region INPUT
        public void Input(MouseState mouse, KeyboardState keyboard)
        {
            if (mouse.IsButtonReleased(MouseButton.Left)) SelectMeshOnViewPort(mouse.Position);
            CameraController.currentCamera.Input(mouse, keyboard);
        }

        private void SelectMeshOnViewPort(Vector2 mousePos)
        {
            Mesh? selectedMesh = meshSelector.GetObjectOnSelection(mousePos);
            if (selectedMesh != null) CameraController.currentCamera.TweenCamera(selectedMesh.position);
        }
        #endregion
    }
}
