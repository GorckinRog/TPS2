using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSource : MonoBehaviour
{
    public Transform targetpoint;
    public Camera cameraLink;
    public float targetInSkyDistance;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var ray = cameraLink.ViewportPointToRay(new Vector3(0.5f, 0.7f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            targetpoint.position = hit.point;
        }
        else
        {
            targetpoint.position = ray.GetPoint(targetInSkyDistance);
        }

        transform.LookAt(targetpoint.position);
    }
}
