using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsCode : MonoBehaviour
{
    private Inventory invent;
    [SerializeField] string iName;
    [SerializeField] float iSize;
    [SerializeField] Sprite iSprite;
    public void Start()
    {
        invent = FindObjectOfType<Inventory>();    
    }
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("item if 1");
            if (invent.InventCalculations(iName, iSprite))
            {
                Debug.Log("item if 2");
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("error");
            }
        }

    }
    

}
