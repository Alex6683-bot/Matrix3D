using Matrix3D.Rendering;
using System;
using Matrix3D.GL_SetUp;
using OpenTK.Mathematics;
using System.Security.Cryptography.X509Certificates;
using Matrix3D.Structures;

namespace Matrix3D.Inbuilt;

class GridPlane
{
    public float depth = 1;
    //Data
    Vertex[] vertices = {

       new Vertex(1f,  1f, 0.0f, 1.0f, 1.0f),  // top right
       new Vertex(1f, -1f, 0.0f, 1.0f, 0.0f),  // bottom right
       new Vertex(-1f, -1f, 0.0f, 0.0f, 0.0f),  // bottom left
       new Vertex(-1f,  1f, 0.0f, 0.0f, 1.0f)   // top left

    };

    uint[] indices =
    {
        0, 1 ,2,
        2, 3, 0

    };

    Shader gridPlaneShader = new Shader(
    @"C:\Users\Alexm\OneDrive\Desktop\Files\Coding\C#\TK\Matrix3D\Matrix3D\src\Inbuilt\Grid\Shaders\gridPlane.vert",
    @"C:\Users\Alexm\OneDrive\Desktop\Files\Coding\C#\TK\Matrix3D\Matrix3D\src\Inbuilt\Grid\Shaders\gridPlane.frag"
    );
    Mesh plane;

    private void SetUniforms()
    {
        gridPlaneShader.SetUniformFloat("cameraRadius", CameraController.currentCamera.radius);
        gridPlaneShader.SetUniformFloat("depth", depth);
    }
    public GridPlane()
    {
        plane = new Mesh(vertices, indices, gridPlaneShader);
    }

    public void RenderPlane()
    {
        plane.RenderMesh(CameraController.currentCamera);
        SetUniforms();
    }

}
