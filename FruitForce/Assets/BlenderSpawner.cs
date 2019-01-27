using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlenderSpawner : MonoBehaviour
{

    public GameObject BlenderPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("Blender").Length < 1)
        {
            Instantiate(BlenderPrefab, Vector3.zero, Quaternion.identity);
        }
    }
}
