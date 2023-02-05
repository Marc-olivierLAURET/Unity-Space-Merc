using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject Weapon_Two;
    public GameObject Weapon_One;
    private WeaponStat current_weapon;

    //public Health health;

    private bool is_shooting = false;

    // Gun Stats



    private float cooldown_change_wp;
    private float change_wp = 1f;
    


    // Start is called before the first frame update
    void Start()
    {
        // Weapons stats
        current_weapon = Weapon_One.GetComponent<WeaponStat>();

        // Timer and cooldown management
        cooldown_change_wp = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WeaponsManagement(Player_Animation animator) {
        if ((Time.time < cooldown_change_wp)) {
            return;
        }
        if (!is_shooting && !current_weapon.reloading) {
            change_weapon(animator);
        }

        if ((Input.GetKeyDown("r") || current_weapon.current_clip == 0) && current_weapon.Reload())
            animator.Set_animation_trigger("IsReloading");

        if (current_weapon.automatic) {
            if (Input.GetMouseButton(0))
                is_shooting = true;
            else
                is_shooting = false;
        }
        else if (!current_weapon.automatic) {
            if (Input.GetMouseButtonDown(0))
                is_shooting = true;
            else
                is_shooting = false;
        }
        if (is_shooting)
            current_weapon.shoot();
    }

    void change_weapon(Player_Animation animator) {
        if (Input.GetAxis("Mouse ScrollWheel") != 0f ) {
            if (current_weapon == Weapon_One.GetComponent<WeaponStat>()) {
                current_weapon = Weapon_Two.GetComponent<WeaponStat>();
                Weapon_One.SetActive(false);
                Weapon_Two.SetActive(true);
            }
            else {
                current_weapon = Weapon_One.GetComponent<WeaponStat>();
                Weapon_Two.SetActive(false);
                Weapon_One.SetActive(true);
            }
            if (current_weapon.Is2HGun)
                animator.Set_animation_bool("2HGun", true);
            else
                animator.Set_animation_bool("2HGun", false);
            cooldown_change_wp = Time.time + change_wp;
        }
    }
}