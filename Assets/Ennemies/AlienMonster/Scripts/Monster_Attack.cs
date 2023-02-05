using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Attack : MonoBehaviour
{
    public Player_Animation animator;

    public void set_attack(bool value) {
        animator.Set_animation_bool("Attack", value);
    }
}
