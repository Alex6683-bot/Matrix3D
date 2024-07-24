using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Matrix3D.GL_SetUp;
using Matrix3D.Inbuilt;
using OpenTK.Mathematics;

namespace Matrix3D.Rendering
{
    static class ShaderStorage
    {
        public static Shader defaultMeshShader = new Shader(GetRootFolderPath() + @"\src\Rendering\Shaders\Mesh\meshShader.vert", GetRootFolderPath() + @"\src\Rendering\Shaders\Mesh\meshShader.frag");
        public static Shader screenQuadShader = new Shader(GetRootFolderPath() + @"\src\Rendering\Shaders\ScreenQuad\screenQuad.vert", GetRootFolderPath() + @"\src\Rendering\Shaders\ScreenQuad\screenQuad.frag");
        public static Shader planeShader = new Shader(GetRootFolderPath() + @"\src\Rendering\Shaders\Mesh\planeShader.vert", GetRootFolderPath() + @"\src\Rendering\Shaders\Mesh\planeShader.frag");
        public static string GetRootFolderPath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\");
        }
    }
}