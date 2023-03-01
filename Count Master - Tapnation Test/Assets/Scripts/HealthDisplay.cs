using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private Image healthFillImg;
    
    private void Start()
    {
        if (health == null)
        {
            health = GetComponentInParent<Health>();
        }
        
        health.OnHeal += OnHeal;
        health.OnDamage += OnDamage;
        UpdateHealthBarVisible();
    }
 
    private void OnDestroy()
    {
        health.OnDamage -= OnDamage;
        health.OnHeal -= OnHeal;
    }

    private void OnDamage()
    {
        healthFillImg.fillAmount = health.GetHealthAmountNormalized();
        UpdateHealthBarVisible();
    }
    
    private void OnHeal()
    {
        healthFillImg.fillAmount = health.GetHealthAmountNormalized();
    }

    void UpdateHealthBarVisible()
    {
        if (health.IsFullHealth())
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}