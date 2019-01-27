using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juice : MonoBehaviour
{
    public Color color;
    public List<Fruit> ingredients;
    public bool marked = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<Fruit> GetIngredients()
    {
        return ingredients;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Juice")
        {
            
            Color blendColor = Camera.main.GetComponent<Functions>().CombineColors(color, collision.gameObject.GetComponent<Juice>().color);
            GetComponentInParent<SpriteRenderer>().color = blendColor;
            color = blendColor;
            /*
            color.g = Mathf.Sqrt((Mathf.Pow(color.g, 2) + Mathf.Pow(fruitsInside[i].GetComponent<FruitLogic>().color.g, 2))/2);
            color.b = Mathf.Sqrt((Mathf.Pow(color.b, 2) + Mathf.Pow(fruitsInside[i].GetComponent<FruitLogic>().color.b, 2))/2);
            color.a = Mathf.Sqrt((Mathf.Pow(color.a, 2) + Mathf.Pow(fruitsInside[i].GetComponent<FruitLogic>().color.a, 2))/2);
            */

            if (marked)
            {
                Destroy(gameObject.transform.parent.gameObject);
            }
            collision.gameObject.GetComponent<Juice>().marked = true;

        }
    }
        
}
