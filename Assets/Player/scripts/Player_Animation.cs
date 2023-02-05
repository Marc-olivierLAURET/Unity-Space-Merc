using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animation : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public int Get_animation_int(string key) {
        return (animator.GetInteger(key));
    }

    public void Set_animation_int(string key, int value) {
        animator.SetInteger(key, value);
    }

    public bool Get_animation_bool(string key) {
        return (animator.GetBool(key));
    }

    public void Set_animation_bool(string key, bool value) {
         animator.SetBool(key, value);
    }

    public void Set_animation_trigger(string key) {
         animator.SetTrigger(key);
    }
}
