using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockRotation : MonoBehaviour
{
    public Transform clockHand;

    void Start() {
        LeanTween.delayedCall(3f, () => {
        clockHand.LeanRotateAroundLocal(Vector3.forward, -360f, 2f).setEaseInOutBack();
        }).setRepeat(-1);
    }
}

