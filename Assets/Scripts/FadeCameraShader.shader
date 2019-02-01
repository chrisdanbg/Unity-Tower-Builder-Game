// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Hidden/FadeCameraShader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_opacity ("Opacity", Range (0, 1)) = 0
		_Color ("Fade Color", Color) = (0,0,0,1)
	}

	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			uniform sampler2D _MainTex;
			uniform float _opacity;
			uniform float4 _Color;

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}	

			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);
				col = col * _opacity + _Color * (1-_opacity);
				return col;
			}
			ENDCG
		}
	}
}
