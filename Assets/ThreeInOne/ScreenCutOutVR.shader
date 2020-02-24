// Upgrade NOTE: replaced 'UNITY_INSTANCE_ID' with 'UNITY_VERTEX_INPUT_INSTANCE_ID'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'
//VR Shader Integration: https://unity3d.com/how-to/XR-graphics-development-tips#single-pass-stereo-rendering
//https://docs.unity3d.com/Manual/SinglePassStereoRendering.html

Shader "Unlit/ScreenCutoutVR"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
	}
		SubShader
	{
		Tags{ "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
		Lighting Off
		Cull Back
		ZWrite On
		ZTest Less

		Fog{ Mode Off }

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#pragma multi_compile_instancing //instance


			#include "UnityCG.cginc"

			struct appdata
			{

				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;

				UNITY_VERTEX_INPUT_INSTANCE_ID //instance

				UNITY_VERTEX_INPUT_INSTANCE_ID // uint instanceID : SV_InstanceID;

			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
				float4 screenPos : TEXCOORD1;

				UNITY_VERTEX_OUTPUT_STEREO // uint stereoEyeIndex : SV_RenderTargetIndex;

			};

			v2f vert(appdata v)
			{
				v2f o;

				UNITY_SETUP_INSTANCE_ID(v); //unity_StereoEyeIndex = v.instanceID & 0x01;
				UNITY_INITIALIZE_OUTPUT(v2f, o);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o); // o.stereoEyeIndex = unity_StereoEyeIndex;

				UNITY_TRANSFER_INSTANCE_ID(v, o); //Instance


				o.vertex = UnityObjectToClipPos(v.vertex);

				o.screenPos = ComputeScreenPos(o.vertex);
				
				o.uv = v.uv;

				return o;
			}

			//sampler2D _MainTex;
			
			//float4 colors[2];

			UNITY_DECLARE_SCREENSPACE_TEXTURE(_MainTex); //Insert

			fixed4 frag(v2f i) : SV_Target
			{
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(i); // unity_StereoEyeIndex = i.stereoEyeIndex;
				//fixed4 col = UNITY_SAMPLE_SCREENSPACE_TEXTURE(_MainTex, i.uv); //Insert

				i.screenPos /= i.screenPos.w;
				//fixed4 col = tex2D(_MainTex, float2(i.screenPos.x, i.screenPos.y));
				fixed4 col = UNITY_SAMPLE_SCREENSPACE_TEXTURE(_MainTex, float2(i.screenPos.x, i.screenPos.y)); //Insert


				// just invert the colors
				//col = 1 - col;

				return col;
				//return colors(unity_StereoEyeIndex);
			}
			ENDCG
		}
	}
}

