using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovements : MonoBehaviour
{

    public GameObject followTarget;
    public float followSpeed;
    public float followHeight;
    public float followDistance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        Vector3 targetPosition = followTarget.transform.position;
        targetPosition.y += followHeight;
        targetPosition.z -= followDistance;

        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed);
    }
}