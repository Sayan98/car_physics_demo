using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class auto_controller : MonoBehaviour
{
    [SerializeField]
    WheelCollider[] wheelColliders;

    [SerializeField]
    float acceleration, rotate_angle, deacceleration, brake_force;

    [SerializeField]
    Transform com;

    [SerializeField]
    Rigidbody rigidbody;

    bool key_pressed, forward, backward, left, right;


    void Awake() {
        key_pressed = forward = backward = left = right = false;
    }

    void Start() {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update() {
        
        rigidbody.centerOfMass = com.localPosition;

        if(key_pressed)
            movement();
        else {
            deacceleration_func();
            Debug.Log("key");
        }

    }

    private void movement() {

        if(forward || backward)
            for_back_move();
        
        if(left || right)
            rotate_move();

    }

    private void for_back_move() {
        
        var direction = 0;
        var local_speed = acceleration;

        if(forward)
            direction = 1;
        else {
            direction = -1;
            local_speed = acceleration/3;
        }

        
        var inversedata = transform.InverseTransformDirection(rigidbody.velocity);
        var localbrake = brake_force;

        if(inversedata.z > 0 && backward == true  ||  inversedata.z < 0 && forward == true) {
            localbrake = brake_force;
            local_speed = 0;
        }
        else
            localbrake = 0;

        for (int i = 0; i < 3; i++) {
            wheelColliders[i].motorTorque = direction * local_speed;
            wheelColliders[i].brakeTorque = localbrake;
        }
        
    }

    private void rotate_move() {
        
        var direction = 0;

        if(left)
            direction = -1;
        else
            direction = 1;

        wheelColliders[0].steerAngle = direction * rotate_angle;

    }

    private void deacceleration_func() {

        if(forward == false || backward == false)
            for (int i = 0; i < 3; i++) {
                wheelColliders[i].motorTorque = 0;
                wheelColliders[i].brakeTorque = deacceleration;
            }

    }




    public void clicked_button(Button button) {
        key_pressed = true;

        switch (button.name) {
            
            case "W" :  forward = true;
            break;

            case "S" :  backward = true;
            break;

            case "A" :  left = true;
            break;

            case "D" :  right = true;
            break;
            
        }
    }
    
    public void button_released(Button button1) {

        if(button1.name == "W" || button1.name == "S") {
            
            forward = backward = false;

            if(left == false && right == false)
                key_pressed = false;
        
        }
        
        if(button1.name == "A" || button1.name == "D") {
            
            left = right = false;
            wheelColliders[0].steerAngle = 0;

            if(forward == false && backward == false)
                key_pressed = false;
        
        }

    
    }
}
