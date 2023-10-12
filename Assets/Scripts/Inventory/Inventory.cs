using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject slot;
    [SerializeField] GameObject slot2;
    float maxStack = 6;
    List<Construct> items = new List<Construct> ();
    public float maxQuant = 24;
    [SerializeField] GameObject panel;
    public Construct fItem;
    void Awake()
    {
        
    }
    public bool InventCalculations(string iName, Sprite iSprite)
    {
        Debug.Log("start");
        foreach (Construct fItem in items)
        {
            Debug.Log("foreach");
            if (fItem.iName == iName)
            {
                Debug.Log("1if");
                if (fItem.iSize < maxStack)
                {
                    fItem.iSize++;
                    Debug.Log(fItem.iSize);
                    UpdateUISpawn();
                    return true;
                    Debug.Log("2if");
                }
            }
        }
          if (items.Count < maxQuant)
            {
                Construct newItem = new Construct(iName, iSprite);
                items.Add(newItem);
                UpdateUISpawn();
                return true;
                Debug.Log("if");


            }   
            else
            {
                Debug.Log("test");
            }
        
        return false;
    }
 //public void Update()
   // {
     //   UpdateUI();
    //}
    
    public void UpdateUISpawn()
    {
        foreach (Transform child in panel.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Construct fItem in items)
        {
            GameObject clonSlot = Instantiate(slot, panel.transform);
            Image pict = clonSlot.GetComponent<Image>();
            Text text = clonSlot.GetComponentInChildren<Text>();
            pict.sprite = fItem.iSprite;
            text.text = fItem.iSize.ToString();
        }
    }
    //public void UpdateUI()
    //{
       // foreach (Construct fItem in items)
       // {
          //  for (int i = 0; i < 5; i++)
           // {

              //  Image pict2 = slot2.GetComponent<Image>();
              //  Text text2 = slot2.GetComponentInChildren<Text>();
             //   pict2.sprite = fItem.iSprite;
             //   text2.text = fItem.iSize.ToString();
           // }
        //}
        

    //}
}
public class Construct
{
    public string iName;
    public Sprite iSprite;
    public float iSize;



    public Construct(string consName, Sprite consSprite)
    {
        iName = consName;   
        iSprite = consSprite;   
        iSize = 1f;

    }
}
