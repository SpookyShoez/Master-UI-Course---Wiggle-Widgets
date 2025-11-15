using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAnimation : MonoBehaviour
{
    public Transform image;
    
    // Start is called before the first frame update
    void Start()
    {
        image.LeanMoveLocalX(200, 2f);
    }

}
