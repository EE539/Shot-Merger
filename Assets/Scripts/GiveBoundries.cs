using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveBoundries : MonoBehaviour
{
    [HideInInspector]public Bounds bounds;
    // Update is called once per frame
    void Update()
    {
        bounds = new Bounds(transform.position, Vector3.zero);

        foreach (Renderer r in GetComponentsInChildren<Renderer>())
        {
            bounds.Encapsulate(r.bounds);
        }
    }
}
