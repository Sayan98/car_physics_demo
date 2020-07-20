using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    
    public Transform car;
    float distance = 6.4f;
    public float height = 2f;
    float rotationDamping = 3;
    float heightDamping = 2;
    float zoomRacio = 0.5f;
    float DefaultFOV = 60;
    public Vector3 rotationVector;
    public Rigidbody  rigidbody;

 
void LateUpdate () {
    var wantedAngel = rotationVector.y;
    var wantedHeight = car.position.y + height;
    var myAngel = transform.eulerAngles.y;
    var myHeight = transform.position.y;
        myAngel = Mathf.LerpAngle(myAngel,wantedAngel,rotationDamping*Time.deltaTime);
        myHeight = Mathf.Lerp(myHeight,wantedHeight,heightDamping*Time.deltaTime);
    var currentRotation = Quaternion.Euler(0,myAngel,0);
    transform.position = car.position;
    transform.position -= currentRotation*Vector3.forward*distance;

    Vector3 temp = transform.position;
        temp.y = myHeight;
        transform.position = temp;

        transform.LookAt(car);
}
void FixedUpdate (){
    var localVilocity = car.InverseTransformDirection(rigidbody.velocity);
    if (localVilocity.z<-0.5)
        rotationVector.y = car.eulerAngles.y + 180;
    else
        rotationVector.y = car.eulerAngles.y;
    var acc = rigidbody.velocity.magnitude;

//Camera.current.fieldOfView = DefaultFOV + acc*zoomRacio;
}

  
    
}
