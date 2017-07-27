// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.18 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.18;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:1,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:4013,x:33636,y:32966,varname:node_4013,prsc:2|diff-5732-OUT,spec-3044-OUT,gloss-1619-OUT,normal-8875-OUT;n:type:ShaderForge.SFN_Tex2d,id:8265,x:32019,y:32648,ptovrint:False,ptlb:BASE,ptin:_BASE,varname:node_8265,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:51dd4619ac149904184d2d456d727e8a,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:970,x:32050,y:32850,ptovrint:False,ptlb:Decal_01,ptin:_Decal_01,varname:node_970,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:43ae12128741a674882c94d32fc27799,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Lerp,id:8638,x:32306,y:32714,varname:node_8638,prsc:2|A-8265-RGB,B-970-RGB,T-970-A;n:type:ShaderForge.SFN_Lerp,id:6241,x:32550,y:32803,varname:node_6241,prsc:2|A-8638-OUT,B-8410-RGB,T-8410-A;n:type:ShaderForge.SFN_Tex2d,id:8410,x:32279,y:32938,ptovrint:False,ptlb:Decal_02,ptin:_Decal_02,varname:node_8410,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:27621c55dab26cf4c9c414107100d63d,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:5480,x:32585,y:33003,ptovrint:False,ptlb:Decal_03,ptin:_Decal_03,varname:node_5480,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:2ab3b7e78eee1ba45bfe97c3eb2c0c86,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:4238,x:32898,y:33082,ptovrint:False,ptlb:Decal_04,ptin:_Decal_04,varname:node_4238,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:64d598db15a147f4caaec2a702f2c3df,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Lerp,id:2561,x:32841,y:32873,varname:node_2561,prsc:2|A-6241-OUT,B-5480-RGB,T-5480-A;n:type:ShaderForge.SFN_Lerp,id:5732,x:33159,y:32945,varname:node_5732,prsc:2|A-2561-OUT,B-4238-RGB,T-4238-A;n:type:ShaderForge.SFN_Vector1,id:3044,x:33354,y:33000,varname:node_3044,prsc:2,v1:0;n:type:ShaderForge.SFN_Tex2d,id:4318,x:32027,y:33316,ptovrint:False,ptlb:Roughness_01,ptin:_Roughness_01,varname:node_4318,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Lerp,id:5701,x:32294,y:33218,varname:node_5701,prsc:2|A-9765-OUT,B-4318-R,T-4318-A;n:type:ShaderForge.SFN_Tex2d,id:4640,x:32389,y:33706,ptovrint:False,ptlb:Normal_01,ptin:_Normal_01,varname:node_4640,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Tex2d,id:7949,x:32294,y:33409,ptovrint:False,ptlb:Roughness_02,ptin:_Roughness_02,varname:node_7949,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Lerp,id:6750,x:32567,y:33238,varname:node_6750,prsc:2|A-5701-OUT,B-7949-R,T-7949-A;n:type:ShaderForge.SFN_Tex2d,id:9298,x:32389,y:33915,ptovrint:False,ptlb:Normal_02,ptin:_Normal_02,varname:node_9298,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:8657e81d21e6edb4d8c3d22094d4ac9a,ntxv:3,isnm:True;n:type:ShaderForge.SFN_NormalBlend,id:4534,x:32666,y:33691,varname:node_4534,prsc:2|BSE-4640-RGB,DTL-9298-RGB;n:type:ShaderForge.SFN_ValueProperty,id:9765,x:32027,y:33195,ptovrint:False,ptlb:BASE roughness,ptin:_BASEroughness,varname:node_9765,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_Lerp,id:5710,x:32859,y:33281,varname:node_5710,prsc:2|A-6750-OUT,B-9277-R,T-9277-A;n:type:ShaderForge.SFN_Tex2d,id:9277,x:32586,y:33452,ptovrint:False,ptlb:Roughness_03,ptin:_Roughness_03,varname:_Roughness_03,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Lerp,id:1619,x:33226,y:33290,varname:node_1619,prsc:2|A-5710-OUT,B-5402-R,T-5402-A;n:type:ShaderForge.SFN_Tex2d,id:5402,x:32953,y:33461,ptovrint:False,ptlb:Roughness_04,ptin:_Roughness_04,varname:_Roughness_04,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_NormalBlend,id:7982,x:32907,y:33691,varname:node_7982,prsc:2|BSE-4534-OUT,DTL-701-RGB;n:type:ShaderForge.SFN_NormalBlend,id:8875,x:33195,y:33721,varname:node_8875,prsc:2|BSE-7982-OUT,DTL-8302-RGB;n:type:ShaderForge.SFN_Tex2d,id:701,x:32698,y:33959,ptovrint:False,ptlb:Normal_03,ptin:_Normal_03,varname:node_701,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:e7307722990bc2d4bad3fc88bbfd9f7a,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Tex2d,id:8302,x:33012,y:33939,ptovrint:False,ptlb:Normal_04,ptin:_Normal_04,varname:node_8302,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:8657e81d21e6edb4d8c3d22094d4ac9a,ntxv:3,isnm:True;proporder:8265-970-8410-5480-4238-4318-4640-7949-9298-9765-9277-5402-701-8302;pass:END;sub:END;*/

