Shader "Unlit/SkyboxCube"
{
    Properties
    {
        Skybox ("Skybox", Cube) = "" {}
    }
    SubShader
    {
        Tags { "Queue"="Background" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 viewDirection : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float3 viewDirection : TEXCOORD0;
            };

            samplerCUBE Skybox;
          
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.viewDirection = mul(unity_ObjectToWorld, v.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = texCUBE(Skybox, i.viewDirection);
                return col;
            }
            ENDCG
        }
    }
}
