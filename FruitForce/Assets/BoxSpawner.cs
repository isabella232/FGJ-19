using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public int interval = 300;
    public GameObject boxPrefab;
    private int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (GameObject.FindGameObjectsWithTag("Fruit").Length < 5)
        counter++;
      if(counter > interval && GameObject.FindGameObjectsWithTag("Box").Length < 3)
        {
            SpawnBox();
            counter = 0;
        }
    }
    public void SpawnBox()
    {
        GameObject box = Instantiate(boxPrefab, GameObject.FindGameObjectWithTag("CustomerManager").GetComponent<CustomerManager>().RandomSpawnPos(false),Quaternion.identity);
        box.transform.parent = GameObject.FindGameObjectWithTag("GameState").transform;
        Vector2 dir = transform.position - box.transform.position;
        box.transform.position = new Vector3(box.transform.position.x, box.transform.position.y, 0);
        Debug.Log("OFKFO " + box.transform.position);
        box.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-0.3f,0.3f)+dir.normalized.x, Random.Range(-0.7f, 0.7f) + dir.normalized.y) *40f);
    }
}
