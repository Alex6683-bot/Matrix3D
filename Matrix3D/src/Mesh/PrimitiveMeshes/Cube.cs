using Matrix3D.GL_SetUp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using OpenTK.Mathematics;
using System.Text;
using System.Threading.Tasks;
using Matrix3D.Structures;

namespace Matrix3D.Rendering
{
    static class Cube
    {

        public static Vertex[] vertices =
        {
             // Positions        // UVs        // Normals
            // Front face
            new Vertex(-0.5f, -0.5f,  0.5f,  0.0f, 0.0f,  0.0f,  0.0f,  1.0f),  // Bottom-left
            new Vertex(0.5f, -0.5f,  0.5f,  1.0f, 0.0f,  0.0f,  0.0f,   1.0f),  // Bottom-right
            new Vertex(0.5f,  0.5f,  0.5f,  1.0f, 1.0f,  0.0f,  0.0f,   1.0f),  // Top-right
            new Vertex(-0.5f,  0.5f,  0.5f,  0.0f, 1.0f,  0.0f,  0.0f,  1.0f),  // Top-left
            
            // Back face
            new Vertex(-0.5f, -0.5f, -0.5f,  0.0f, 0.0f,  0.0f,  0.0f, -1.0f),  // Bottom-left
            new Vertex(0.5f, -0.5f, -0.5f,  1.0f, 0.0f,  0.0f,  0.0f, -1.0f),  // Bottom-right
            new Vertex(0.5f,  0.5f, -0.5f,  1.0f, 1.0f,  0.0f,  0.0f, -1.0f),  // Top-right
            new Vertex(-0.5f,  0.5f, -0.5f,  0.0f, 1.0f,  0.0f,  0.0f, -1.0f),  // Top-left
            
            // Left face
            new Vertex(-0.5f,  0.5f,  0.5f,  1.0f, 0.0f, -1.0f,  0.0f,  0.0f),  // Top-right
            new Vertex(-0.5f,  0.5f, -0.5f,  1.0f, 1.0f, -1.0f,  0.0f,  0.0f),  // Top-left
            new Vertex(-0.5f, -0.5f, -0.5f,  0.0f, 1.0f, -1.0f,  0.0f,  0.0f),  // Bottom-left
            new Vertex(-0.5f, -0.5f,  0.5f,  0.0f, 0.0f, -1.0f,  0.0f,  0.0f),  // Bottom-right
            
            // Right face
            new Vertex(0.5f,  0.5f,  0.5f,  1.0f, 0.0f,  1.0f,  0.0f,  0.0f),  // Top-left
            new Vertex(0.5f,  0.5f, -0.5f,  1.0f, 1.0f,  1.0f,  0.0f,  0.0f),  // Top-right
            new Vertex(0.5f, -0.5f, -0.5f,  0.0f, 1.0f,  1.0f,  0.0f,  0.0f),  // Bottom-right
            new Vertex(0.5f, -0.5f,  0.5f,  0.0f, 0.0f,  1.0f,  0.0f,  0.0f),  // Bottom-left
            
            // Top face
            new Vertex(-0.5f,  0.5f,  0.5f,  0.0f, 1.0f,  0.0f,  1.0f,  0.0f),  // Top-left
            new Vertex(0.5f,  0.5f,  0.5f,  1.0f, 1.0f,  0.0f,  1.0f,  0.0f),  // Top-right
            new Vertex(0.5f,  0.5f, -0.5f,  1.0f, 0.0f,  0.0f,  1.0f,  0.0f),  // Bottom-right
            new Vertex(-0.5f,  0.5f, -0.5f,  0.0f, 0.0f,  0.0f,  1.0f,  0.0f),  // Bottom-left
            
            // Bottom face
            new Vertex(-0.5f, -0.5f,  0.5f,  0.0f, 1.0f,  0.0f, -1.0f,  0.0f),  // Top-right
            new Vertex(0.5f, -0.5f,  0.5f,  1.0f, 1.0f,  0.0f, -1.0f,  0.0f),  // Top-left
            new Vertex(0.5f, -0.5f, -0.5f,  1.0f, 0.0f,  0.0f, -1.0f,  0.0f),  // Bottom-left
            new Vertex(-0.5f, -0.5f, -0.5f,  0.0f, 0.0f,  0.0f, -1.0f,  0.0f),  // Bottom-right
        };

        public static uint[] indices =
        {
           // Front face
           0, 1, 2, 2, 3, 0, 
           // Back face
           4, 5, 6, 6, 7, 4, 
           // Left face
           8, 9, 10, 10, 11, 8,
           // Right face
           12, 13, 14, 14, 15, 12,
           // Top face
           16, 17, 18, 18, 19, 16,
           // Bottom face
           20, 21, 22, 22, 23, 20
        };
    }
}
