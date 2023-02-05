using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scanner : MonoBehaviour
{
    public AudioSource alertAudio;
    public Material RedMaterial;
    public Material ObjMaterial;

    private bool is_alert = false;

    private void OnTriggerEnter(Collider other) {
        if (!is_alert &&  other.tag == "Actor") {
                StartAlert();
        }
    }

    private void StartAlert() {
        Material[] matArray = gameObject.GetComponent<MeshRenderer> ().materials;
        matArray[1] = RedMaterial;
        gameObject.GetComponent<MeshRenderer> ().materials = matArray;
        alertAudio.Play();
        is_alert = true;
    }
}
