Shader "Custom/watercolorShader"
{
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0
	}
		SubShader
		{
			Tags { "RenderType" = "Opaque" }
			LOD 100

			Pass
			{
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#pragma multi_compile_fog
				#include "UnityCG.cginc"

			   fixed4 _DiffuseColor;

			   struct a2v {
					float4 vertex : POSITION;
					float3 normal : NORMAL;
					float4 texcoord : TEXCOORD0;
				};

				struct v2f
				{
					float4 pos : SV_POSITION;
					float2 uv : TEXCOORD0;
					UNITY_FOG_COORDS(5)
				};

				sampler2D _MainTex;
				float4 _MainTex_ST;

				v2f vert(a2v v)
				{
					v2f o;
					o.pos = UnityObjectToClipPos(v.vertex);
					o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);

					UNITY_TRANSFER_FOG(o, o.pos);
					return o;
				}

				fixed4 frag(v2f i) : SV_Target
				{
					float2 uv = i.uv;
					fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT;
					fixed3 texColor = lerp(tex2D(_MainTex, uv).rgb,ambient, 0);
					texColor = lerp(texColor, 1,1 - tex2D(_MainTex, uv).a);
					fixed3 diffuse = _DiffuseColor.rgb * smoothstep(0.35, 0.4, texColor)*texColor;
					UNITY_APPLY_FOG(i.fogCoord, diffuse);
					return fixed4(diffuse,1);
				}
				ENDCG
			}
		}
}