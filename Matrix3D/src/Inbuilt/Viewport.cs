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
            InitializeViewport();

            Mesh mesh = new Mesh(PrimitiveMeshType.Cube);
            mesh.position = new Vector3(1, 0, 0);
            mesh.rotation = new Vector3(0, 40, 0);
            mesh.lightingEnabled = false;
            //mesh.size = new Vector3(.5f, .5f, .5f);
            MeshManager.meshes.Add(mesh);
        }


        GridPlane gridPlane;
        public void InitializeViewport()
        {
            CameraController.SetCamera(new Camera(new Vector3(0, 0, 0)));

            gridPlane = new GridPlane();
            meshSelector = new MeshSelector();
        }
        #endregion

        #region UPDATE
        public void RenderViewPort()
        {
            MeshManager.SetMeshesToDefault();
            MeshManager.RenderMeshes();
            gridPlane.RenderPlane();
        }

        public void UpdateViewport()
        {
        }
        #endregion

        #region INPUT
        public void Input(MouseState mouse, KeyboardState keyboard)
        {
            if (mouse.IsButtonPressed(MouseButton.Left)) SelectMeshOnViewPort(mouse.Position);
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
