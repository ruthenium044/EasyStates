Shader "Custom/GraphSurface"
{
    Properties
    {
        EmissionColor ("EmissionColor", Color) = (1,1,1,1)
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
        
        float FresnelExponent;
        fixed4 EmissionColor;
        
        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            o.Albedo = saturate(IN.worldPos);
            float fresnel = dot(IN.worldNormal, IN.viewDir);
            fresnel = saturate(1 - fresnel);
            fresnel = pow(fresnel, FresnelExponent);
            o.Emission = EmissionColor + fresnel;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
