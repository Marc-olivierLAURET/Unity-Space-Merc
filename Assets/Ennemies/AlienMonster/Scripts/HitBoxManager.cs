using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxManager : MonoBehaviour
{
    public GameObject attackPoint_1;
    public GameObject attackPoint_2;
    
    public void ActivateAttackPoint(int index)
    {
        if (index == 1) {
            attackPoint_1.SetActive(true);
        }
        else if (index == 2) {
            attackPoint_2.SetActive(true);
        }
        
    }
    public void DesactivateAttackPoint(int index)
    {
        if (index == 1 && attackPoint_1.activeInHierarchy)
            attackPoint_1.SetActive(false);
        else if (index == 2 && attackPoint_2.activeInHierarchy)
            attackPoint_2.SetActive(false);
    }
}
