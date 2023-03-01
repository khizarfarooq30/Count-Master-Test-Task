using System;
using TMPro;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private GateType gateType;
    public GateType GateType => gateType;
    
   
    [SerializeField] private int amount;
    public int GateAmount => amount;
    
    
    [SerializeField] private Collider gateCollider;
    [SerializeField] private Collider otherGate;
    
    
    [SerializeField] private Color positiveColor;
    [SerializeField] private Color negativeColor;
    
    [SerializeField] private TextMeshPro gateText;
    [SerializeField] private SpriteRenderer gateSprite;

    
    private void Awake()
    {
        InitGate();
    }

    private void InitGate()
    {
        switch (gateType)
        {
            case GateType.Add:
                UpdateGateVisuals(positiveColor, "+", amount);
                break;
            case GateType.Subract:
                UpdateGateVisuals(negativeColor, "-", amount);
                break;
            case GateType.Multiply:
                UpdateGateVisuals(positiveColor, "x", amount);
                break;
            case GateType.Divide:
                UpdateGateVisuals(negativeColor, "/", amount);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void UpdateGateVisuals(Color gateColor, string prefix, int gateAmount)
    {
        gateSprite.color = gateColor;
        gateText.text = prefix + gateAmount;
    }

    public void DisableGate()
    {
        gateSprite.gameObject.SetActive(false);
        gateText.gameObject.SetActive(false);
        gateCollider.enabled = false;
        otherGate.enabled = false;
    }
}

public enum GateType
{
    Add,
    Subract,
    Multiply,
    Divide
}
