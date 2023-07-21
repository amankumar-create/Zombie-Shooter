using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Enemies : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI remZom;

    int enemiesCount;
    void Start()
    {
        enemiesCount = transform.childCount;
        remZom.text = enemiesCount.ToString();

    }

    public int GetEnemiesCount()
    {
        return enemiesCount;
    }

    public void ReduceEnemiesCount()
    {
        enemiesCount--;
        remZom.text =  enemiesCount.ToString();
    }
}
