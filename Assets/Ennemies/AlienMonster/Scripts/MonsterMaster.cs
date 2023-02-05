using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMaster : MonoBehaviour
{
    public Health health;
    public Collider Collider;
    private bool Death = false;

    public GameObject targetPlayer;
    public Monster_Attack attack;

    public bool move = false;

    public float min_distance = 4f;

    public EnnemyMovements movements;
    public LookPlayer target;

    public Player_Animation animator;

    public LayerMask PlayerLayer;
    public float ChaseRange = 7f;

    private bool playerSpotted = false;

    public AudioSource spoted;


    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

        // Testing
           
        //
        bool ranged = Physics.CheckSphere(transform.position, ChaseRange, PlayerLayer);
        if (!playerSpotted && ranged || (health.hp != health.Max_hp && !playerSpotted)) {
            spoted.Play();
            playerSpotted = true;
            ChaseRange = ChaseRange * 1.5f;
        }

        if (Death || !ranged)
            return;
        
        bool targetInRange = target.lookTarget(targetPlayer);
        float distance = movements.move(targetPlayer, move, min_distance, animator);

        if (targetInRange && distance <= 2) {
            attack.set_attack(true);
        }
        else {
            attack.set_attack(false);
        }
        
        if (health.is_Dead()) {
            Death = true;
            Collider.enabled = false;
            movements.moveDeath();
            animator.Set_animation_bool("isWalking", false);
            animator.Set_animation_trigger("IsDead");
        }
    }
}
