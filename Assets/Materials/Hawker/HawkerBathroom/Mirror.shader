Shader "Custom/URP_MirrorGlass"
{
    Properties
    {
        _MainTex ("Reflection Texture", 2D) = "white" {}
        _TintColor ("Glass Tint", Color) = (1,1,1,0.2)
        _GlassStrength ("Glass Strength", Range(0,1)) = 0.4
        _FresnelColor ("Fresnel Color", Color) = (1,1,1,1)
        _FresnelPower ("Fresnel Power", Range(0.1,10)) = 3
    }

    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }

        Pass
        {
            Tags { "LightMode"="UniversalForward" }

            Blend SrcAlpha OneMinusSrcAlpha

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            TEXTURE2D(_MainTex);
            SAMPLER(sampler_MainTex);

            float4 _TintColor;
            float _GlassStrength;
            float4 _FresnelColor;
            float _FresnelPower;

            struct Attributes
            {
                float4 positionOS : POSITION;
                float3 normalOS   : NORMAL;
                float2 uv         : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionHCS : SV_POSITION;
                float2 uv          : TEXCOORD0;
                float3 normalWS    : TEXCOORD1;
                float3 viewDirWS   : TEXCOORD2;
            };

            Varyings vert (Attributes IN)
            {
                Varyings OUT;

                OUT.positionHCS = TransformObjectToHClip(IN.positionOS.xyz);
                OUT.uv = IN.uv;

                float3 positionWS = TransformObjectToWorld(IN.positionOS.xyz);
                OUT.normalWS = TransformObjectToWorldNormal(IN.normalOS);
                OUT.viewDirWS = GetWorldSpaceViewDir(positionWS);

                return OUT;
            }

            half4 frag (Varyings IN) : SV_Target
            {
                // Base reflection
                half4 reflection = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, IN.uv);

                // Fresnel effect
                float fresnel = pow(1 - saturate(dot(normalize(IN.viewDirWS), normalize(IN.normalWS))), _FresnelPower);
                float3 fresnelColor = fresnel * _FresnelColor.rgb;

                // Glass tint layer
                half3 tinted = lerp(reflection.rgb, reflection.rgb * _TintColor.rgb, _GlassStrength);

                // Combine reflection + glass fresnel edge
                half3 finalColor = tinted + fresnelColor;

                // Transparency from tint color alpha
                float alpha = _TintColor.a + fresnel * 0.1;

                return half4(finalColor, alpha);
            }

            ENDHLSL
        }
    }
}
