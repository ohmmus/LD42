﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAuthority 
{
    private static bool _timeFrozen = false;

    public static TimeAuthority Instance { get; private set; }
    public static float DeltaTime
    {
        get
        {
            if (!_timeFrozen)
            {
                return Time.deltaTime;
            }
            else
            {
                return 0.0f;
            }
        }
    }
    
    public static float RawDeltaTime
    {
        get { return Time.deltaTime;  }
    }

    public static void ToggleTimeFrozen()
    {
        _timeFrozen = !_timeFrozen;
    }

    public static bool timeFrozen
    {
        set { _timeFrozen = value; }
        get { return _timeFrozen;  }
    }
}
