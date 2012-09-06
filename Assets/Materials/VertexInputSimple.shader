Shader "VertexInputSimple" {
SubShader {
    Pass {
		Cull Off
        Fog { Mode Off }
CGPROGRAM
// Upgrade NOTE: excluded shader from OpenGL ES 2.0 because it does not contain a surface program or both vertex and fragment programs.
#pragma exclude_renderers gles
#pragma vertex vert

// vertex input: position, color
struct appdata {
    float4 vertex : POSITION;
    float4 color : COLOR;
};

struct v2f {
    float4 pos : SV_POSITION;
    fixed4 color : COLOR;
};
v2f vert (appdata v) {
    v2f o;
    o.pos = mul( UNITY_MATRIX_MVP, v.vertex );
    o.color = v.color;
    return o;
}
ENDCG
    }
}
}