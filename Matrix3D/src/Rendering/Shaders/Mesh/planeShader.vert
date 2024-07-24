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

float GenerateWave(float val, int octaves)
{
	float finalValue = 0;
	float amplitude = 1;
	float frequency = 1;
	for (int i = 0; i < octaves; i++)
	{
		finalValue += sin(val * frequency) * amplitude;
		amplitude *= 0.5f;
		frequency *= 1.5f;
	}
	return finalValue;
}
void main()
{
	vec4 worldPos = vec4(vertexPosition, 1.0) * modelMatrix;
	//worldPos.y = worldPos.y + GenerateWave(worldPos.x, 10) * GenerateWave(worldPos.z, 20) * 0.5f;
	gl_Position = worldPos * viewMatrix * projectionMatrix;
	_uvCoords = uvCoords;

	//Normal Recalculation
	/*float neighbour
	RecalculateNormals(vec3(worldPos.x, worldPos.y + GenerateWave(worldPos.x, 10) * GenerateWave(worldPos.z, 20) * 0.5f))*/


	vec4 modifiedNormals = normalize(vec4(normal, 0.0) * normalMatrix);
	_normal = vec3(modifiedNormals);
	fragPos = vec3(worldPos.x, worldPos.y, worldPos.z);
}

/*vec3 RecalculateNormals(vec3 neighbour1, vec3 pos)
{
	vec3 tangent = neighbour1 - pos;
	return normalize(cross(tangent, bitangent));
}*/