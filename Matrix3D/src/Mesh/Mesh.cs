using Matrix3D.GL_SetUp;
using OpenTK.Graphics.ES11;
using OpenTK.Mathematics;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using Matrix3D.Lighting;
using Matrix3D.Rendering;
using Matrix3D.Structures;
using Matrix3D.Inbuilt;

namespace Matrix3D.Rendering
{
    public enum PrimitiveMeshType
    {
        Cube
    }
    class Mesh : ICloneable
    {                                 
        public bool lightingEnabled = true;
        public Vector3 position = new Vector3(0, 0, 0);
        public Vector3 size = new Vector3(1, 1, 1);
        public Vector3 rotation = new Vector3(0, 0, 0);
        public Vector3 color = new Vector3(0.8f, 0.8f, 0.8f);
        //Rendering
        VAO _vao; //this would be used for rendering each object

        VBO _vbo;
        EBO _ebo;
        Shader meshShader;

        Vertex[] meshVertices;
        uint[] meshIndices;

        public int ID;

        public Mesh(Vertex[] vertices, uint[] indices, Shader shader)
        {
            this.meshVertices = vertices;
            this.meshIndices = indices;
            this.meshShader = shader;

            InitializeMesh();
            ID = _vbo.ID;
        }

        public Mesh(Vertex[] vertices, uint[] indices)
        {
            this.meshVertices = vertices;
            this.meshIndices = indices;
            this.meshShader = ShaderStorage.defaultMeshShader;

            InitializeMesh();
            ID = _vbo.ID;
        }

        public Mesh(PrimitiveMeshType primitiveMesh)
        {
            this.meshVertices = primitiveMesh switch
            {
                PrimitiveMeshType.Cube => Cube.vertices,
                _ => Cube.vertices
            };
            
            this.meshIndices = primitiveMesh switch
            {
                PrimitiveMeshType.Cube => Cube.indices,
                _ => Cube.indices
            };

            this.meshShader = ShaderStorage.defaultMeshShader;
            
            InitializeMesh();
            ID = _vbo.ID;
        }
        public Mesh(PrimitiveMeshType primitiveMesh, Shader shader)
        {
            this.meshVertices = primitiveMesh switch
            {
                PrimitiveMeshType.Cube => Cube.vertices,
                _ => Cube.vertices
            };

            this.meshIndices = primitiveMesh switch
            {
                PrimitiveMeshType.Cube => Cube.indices,
                _ => Cube.indices
            };

            this.meshShader = shader;

            InitializeMesh();
            ID = _vbo.ID;
        }
        public void RenderMesh(Camera camera)
        {
            meshShader.RunShader();
            GlobalLightSource.SetUniforms(meshShader);
            SetUniforms();

            _vao.Bind();

            camera.SetUpEyeSpace(meshShader);
            camera.UpdateCamera();

            GL.DrawElements(PrimitiveType.Triangles, meshIndices.Length, DrawElementsType.UnsignedInt, 0);

        }

        private void SetUniforms()
        {
            Matrix4 rotationMatrix = Matrix4.CreateRotationX(MathHelper.DegreesToRadians(rotation.X)) * 
                                     Matrix4.CreateRotationY(MathHelper.DegreesToRadians(rotation.Y)) * 
                                     Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(rotation.Z));

            Matrix4 modelMatrix = Matrix4.CreateScale(size) * rotationMatrix * Matrix4.CreateTranslation(position);
            Matrix4 normalMatrix = Matrix4.Transpose(Matrix4.Invert(rotationMatrix * Matrix4.CreateScale(size)));

            meshShader.SetUniformMatrix4("modelMatrix", modelMatrix);
            meshShader.SetUniformMatrix4("normalMatrix", normalMatrix);
            meshShader.SetUniformVector3("color", color);
            meshShader.SetUniformFloat("lightingEnabled", lightingEnabled ? 1 : 0);
        }

        private void InitializeMesh()
        {
            _vao = new VAO();
            _vao.Bind();

            _vbo = new VBO(meshVertices);
            _ebo = new EBO(meshIndices);

            _ebo.Bind();
            _vbo.Bind();

            _vao.LinkAttributes(meshShader.GetAttribLocation("vertexPosition"), 3, sizeof(float) * 8, 0);
            _vao.LinkAttributes(meshShader.GetAttribLocation("uvCoords"), 2, sizeof(float) * 8, 3 * sizeof(float));
            _vao.LinkAttributes(meshShader.GetAttribLocation("normal"), 3, sizeof(float) * 8, 5 * sizeof(float));

            _vao.UnBind();
            _vbo.UnBind();
            _ebo.UnBind();
        }

        public object Clone()
        {
            Mesh clonedMesh = new Mesh(this.meshVertices, this.meshIndices, this.meshShader);
            clonedMesh.position = this.position;
            clonedMesh.size = this.size;
            clonedMesh.rotation = this.rotation;
            clonedMesh.color = this.color;
            clonedMesh.ID = this.ID;
            clonedMesh._vao = this._vao;
            clonedMesh._vbo = this._vbo;
            clonedMesh._ebo = this._ebo;

            return clonedMesh;
        }
    }
}
