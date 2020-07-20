using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField]
    WheelCollider[] wheelColliders;

    [SerializeField]
    Transform[] wheels;

    bool move;
    public Transform com;
    
    [SerializeField]
    float torque, steer, deacceleration_speed;



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

        for (int i = 0; i < 4; i++)
            wheels[i].Rotate(0, -wheelColliders[i].rpm * Time.deltaTime, 0);
        Debug.Log(wheelColliders[1].steerAngle - wheels[1].localEulerAngles.y);
        wheels[0].localEulerAngles = new Vector3(wheels[0].localEulerAngles.x , wheelColliders[0].steerAngle - wheels[0].localEulerAngles.y , wheels[0].localEulerAngles.z);
        wheels[1].localEulerAngles = new Vector3(wheels[1].localEulerAngles.x , wheelColliders[1].steerAngle - wheels[1].localEulerAngles.y , wheels[1].localEulerAngles.z);
        


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
