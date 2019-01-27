using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxLogic : MonoBehaviour
{
    public int maxAmount;
    public float maxForce = 100f;
    public float minForce = 20f;
    public List<Fruit> fruits;
    private int boxPrice;
    private int pricePerFruit = 10;
    // Start is called before the first frame update
    void Start()
    {
        
        fruits = new List<Fruit>();
        int amount = Random.Range(2, maxAmount);
        boxPrice = pricePerFruit * amount + (int)(GameObject.FindGameObjectWithTag("CustomerManager").GetComponent<CustomerManager>().customersServed*0.25f);
        for(int i = 0; i < amount; i++)
        {
            int whichFruit = Random.Range(0, System.Enum.GetValues(typeof(Fruit)).Length);
            fruits.Add((Fruit)whichFruit);
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("WOOOUT");
            Open();
            
        }*/
    }

    public void Open()
    {
        foreach(Fruit fruit in fruits)
        {
            GameObject obj = Instantiate(Resources.Load<GameObject>("Prefabs/" + fruit.ToString()),transform.position,Quaternion.identity);
            float forceX = Random.Range(-maxForce, maxForce);
            float forceY = Random.Range(-maxForce, maxForce);
            obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(forceX, forceY));
        }
        GameObject.FindGameObjectWithTag("CustomerManager").GetComponent<CustomerManager>().AddMoney(-boxPrice);
        Destroy(transform.parent.gameObject);
    }
}
