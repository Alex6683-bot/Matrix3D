using Matrix3D.GL_SetUp;
using Matrix3D.Rendering;
using Matrix3D.Structures;
using Matrix3D.Textures;
using Matrix3D.Inbuilt;

namespace Matrix3D.Rendering
{
    class Screen_Quad
    {
        private Vertex[] vertices =
        {
            // Positions      // UVs
            new Vertex(-1.0f,  1.0f, 0.0f,  0.0f, 1.0f), // Top-left
            new Vertex( 1.0f,  1.0f, 0.0f,  1.0f, 1.0f), // Top-right
            new Vertex( 1.0f, -1.0f, 0.0f,  1.0f, 0.0f), // Bottom-right
            new Vertex(-1.0f, -1.0f, 0.0f,  0.0f, 0.0f), // Bottom-left
        };
        private uint[] indices =
        {
            0, 1, 2,
            2, 3, 0 
        };

        Mesh quad;
                                          
        Texture texture;
        public Screen_Quad()
        {
            quad = new Mesh(vertices, indices, ShaderStorage.screenQuadShader);
        }

        public void Render()
        {
            quad.RenderMesh(CameraController.currentCamera);
        }
    }
}
