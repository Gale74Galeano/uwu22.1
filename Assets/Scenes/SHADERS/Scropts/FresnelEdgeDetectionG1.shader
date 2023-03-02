Shader "Example/FresnelEdgeDetectionG1"
{
    Properties
    { 
    _MainTex("Main Texture", 2D)= "white"{}
        _Color("Edge Colo", Color)= (0,0,0,1)
    }

    SubShader
    {
        Tags { "RenderType" = "Opaque" "RenderPipeline" = "UniversalRenderPipeline" }

        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"            

            struct Attributes
            {
                float4 positionOS   : POSITION;
                float2 pepitoUv     : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionHCS   : POSITION;
                float2 pepitoUv     : TEXCOORD0;
            };
            sampler2D _MainTex;
            float4 _Color;

            Varyings vert(Attributes IN)
            {
                Varyings OUT;
                OUT.positionHCS = TransformObjectToHClip(IN.positionOS.xyz);
                OUT.pepitoUv=IN.pepitoUv;
                return OUT;
            }

            half4 frag(Varyings IN) : SV_Target
            {
                return tex2D(_MainTex,IN.pepitoUv);
            }
            ENDHLSL
        }
    }
}