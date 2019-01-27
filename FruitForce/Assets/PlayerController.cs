using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int playerNum = 1;
    public string playerController = "c1_";
    float hInput = 0f;
    float vInput = 0f;
    float hInput2 = 0f;
    float vInput2 = 0f;
    public float maxVelocity = 4.0f;
    bool haveGrabbed = false;
    float throwing = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        hInput = Input.GetAxis(playerController + "joystick_horizontal");
        vInput = Input.GetAxis(playerController + "joystick_vertical");
        hInput2 = Input.GetAxis(playerController + "joystick2_horizontal");
        vInput2 = Input.GetAxis(playerController + "joystick2_vertical");

        //Debug.Log("hor "+hInput2 +" ver "+vInput2);
        //Debug.Log(Input.GetButton(playerController + "button_x") + " " + Input.GetButton(playerController + "button_o"));
        if (Mathf.Sqrt(hInput2 * hInput2 + vInput2 * vInput2) >= 0.3f)
        {
            transform.localEulerAngles = new Vector3(0.0f, 0.0f, Mathf.Atan2(vInput2, hInput2) * 180 / Mathf.PI - 90);
        }

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(hInput, vInput) * 10);
        if (rb.velocity.magnitude > maxVelocity)
        {
            rb.velocity = rb.velocity.normalized * maxVelocity;
        }

        if (Input.GetButtonDown(playerController + "button_x"))
        {
            CircleCollider2D[] results = new CircleCollider2D[10];
            int num = transform.GetChild(0).GetComponent<CircleCollider2D>().OverlapCollider(new ContactFilter2D(), results);
            for (int i = 0; i < num; i++)
            {
                if (results[i].transform.childCount > 0)
                {
                    if (results[i].transform.GetChild(0).tag == "Blender")
                    {
                        results[i].transform.GetChild(0).GetComponent<BlenderLogic>().Blend();
                    }
                }
            }
        }

        if (Input.GetButtonDown(playerController + "button_o"))
        {

        }

        if (Input.GetButtonDown(playerController + "button_R1"))
        {
            if (!haveGrabbed)
            {
                CircleCollider2D[] results = new CircleCollider2D[3];
                int num = transform.GetChild(0).GetComponent<CircleCollider2D>().OverlapCollider(new ContactFilter2D(), results);
                for (int i = 0; i < num; i++)
                {
                    if (results[i].tag == "Ungrabable")
                        continue;
                    results[i].transform.SetParent(transform.GetChild(0));
                    results[i].transform.localPosition = Vector3.zero;
                    results[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    results[i].GetComponent<Rigidbody2D>().isKinematic = true;
                    haveGrabbed = true;
                }

            }
            else if (haveGrabbed)
            {
                
                Transform trans = transform.GetChild(0).GetChild(0);
                trans.parent = null;
                float angle = (transform.eulerAngles.z+90)/180*Mathf.PI;
                Debug.Log(angle);
                Vector2 velocity = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
                trans.GetComponent<Rigidbody2D>().isKinematic = false;
                trans.GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity + velocity*5;

                
                haveGrabbed = false;
            }
            
        }

    }
}
