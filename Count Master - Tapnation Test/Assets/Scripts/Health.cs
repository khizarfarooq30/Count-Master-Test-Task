using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    public int Max_Health { get { return maxHealth; } set { maxHealth = value; } }
    private int currentHealth;
   
    public Action OnDamage;
    public Action OnDie;
    public Action OnHeal;
        
    private void Start()
    {
        currentHealth = maxHealth;
    }

    [ContextMenu("Damage player")]
    public void TestPlayerDamage()
    {
        AddDamage(currentHealth - Mathf.FloorToInt(currentHealth * 0.5f));
    }
    
    public void AddDamage(int damageAmount)
    {
        if(IsDead()) return;
        
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        
        OnDamage?.Invoke();

        if (IsDead())
        {
            OnDie?.Invoke();
        }
    }

    public bool IsDead() => currentHealth == 0;

    public float GetHealthAmountNormalized() => (float)currentHealth / maxHealth;

    public bool IsFullHealth() => currentHealth == maxHealth;

    public void SetHealthAmountMax(int maxHealthAmount, bool updateHealthAmount)
    {
        maxHealth = maxHealthAmount;

        if (updateHealthAmount) currentHealth = maxHealth;
        
        OnHeal?.Invoke();
    }

    public void AddHeal(float healAmount)
    {
        currentHealth += Mathf.FloorToInt(healAmount);
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        OnHeal?.Invoke();
    }
}
