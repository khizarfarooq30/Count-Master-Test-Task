using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class PlayerCrowd : MonoBehaviour
{
    [SerializeField] private PlayerCrowdCounter playerCrowdCounter;
    [SerializeField] private PlayerAnimator visualPrefab;
    
    [SerializeField] private Transform crowdParent;
    [SerializeField] private float radius;
    [SerializeField] private float angle;

    public static Action OnSubractCrowd;

    private void Start()
    {
        AssignCrowdPositions();
    }

    private void AssignCrowdPositions()
    {
        for (int i = 0; i < crowdParent.childCount; i++)
        {
            crowdParent.GetChild(i).DOLocalMove(Helper.GetAngularPosition(i, radius, angle), 0.5f).SetEase(Ease.OutBack);
        }       
        
        playerCrowdCounter.SetCrowdCounterText(crowdParent.childCount);
    }
    
    public float GetCrowdRadius()
    {
        return radius * Mathf.Sqrt(crowdParent.childCount);
    }

    public void TriggerGate(GateType type, int amount)
    {
        int childCount = crowdParent.childCount;
        
        switch (type)
        {
            case GateType.Add:
                AddCrowd(amount);
                break;
            case GateType.Subract:
                SubractCrowd(amount);
                break;
            case GateType.Multiply:
                int amountToMultiply = childCount * amount - childCount;
                AddCrowd(amountToMultiply);
                break;
            case GateType.Divide:
                int amountToDivide = childCount - (childCount / amount);
                SubractCrowd(amountToDivide);
                break;
        }
    }

    private void AddCrowd(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
           PlayerAnimator playerAnimator =  Instantiate(visualPrefab, crowdParent);
           playerAnimator.Run();

           playerAnimator.gameObject.name = "player visual " + i;
        }

        AssignCrowdPositions();
    }

    private void SubractCrowd(int amount)
    {
        if (amount > crowdParent.childCount)
        {
            amount = crowdParent.childCount;
            GameManager.GameFail();
        }

        int currentCrowdCount = crowdParent.childCount;
        
        for (int i = currentCrowdCount - 1; i >= currentCrowdCount - amount; i--)
        {
            Transform childTransform = crowdParent.GetChild(i);
            childTransform.parent = null;
            Destroy(childTransform.gameObject);
            
            playerCrowdCounter.SetCrowdCounterText(crowdParent.childCount);
        }

        AssignCrowdPositions();
        OnSubractCrowd?.Invoke();
    }

    public void UpdateCrowdCounterText()
    {
        playerCrowdCounter.SetCrowdCounterText(crowdParent.childCount);
    }

    public bool IsLastPlayerLeftInCrowd() => crowdParent.childCount == 1;
}
