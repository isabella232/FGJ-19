using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlenderLogic : MonoBehaviour
{

    public List<GameObject> fruitsInside;
    public GameObject juicePrefab;
    public int maxCount = 1;

    public bool isOpen = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Blend()
    {
        if(fruitsInside.Count != 0)
        {
            GameObject juice = Instantiate(juicePrefab, transform.position, Quaternion.identity);
            Color color = fruitsInside[0].GetComponent<FruitLogic>().color;
            juice.GetComponent<SpriteRenderer>().color = color;
            juice.GetComponentInChildren<Juice>().color = color;
            fruitsInside.Clear();

            /*
            Color juiceColor = new Color();
            juiceColor.r = color.x / fruitAmount;
            juiceColor.g = color.y / fruitAmount;
            juiceColor.b = color.z / fruitAmount;
            */
            
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fruit" && isOpen && fruitsInside.Count < maxCount)
        {
            
            collision.gameObject.transform.parent.gameObject.SetActive(false);
            fruitsInside.Add(collision.gameObject);
        }
    }
}
