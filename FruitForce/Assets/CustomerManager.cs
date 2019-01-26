﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Fruit
{
    Banana,
    Apple,
    Orange
}

public class CustomerManager : MonoBehaviour
{
    public GameObject customerPrefab;
    public Vector2 areaSize;
    public int distanceFromEdge;
    
    // Start is called before the first frame update
    void Start()
    {
        areaSize = new Vector2(Camera.main.pixelWidth, Camera.main.pixelHeight);
        Debug.Log("Resolution " + areaSize);
        distanceFromEdge = 50;
        SpawnCustomer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 RandomSpawnPos()
    {
        int where = Random.Range(0, 2);
        Debug.Log("Where " + where);
        int x, y;
        if(where == 0)
        {
            x = Random.Range(0 + distanceFromEdge, (int)areaSize.x - distanceFromEdge);
            where = Random.Range(0, 2);
            if (where == 0)
            {
                y = 0 + distanceFromEdge;
            }
            else
            {
                y = (int)areaSize.y - distanceFromEdge;
            }
                
        }
        else
        {
            y = Random.Range(0 + distanceFromEdge, (int)areaSize.y - distanceFromEdge);
            where = Random.Range(0, 2);
            
            if (where == 0)
            {
                x = 0 + distanceFromEdge;
            }
            else
            {
                x = (int)areaSize.x - distanceFromEdge;
            }
        }
        Debug.Log("X " + x + " Y " + y);
        return Camera.main.ScreenToWorldPoint(new Vector3(x,y,0));
    }

    public void SpawnCustomer()
    {
        Vector2 spawnPos = RandomSpawnPos();
        Debug.Log("SSPAWNWN "+spawnPos);
        GameObject customer = Instantiate(customerPrefab, spawnPos, Quaternion.identity);
        int x = 0;
        int y = 0;
        if(spawnPos.x == (0 + distanceFromEdge))
        {
            x = 1;
        }
        else if(spawnPos.x == (areaSize.x - distanceFromEdge))
        {
            x = -1;
        }
        if (spawnPos.y == (0 + distanceFromEdge))
        {
            y = 1;
        }
        else if (spawnPos.y == (areaSize.y - distanceFromEdge))
        {
            y = -1;
        }
        customer.GetComponentInChildren<CustomerLogic>().SetIngredients(x,y);

    }
}