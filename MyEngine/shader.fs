#version 330 core
out vec4 FragColor;

in vec3 Normal;  
in vec3 FragPos;  
  
uniform vec3 lightPos; // 光源位置 (从C++传进来)
uniform vec3 lightColor; // 光的颜色
uniform vec3 objectColor; // 箱子的颜色

void main()
{
    // 1. 环境光 (Ambient) - 就算背光处也不是全黑的，有一点点亮度
    float ambientStrength = 0.1;
    vec3 ambient = ambientStrength * lightColor;
  	
    // 2. 漫反射 (Diffuse)
    vec3 norm = normalize(Normal);
    vec3 lightDir = normalize(lightPos - FragPos); // 光的方向 = 光位置 - 像素位置
    float diff = max(dot(norm, lightDir), 0.0); // 核心算法：点乘计算夹角
    vec3 diffuse = diff * lightColor;
            
    // 结果合并
    vec3 result = (ambient + diffuse) * objectColor;
    FragColor = vec4(result, 1.0);
}