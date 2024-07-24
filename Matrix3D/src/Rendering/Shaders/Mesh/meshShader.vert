#version 460 core

layout (location = 0) in vec3 vertexPosition;
layout (location = 1) in vec2 uvCoords;
layout (location = 2) in vec3 normal;

out vec2 _uvCoords;
out vec3 _normal;
out vec3 fragPos;

uniform mat4 viewMatrix;
uniform mat4 projectionMatrix;
uniform mat4 modelMatrix;
uniform mat4 normalMatrix;


void main()
{
	vec4 worldPos = vec4(vertexPosition, 1.0) * modelMatrix;
	gl_Position = worldPos * viewMatrix * projectionMatrix;
	_uvCoords = uvCoords;

	vec4 modifiedNormals = normalize(vec4(normal, 0.0) * normalMatrix);
	_normal = vec3(modifiedNormals);
	fragPos = vec3(worldPos.x, worldPos.y, worldPos.z);
}