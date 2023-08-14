using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicController : MonoBehaviour
{
    public static float cost = 0;
    // Startis called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void Movement(int type, int spead, int lotation=0)
    {

        cost += (1+ type* 0.25f)* (spead+1)* (lotation+1);
    }

    public static void Area(int radius, int time, int angle=360)
    {
        
        cost += radius* time* (angle+1);
    }

    public static void Danage(int physics, int stun)
    {
        
        cost += (physics+1)* (stun+1);
    }
}