Shader "Shader Forge/decal" {
    Properties {
        _BASE ("BASE", 2D) = "white" {}
        _Decal_01 ("Decal_01", 2D) = "white" {}
        _Decal_02 ("Decal_02", 2D) = "white" {}
        _Decal_03 ("Decal_03", 2D) = "white" {}
        _Decal_04 ("Decal_04", 2D) = "white" {}
        _Roughness_01 ("Roughness_01", 2D) = "white" {}
        _Normal_01 ("Normal_01", 2D) = "bump" {}
        _Roughness_02 ("Roughness_02", 2D) = "white" {}
        _Normal_02 ("Normal_02", 2D) = "bump" {}
        _BASEroughness ("BASE roughness", Float ) = 0.1
        _Roughness_03 ("Roughness_03", 2D) = "white" {}
        _Roughness_04 ("Roughness_04", 2D) = "white" {}
        _Normal_03 ("Normal_03", 2D) = "bump" {}
        _Normal_04 ("Normal_04", 2D) = "bump" {}
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _BASE; uniform float4 _BASE_ST;
            uniform sampler2D _Decal_01; uniform float4 _Decal_01_ST;
            uniform sampler2D _Decal_02; uniform float4 _Decal_02_ST;
            uniform sampler2D _Decal_03; uniform float4 _Decal_03_ST;
            uniform sampler2D _Decal_04; uniform float4 _Decal_04_ST;
            uniform sampler2D _Roughness_01; uniform float4 _Roughness_01_ST;
            uniform sampler2D _Normal_01; uniform float4 _Normal_01_ST;
            uniform sampler2D _Roughness_02; uniform float4 _Roughness_02_ST;
            uniform sampler2D _Normal_02; uniform float4 _Normal_02_ST;
            uniform float _BASEroughness;
            uniform sampler2D _Roughness_03; uniform float4 _Roughness_03_ST;
            uniform sampler2D _Roughness_04; uniform float4 _Roughness_04_ST;
            uniform sampler2D _Normal_03; uniform float4 _Normal_03_ST;
            uniform sampler2D _Normal_04; uniform float4 _Normal_04_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
                UNITY_FOG_COORDS(7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _Normal_01_var = UnpackNormal(tex2D(_Normal_01,TRANSFORM_TEX(i.uv0, _Normal_01)));
                float3 _Normal_02_var = UnpackNormal(tex2D(_Normal_02,TRANSFORM_TEX(i.uv0, _Normal_02)));
                float3 node_4534_nrm_base = _Normal_01_var.rgb + float3(0,0,1);
                float3 node_4534_nrm_detail = _Normal_02_var.rgb * float3(-1,-1,1);
                float3 node_4534_nrm_combined = node_4534_nrm_base*dot(node_4534_nrm_base, node_4534_nrm_detail)/node_4534_nrm_base.z - node_4534_nrm_detail;
                float3 node_4534 = node_4534_nrm_combined;
                float3 _Normal_03_var = UnpackNormal(tex2D(_Normal_03,TRANSFORM_TEX(i.uv0, _Normal_03)));
                float3 node_7982_nrm_base = node_4534 + float3(0,0,1);
                float3 node_7982_nrm_detail = _Normal_03_var.rgb * float3(-1,-1,1);
                float3 node_7982_nrm_combined = node_7982_nrm_base*dot(node_7982_nrm_base, node_7982_nrm_detail)/node_7982_nrm_base.z - node_7982_nrm_detail;
                float3 node_7982 = node_7982_nrm_combined;
                float3 _Normal_04_var = UnpackNormal(tex2D(_Normal_04,TRANSFORM_TEX(i.uv0, _Normal_04)));
                float3 node_8875_nrm_base = node_7982 + float3(0,0,1);
                float3 node_8875_nrm_detail = _Normal_04_var.rgb * float3(-1,-1,1);
                float3 node_8875_nrm_combined = node_8875_nrm_base*dot(node_8875_nrm_base, node_8875_nrm_detail)/node_8875_nrm_base.z - node_8875_nrm_detail;
                float3 node_8875 = node_8875_nrm_combined;
                float3 normalLocal = node_8875;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float4 _Roughness_01_var = tex2D(_Roughness_01,TRANSFORM_TEX(i.uv0, _Roughness_01));
                float4 _Roughness_02_var = tex2D(_Roughness_02,TRANSFORM_TEX(i.uv0, _Roughness_02));
                float4 _Roughness_03_var = tex2D(_Roughness_03,TRANSFORM_TEX(i.uv0, _Roughness_03));
                float4 _Roughness_04_var = tex2D(_Roughness_04,TRANSFORM_TEX(i.uv0, _Roughness_04));
                float gloss = 1.0 - lerp(lerp(lerp(lerp(_BASEroughness,_Roughness_01_var.r,_Roughness_01_var.a),_Roughness_02_var.r,_Roughness_02_var.a),_Roughness_03_var.r,_Roughness_03_var.a),_Roughness_04_var.r,_Roughness_04_var.a); // Convert roughness to gloss
                float specPow = exp2( gloss * 10.0+1.0);
/////// GI Data:
                UnityLight light;
                #ifdef LIGHTMAP_OFF
                    light.color = lightColor;
                    light.dir = lightDirection;
                    light.ndotl = LambertTerm (normalDirection, light.dir);
                #else
                    light.color = half3(0.f, 0.f, 0.f);
                    light.ndotl = 0.0f;
                    light.dir = half3(0.f, 0.f, 0.f);
                #endif
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = attenuation;
                UnityGI gi = UnityGlobalIllumination (d, 1, gloss, normalDirection);
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float LdotH = max(0.0,dot(lightDirection, halfDirection));
                float4 _BASE_var = tex2D(_BASE,TRANSFORM_TEX(i.uv0, _BASE));
                float4 _Decal_01_var = tex2D(_Decal_01,TRANSFORM_TEX(i.uv0, _Decal_01));
                float4 _Decal_02_var = tex2D(_Decal_02,TRANSFORM_TEX(i.uv0, _Decal_02));
                float4 _Decal_03_var = tex2D(_Decal_03,TRANSFORM_TEX(i.uv0, _Decal_03));
                float4 _Decal_04_var = tex2D(_Decal_04,TRANSFORM_TEX(i.uv0, _Decal_04));
                float3 diffuseColor = lerp(lerp(lerp(lerp(_BASE_var.rgb,_Decal_01_var.rgb,_Decal_01_var.a),_Decal_02_var.rgb,_Decal_02_var.a),_Decal_03_var.rgb,_Decal_03_var.a),_Decal_04_var.rgb,_Decal_04_var.a); // Need this for specular when using metallic
                float specularMonochrome;
                float3 specularColor;
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, 0.0, specularColor, specularMonochrome );
                specularMonochrome = 1-specularMonochrome;
                float NdotV = max(0.0,dot( normalDirection, viewDirection ));
                float NdotH = max(0.0,dot( normalDirection, halfDirection ));
                float VdotH = max(0.0,dot( viewDirection, halfDirection ));
                float visTerm = SmithBeckmannVisibilityTerm( NdotL, NdotV, 1.0-gloss );
                float normTerm = max(0.0, NDFBlinnPhongNormalizedTerm(NdotH, RoughnessToSpecPower(1.0-gloss)));
                float specularPBL = max(0, (NdotL*visTerm*normTerm) * unity_LightGammaCorrectionConsts_PIDiv4 );
                float3 directSpecular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularPBL*lightColor*FresnelTerm(specularColor, LdotH);
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float3 directDiffuse = ((1 +(fd90 - 1)*pow((1.00001-NdotL), 5)) * (1 + (fd90 - 1)*pow((1.00001-NdotV), 5)) * NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _BASE; uniform float4 _BASE_ST;
            uniform sampler2D _Decal_01; uniform float4 _Decal_01_ST;
            uniform sampler2D _Decal_02; uniform float4 _Decal_02_ST;
            uniform sampler2D _Decal_03; uniform float4 _Decal_03_ST;
            uniform sampler2D _Decal_04; uniform float4 _Decal_04_ST;
            uniform sampler2D _Roughness_01; uniform float4 _Roughness_01_ST;
            uniform sampler2D _Normal_01; uniform float4 _Normal_01_ST;
            uniform sampler2D _Roughness_02; uniform float4 _Roughness_02_ST;
            uniform sampler2D _Normal_02; uniform float4 _Normal_02_ST;
            uniform float _BASEroughness;
            uniform sampler2D _Roughness_03; uniform float4 _Roughness_03_ST;
            uniform sampler2D _Roughness_04; uniform float4 _Roughness_04_ST;
            uniform sampler2D _Normal_03; uniform float4 _Normal_03_ST;
            uniform sampler2D _Normal_04; uniform float4 _Normal_04_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
                UNITY_FOG_COORDS(7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _Normal_01_var = UnpackNormal(tex2D(_Normal_01,TRANSFORM_TEX(i.uv0, _Normal_01)));
                float3 _Normal_02_var = UnpackNormal(tex2D(_Normal_02,TRANSFORM_TEX(i.uv0, _Normal_02)));
                float3 node_4534_nrm_base = _Normal_01_var.rgb + float3(0,0,1);
                float3 node_4534_nrm_detail = _Normal_02_var.rgb * float3(-1,-1,1);
                float3 node_4534_nrm_combined = node_4534_nrm_base*dot(node_4534_nrm_base, node_4534_nrm_detail)/node_4534_nrm_base.z - node_4534_nrm_detail;
                float3 node_4534 = node_4534_nrm_combined;
                float3 _Normal_03_var = UnpackNormal(tex2D(_Normal_03,TRANSFORM_TEX(i.uv0, _Normal_03)));
                float3 node_7982_nrm_base = node_4534 + float3(0,0,1);
                float3 node_7982_nrm_detail = _Normal_03_var.rgb * float3(-1,-1,1);
                float3 node_7982_nrm_combined = node_7982_nrm_base*dot(node_7982_nrm_base, node_7982_nrm_detail)/node_7982_nrm_base.z - node_7982_nrm_detail;
                float3 node_7982 = node_7982_nrm_combined;
                float3 _Normal_04_var = UnpackNormal(tex2D(_Normal_04,TRANSFORM_TEX(i.uv0, _Normal_04)));
                float3 node_8875_nrm_base = node_7982 + float3(0,0,1);
                float3 node_8875_nrm_detail = _Normal_04_var.rgb * float3(-1,-1,1);
                float3 node_8875_nrm_combined = node_8875_nrm_base*dot(node_8875_nrm_base, node_8875_nrm_detail)/node_8875_nrm_base.z - node_8875_nrm_detail;
                float3 node_8875 = node_8875_nrm_combined;
                float3 normalLocal = node_8875;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float4 _Roughness_01_var = tex2D(_Roughness_01,TRANSFORM_TEX(i.uv0, _Roughness_01));
                float4 _Roughness_02_var = tex2D(_Roughness_02,TRANSFORM_TEX(i.uv0, _Roughness_02));
                float4 _Roughness_03_var = tex2D(_Roughness_03,TRANSFORM_TEX(i.uv0, _Roughness_03));
                float4 _Roughness_04_var = tex2D(_Roughness_04,TRANSFORM_TEX(i.uv0, _Roughness_04));
                float gloss = 1.0 - lerp(lerp(lerp(lerp(_BASEroughness,_Roughness_01_var.r,_Roughness_01_var.a),_Roughness_02_var.r,_Roughness_02_var.a),_Roughness_03_var.r,_Roughness_03_var.a),_Roughness_04_var.r,_Roughness_04_var.a); // Convert roughness to gloss
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float LdotH = max(0.0,dot(lightDirection, halfDirection));
                float4 _BASE_var = tex2D(_BASE,TRANSFORM_TEX(i.uv0, _BASE));
                float4 _Decal_01_var = tex2D(_Decal_01,TRANSFORM_TEX(i.uv0, _Decal_01));
                float4 _Decal_02_var = tex2D(_Decal_02,TRANSFORM_TEX(i.uv0, _Decal_02));
                float4 _Decal_03_var = tex2D(_Decal_03,TRANSFORM_TEX(i.uv0, _Decal_03));
                float4 _Decal_04_var = tex2D(_Decal_04,TRANSFORM_TEX(i.uv0, _Decal_04));
                float3 diffuseColor = lerp(lerp(lerp(lerp(_BASE_var.rgb,_Decal_01_var.rgb,_Decal_01_var.a),_Decal_02_var.rgb,_Decal_02_var.a),_Decal_03_var.rgb,_Decal_03_var.a),_Decal_04_var.rgb,_Decal_04_var.a); // Need this for specular when using metallic
                float specularMonochrome;
                float3 specularColor;
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, 0.0, specularColor, specularMonochrome );
                specularMonochrome = 1-specularMonochrome;
                float NdotV = max(0.0,dot( normalDirection, viewDirection ));
                float NdotH = max(0.0,dot( normalDirection, halfDirection ));
                float VdotH = max(0.0,dot( viewDirection, halfDirection ));
                float visTerm = SmithBeckmannVisibilityTerm( NdotL, NdotV, 1.0-gloss );
                float normTerm = max(0.0, NDFBlinnPhongNormalizedTerm(NdotH, RoughnessToSpecPower(1.0-gloss)));
                float specularPBL = max(0, (NdotL*visTerm*normTerm) * unity_LightGammaCorrectionConsts_PIDiv4 );
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularPBL*lightColor*FresnelTerm(specularColor, LdotH);
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float3 directDiffuse = ((1 +(fd90 - 1)*pow((1.00001-NdotL), 5)) * (1 + (fd90 - 1)*pow((1.00001-NdotV), 5)) * NdotL) * attenColor;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
