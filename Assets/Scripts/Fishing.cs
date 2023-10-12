using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing : MonoBehaviour
{
    [SerializeField] GameObject fish;
    [SerializeField] GameObject player;
    float posX;
    float posY;
    float rayLength = 1f;
    int timer;
    int timerTime = 30;
    bool fishingTimer = true;
    Vector2 dir;
    [SerializeField] LayerMask layerMask;
    [SerializeField] PlayerMove dirPlayer;

    void Update()
    {
        RaycastPhysics();
        if (timer == 0)
        {   
            fishingTimer = true;
        }
    }
    void RaycastPhysics()
    {
        posX = player.transform.position.x;
        posY = player.transform.position.y;

        Vector2 pos = transform.position; 
        
        Direction();


        RaycastHit2D ray = Physics2D.Raycast(pos, dir, rayLength, layerMask);

        Debug.DrawRay(pos, dir * rayLength, Color.green, 1f);
        if (ray.collider != null)
        {
            // Debug.Log(ray.collider.name);
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("E");
                Debug.Log(fishingTimer);
                if (fishingTimer == true)
                {
                    timer = timerTime;
                    RandFishing();
                    fishingTimer = false;
                    Debug.Log("Yes");
                }
            }
        }
    }

    void RandFishing()
    {
        int random = Random.Range(0, 3);
       
        Debug.Log(random + "RANDOM");
        Vector3 posFish = new Vector3(posX, posY, 0);
        switch (random)
        {
            case 0:
                Instantiate(fish, posFish, Quaternion.identity);
                StartCoroutine(Timer());
                break;

            case 1:
                Debug.Log("case 1");
                StartCoroutine(Timer());
                break;

            case 2:
                Debug.Log("case 2");
                StartCoroutine(Timer());
                break;

            case 3:
                Debug.Log("case 3");
                StartCoroutine(Timer());
                break;
        }
    }

    IEnumerator Timer()
    {
        while (timer > 0)
        {
            timer--;
            Debug.Log(timer);
            yield return new WaitForSeconds(1f);
        }
    }
    private void Direction ()
    {
        if (dirPlayer.moveV > 0)
        {
            dir = transform.up;
        }
        else if (dirPlayer.moveV < 0)
        {
            dir = -transform.up;       
        }        
        else if (dirPlayer.moveH > 0)
        {
            dir = transform.right;      
        }        
        else if (dirPlayer.moveH < 0)
        {
            dir = -transform.right;   
        }
    }
}
