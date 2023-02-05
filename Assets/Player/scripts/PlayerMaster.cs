using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMaster : MonoBehaviour
{
    public Health health;
    public PlayerMovements movements;
    public PlayerRotation rotation;
    public Attack attack;

    public Player_Animation animator;

    public SceneManagement management;
    public Ending game_over;
    public Ending Victory;

    private bool is_Dead = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (game_over.gameObject.activeInHierarchy || Victory.gameObject.activeInHierarchy) {
            animator.Set_animation_int("isWalking", 0);
            return;
        }

        bool status = health.is_Dead();

        if (management.Get_Pause())
            return;

        rotation.look(status);
        if (status) {
            if (!is_Dead) {
                is_Dead = true;
                game_over.gameObject.SetActive(true);
                game_over.SetDead();
            }
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (management.Get_Pause())
                management.PauseMenu(false);
            else
                management.PauseMenu(true);
        }

        movements.move(animator);
        attack.WeaponsManagement(animator);
    }
}
