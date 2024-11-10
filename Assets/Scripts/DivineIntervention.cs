using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivineIntervention : MonoBehaviour
{
    [SerializeField] private float gravitationalConstant = 6.67430e-11f;
    
    [SerializeField] CelestialBody body1;
    [SerializeField] private CelestialBody body2;
    [SerializeField] private CelestialBody body3;
    
    private void FixedUpdate()
    {
        body1.ApplyAcceleration( -gravitationalConstant  * (body1.getPosition - body2.getPosition) / Mathf.Pow((body1.getPosition - body2.getPosition).magnitude, 3) 
                                 - gravitationalConstant  * (body1.getPosition - body3.getPosition) / Mathf.Pow((body1.getPosition - body3.getPosition).magnitude, 3));
        body2.ApplyAcceleration( -gravitationalConstant  * (body2.getPosition - body1.getPosition) / Mathf.Pow((body2.getPosition - body1.getPosition).magnitude, 3) 
                                 - gravitationalConstant  * (body2.getPosition - body3.getPosition) / Mathf.Pow((body2.getPosition - body3.getPosition).magnitude, 3));
        body3.ApplyAcceleration( -gravitationalConstant  * (body3.getPosition - body1.getPosition) / Mathf.Pow((body3.getPosition - body1.getPosition).magnitude, 3) 
                                 - gravitationalConstant  * (body3.getPosition - body2.getPosition) / Mathf.Pow((body3.getPosition - body2.getPosition).magnitude, 3));
    }
}
