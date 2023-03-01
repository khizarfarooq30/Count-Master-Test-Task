using System;
using DG.Tweening;
using UnityEngine;

public class TextTweener : MonoBehaviour
{
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        rectTransform.DOScale(1.15f, 0.75f).SetLoops(-1, LoopType.Yoyo);
    }

    private void OnDisable()
    {
        rectTransform.DOKill();
    }
}