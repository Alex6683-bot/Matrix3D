#version 460 core

out vec4 FragColor;

in vec2 _uvCoords;
in vec3 nearPoint;
in vec3 farPoint;

uniform mat4 projectionMatrix;
uniform mat4 viewMatrix;

float near = 0.01;
float far = 100;

vec4 grid(vec3 fragPos3D, float scale, bool drawAxis) 
{
    vec2 coord = fragPos3D.xz * scale;
    vec2 derivative = fwidth(coord);
    vec2 grid = abs(fract(coord - 0.5) - 0.5) / derivative;
    float line = min(grid.x, grid.y);
    float minimumz = min(derivative.y, 1);
    float minimumx = min(derivative.x, 1);
    vec4 color = vec4(0.2, 0.2, 0.2, 1.0 - min(line, 1.0));
    if(fragPos3D.x > -0.1 * minimumz && fragPos3D.x < 0.1 * minimumz)
        color.z = 1.0;
    if(fragPos3D.z > -0.1 * minimumx && fragPos3D.z < 0.1 * minimumx)
        color.x = 1.0;
    return color;
}

float computeDepth(vec3 pos) 
{
    vec4 clip_space_pos = vec4(pos.xyz, 1.0) * viewMatrix * projectionMatrix;
    return (clip_space_pos.z / clip_space_pos.w) * 0.5f + 0.5;
}

float computeLinearDepth(vec3 pos) 
{
    vec4 clip_space_pos = vec4(pos.xyz, 1.0) * viewMatrix * projectionMatrix;
    float clip_space_depth = (clip_space_pos.z / clip_space_pos.w);
    float linearDepth = (2.0 * near * far) / (far + near - clip_space_depth * (far - near));
    return linearDepth / far;
}

void main() 
{
    float t = -nearPoint.y / (farPoint.y - nearPoint.y);
    vec3 fragPos3D = nearPoint + t * (farPoint - nearPoint);

    gl_FragDepth = computeDepth(fragPos3D);

    float linearDepth = computeLinearDepth(fragPos3D) * 1.1;
    float fading = max(0, (0.5 - linearDepth));

    FragColor = (grid(fragPos3D, 10, true) + grid(fragPos3D, 0.1, true)) * float(t > 0);
    FragColor.a *= fading;
}


//The code is mostly copied from https://asliceofrendering.com/scene%20helper/2020/01/05/InfiniteGrid/ because, I can't seem to understand the math...... but thank you!
//hipity hopity your now my property