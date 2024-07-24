using Matrix3D.Structures;
using OpenTK.Mathematics;

namespace Matrix3D.Rendering
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

        public static void GeneratePlane(int width, int height, int resolution, out Vertex[] vertices, out uint[] indices)
        {
            List<Vertex> verts = new List<Vertex>();
            List<uint> inds = new List<uint>();
            
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    verts.Add(new Vertex(x - width / 2, 0, y - height / 2, x / width, y / height, 0, 1, 0));

                    //INDICES
                    if (x < width - 1 && y < height - 1)
                    {
                        //Triangle Bottom
                        inds.Add((uint)Convert(x, y));
                        inds.Add((uint)Convert(x + 1, y));
                        inds.Add((uint)Convert(x + 1, y + 1));

                        //Triangle Top
                        inds.Add((uint)Convert(x + 1, y + 1));
                        inds.Add((uint)Convert(x, y + 1));
                        inds.Add((uint)Convert(x, y));
                    }

                }
            }
            vertices = verts.ToArray();
            indices = inds.ToArray();

            int Convert(int x, int y) //converts 2d index to 1d
            {
                return y * height + x;
            }
        }
    }
}
