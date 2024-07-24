using Matrix3D.Inbuilt;
using Matrix3D.Rendering;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Mathematics;

namespace Matrix3D.src.Inbuilt
{
    class ViewportInputHandler
    {
        MeshSelector meshSelector;
        public ViewportInputHandler()
        {
            meshSelector = new MeshSelector();
        }


        public void UpdateInput(MouseState mouse, KeyboardState keyboard)
        {
            KeyboardInput(keyboard);
            MouseInput(mouse);
            CameraController.currentCamera.Input(mouse, keyboard);
        }

        private void KeyboardInput(KeyboardState keyboard)
        {
            if (keyboard.IsKeyPressed(Keys.Escape)) Environment.Exit(69);
        }
        private void MouseInput(MouseState mouse)
        {
            if (mouse.IsButtonReleased(MouseButton.Left)) SelectMeshOnViewPort(mouse.Position);
        }
        private void SelectMeshOnViewPort(Vector2 mousePos)
        {
            Mesh? selectedMesh = meshSelector.GetObjectOnSelection(mousePos);
            if (selectedMesh != null) CameraController.currentCamera.TweenCamera(selectedMesh.position);
        }
    }
}
