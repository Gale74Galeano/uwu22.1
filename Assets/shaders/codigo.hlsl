void RGB2HSV_float(float3 RGBColor, out float3 HSVColor)
{
	float3 c = RGB_Color;

	float cMin = min(min(c.r, c.g), c.b);
	float cMax = max(max(c.r, c.g), c.b);
	float delta = cMax - cMin;

	HSVColor = 0;
	HSVColor.x = 1;
	HSVColor.y = cMax == 0 ? 0 : delta / cMax;
	HSVColor.z = cMax; // value

}