using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;

namespace Matrix3D.GL_SetUp
{
    class EBO
    {
        public int ID;

        public EBO(uint[] indices)
        {
            int size = indices.Length * sizeof(uint);
            //Create Buffer
            ID = GL.GenBuffer();
            //Bind the currently created Buffer
            Bind();

            GL.BufferData(BufferTarget.ElementArrayBuffer, size, indices, BufferUsageHint.StaticDraw);
        }

        public void Bind() => GL.BindBuffer(BufferTarget.ElementArrayBuffer, ID);
        public void UnBind() => GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
        public void Delete() => GL.DeleteBuffer(ID);
    }
}
