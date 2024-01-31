using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraS : MonoBehaviour
{
    public GameObject Player; //nhân vật 
    public float  start, end; //điểm bắt đầu và kết thúc màn chơi
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //vị trí của nhân vật
        var playerX = Player.transform.position.x;

        //vị trí của camera
        var camX = transform.position.x;
        var camY = transform.position.y;//0
        var camZ = transform.position.z;//-10
        if(playerX > start && playerX < end)
        {
            camX = playerX;
        }
        else
        {
            if(playerX < start) 
            {
                camX = start;
            }
            if(playerX > end) 
            {
                camX = end;
            }
        }
        //set lai vi tri cho camera
        transform.position = new Vector3( camX, camY, camZ);
    }
}
