#version 460 core

out vec4 FragColor;

in vec2 _uvCoords;
uniform sampler2D screenTexture;

void main()
{
	FragColor = texture(screenTexture, _uvCoords);
	//FragColor = vec4(_uvCoords, 0.0f, 1.0f);
}