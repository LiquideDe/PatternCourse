using System.Collections.Generic;
using System;
using UnityEngine;

public class LoadCircleConfigs
{
    public List<CircleConfig> _circleConfigs;
    
    public LoadCircleConfigs()
    {
        Load();
    }

    public CircleConfig Get(TypeCircle typeCircle)
    {
        foreach(CircleConfig circleConfig in _circleConfigs)
        {
            if (circleConfig.TypeCircle == typeCircle)
                return circleConfig;
        }

        throw new ArgumentException(nameof(TypeCircle));
    }

    private void Load()
    {
        _circleConfigs = new List<CircleConfig>();
        _circleConfigs.AddRange(Resources.LoadAll<CircleConfig>("Circles"));
    }
}
