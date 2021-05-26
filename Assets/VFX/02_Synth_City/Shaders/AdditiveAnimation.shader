// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True,fsmp:False;n:type:ShaderForge.SFN_Final,id:4795,x:32724,y:32693,varname:node_4795,prsc:2|emission-2393-OUT;n:type:ShaderForge.SFN_Tex2d,id:6074,x:32063,y:32587,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:2393,x:32495,y:32793,varname:node_2393,prsc:2|A-6431-OUT,B-2053-RGB,C-3847-OUT,D-9248-OUT,E-4782-OUT;n:type:ShaderForge.SFN_VertexColor,id:2053,x:32198,y:32739,varname:node_2053,prsc:2;n:type:ShaderForge.SFN_Color,id:797,x:31969,y:32920,ptovrint:True,ptlb:Color,ptin:_TintColor,varname:_TintColor,prsc:2,glob:False,taghide:False,taghdr:True,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Vector1,id:9248,x:32235,y:33081,varname:node_9248,prsc:2,v1:2;n:type:ShaderForge.SFN_Tex2d,id:7997,x:32404,y:33242,varname:node_7997,prsc:2,ntxv:0,isnm:False|UVIN-3778-OUT,TEX-9787-TEX;n:type:ShaderForge.SFN_TexCoord,id:8933,x:31660,y:33118,varname:node_8933,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Time,id:8367,x:31506,y:33406,varname:node_8367,prsc:2;n:type:ShaderForge.SFN_Add,id:3598,x:31944,y:33161,varname:node_3598,prsc:2|A-8933-U,B-3677-OUT;n:type:ShaderForge.SFN_Append,id:3778,x:32137,y:33222,varname:node_3778,prsc:2|A-3598-OUT,B-8933-V;n:type:ShaderForge.SFN_Multiply,id:6431,x:32231,y:32558,varname:node_6431,prsc:2|A-6074-RGB,B-6074-A;n:type:ShaderForge.SFN_Multiply,id:3677,x:31813,y:33315,varname:node_3677,prsc:2|A-8367-TSL,B-9520-OUT;n:type:ShaderForge.SFN_Slider,id:9520,x:31524,y:33536,ptovrint:False,ptlb:Speed,ptin:_Speed,varname:node_9520,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:10;n:type:ShaderForge.SFN_Tex2dAsset,id:9787,x:31750,y:33695,ptovrint:False,ptlb:Noise,ptin:_Noise,varname:node_9787,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:3530,x:32394,y:33538,varname:node_3530,prsc:2,ntxv:0,isnm:False|UVIN-978-OUT,TEX-9787-TEX;n:type:ShaderForge.SFN_Multiply,id:7357,x:31980,y:33427,varname:node_7357,prsc:2|A-3677-OUT,B-2477-OUT;n:type:ShaderForge.SFN_Vector1,id:2477,x:31834,y:33559,varname:node_2477,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Add,id:3099,x:32137,y:33375,varname:node_3099,prsc:2|A-8933-U,B-7357-OUT;n:type:ShaderForge.SFN_Append,id:978,x:32294,y:33429,varname:node_978,prsc:2|A-3099-OUT,B-8933-V;n:type:ShaderForge.SFN_Multiply,id:4782,x:32599,y:33181,varname:node_4782,prsc:2|A-7997-R,B-3530-R;n:type:ShaderForge.SFN_Multiply,id:3847,x:32220,y:32931,varname:node_3847,prsc:2|A-797-RGB,B-797-A;proporder:6074-797-9520-9787;pass:END;sub:END;*/

Shader "Shader Forge/AdditiveAnimation" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        [HDR]_TintColor ("Color", Color) = (0.5,0.5,0.5,1)
        _Speed ("Speed", Range(0, 10)) = 1
        _Noise ("Noise", 2D) = "white" {}
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One One
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float4 _TintColor;
            uniform float _Speed;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float4 node_8367 = _Time;
                float node_3677 = (node_8367.r*_Speed);
                float2 node_3778 = float2((i.uv0.r+node_3677),i.uv0.g);
                float4 node_7997 = tex2D(_Noise,TRANSFORM_TEX(node_3778, _Noise));
                float2 node_978 = float2((i.uv0.r+(node_3677*0.5)),i.uv0.g);
                float4 node_3530 = tex2D(_Noise,TRANSFORM_TEX(node_978, _Noise));
                float3 emissive = ((_MainTex_var.rgb*_MainTex_var.a)*i.vertexColor.rgb*(_TintColor.rgb*_TintColor.a)*2.0*(node_7997.r*node_3530.r));
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG_COLOR(i.fogCoord, finalRGBA, fixed4(0,0,0,1));
                return finalRGBA;
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
