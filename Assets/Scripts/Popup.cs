using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    public Transform content;
    public CanvasGroup darkCanvasGroup;

    private void OnEnable() {
        content.localScale = Vector3.zero;
        content.LeanScale(Vector3.one, 0.5f).setEaseOutBack();

        darkCanvasGroup.alpha = 0;
        darkCanvasGroup.LeanAlpha(1f, 0.5f);
    }

    public void OnClose() {
        content.LeanScale(Vector3.zero, 0.5f).setEaseInOutSine().setOnComplete(() => {
            gameObject.SetActive(false);
        });
        darkCanvasGroup.LeanAlpha(0, 0.5f);
    }
}
