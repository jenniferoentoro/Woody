#version 330 core
		// lokasi        //type data
layout(location = 0) in vec3 aPosition;
// layout(location = 1) in vec3 aColor;

//menyediakan variabel yang bisa dikirim ke next step
out vec4 vertexColor;

void main(void)
{
	gl_Position = vec4(aPosition,1.0);
	vertexColor = vec4(0.0,1.0,1.0,1.0);
	//vertexColor = vec4(aColor,1.0);
}