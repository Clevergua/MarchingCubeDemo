Shader "Custom/Grass"
{
    Properties
    {

        _Color0("Color0", Color) = (1,1,1,1)
        _Color1("Color1", Color) = (1,1,1,1)
        _Color2("Color2", Color) = (1,1,1,1)
        _Color3("Color3", Color) = (1,1,1,1)
        _Color4("Color4", Color) = (1,1,1,1)
        _GrassWidth("Grass Width", Float) = 0.1
        _GrassHeight("Grass Height", Float) = 1

        _WindNoiseTex("Wind Noise Tex", 2D) =  "white" {}
        _WindForce ("Wind Force", Vector) = (0,0,0,0) 
        _WindFrequency("Wind Frequency", Float) = 1
        
    }
    SubShader
    {
        Tags { "RenderType" = "Opaque" }
        LOD 200


        Pass{
            CGPROGRAM
            #include "UnityCG.cginc"

            #pragma vertex vert 
            #pragma geometry geom 
            #pragma fragment frag 
            #pragma target 4.0

            float4 _Color0;
            float4 _Color1;
            float4 _Color2;
            float4 _Color3;
            float4 _Color4;

            float _GrassWidth;
            float _GrassHeight;
            sampler2D _WindNoiseTex;
            float4 _WindNoiseTex_ST;
            float4 _WindForce;
            float _WindFrequency;
            
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv1 : TEXCOORD1;
            };
            struct v2g
            {
                float4 pos : SV_POSITION;
                float2 uv1 : TEXCOORD1;
            };
            struct g2f
            {
                float4 pos : SV_POSITION;
                float4 color : COLOR;
            };


            v2g vert(appdata a)
            {
                v2g o;
                o.pos = a.vertex;
                o.uv1 = a.uv1;
                return o;
            }

            float rand3(float3 input)
            {
                return frac(sin(dot(input, float3(12.9898, 78.233, 53.539))) * 43758.5453);
            }
            float rand2(float2 input)
            {
                return frac(sin(dot(input, float2(37.7797, 65.452))) * 67797.2782);
            }
            float3x3 AngleAxis3x3(float angle, float3 axis)
            {
                float c, s;
                sincos(angle, s, c);

                float t = 1 - c;
                float x = axis.x;
                float y = axis.y;
                float z = axis.z;

                return float3x3(
                t * x * x + c, t * x * y - s * z, t * x * z + s * y,
                t * x * y + s * z, t * y * y + c, t * y * z - s * x,
                t * x * z - s * y, t * y * z + s * x, t * z * z + c
                );
            }

            [maxvertexcount(12)]
            void geom(triangle v2g input[3], inout TriangleStream<g2f> triStream)
            {
                g2f o;
                o.pos =UnityObjectToClipPos(input[0].pos);
                o.color = _Color4;
                triStream.Append(o);
                o.pos =UnityObjectToClipPos(input[1].pos);
                o.color = _Color4;
                triStream.Append(o);
                o.pos =UnityObjectToClipPos(input[2].pos);
                o.color = _Color4;
                triStream.Append(o);
                triStream.RestartStrip();

                for(int i=0; i<3; i++){
                    float3x3 facingRotationMatrix = AngleAxis3x3(rand3(input[i].pos) * UNITY_TWO_PI, float3(0, 1, 0));
                    //Calculate wind
                    float2 uv = input[i].pos.xz * _WindNoiseTex_ST.xy + _WindNoiseTex_ST.zw + float2(_Time.x * 0.01, _Time.x * 0.01);
                    fixed4 noiseColor = tex2Dlod(_WindNoiseTex, float4(uv, 0, 0));
                    float windx = _WindForce.x * (sin(_Time.x * _WindFrequency * noiseColor.r) + 1.5) ;
                    float windz = _WindForce.z * (sin(_Time.x * _WindFrequency * noiseColor.r) + 1.5);

                    float3 top = float3(input[i].uv1.x, _GrassHeight - (input[i].uv1.y + input[i].uv1.x)*0.5, input[i].uv1.y);

                    o.pos =UnityObjectToClipPos(input[i].pos + mul(facingRotationMatrix , float3(-_GrassWidth, 0 , 0)));
                    o.color = _Color0;
                    triStream.Append(o);
                    o.pos = UnityObjectToClipPos(input[i].pos + mul(facingRotationMatrix , float3(_GrassWidth, 0, 0)));
                    o.color = _Color0;
                    triStream.Append(o);

                    o.pos =UnityObjectToClipPos(input[i].pos+ float4(windx, 0, windz, 0) * 0.15 + mul(facingRotationMatrix , float3(-_GrassWidth + 0.33 * top.x, 0.33 * top.y , 0.33 * top.z)));
                    o.color = _Color1;
                    triStream.Append(o);
                    o.pos =UnityObjectToClipPos(input[i].pos+ float4(windx, 0, windz, 0) * 0.15 + mul(facingRotationMatrix , float3(_GrassWidth + 0.33 * top.x, 0.33 * top.y , 0.33 * top.z)));
                    o.color = _Color1;
                    triStream.Append(o);

                    o.pos =UnityObjectToClipPos(input[i].pos+ float4(windx, 0, windz, 0) * 0.5 + mul(facingRotationMatrix , float3(-_GrassWidth + 0.66 * top.x, 0.66 * top.y , 0.66 * top.z)));
                    o.color = _Color2;
                    triStream.Append(o);
                    o.pos =UnityObjectToClipPos(input[i].pos+ float4(windx, 0, windz, 0) * 0.5 + mul(facingRotationMatrix , float3(_GrassWidth + 0.66 * top.x, 0.66 * top.y , 0.66 * top.z)));
                    o.color = _Color2;
                    triStream.Append(o);

                    o.pos = UnityObjectToClipPos(input[i].pos + float4(windx, 0, windz, 0) + mul(facingRotationMatrix , top));
                    o.color = _Color3;
                    triStream.Append(o);
                    triStream.RestartStrip();
                }
                

                
            }

            fixed4 frag(g2f i) : COLOR
            {
                return i.color;
            }


            ENDCG
        }

    }
    FallBack "Diffuse"
}
