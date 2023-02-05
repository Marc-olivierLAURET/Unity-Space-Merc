using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


public class Objective : MonoBehaviour
{

    public Ennemies Ennemies_obj;
    public Text value;

    // Start is called before the first frame update
    void Start()
    {
        value.text = Ennemies_obj.getAliveEnnemies().ToString() + "/" + Ennemies_obj.getTotalEnnemies().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        value.text = Ennemies_obj.getAliveEnnemies().ToString() + "/" + Ennemies_obj.getTotalEnnemies().ToString();
    }
}
