using UnityEngine;
using UnityEngine.EventSystems;

public class GameStartTrigger : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        GameManager.GameStart();
        gameObject.SetActive(false);
    }
}
