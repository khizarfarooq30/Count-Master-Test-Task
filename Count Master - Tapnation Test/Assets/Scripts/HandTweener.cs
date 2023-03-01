using DG.Tweening;
using UnityEngine;

public class HandTweener : MonoBehaviour
{
    [SerializeField] private float xTweenVal = 208f;
    
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        rectTransform.DOAnchorPos3DX(xTweenVal, 1f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
    }

    private void OnDisable()
    {
        rectTransform.DOKill();
    }
}