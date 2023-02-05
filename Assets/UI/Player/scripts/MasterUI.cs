using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterUI : MonoBehaviour
{
    public Health Health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Health.hp <=0)
            gameObject.SetActive(false);        
    }
}
