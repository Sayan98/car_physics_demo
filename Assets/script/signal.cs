using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class signal : MonoBehaviour
{
    
    MeshRenderer renderer;

    void Awake() {
        
        renderer = GetComponent<MeshRenderer>();

    }
    void Start() {

        var choice = Random.Range(0,2);
        
        if(choice == 0)
            renderer.material.color = Color.red;
        else if(choice == 1)
                renderer.material.color = Color.yellow;
        else if(choice == 2)
                renderer.material.color = Color.green;

        StartCoroutine(change_color());
    
    }


    IEnumerator change_color() {

        yield return new WaitForSeconds(5);

        if(renderer.material.color == Color.red)
            renderer.material.color = Color.yellow;

        else if(renderer.material.color == Color.yellow)
                renderer.material.color = Color.green;
        else 
            renderer.material.color = Color.red;

        StartCoroutine(change_color());

    }
    
}
