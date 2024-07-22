#version 460 core

out vec4 FragColor;
in vec2 _uvCoords;

uniform float borderThickness;
uniform float lineThickness;
uniform float gridResolution;

float grid(vec2 uv)
{
	vec2 grid_UV = fract(uv);
	return max(grid_UV.x, grid_UV.y);
}
void main()
{
	//Borders
	float xBorder = min(step(borderThickness, _uvCoords.x), step(_uvCoords.x, 1 - borderThickness));
	float yBorder = min(step(borderThickness, _uvCoords.y), step(_uvCoords.y, 1 - borderThickness));

	float border = min(xBorder, yBorder);

	//Grid
	float gridUV = grid(_uvCoords * gridResolution);
	gridUV = step(1 - lineThickness, gridUV);


	float color = max(1 - border, gridUV);
	
	if (color < 1)
	{
		discard;
	}
	else
	{
		FragColor = vec4(vec3(0.8f), 1.0f);
		if (_uvCoords.y >= borderThickness && _uvCoords.y <= 1 - borderThickness && _uvCoords.x >= borderThickness && _uvCoords.x <= 1 - borderThickness)
		{
			// Y Axis highlight
			if (_uvCoords.y > (0.5 - (lineThickness / gridResolution)) && _uvCoords.y < 0.5f)
			{
				FragColor = vec4(0.0f, 0.0f, 1.0f, 1.0f);
			}
			// X Axis highlight
			if (_uvCoords.x > (0.5 - (lineThickness / gridResolution)) && _uvCoords.x < 0.5f)
			{
				FragColor = vec4(1.0f, 0.0f, 0.0f, 1.0f);
			}
		}
	}

	//FragColor = vec4(vec3(border), 1.0f);
}