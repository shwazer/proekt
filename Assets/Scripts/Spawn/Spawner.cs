using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float startSpawnRes = 1f;
    [SerializeField] float colDownSpawn = 180f;
    [SerializeField] GameObject parent;
    [SerializeField] GameObject stone;
    [SerializeField] GameObject tree;
    public GameObject skin;
    private GameObject resurs;
    public float cellSize;
    public float cellWidth;
    public float cellHeight;
    public SlotScript slotScript;
    List<GameObject> slots = new List<GameObject> ();   
    
    

    void Start()
    {
        InvokeRepeating("Spawn", startSpawnRes, colDownSpawn);
    }

    void Awake()
    {
        Generate();
    }

    private void Generate()
    {
        for ( int x = 0; x < cellWidth; x++ )
        {
            for ( int y = 0; y < cellHeight; y++ )
            {
                GameObject grid = Instantiate(skin, new Vector3((x * cellSize) - 7.5f, (y * cellSize) - 27.5f, 0), Quaternion.identity);
                grid.transform.SetParent(transform);
                slots.Add(grid);
            }
        }
    }

    private void Spawn()
    {
        
        int count = Random.Range(0, slots.Count + 1);
        Vector3 cordRes = slots[count].transform.position;
        
        if (slots[count].GetComponent<SlotScript>().freePlace)
        {
            int cases = Random.Range(0, 2);
            switch (cases)
            {
                case 0:
                    parent = Instantiate(stone, cordRes, Quaternion.identity);
                    parent.transform.SetParent(transform);
                    slots[count].GetComponent<SlotScript>().freePlace = false;
                    break;

                case 1:
                    parent = Instantiate(tree, cordRes, Quaternion.identity);
                    parent.transform.SetParent(transform);
                    slots[count].GetComponent<SlotScript>().freePlace = false;
                    break;
                case 2:
                    break;
            }
        }
    }

   


}
