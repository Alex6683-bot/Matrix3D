using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;

namespace Matrix3D.GL_SetUp
{
    class VAO
    {
        public int ID;
        public VAO() 
        {
            ID = GL.GenVertexArray();
        }

        public void LinkAttributes(int location, int size, int stride, int offset)
        {
            GL.VertexAttribPointer(location, size, VertexAttribPointerType.Float, false, stride, offset);
            GL.EnableVertexAttribArray(location);
        }
        public void Bind() => GL.BindVertexArray(ID);
        public void UnBind() => GL.BindVertexArray(0);

    }
}
