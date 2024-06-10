using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class Enemy_damage_doing : MonoBehaviour
{
    public SplineContainer thePath;
    public float damageRate;

    private Vector3 endKnot;

    void Start()
    {
        endKnot = thePath.Spline.ToArray()[thePath.Splines.Count - 1].Position;
    }

    void Update()
    {
        if(transform.position == endKnot) 
        {
            
        }
    }
}
