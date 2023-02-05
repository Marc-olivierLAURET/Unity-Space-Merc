using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Player_Animation animator;
    public AudioSource hit = null;
    public AudioSource dead = null;

    public float Max_hp = 100;
    public float hp = 100;
    bool isDead = false;

    private float Hit_cooldown;
    public float Hit_Anim_time = 3f;

    public bool regenerateHealth = false;
    public float healthPerSecond = 1;


    void Start() {
        Hit_cooldown = Time.time;
    }

    void Update() {
        if (hp > Max_hp)
            hp = Max_hp;
        if (hp < 0)
            hp = 0;
        if (hp > 0 && hp < Max_hp && regenerateHealth)
            hp += healthPerSecond * Time.deltaTime;
    }

    public bool UpdateHp(int newValue) {
        hp += newValue;

        if (hp <= 0) {
            if (!isDead) {
                if (dead)
                    dead.Play(0);
                animator.Set_animation_trigger("IsDead");
                animator.Set_animation_trigger("IsDead_Upper");
            }
            isDead = true;
            return (true);
        }

        if (Hit_cooldown < Time.time) {
            if (hit)
                hit.Play(0);
            animator.Set_animation_trigger("Hit");
            Hit_cooldown = Time.time + Hit_Anim_time;
        }
        return (false);
    }

    public bool is_Dead() {
        return (isDead);
    }

    public void set_Death(bool newValue) {
        isDead = newValue;
    }

    public float getHPpercent() {
        if (hp == Max_hp)
            return (100);
        return ((hp % Max_hp));
    }
}
