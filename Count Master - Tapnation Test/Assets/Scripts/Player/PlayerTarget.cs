using DG.Tweening;
using UnityEngine;

public class PlayerTarget : MonoBehaviour
{
    [SerializeField] private ParticleSystem bloodEffect;

    public bool hasDetected;
    
    private PlayerCrowd playerCrowd;
    private bool isLevelEndReached;
    
    private void Start()
    {
        playerCrowd = GetComponentInParent<PlayerCrowd>();
        GameManager.Instance.OnGameFail += DisableTarget;
        GameManager.Instance.OnReachLevelEnd += OnReachLevelEnd;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnGameFail -= DisableTarget;    
        GameManager.Instance.OnReachLevelEnd -= OnReachLevelEnd;
    }

    private void DisableTarget()
    {
        gameObject.SetActive(false);
    }

    
    private void OnReachLevelEnd()
    {
        isLevelEndReached = true;
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
            if (isLevelEndReached)
            {
                if (playerCrowd.IsLastPlayerLeftInCrowd())
                {
                    GameManager.GameWin();
                    return;
                }
            }
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
