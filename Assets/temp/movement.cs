using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField]
    WheelCollider[] wheelColliders;

    [SerializeField]
    Transform[] wheels;

    [SerializeField]
    float torque, steer, deacceleration_speed;


    bool move;
    public Transform com;
    Rigidbody rigidbody;


    void Awake() {

        move = false;

    }


    void Start() {

        rigidbody = GetComponent<Rigidbody>();
        rigidbody.centerOfMass = com.localPosition;

    }


    void Update() {
        
        acceleration();
        deacceleration();
        breaks();
        tyre_rotate();

    }


    void acceleration() {

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)) {

            move = true;

            for (int i = 0; i < 4; i++) {

                wheelColliders[i].motorTorque = Input.GetAxis("Vertical") * torque; 
                wheelColliders[i].brakeTorque = 0;

            }
        }
        else
            move = false;
            

        wheelColliders[0].steerAngle = Input.GetAxis("Horizontal") * steer;
        wheelColliders[1].steerAngle = Input.GetAxis("Horizontal") * steer;

    }


    void tyre_rotate() {

        /*for (int i = 0; i < 4; i++)
            wheels[i].Rotate(0, -wheelColliders[i].rpm/60*360 * Time.deltaTime, 0);
            wheel[].localeul = vec(whell localeula, whelel steeranglw - localeular)
            
            */


        Vector3 v = wheels[0].position;
        Quaternion q = wheels[0].rotation;
        wheelColliders[0].GetWorldPose(out v, out q);

        wheels[0].position = v;
        wheels[0].rotation = q;        

    }


    void deacceleration() {

        if(move == false) {
            for (int i = 0; i < 4; i++) {

                wheelColliders[i].brakeTorque = deacceleration_speed;
                wheelColliders[i].motorTorque = 0;   

            } 
        }
    }


    void breaks() {

        if(Input.GetKey(KeyCode.Space)) {
            for (int i = 0; i < 4; i++) {

                wheelColliders[i].brakeTorque = 50000;
                wheelColliders[i].motorTorque = 0;   

            } 
        }
    }


}
