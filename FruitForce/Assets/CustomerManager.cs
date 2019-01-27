using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Fruit
{
    Orange,
    Red,
    Green,
    Yellow,
    Purple

}

public class CustomerManager : MonoBehaviour
{
    public GameObject customerPrefab;
    public Vector2 areaSize;
    public int distanceFromEdge;
    public int money = 100;
    public int customersServed = 0;
    public int customerFrequency = 60;
    public int maxCustomers = 100;
    private int counter = 0;
    private float customerSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        areaSize = new Vector2(Camera.main.pixelWidth, Camera.main.pixelHeight);
        Debug.Log("Resolution " + areaSize);
        distanceFromEdge = -50;
        SpawnCustomer();
        GameObject.FindGameObjectWithTag("Score").GetComponent<Text>().text = "Money: " + money.ToString();
        GameObject.FindGameObjectWithTag("Customers").GetComponent<Text>().text = "Customers Served: " + customersServed.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        counter++;
        if(counter > customerFrequency && GameObject.FindGameObjectsWithTag("Customer").Length < maxCustomers)
        {
            SpawnCustomer();
            counter = 0;
        }
    }

    public Vector3 RandomSpawnPos(bool customer)
    {
        /*
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
        */
        float y = Random.Range(0 - distanceFromEdge, (int)areaSize.y + distanceFromEdge);
        float x;
        if (customer == true)
        {
            x = 0 + distanceFromEdge;
        }
        else
        {
            x = (int)areaSize.x - distanceFromEdge;
        }
        return Camera.main.ScreenToWorldPoint(new Vector3(x, y, 0));
    }

    public void SpawnCustomer()
    {
        Vector2 spawnPos = RandomSpawnPos(true);
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
        //customer.GetComponentInChildren<CustomerLogic>().SetIngredients(x,y);
        Vector2 dir = transform.position - customer.transform.position;
        customer.transform.position = new Vector3(customer.transform.position.x, customer.transform.position.y, 0);
        /*
        if (dir.x < dir.y)
        {
            dir = new Vector2(0, dir.y);
        }
        else
        {
            dir = new Vector2(dir.x, 0);

        }
        */
        //customer.GetComponent<Rigidbody2D>().AddForce(dir.normalized * 80f);
        customer.GetComponent<ConstantForce2D>().force = dir.normalized*customerSpeed;
        int spriteNum = Random.Range(1, 5);
        customer.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/doggy" + spriteNum);
    }

    public void AddMoney(int amount)
    {
        money += amount;
        GameObject.FindGameObjectWithTag("Score").GetComponent<Text>().text = "Score: " + money.ToString();
        if(money<0)
        {
           //YOUU LOOOSE
        }
    }
    public void CustomerServed()
    {
        customersServed++;
        GameObject.FindGameObjectWithTag("Customers").GetComponent<Text>().text = "Customers Served: " + customersServed.ToString();

    }
}
