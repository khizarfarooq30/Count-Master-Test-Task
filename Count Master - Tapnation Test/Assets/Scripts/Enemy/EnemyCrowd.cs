using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyCrowd : MonoBehaviour
{
    private int enemyAmount;

    [SerializeField] private float radius;
    [SerializeField] private float angle;
   
    [SerializeField] private List<EnemyController> enemyList;

    private EnemyCrowdCounter enemyCrowdCounter;

    private void Start()
    {
        enemyCrowdCounter = GetComponentInChildren<EnemyCrowdCounter>();
        enemyList = GetComponentsInChildren<EnemyController>().ToList();

        enemyAmount = enemyList.Count;
        enemyCrowdCounter.SetEnemyCounterText(enemyAmount);

        AssignCrowdPositions();
    }

    void AssignCrowdPositions()
    {
        for (int i = 0; i < enemyList.Count; i++)
        {
            enemyList[i].transform.localPosition = Helper.GetAngularPosition(i, radius, angle);
        }
    }

    public void KillEnemy()
    {
        enemyAmount--;
        enemyCrowdCounter.SetEnemyCounterText(enemyAmount);

        if (enemyAmount == 0)
        {
            enemyCrowdCounter.DisableCounter();
        }
    }
}