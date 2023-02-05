using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawsBehaviour : MonoBehaviour
{
    public int damage = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        GameObject victim = collision.gameObject;
        if (victim.CompareTag("Actor"))
         {
            victim.GetComponent<Health>().UpdateHp(-damage);
         }
    }
}
