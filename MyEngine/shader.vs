#version 330 core
layout (location = 0) in vec3 aPos;
layout (location = 1) in vec3 aNormal; // 接收法线

out vec3 Normal; // 传给片段着色器
out vec3 FragPos; // 当前像素的世界坐标

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;

void main()
{
    gl_Position = projection * view * model * vec4(aPos, 1.0);
    FragPos = vec3(model * vec4(aPos, 1.0)); // 算出在世界里的真实位置
    Normal = aNormal;
}