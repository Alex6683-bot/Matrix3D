#version 460 core
layout (location = 0) in vec3 vertexPosition;
layout (location = 1) in vec2 uvCoords;

out vec2 _uvCoords;
out vec3 nearPoint;
out vec3 farPoint;

uniform mat4 viewMatrix;
uniform mat4 projectionMatrix;
uniform mat4 modelMatrix;


vec3 UnprojectPoint(float x, float y, float z) 
{
    mat4 viewInv = inverse(viewMatrix);
    mat4 projInv = inverse(projectionMatrix);
    vec4 unprojectedPoint =  vec4(x, y, z, 1.0) * projInv * viewInv;
    return unprojectedPoint.xyz / unprojectedPoint.w;
}

void main()
{
    vec3 pos = vertexPosition;

    nearPoint = UnprojectPoint(pos.x, pos.y, -1.0f);
    farPoint  = UnprojectPoint(pos.x, pos.y, 1.0f);

    gl_Position = vec4(pos, 1.0);
    _uvCoords = uvCoords;
}

