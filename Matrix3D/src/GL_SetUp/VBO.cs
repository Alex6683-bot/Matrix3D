using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Matrix3D.Structures;
using OpenTK.Graphics.OpenGL;

namespace Matrix3D.GL_SetUp
{
    class VBO
    {
        public int ID;

        public VBO(Vertex[] vertices)
        {
            int size = vertices.Length * Marshal.SizeOf(typeof(Vertex));
            //Create Buffer
            ID = GL.GenBuffer();
            //Bind the currently created Buffer
            Bind();

            GL.BufferData<Vertex>(BufferTarget.ArrayBuffer, size, vertices, BufferUsageHint.StaticDraw);
        }

        public void Bind() => GL.BindBuffer(BufferTarget.ArrayBuffer, ID);
        public void UnBind() => GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        public void Delete() => GL.DeleteBuffer(ID);
    }
}
