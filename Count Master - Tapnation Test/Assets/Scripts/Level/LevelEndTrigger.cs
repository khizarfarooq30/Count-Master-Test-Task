using UnityEngine;

public class LevelEndTrigger : MonoBehaviour
{
    [SerializeField] private ParticleSystem confettiEffect;

    [SerializeField] private bool isLevelWinTrigger;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            confettiEffect.Play();

            if (isLevelWinTrigger)
            {
                GameManager.GameWin();
                return;
            }
            
            GameManager.ReachedLevelEnd();
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        var boxTransform = transform;
        Gizmos.DrawWireCube(boxTransform.position, boxTransform.localScale);
    }
#endif
}
