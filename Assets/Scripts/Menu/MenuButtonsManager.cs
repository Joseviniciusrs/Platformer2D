using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuButtonsManager : MonoBehaviour
{
    public List<GameObject> buttons;

    [Header("Animation")]
    public float duracao = .2f;
    public float delay = .05f;
    public Ease ease = Ease.OutBack;

    private void Awake()
    {
        HideAllButtons();
        ShowButtons();
    }

    private void HideAllButtons()
    {
        foreach(var h in buttons)
        {
            h.transform.localScale = Vector3.zero;
            h.SetActive(false);
        }
    }

    private void ShowButtons()
    {

        for (int i = 0; i < buttons.Count; i++)
        {
            var h = buttons[i];
            h.SetActive(true);
            h.transform.DOScale(1, duracao).SetDelay(i*delay).SetEase(ease);
        }
    }
}
