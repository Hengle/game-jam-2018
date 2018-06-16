// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Jam/Shield"
{
	Properties
	{
		_MainTex("_MainTex", 2D) = "white" {}
		_Mask("Mask", 2D) = "white" {}
		_TextureSample0("Texture Sample 0", 2D) = "white" {}
		_RimColor("RimColor", Color) = (0,0,0,0)
		_Color0("Color 0", Color) = (0,0,0,0)
		_Rim("Rim", Float) = 0
		_powerRim("powerRim", Float) = 0
		_Vector0("Vector 0", Vector) = (1,0,0,0)
		_Speed("Speed", Vector) = (1,0,0,0)
		_Vector1("Vector 1", Vector) = (0.38,0.6,0,0)
		_Tiling("Tiling", Vector) = (0.38,0.6,0,0)
		_Opacity("Opacity", Float) = 0
		_ColorLine("ColorLine", Color) = (0,0,0,0)
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0" "IsEmissive" = "true"  }
		Cull Back
		ZWrite Off
		Blend One OneMinusSrcAlpha , One OneMinusSrcAlpha
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#pragma surface surf Unlit keepalpha noshadow 
		struct Input
		{
			half2 uv_texcoord;
			float3 worldNormal;
			float3 viewDir;
		};

		uniform half4 _Color0;
		uniform sampler2D _MainTex;
		uniform float4 _MainTex_ST;
		uniform half4 _RimColor;
		uniform half _Rim;
		uniform half _powerRim;
		uniform sampler2D _TextureSample0;
		uniform half2 _Tiling;
		uniform half2 _Speed;
		uniform half _Opacity;
		uniform half4 _ColorLine;
		uniform sampler2D _Mask;
		uniform half2 _Vector1;
		uniform half2 _Vector0;

		inline fixed4 LightingUnlit( SurfaceOutput s, half3 lightDir, half atten )
		{
			return fixed4 ( 0, 0, 0, s.Alpha );
		}

		void surf( Input i , inout SurfaceOutput o )
		{
			float2 uv_MainTex = i.uv_texcoord * _MainTex_ST.xy + _MainTex_ST.zw;
			half3 ase_worldNormal = i.worldNormal;
			float dotResult20 = dot( ase_worldNormal , i.viewDir );
			float4 temp_output_46_0 = ( ( ( _Color0 * _Color0.a * tex2D( _MainTex, uv_MainTex ) ) + ( _RimColor * _RimColor.a * saturate( pow( ( 1.0 - abs( dotResult20 ) ) , _Rim ) ) * _powerRim ) + ( tex2D( _TextureSample0, ( ( i.uv_texcoord * _Tiling ) + ( _Speed * _Time.y ) ) ) * _Opacity * _ColorLine * _ColorLine.a ) ) * tex2D( _Mask, ( ( i.uv_texcoord * _Vector1 ) + ( _Vector0 * _Time.y ) ) ) );
			o.Emission = temp_output_46_0.rgb;
			o.Alpha = temp_output_46_0.r;
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=15301
1964;72;1457;929;2024.517;-174.3852;1.614406;True;False
Node;AmplifyShaderEditor.WorldNormalVector;18;-2479.284,-55.41556;Float;False;False;1;0;FLOAT3;0,0,1;False;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.ViewDirInputsCoordNode;19;-2487.084,162.9842;Float;False;World;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.DotProductOpNode;20;-2191.984,48.58451;Float;False;2;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;37;-2132.065,692.0907;Float;False;Property;_Tiling;Tiling;11;0;Create;True;0;0;False;0;0.38,0.6;1,1;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.AbsOpNode;21;-2041.184,105.7843;Float;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;38;-1872.065,773.9904;Float;False;Property;_Speed;Speed;9;0;Create;True;0;0;False;0;1,0;0,0.5;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.TextureCoordinatesNode;32;-2280.452,550.1027;Float;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleTimeNode;41;-1877.265,935.1907;Float;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;39;-1641.965,832.4908;Float;False;2;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;25;-1848.784,395.6841;Float;False;Property;_Rim;Rim;6;0;Create;True;0;0;False;0;0;3.01;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;33;-1886.702,535.9167;Float;True;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.OneMinusNode;22;-1844.884,156.484;Float;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.PowerNode;23;-1647.284,216.2838;Float;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;34;-1533.702,540.9167;Float;True;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.Vector2Node;47;-733.2784,1266.207;Float;False;Property;_Vector0;Vector 0;8;0;Create;True;0;0;False;0;1,0;0.08,0.5;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SimpleTimeNode;53;-738.4785,1427.407;Float;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;48;-993.2784,1184.307;Float;False;Property;_Vector1;Vector 1;10;0;Create;True;0;0;False;0;0.38,0.6;1,1;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.TextureCoordinatesNode;52;-1141.665,1042.319;Float;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;43;-732.8629,614.976;Float;False;Property;_Opacity;Opacity;12;0;Create;True;0;0;False;0;0;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;30;-1373.37,422.8032;Float;False;Property;_powerRim;powerRim;7;0;Create;True;0;0;False;0;0;2;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;50;-503.1785,1324.707;Float;False;2;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.ColorNode;26;-1437.884,-84.91592;Float;False;Property;_RimColor;RimColor;4;0;Create;True;0;0;False;0;0,0,0,0;0,0.5448277,1,0.641;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SaturateNode;24;-1461.384,200.6841;Float;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;31;-1117.802,578.217;Float;True;Property;_TextureSample0;Texture Sample 0;3;0;Create;True;0;0;False;0;5798ded558355430c8a9b13ee12a847c;dcf1f7f2c1dc6f941a7d1feb332df699;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;49;-747.9155,1028.133;Float;True;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.ColorNode;44;-917.4628,782.6758;Float;False;Property;_ColorLine;ColorLine;13;0;Create;True;0;0;False;0;0,0,0,0;0.02205884,0.5144014,1,0.528;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;3;-674.6933,-259.7252;Float;False;Property;_Color0;Color 0;5;0;Create;True;0;0;False;0;0,0,0,0;0.3529412,0.7054768,1,0.566;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;1;-1020.093,7.874805;Float;True;Property;_MainTex;_MainTex;1;0;Create;True;0;0;False;0;5798ded558355430c8a9b13ee12a847c;5798ded558355430c8a9b13ee12a847c;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;27;-1170.284,278.2838;Float;False;4;4;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;42;-506.6402,367.1305;Float;False;4;4;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;3;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;51;-394.9155,1033.133;Float;True;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;4;-295.6934,-127.7252;Float;False;3;3;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;2;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;15;-94.63683,255.0465;Float;False;3;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;45;-337.0062,491.5309;Float;True;Property;_Mask;Mask;2;0;Create;True;0;0;False;0;5798ded558355430c8a9b13ee12a847c;373125941566f5947bccb94cb907ee96;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;46;111.4404,446.4285;Float;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;328,4;Half;False;True;2;Half;ASEMaterialInspector;0;0;Unlit;Jam/Shield;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;2;False;-1;0;False;-1;False;0;0;False;0;Custom;0.5;True;False;0;True;Transparent;;Transparent;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;False;3;1;False;-1;10;False;-1;3;1;False;-1;10;False;-1;-1;False;-1;-1;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;0;-1;-1;-1;0;0;0;False;0;0;0;False;-1;-1;0;False;-1;15;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;20;0;18;0
WireConnection;20;1;19;0
WireConnection;21;0;20;0
WireConnection;39;0;38;0
WireConnection;39;1;41;0
WireConnection;33;0;32;0
WireConnection;33;1;37;0
WireConnection;22;0;21;0
WireConnection;23;0;22;0
WireConnection;23;1;25;0
WireConnection;34;0;33;0
WireConnection;34;1;39;0
WireConnection;50;0;47;0
WireConnection;50;1;53;0
WireConnection;24;0;23;0
WireConnection;31;1;34;0
WireConnection;49;0;52;0
WireConnection;49;1;48;0
WireConnection;27;0;26;0
WireConnection;27;1;26;4
WireConnection;27;2;24;0
WireConnection;27;3;30;0
WireConnection;42;0;31;0
WireConnection;42;1;43;0
WireConnection;42;2;44;0
WireConnection;42;3;44;4
WireConnection;51;0;49;0
WireConnection;51;1;50;0
WireConnection;4;0;3;0
WireConnection;4;1;3;4
WireConnection;4;2;1;0
WireConnection;15;0;4;0
WireConnection;15;1;27;0
WireConnection;15;2;42;0
WireConnection;45;1;51;0
WireConnection;46;0;15;0
WireConnection;46;1;45;0
WireConnection;0;2;46;0
WireConnection;0;9;46;0
ASEEND*/
//CHKSM=02AE99E6956DFE523EB050A6A725EB5502932AD4