using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class CustomerLogic : MonoBehaviour
{
    public List<Fruit> ingredients;
    public GameObject fruitUI;
    public GameObject fruitImage;
    public int offSet = 10;
    public int customerRange = 10;
    public Color color;

    private float startX;
    private bool leave = false;
    private bool stopped = false;
    private CustomerManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("CustomerManager").GetComponent<CustomerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!leave)
        {
            if (!stopped)
            {
                if (Camera.main.WorldToScreenPoint(transform.position).x < manager.areaSize.x - customerRange && Camera.main.WorldToScreenPoint(transform.position).x > 0 + customerRange)
                {
                    if (Camera.main.WorldToScreenPoint(transform.position).y < manager.areaSize.y - customerRange && Camera.main.WorldToScreenPoint(transform.position).y > 0 + customerRange)
                    {
                        transform.parent.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
                        transform.parent.GetComponent<ConstantForce2D>().force = Vector2.zero;
                        transform.parent.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                        SetIngredients(0, 0);
                        stopped = true;
                    }
                }
            }
            else
            {
                transform.parent.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                transform.parent.GetComponent<Rigidbody2D>().rotation = 0;
                fruitUI.transform.position = Camera.main.WorldToScreenPoint(transform.position);
                fruitUI.transform.position = new Vector3(fruitUI.transform.position.x + 50, fruitUI.transform.position.y, 0);

            }
        }
        else
        {
            transform.parent.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            transform.parent.GetComponent<ConstantForce2D>().force = new Vector2(-10f, 0);
            if(startX - 0.8f > transform.position.x)
            {
                Destroy(gameObject.transform.parent.gameObject);
            }
        }
    }

    public void SetIngredients(int sideX, int sideY)
    {
        if(transform.position.x < manager.transform.position.x)
        {
            sideX = 1;
        }
        else
        {
            sideX = -1;
        }
        if (transform.position.y < manager.transform.position.y)
        {
            sideY = 1;
        }
        else
        {
            sideY = -1;
        }
        fruitUI = Instantiate(fruitUI, GameObject.FindGameObjectWithTag("Canvas").transform);
        fruitUI.transform.position = Camera.main.WorldToScreenPoint(transform.position);
        fruitUI.transform.position = new Vector3(fruitUI.transform.position.x + sideX*20, fruitUI.transform.position.y, 0);
        int howMany = Random.Range(1, 4);
        Color color1 = new Color();
        for(int i = 0; i < howMany; i++)
        {
            int whichFruit = Random.Range(0, System.Enum.GetValues(typeof(Fruit)).Length);
            if (i>0)
            {
                color1 = Camera.main.GetComponent<Functions>().CombineColors(color1, Resources.Load<GameObject>("Prefabs/" + ((Fruit)whichFruit).ToString()).GetComponentInChildren<FruitLogic>().color);
            }
            else
            {
                color1 = Resources.Load<GameObject>("Prefabs/" + ((Fruit)whichFruit).ToString()).GetComponentInChildren<FruitLogic>().color;
            }
            ingredients.Add((Fruit) whichFruit);

        }
        GameObject obj = Instantiate(fruitImage, fruitUI.transform);
        obj.transform.localPosition = new Vector3(0, 0, 0);
        obj.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Juice".ToString());
        obj.GetComponent<Image>().color = color1;
        color = color1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.tag == "Juice")
        {
            List<Fruit> juice = collision.gameObject.GetComponent<Juice>().GetIngredients();
            /*bool match = true;
            foreach(Fruit fruit in juice)
            {
                if(!ingredients.Contains(fruit))
                {
                    match = false;
                    break;
                }
            }
            */


            float h1, s1, v1;
            Color.RGBToHSV(color, out h1, out s1, out v1);

            float h2, s2, v2;
            Color.RGBToHSV(collision.gameObject.GetComponent<Juice>().color, out h2, out s2, out v2);

            float difference = Mathf.Abs(h1 - h2);

            bool upside = false;
            if (difference > 0.5f)
            {
                difference = 1 - difference;
                upside = true;
            }
            //MAYBE DOUBLE PENALTY
            GameObject text = Instantiate(Resources.Load<GameObject>("Prefabs/Text"), GameObject.FindGameObjectWithTag("Canvas").transform);

            int sideX, sideY;
            if (transform.position.x < manager.transform.position.x)
            {
                sideX = 1;
            }
            else
            {
                sideX = -1;
            }
            if (transform.position.y < manager.transform.position.y)
            {
                sideY = 1;
            }
            else
            {
                sideY = -1;
            }

            text.transform.position = Camera.main.WorldToScreenPoint(transform.position);
            text.transform.position = new Vector2(text.transform.position.x + sideX*80, text.transform.position.y );
            text.GetComponent<Text>().text = "I'm " + ((int)(100f - 2*difference * 100f)) + "% Happy";
            GameObject.FindGameObjectWithTag("CustomerManager").GetComponent<CustomerManager>().SpawnCustomer();
            GameObject.FindGameObjectWithTag("CustomerManager").GetComponent<CustomerManager>().AddMoney((int)(100f - 2 * difference * 100f));
            GameObject.FindGameObjectWithTag("CustomerManager").GetComponent<CustomerManager>().CustomerServed();

            Destroy(fruitUI);
            Destroy(collision.transform.parent.gameObject);
            //Destroy(gameObject.transform.parent.gameObject);
            leave = true;
            startX = transform.position.x;
            
        }
    }
}
