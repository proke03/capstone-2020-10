﻿Shader "Custom/NormalAndShadow" {
	Properties{
		_Cutoff("Shadow alpha cutoff", Range(0,1)) = 0.5
		[PerRendererData]_MainTex("Sprite Texture", 2D) = "white" {}
		_Color("Tint", Color) = (1,1,1,1)
		_BumpMap("Normalmap", 2D) = "bump" {}
		[MaterialToggle] PixelSnap("Pixel snap", Float) = 0
		[HideInInspector] _RendererColor("RendererColor", Color) = (1,1,1,1)
		[HideInInspector] _Flip("Flip", Vector) = (1,1,1,1)
		[PerRendererData] _AlphaTex("External Alpha", 2D) = "white" {}
		[PerRendererData] _EnableExternalAlpha("Enable External Alpha", Float) = 0
	}
		SubShader{
			Tags
			{
				"Queue" = "Geometry"
				"RenderType" = "TransparentCutout"
			}

			LOD 200
			Cull Off

			CGPROGRAM
			// Lambert lighting model, and enable shadows on all light types
			#pragma surface surf Lambert addshadow fullforwardshadows vertex:vert nofog nolightmap keepalpha noinstancing
			#pragma multi_compile_local _ PIXELSNAP_ON
			#pragma multi_compile _ ETC1_EXTERNAL_ALPHA
			#pragma target 3.0
			#include "UnitySprites.cginc"

			struct Input
			{
				float2 uv_MainTex;
				float2 uv_BumpMap;
				fixed4 color;
			};

			void vert(inout appdata_full v, out Input o) {
				v.vertex = UnityFlipSprite(v.vertex, _Flip);

				#if defined(PIXELSNAP_ON)
				v.vertex = UnityPixelSnap(v.vertex);
				#endif

				UNITY_INITIALIZE_OUTPUT(Input, o);
				o.color = v.color * _Color * _RendererColor;
			}

			fixed _Cutoff;
			sampler2D _BumpMap;

			void surf(Input IN, inout SurfaceOutput o) {
				fixed4 c = SampleSpriteTexture(IN.uv_MainTex) * _Color;
				o.Albedo = c.rgb * c.a;
				o.Alpha = c.a;
				o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
				clip(o.Alpha - _Cutoff);
			}
			ENDCG
		}
			Fallback "Transparent/VertexLit"
}