using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    
    [SerializeField]
    Transform arrow, objective;


    void Update() {
        
        var target = new Vector3(objective.GetChild(0).GetChild(0).position.x, arrow.position.y, objective.GetChild(0).GetChild(0).position.z);
        arrow.LookAt(target);

    }
    void OnTriggerEnter(Collider enter) {
        
        if(enter.gameObject.name == "pick")
            Destroy(enter.gameObject.transform.parent.gameObject);

    }
    
}
