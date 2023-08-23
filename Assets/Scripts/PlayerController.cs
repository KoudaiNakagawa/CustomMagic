using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Player; 
    public GameObject CharaMoveButtons;
    public GameObject SelectMagicButtons;
    
    RaycastHit2D hitX, hitY;
    new Vector2 pos, moveV2;
    float moveSpead = 0.05f;
    float rayMaxDistance = 15;
    int ButtonVec2X = 1 << 6;
    int ButtonVec2Y = 1 << 7;

    int[] layers = new int[3];
    RaycastHit2D[] hits = new RaycastHit2D[3];

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i < 3; i++)
        {
            layers[i] = 1 << i+6;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            pos.x = Input.mousePosition.x;
            pos.y = Input.mousePosition.y;

            Ray ray = Camera.main.ScreenPointToRay(pos);

            for(int i=0; i < 3; i++)
            {
                hits[i] = Physics2D.Raycast(ray.origin, ray.direction, rayMaxDistance, layers[i]);
                if (hits[i].collider) { Debug.Log(hits[i].collider.gameObject.name); }
            }

            /*
            hitX = Physics2D.Raycast(ray.origin, ray.direction, rayMaxDistance, ButtonVec2X);
            hitY = Physics2D.Raycast(ray.origin, ray.direction, rayMaxDistance, ButtonVec2Y);
            
            if( hitX.collider) { Debug.Log(hitX.collider.gameObject.name); }
            if( hitY.collider) { Debug.Log(hitY.collider.gameObject.name); }
            */
        }
        else if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)  
            {
                pos = touch.position;  
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


    }

    void FixedUpdate()
    {
        Player.transform.Translate(moveV2 *moveSpead);
    }
}
