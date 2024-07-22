using Matrix3D.Structures;
using OpenTK.Mathematics;

namespace Matrix3D.src.Mesh.PrimitiveMeshes
{
    static class Plane
    {
        public static Vertex[] vertices = 
        {
            new Vertex(1f,  1f, 0.0f, 1.0f, 1.0f),  // top right
            new Vertex(1f, -1f, 0.0f, 1.0f, 0.0f),  // bottom right
            new Vertex(-1f, -1f, 0.0f, 0.0f, 0.0f),  // bottom left
            new Vertex(-1f,  1f, 0.0f, 0.0f, 1.0f)   // top left
        };

        public static uint[] indices =
        {
            0, 1 ,2,
            2, 3, 0
        };

        /*public static Vertex[] GeneratePlane(int width, int height, int resolution)
        {
            Vertex[] vertices = new Vertex[width * height * resolution];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int index = x * width + y;
                    vertices[index] = new Vertex(x, 0, y, 0, 0);
                }
            }
        }*/
    }
}
