using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class concho : MonoBehaviour
{
    public float left,right;
    private bool isRight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var namX = transform.position.x;
        if(namX < left)
        {
            isRight = true;
        }
        if(namX > right)
        {
            isRight = false;
        }
        if(isRight)
        {
            transform.Translate(new Vector3(Time.deltaTime * 1,0,0));
            Vector2 scale  = transform.localScale;
            scale.x *= scale.x >0 ? -1: 1;
            transform.localScale = scale;

        }
        else
        {
            transform.Translate(new Vector3(-Time.deltaTime * 1,0,0));
            
            Vector2 scale  = transform.localScale;
            scale.x *= scale.x >0 ? 1: -1;
            transform.localScale = scale;
        }
    }
}
