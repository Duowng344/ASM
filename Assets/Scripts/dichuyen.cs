using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class dichuyen : MonoBehaviour
{
    public Animator animator;
    public bool isRight = true;
    private Rigidbody2D rb;
    private bool nen;
    public GameObject panel, button, text;
    public TextMeshProUGUI diemText;
    public TextMeshProUGUI Tym;
    public int Mau = 3;
    int tong = 0;

    void tinhTong(int score)
    {
        tong += score ;
        diemText.text =""+ tong;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        tinhTong(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            //isRight = true;
            animator.SetBool("isIdle",false);
            animator.SetBool("isRunning",true);
            transform.Translate(Time.deltaTime * 3,0,0);
            Vector2 scale  = transform.localScale;
            scale.x *= scale.x >0 ? 1: -1;
            transform.localScale = scale;
        }
       
        if(Input.GetKey(KeyCode.A))

        {
            //isRight = false;
            animator.SetBool("isIdle",false);
            animator.SetBool("isRunning",true);
            transform.Translate( -Time.deltaTime * 3,0,0);
            Vector2 scale  = transform.localScale;
            scale.x *= scale.x >0 ? -1: 1;
            transform.localScale = scale;
        }
        if(nen)
        {
        if(Input.GetKey(KeyCode.Space))
                {
                    if(isRight)
                    {
                        // transform.Translate(Time.deltaTime*3, Time.deltaTime*5,0);
                        rb.AddForce(new Vector2(0,250));
                        Vector2 scale  = transform.localScale;
                        scale.x *= scale.x >0 ? 1: -1;
                        transform.localScale = scale;
                    }
                    else
                    {
                        // transform.Translate(-Time.deltaTime*3, Time.deltaTime*5,0);
                        rb.AddForce(new Vector2(0,250));
                        Vector2 scale  = transform.localScale;
                        scale.x *= scale.x >0 ? -1: 1;
                        transform.localScale = scale;
                    }
                    nen = false;
        }
        }
        
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag =="platform")
        {
            nen = true;

        }
        if(collision.gameObject.tag == "qua_man")
        {
            SceneManager.LoadScene("Man_2");
        }
    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag =="player_kill")
        {
            //nam die

            var name = collision.attachedRigidbody.name;
            Destroy(GameObject.Find(name));
        }
        if(collision.gameObject.tag =="kill_player")
        {
            if(collision.gameObject.tag == "heo"){
            animator.SetBool("isRunning",false);
             animator.SetBool("isIdle",false);
              animator.SetBool("isDie",true);
        }
            Mau--;
            
            if(Mau==0)
            {
                //game over , replay man choi
            Time.timeScale = 0; //dung sence
            panel.SetActive(true);   //show panel
            button.SetActive(true);  // show button
            text.SetActive(true);  //show text
            }
        }
        if(collision.gameObject.tag =="coin")
        {
            var name = collision.attachedRigidbody.name;
            Destroy(GameObject.Find(name));
            tinhTong(1);
        }
    }

}

