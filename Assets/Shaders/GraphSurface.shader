Shader "Custom/GraphSurface"
{
    Properties
    {
        EmissionColor ("EmissionColor", Color) = (1,1,1,1)
        Glossiness ("Smoothness", Range(0,1)) = 0.5
        FresnelExponent ("FresnelExponent", Range(0.25, 4)) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows
        #pragma target 3.0

        struct Input
        {
            float3 worldPos;
            float3 worldNormal;
            float3 viewDir;
        };

        half Glossiness;
        float FresnelExponent;
        fixed4 EmissionColor;
        
        UNITY_INSTANCING_BUFFER_START(Props)
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            o.Albedo = saturate(IN.worldPos);
            o.Smoothness = Glossiness;
            
            float fresnel = dot(IN.worldNormal, IN.viewDir);
            fresnel = saturate(1 - fresnel);
            fresnel = pow(fresnel, FresnelExponent);
            o.Emission = EmissionColor + fresnel;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
