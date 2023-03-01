using TMPro;
using UnityEngine;

public class EnemyCrowdCounter : MonoBehaviour
{
   [SerializeField] private TextMeshPro enemyCounterText;


   public void SetEnemyCounterText(int amount)
   {
      enemyCounterText.SetText(amount.ToString());
   }

   public void DisableCounter()
   {
      gameObject.SetActive(false);
   }
}
