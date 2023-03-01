using UnityEngine;

public class PlayerSensor : MonoBehaviour
{
    [SerializeField] private PlayerCrowd playerCrowd;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Gate gate))
        {
            TriggerGate(gate.GateType, gate.GateAmount);
            gate.DisableGate();
        }

    }

    private void TriggerGate(GateType type, int amount)
    {
        playerCrowd.TriggerGate(type, amount);
    }
}
