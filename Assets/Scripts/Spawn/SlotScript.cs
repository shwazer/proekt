using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotScript : MonoBehaviour
{
    public bool freePlace = true;
    
    
    void Start()
    {
        if(transform.childCount > 0)
        {
            //Debug.Log("vse est!");
            freePlace = false;
            //return freePlace;
        }
        else
        {
            //Debug.Log("net");
            freePlace = true;
            //return freePlace;
        }
    }

    
    
}
