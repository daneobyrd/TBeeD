half4 SimplexWobble(half4 vertexPosition, half Magnitude, half Frequency, half inTime )
{
    half4 simplexInput = vertexPosition * Frequency;

    half FrameRate = 5;
    half steppedTime = round(Time.y * FrameRate) / FrameRate;
    SimplexWobble(v.vertex, IN_MAGNITUDE, IN_FREQUENCY, steppedTime);
    
    half2 xUV = half2.xy + inTime);
    half2 yUV = half2.yz + inTime*2);
    half2 zUV = half2.xz + inTime*4);

    half simplex_x = (tex2Dlod(_SimplexNoise, half4(xUV,0,0)).r-0.5);
    half simplex_y = (tex2Dlod(_SimplexNoise, half4(yUV,0,0)).r-0.5);
    half simplex_z = (tex2Dlod(_SimplexNoise, half4(zUV,0,0)).r-0.5);

    return half4(simplex_x, simplex_y, simplex_z, 0) * Magnitude;
}
