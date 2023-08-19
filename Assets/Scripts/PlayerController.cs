using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player; 
    new Vector2 moveV2;
    float moveSpead = 0.05f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetMouseButtonDown(0))  
        {
            var pos = Input.mousePosition;
        }
        else if (Input.touchCount > 0)  
        {
            var touch = Input.GetTouch(0);  
            if (touch.phase == TouchPhase.Began)  
            {
                var pos = touch.position;  
            }
        }

        moveV2 = new Vector2(0f, 0f);
        
        if (Input.GetKey(KeyCode.LeftArrow) | Input.GetKey(KeyCode.A))
        {
			moveV2.x += -1f;
		}
        if (Input.GetKey(KeyCode.UpArrow) | Input.GetKey(KeyCode.W)) 
        {
			moveV2.y += 1f;
		}
		if (Input.GetKey(KeyCode.RightArrow) | Input.GetKey(KeyCode.D)) 
        {
			moveV2.x += 1f;
        }
		if (Input.GetKey(KeyCode.DownArrow) | Input.GetKey(KeyCode.S)) 
        {
			moveV2.y += -1f;
        }
        
        moveV2.Normalize();
        player.transform.Translate(moveV2 *moveSpead);
    }
}
