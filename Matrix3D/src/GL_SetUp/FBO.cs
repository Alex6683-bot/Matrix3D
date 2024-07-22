using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Matrix3D.GL_SetUp
{
    class FBO
    {
        public int ID;
        public int textureID;
        public int renderBufferID;
        public FBO()
        {
            ID = GL.GenFramebuffer();
            Bind();

            CreateTexture();
            CreateRenderBuffer();
            AttachBuffers();

            Unbind();
        }
            
        private void CreateTexture()
        {
            textureID = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, textureID);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb, WindowConfig.width, WindowConfig.height, 0, PixelFormat.Rgb, PixelType.UnsignedByte, 0);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
        }

        private void CreateRenderBuffer()
        {
            renderBufferID = GL.GenRenderbuffer();
            GL.BindRenderbuffer(RenderbufferTarget.Renderbuffer, renderBufferID);

            GL.RenderbufferStorage(RenderbufferTarget.Renderbuffer, RenderbufferStorage.Depth24Stencil8, WindowConfig.width, WindowConfig.height);
            GL.BindRenderbuffer(RenderbufferTarget.Renderbuffer, 0);
        }

        private void AttachBuffers()
        {
            GL.FramebufferTexture2D(FramebufferTarget.Framebuffer, FramebufferAttachment.ColorAttachment0, TextureTarget.Texture2D, textureID, 0);
            GL.FramebufferRenderbuffer(FramebufferTarget.Framebuffer, FramebufferAttachment.DepthStencilAttachment, RenderbufferTarget.Renderbuffer, renderBufferID);
        }
        public void Bind()
        {
            GL.BindFramebuffer(FramebufferTarget.Framebuffer, ID);
            GL.ReadBuffer(ReadBufferMode.ColorAttachment0);
        }
        public void Unbind() => GL.BindFramebuffer(FramebufferTarget.Framebuffer, 0);
    }
}
