using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMover : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(10 * Mathf.Cos(Time.time), 0, 10 * Mathf.Cos(Time.time)) * Time.deltaTime);
    }
}
