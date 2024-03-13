#version 330 core

//tadi nyimpen di index 0 shader nya pas di Window.cs
//terus nyimpen apa? nyimpen type data vec3
//kalo data di passing dari shader langsung, pakai in, soalnya ada out dll
//in itu nerima data dari luar
layout(location = 0) in vec3 aPosition;
//layout(location = 1) in vec3 aColor; //segitiga rgb atau triangle 2 //dari GL.EnableVertexAttribArray(1); di window.cs

//menyediakan variabel yang bisa dikirim ke next step -> .frag
out vec4 vertexColor;

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;


void main(void)
{
	//untuk pertemuan satu sampai akhir, itu parameter 2 1.0 terus"an gpp
	//kita ga nyentuh itu soalnya
	gl_Position = vec4(aPosition, 1.0) * model * view * projection;

	
	//vertexColor = vec4(aColor, 1.0); //comment triangle 2
}