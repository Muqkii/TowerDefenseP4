using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines;
using static UnityEditor.FilePathAttribute;

public class Spline_Movement : MonoBehaviour
{
    public SplineContainer thePath;
    public float speed;
    private float duration = 0.0f;

    Vector3 oldPos;

    Vector3 lookDir;
    void Start()
    {
        transform.position = GameObject.Find("Spawnpoint").transform.position;
    }

    void Update()
    {
        //Quaternion lookRotation = Quaternion.identity;
        //eulerAngles = thePath.EvaluateTangent(thePath.Spline, duration);
        duration += (speed * Time.deltaTime) * 0.01f;
        transform.position = thePath.EvaluatePosition(thePath.Spline, duration);
        //transform.LookAt(thePath.gameObject.transform.position * thePath.EvaluateAcceleration(thePath.Spline, duration));
        //transform.LookAt(oldPos);
        //transform.LookAt(thePath.EvaluateTangent(thePath.Spline, duration));
        lookDir = oldPos - transform.position;
        transform.forward = -lookDir;
        oldPos = transform.position;

        //transform.rotation = lookRotation;
        //Debug.Log(thePath.EvaluateTangent(thePath.Spline, duration));
    }
}
