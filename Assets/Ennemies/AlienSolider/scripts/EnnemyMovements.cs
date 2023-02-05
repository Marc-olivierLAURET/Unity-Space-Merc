using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class EnnemyMovements : MonoBehaviour
{

    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public float move(GameObject player, bool movement, float min_distance, Player_Animation animator) {
        if (movement && Vector3.Distance(player.transform.position, transform.position) > min_distance) {
            agent.SetDestination(player.transform.position);
            animator.Set_animation_bool("isWalking", true);
        } 
        else {
            agent.SetDestination(transform.position);
            animator.Set_animation_bool("isWalking", false);
        }
        return (Vector3.Distance(player.transform.position, transform.position));
    }

    public void moveDeath() {
        agent.SetDestination(transform.position);
    }
}
