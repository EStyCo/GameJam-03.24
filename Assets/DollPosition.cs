using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollPosition : MonoBehaviour
{
    [SerializeField] GameObject leftPosition;
    [SerializeField] GameObject rightPosition;

    public void SwitchPosition(bool isLeft)
    { 

        if(!isLeft)
        {
            transform.position = rightPosition.transform.position;
            gameObject.GetComponentInChildren<SpriteRenderer>().flipY = true;
        }
        else 
        {
            transform.position = leftPosition.transform.position;
            gameObject.GetComponentInChildren<SpriteRenderer>().flipY = false;
        }
    }
}
