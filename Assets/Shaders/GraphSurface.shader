Shader "Custom/GraphSurface"
{
    Properties
    {
        NormalColor ("NormalColor", Color) = (1,1,1,1)
        EmissionColor ("EmissionColor", Color) = (1,1,1,1)
        Glossiness ("Smoothness", Range(0,1)) = 0.5
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
        };

        half Glossiness;
        fixed4 NormalColor;
        fixed4 EmissionColor;
        
        UNITY_INSTANCING_BUFFER_START(Props)
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            o.Albedo = saturate(IN.worldPos * 0.5 + 0.5);
            o.Emission = EmissionColor;
            o.Normal = NormalColor;
            o.Smoothness = Glossiness;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
