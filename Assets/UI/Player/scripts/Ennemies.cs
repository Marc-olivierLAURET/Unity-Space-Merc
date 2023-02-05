using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemies : MonoBehaviour
{
    private int totalEnnemies = 1;
    private int aliveEnnemies = 1;

    public Ending Victory;

    //public GameObject Ennemies_obj;

    void Start()
    {
        totalEnnemies = countTotalEnnemies();
        aliveEnnemies = countAliveEnnemies();
    }

    void Update()
    {
        totalEnnemies = countTotalEnnemies();
        aliveEnnemies = countAliveEnnemies();

        if (aliveEnnemies == 0 && !Victory.gameObject.activeInHierarchy) {
            Victory.gameObject.SetActive(true);
            Victory.SetDead();
        }
    }

    private int countTotalEnnemies() {
        int ennemyCount = 0;
        foreach (Transform child in transform) {
            if (child.gameObject.activeInHierarchy)
                ennemyCount = ennemyCount + 1;
        }
        return (ennemyCount);
    }

    private int countAliveEnnemies() {
        int ennemyCount = 0;
        foreach (Transform child in transform) {
            if (child.gameObject.activeInHierarchy && child.gameObject.GetComponent<Health>().hp > 0)
                ennemyCount = ennemyCount + 1;
        }
        return (ennemyCount);
    }


    public int getTotalEnnemies() {
        return (totalEnnemies);
    }

    public int getAliveEnnemies() {
        return (aliveEnnemies);
    }
}
