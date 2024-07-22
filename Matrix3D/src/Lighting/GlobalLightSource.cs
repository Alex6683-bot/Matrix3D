using System;
using OpenTK.Mathematics;
using Matrix3D.GL_SetUp;

namespace Matrix3D.Lighting
{
    static class GlobalLightSource
    {
        public static Vector3 position = new Vector3(3, 3, 1);
        public static Vector3 lightColor = new Vector3(1, 1, 1);
        public static float ambientBrightness = 0.1f;
        public static void SetUniforms(Shader shader)
        {
            shader.SetUniformVector3("globalLightPosition", position);
            shader.SetUniformVector3("lightColor", lightColor);
            shader.SetUniformFloat("ambientBrightness", ambientBrightness);
        }
    }
}
