using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    new Vector2 moveV2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveV2 = new Vector2(0f, 0f);
        
        if (Input.GetKey (KeyCode.LeftArrow) | Input.GetKey (KeyCode.A)) 
        {
			moveV2.x += -0.05f;
		}
		if (Input.GetKey (KeyCode.RightArrow) | Input.GetKey (KeyCode.D)) 
        {
			moveV2.x += 0.05f;
        }
        if (Input.GetKey (KeyCode.UpArrow) | Input.GetKey (KeyCode.W)) 
        {
			moveV2.y += 0.05f;
		}
		if (Input.GetKey (KeyCode.DownArrow) | Input.GetKey (KeyCode.S)) 
        {
			moveV2.y += -0.05f;
        }

        transform.Translate(moveV2);
    }
}
