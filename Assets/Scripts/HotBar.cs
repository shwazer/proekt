using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotBar : MonoBehaviour
{
    Image[] thingImage;
    int place;
   [SerializeField] GameObject hand;

    void Start()
    {
        place = 0;
        hand.GetComponent<SpriteRenderer>().sprite = thingImage[place].sprite;
    }

    void Update()
    {
        float mouseWheel = Input.GetAxis("Mouse ScrollWheel");
        if (mouseWheel > 0)
        {
            place++;
            if(place > 0)
            {
                place = thingImage.Length + 1;
            }
        }
        if(mouseWheel < 0)
        {
            place--;
            if (place < 0)
            {
                place = thingImage.Length - 1; 
            }
        }
        else if (place >= thingImage.Length)
        {
            place = 0;
        }
        hand.GetComponent<SpriteRenderer>().sprite = thingImage[place].sprite;

    }
}
