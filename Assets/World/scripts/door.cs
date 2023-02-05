using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public Transform shape;
    public Vector3 closedPosition;
    public Vector3 openedPosition;
    public float openSpeed = 5;

    private bool open = false;

    public AudioSource doorNoice;
    private int entitiesAround = 0;

    // Update is called once per frame
    void Update() {
        if (entitiesAround != 0) {
            shape.position = Vector3.Lerp(shape.position, openedPosition, Time.deltaTime * openSpeed);
        } else {
            shape.position = Vector3.Lerp(shape.position, closedPosition, Time.deltaTime * openSpeed);
        }
    }

    private void OnTriggerEnter(Collider other) {
        
        if (other.tag == "Actor") {
            entitiesAround +=1;
            Openshape();
        }
    }

    private void OnTriggerExit(Collider other) {
        
        if (other.tag == "Actor") {
            entitiesAround -= 1;
            Closeshape();
        }
    }

    public void Closeshape() {
        open = false;
    }

    public void Openshape() {
        doorNoice.Play();
        open = true;
    }
}
