using UnityEngine;
using System.Collections;

namespace Rotary
{
    
    public interface IOrientationChangedSubscriber  {

        void OnOrientationChanged(Vector2 newUp, Vector2 newRight);

    }

}