using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpButton : MonoBehaviour
{
    private void OnEnable()
    {
        transform.localScale = Vector3.zero;//(0,0,0) (1,1,1)
        transform.LeanScale(Vector3.one, 0.5f).setEaseOutBack();
    }

    public void OnClose()
    {
        transform.LeanScale(Vector3.zero, 0.5f).setEaseInOutSine().setOnComplete(() => {
            gameObject.SetActive(false);
        });
    }       
}

