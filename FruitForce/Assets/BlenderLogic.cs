using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlenderLogic : MonoBehaviour
{

    public List<GameObject> fruitsInside;
    public GameObject juicePrefab;
    public int maxCount = 1;

    public bool isOpen = true;

    public bool blending = false;
    float blendTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (blending)
        {
            gameObject.transform.parent.transform.eulerAngles += new Vector3(0, 0, (Random.value - 0.5f) * 30);

            blendTime += Time.deltaTime;
        }
        if (blendTime >= 3f)
        {
            endBlend();
            blendTime = 0f;
        }
    }

    void endBlend()
    {
        if (fruitsInside.Count != 0)
        {
            Vector3 newPos = transform.TransformPoint(new Vector3(0, 0.3f));
            GameObject juice = Instantiate(juicePrefab, newPos, Quaternion.identity);
            Color color = fruitsInside[0].GetComponent<FruitLogic>().color;

            juice.GetComponent<SpriteRenderer>().color = color;
            juice.GetComponentInChildren<Juice>().color = color;
            Vector2 dir = new Vector2((Random.value - 0.5f)*0.5f, 1).normalized;
            dir = transform.TransformDirection(dir);
            juice.GetComponent<Rigidbody2D>().velocity = dir*3f;
            transform.parent.GetComponent<Rigidbody2D>().velocity = -dir;
            fruitsInside.Clear();

            /*
            Color juiceColor = new Color();
            juiceColor.r = color.x / fruitAmount;
            juiceColor.g = color.y / fruitAmount;
            juiceColor.b = color.z / fruitAmount;
            */

        }

        transform.parent.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Blender1");
        blending = false;
    }

    public void Blend()
    {
        blending = true;
        transform.parent.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Blender0");
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
