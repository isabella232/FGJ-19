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

        CreatePlayer(transform.parent.GetChild(1).GetComponent<StartMenu>().controller);
    }

    void CreatePlayer(int i)
    {
        c[i - 1] = true;
        numPlayer++;
        GameObject newPlayer = Instantiate(player);
        newPlayer.GetComponent<PlayerController>().playerController = "c" + i + "_";
        newPlayer.GetComponent<PlayerController>().playerNum = numPlayer;

        newPlayer.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Doggy" + numPlayer);
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
                        CreatePlayer(i);
                    }
            }
        }
    }
}
