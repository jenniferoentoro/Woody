#version 330
//memang ga pakek core

//ngeluarin data
//X,Y,Z, ALPHA 
out vec4 outputColor;

in vec4 vertexColor; 
uniform vec3 objColor; 
//uniform vec4  ourColor;

void main()
{
	//rgba
	//outputColor = vec4(1.0, 0.0, 0.0, 1.0); //warna segitiga //default, nanti off dion
	//outputColor = vertexColor;
	//outputColor = ourColor;
	outputColor = vec4(objColor, 1.0);  
}