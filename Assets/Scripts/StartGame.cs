using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void start()
    {
        SceneManager.LoadScene("Man_1");
    }
    public void replay(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale=1;
    }
}
