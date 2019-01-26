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
    public Color color;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetIngredients(int sideX, int sideY)
    {
        fruitUI = Instantiate(fruitUI, GameObject.FindGameObjectWithTag("Canvas").transform);
        fruitUI.transform.position = Camera.main.WorldToScreenPoint(transform.position);
        fruitUI.transform.position = new Vector3(fruitUI.transform.position.x + sideX*40, fruitUI.transform.position.y + sideY*40, 0);
        int howMany = Random.Range(1, 4);
        Color color1 = new Color();
        for(int i = 0; i < howMany; i++)
        {
            int whichFruit = Random.Range(0, System.Enum.GetValues(typeof(Fruit)).Length);
            if (i>0)
            {
                color1 = Camera.main.GetComponent<Functions>().CombineColors(color1, Resources.Load<GameObject>("Prefabs/" + ((Fruit)whichFruit).ToString()).GetComponentInChildren<FruitLogic>().color);
                Debug.Log("COCOCOCOOC " + color1);
            }
            else
            {
                color1 = Resources.Load<GameObject>("Prefabs/" + ((Fruit)whichFruit).ToString()).GetComponentInChildren<FruitLogic>().color;
                Debug.Log("COCOCOCOOC " + color1);
            }
            ingredients.Add((Fruit) whichFruit);
            GameObject obj = Instantiate(fruitImage, fruitUI.transform);
            obj.transform.localPosition = new Vector3(-fruitUI.GetComponent<RectTransform>().sizeDelta.x / 2 + fruitImage.GetComponent<RectTransform>().sizeDelta.x * (i+0.5f)+ offSet, 0, 0);
            obj.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/"+ ((Fruit)whichFruit).ToString());
        }
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

            Debug.Log("color " + h1 + " " + s1 + " " + v1);
            Debug.Log("color " + h2 + " " + s2 + " " + v2);
            float difference = Mathf.Abs(h1 - h2);

            bool upside = false;
            if (difference > 0.5f)
            {
                difference = 1 - difference;
                upside = true;
            }
            //MAYBE DOUBLE PENALTY
            Debug.Log("This juice is " +((int)(100f-difference*100f)) + "% right");
            GameObject.FindGameObjectWithTag("CustomerManager").GetComponent<CustomerManager>().SpawnCustomer();
            Destroy(fruitUI);
            Destroy(collision.transform.parent.gameObject);
            Destroy(gameObject.transform.parent.gameObject);
            
        }
    }
}
