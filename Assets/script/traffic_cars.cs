using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class traffic_cars : MonoBehaviour
{
    
    [SerializeField]
    PathCreator path;

    public float speed, local_speed;

    public float distance;


    void Start() {
        local_speed = speed;
    }
    
    
    void Update() {
        
        distance += local_speed * Time.deltaTime;
        transform.position = path.path.GetPointAtDistance(distance);
        transform.rotation = path.path.GetRotationAtDistance(distance);

    }
    
    void OnTriggerStay(Collider enter) {

        if(enter.gameObject.tag == "signal") {

            MeshRenderer renderer = enter.gameObject.GetComponent<MeshRenderer>();
            
            if(renderer.material.color == Color.red || renderer.material.color == Color.yellow)
                local_speed = 0;
            else
                local_speed = speed;
        }

    }


    void OnCollisionStay(Collision enter) {
        
        if(enter.gameObject.tag == "cars") {

            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 toOther = enter.gameObject.transform.position - transform.position;

            if (Vector3.Dot(forward, toOther) > 0) {

                local_speed = 0;
            
            }

        }

    }


    void OnCollisionExit(Collision exit) {
        
        if(exit.gameObject.tag == "cars")
            StartCoroutine(wait_start());

    }


    IEnumerator wait_start() {

        yield return new WaitForSeconds(1.5f);
        local_speed = speed;

    }

}
