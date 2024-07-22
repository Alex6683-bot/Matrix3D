using Matrix3D.Rendering;
using System;

namespace Matrix3D.Inbuilt
{
    static class MeshManager
    {
        public static List<Mesh> meshes = new List<Mesh>();

        public static void SetMeshesToDefault()
        {
            for (int i = 0; i < meshes.Count; i++)
            {
                meshes[i].lightingEnabled = true;
                meshes[i].renderColor = meshes[i].color;
            }
        }
        public static void RenderMeshes()
        {
            for (int i = 0; i < meshes.Count; i++) meshes[i].RenderMesh(CameraController.currentCamera);
        }

    }
}