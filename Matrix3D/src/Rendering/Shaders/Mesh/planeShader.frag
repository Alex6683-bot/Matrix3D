#version 460 core

out vec4 FragColor;

in vec2 _uvCoords;
in vec3 _normal;
in vec3 fragPos;

uniform vec3 color;
uniform vec3 globalLightPosition;
uniform vec3 lightColor;
uniform float lightingEnabled;
uniform vec3 cameraPosition;
uniform float ambientBrightness;

void main()
{
	if (lightingEnabled == 1)
	{
		//Lighting
		vec3 lightDirection = normalize(cameraPosition - fragPos);
		float diffuse = max(0, dot(_normal * (gl_FrontFacing ? -1 : 1), lightDirection));
		FragColor = vec4(color * (diffuse + ambientBrightness), 1.0);
		//FragColor = vec4(_normal, 1.0f);
	}
	else FragColor = vec4(color, 1.0f);

}