using DG.Tweening;
using UnityEngine;

public class PlayerTarget : MonoBehaviour
{
    [SerializeField] private ParticleSystem bloodEffect;

    private PlayerCrowd playerCrowd;
    
    public bool hasDetected;

    private void Start()
    {
        playerCrowd = GetComponentInParent<PlayerCrowd>();
        GameManager.Instance.OnGameFail += DisableTarget;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnGameFail -= DisableTarget;
    }

    private void DisableTarget()
    {
        gameObject.SetActive(false);
    }

    public void Kill()
    {
        bloodEffect.transform.parent = null;
        bloodEffect.Play();
        transform.parent = null;
        PlayerCrowd.OnSubractCrowd?.Invoke();
        transform.DOKill();
        playerCrowd.UpdateCrowdCounterText();
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Obstacle obstacle))
        {
            Kill();
        }
        
        
        if (other.TryGetComponent(out Multiplier multiplier))
        {
           
            if (playerCrowd.IsLastPlayerLeftInCrowd())
            {
                GameManager.GameWin();
                return;
            }
            
            multiplier.Disable();
            Kill();
        }
    }
}
