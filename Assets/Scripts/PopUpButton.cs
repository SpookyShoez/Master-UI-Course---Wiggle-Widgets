using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PopUpButton : MonoBehaviour
{
    public Transform content;
    public CanvasGroup darkCanvasGroup;

    private void OnEnable()
    {
        transform.localScale = Vector3.zero;//(0,0,0) (1,)
        transform.LeanScale(Vector3.one, 0.5f).setEaseOutBack();

        darkCanvasGroup.alpha = 0;
        darkCanvasGroup.LeanAlpha(1f, 0.5f);
    }

    public void OnClose()
    {
        transform.LeanScale(Vector3.zero, 0.5f).setEaseInOutSine().setOnComplete(() => {
        gameObject.SetActive(false);
        });
        darkCanvasGroup.LeanAlpha(0f, 0.5f);
    }       
}



