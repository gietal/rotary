﻿using UnityEngine;
using System.Collections;

namespace Rotary
{
    
    public interface IOrientationChangedSubscriber  
    {

        void OnOrientationChanged(float newAngle);

    }

}