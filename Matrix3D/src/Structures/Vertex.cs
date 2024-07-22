using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix3D.Structures
{
    struct Vertex
    {
        public Vector3 position;
        public Vector2 UV;
        public Vector3 normal;
        public Vertex(float x, float y, float z, float uvX, float uvY, float normalX = 0, float normalY = 0, float normalZ = 0)
        {
            position = new Vector3(x, y, z);
            UV = new Vector2(uvX, uvY);
            normal = new Vector3(normalX, normalY, normalZ);
        }
    }
}
