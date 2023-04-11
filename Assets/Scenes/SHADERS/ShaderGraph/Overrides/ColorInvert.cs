using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

[VolumeComponentMenu("Custom Effects/Color Invert")]
public class ColorInvert : VolumeComponent, IPostProcessComponent
{
    public ClampedFloatParameter weight = new ClampedFloatParameter(1,0,1,true);
    public bool IsActive() => weight.value > 0;
    public bool IsTileCompatible() => true;

    
}
