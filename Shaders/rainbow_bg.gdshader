shader_type canvas_item;

uniform float speed = 1.5;

void fragment()
{
    float t = TIME * speed;
    vec3 color = vec3(
        sin(t) * 0.5 + 0.5,
        sin(t + 2.094) * 0.5 + 0.5,
        sin(t + 4.188) * 0.5 + 0.5
    );

    COLOR = vec4(color, 1.0);
}
