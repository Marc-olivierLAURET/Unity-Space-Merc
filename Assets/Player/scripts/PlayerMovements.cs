using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{

    public Rigidbody body;
    public float speed;
    public float turnSpeed;
    public float turnAngle;

    // public Health health;

    // public Player_Animation animator;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void move(Player_Animation animator) {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float current_speed = speed;

        moveAnimation(h, v, animator);

        if (v < 0 || h != 0)
            current_speed = (current_speed / 2);

        Vector3 mv = new Vector3(h, 0f, v);
        transform.Translate(mv * current_speed * Time.deltaTime);
    }

    private void moveAnimation(float h, float v, Player_Animation animator) {
        // Animation Management

        // DIAGONAL
        if ((v > 0 && h > 0))
            animator.Set_animation_int("isWalking", 9);

        else if ((v < 0 && h > 0))
            animator.Set_animation_int("isWalking", 3);
        
        else if ((v > 0 && h < 0))
            animator.Set_animation_int("isWalking", 7);

        else if ((v < 0 && h < 0))
            animator.Set_animation_int("isWalking", 1);

        // VERTICAL AND HORIZONTAL
        else if (v > 0)
            animator.Set_animation_int("isWalking", 8);

        else if (v < 0)
            animator.Set_animation_int("isWalking", 2);
        
        else if (h > 0)
            animator.Set_animation_int("isWalking", 6);

        else if (h < 0)
            animator.Set_animation_int("isWalking", 4);
        
        // IDLE
        else if ((v == 0 && h == 0))
            animator.Set_animation_int("isWalking", 0);
    }
}
