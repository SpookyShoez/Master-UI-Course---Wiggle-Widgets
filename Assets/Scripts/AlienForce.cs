using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienForce : MonoBehaviour
{
    public GameObject resultWindow;

    // Start is called before the first frame update
    void Start()
    {
        LeanTween.delayedCall(10f, () => {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector3(45, 14f, 0), ForceMode2D.Impulse);
            rb.SetRotation(45f);
            LeanTween.delayedCall(5f, () => {
                if (resultWindow != null) {
                    resultWindow.SetActive(true);
                }
            });
        });
    }
}
