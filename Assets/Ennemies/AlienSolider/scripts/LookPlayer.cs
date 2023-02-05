using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        

    }

    public bool lookTarget(GameObject targetPlayer) {
        RaycastHit hit;
        Ray ray = new Ray();

        ray.origin = transform.position;
        ray.direction = targetPlayer.transform.position - transform.position;

        if(Physics.Raycast(ray, out hit))
        {
            Vector3 playerTarget = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            transform.LookAt(playerTarget);
            if (hit.collider.name == "Player" && !hit.collider.gameObject.GetComponent<Health>().is_Dead()) {                            // faction? ex raider vs Zombies
                return (true);
            }
            else
                return (false);
        }
        return (false);
    }
}
