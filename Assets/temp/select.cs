using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class select : MonoBehaviour
{
    public Text[] texts = new Text[5];
    [HideInInspector]
    public int config = 0;

    [SerializeField]
    MeshRenderer renderer;

    [SerializeField]
    GameObject ui_button, select_center, pause;

    [SerializeField]
    GameObject[] todeactivate = new GameObject[3];

    public Rigidbody rigidbody;
    public Slider[] sliders = new Slider[5];

    auto_controller controller;

    void Start() {

        ui_button.SetActive(false);
        select_center.SetActive(true);
        pause.SetActive(false);

        controller = GameObject.Find("player").GetComponent<auto_controller>();
    
    }

    void toall() {

        ui_button.SetActive(true);
        select_center.SetActive(false);
        Destroy(todeactivate[0]);
        Destroy(todeactivate[1]);
        Destroy(todeactivate[2]);

        controller.set_data();

            sliders[0].value = controller.acceleration;
            texts[4].text = sliders[0].value.ToString();

            sliders[1].value = controller.deacceleration;
            texts[0].text = sliders[1].value.ToString();

            sliders[2].value = controller.brake_force;
            texts[1].text = sliders[2].value.ToString();

            sliders[3].value = controller.rotate_angle;
            texts[2].text = sliders[3].value.ToString();

            sliders[4].value = rigidbody.mass;
            texts[3].text = sliders[4].value.ToString();

    }


    public void red_default() {
    
        config=1;
        toall();
    
    }


    public void green_default() {

        config=2;
        renderer.material.color = Color.green;
        toall();

    }

    public void purple_default() {
    
        config=3;
        renderer.material.color = Color.magenta;
        toall();

    }


    public void cyan_default() {
        
        config=4;
        renderer.material.color = Color.cyan;
        toall();

    }
    

    public void accelrartion (float value) {
        controller.acceleration = value;
        texts[4].text = value.ToString();
        
    }

    public void deaccelrartion (float value) {
        controller.deacceleration = value;
        texts[0].text = value.ToString();
    }

    public void brake (float value) {
        controller.brake_force = value;
        texts[1].text = value.ToString();

    }

    public void rot_angle (float value) {
        controller.rotate_angle = value;
        texts[2].text = value.ToString();

    }

    public void weight (float value) {
        rigidbody.mass = value;
        texts[3].text = value.ToString();

    }

    public void pause_menu() {
        ui_button.SetActive(false);
        pause.SetActive(true);
    }

    public void pause_close() {
        ui_button.SetActive(true);
        pause.SetActive(false);
    }

    public void restart() {

        SceneManager.LoadScene(0);

    }

}
