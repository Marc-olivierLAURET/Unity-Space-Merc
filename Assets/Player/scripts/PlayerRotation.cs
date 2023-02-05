using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{

    public Camera followCam;
    public GameObject mouseTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void look(bool status) {
        RaycastHit hit;
        Ray ray = followCam.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit) ) {
            Vector3 tpm = hit.point;
            mouseTarget.transform.position = tpm;
            if (status) {
                return;
        }
        Vector3 playerTarget = new Vector3(hit.point.x, transform.position.y, hit.point.z);
        transform.LookAt(playerTarget);
        }
    }
}