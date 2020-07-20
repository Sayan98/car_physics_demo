using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maping : MonoBehaviour
{
    
    public WheelCollider collider;

    Vector3 center;
    RaycastHit hit;

    void Update() {
        
        center = collider.transform.TransformPoint(collider.center);
        if(Physics.Raycast(center, collider.transform.right, out hit, collider.suspensionDistance + collider.radius))
            transform.position = hit.point + (-collider.transform.right * collider.radius);
        else
            transform.position = center - (-collider.transform.right * collider.suspensionDistance);

    }

    
}
