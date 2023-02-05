using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBehaviour : MonoBehaviour
{
    int bulletDamage = 0;
    Vector3 prev = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setDamage(int damage) {
        bulletDamage = damage;
    }

    private void OnTriggerEnter(Collider collision)
    {
        GameObject victim = collision.gameObject;

        if (victim.CompareTag("Door"))
            return;
        if (victim.CompareTag("Actor"))
         {
            victim.GetComponent<Health>().UpdateHp(-bulletDamage);
         }
        Destroy(gameObject);
    }

    private void OnTriggerExit(Collider collision) {
        GameObject victim = collision.gameObject;
        if (victim.CompareTag("Door"))
            return;

    }
}