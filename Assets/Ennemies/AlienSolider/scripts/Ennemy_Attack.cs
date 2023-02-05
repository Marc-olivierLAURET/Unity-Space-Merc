using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy_Attack : MonoBehaviour
{
    public WeaponStat weapon;

    private bool is_shooting = false;


    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        if (is_shooting) {
            weapon.shoot();
        }
    }

    public void Set_Shooting(bool value) {
        is_shooting = value;
    }
}
