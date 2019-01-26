using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFactory : MonoBehaviour
{

    public GameObject player;
    bool[] c;
    int numPlayer = 0;
    // Start is called before the first frame update
    void Start()
    {
        c = new bool[4];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("c0_button_x"))
        {
            for (int i = 1; i < 5; i++)
            {
                if (Input.GetButtonDown("c" + i + "_button_x"))
                    if (c[i-1] == false)
                    {
                        c[i - 1] = true;
                        numPlayer++;
                        GameObject newPlayer = Instantiate(player);
                        newPlayer.GetComponent<PlayerController>().playerController = "c" + i + "_";
                        newPlayer.GetComponent<PlayerController>().playerNum = numPlayer;
                    }
            }
        }
    }
}
