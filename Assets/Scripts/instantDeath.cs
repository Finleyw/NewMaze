using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class instantDeath : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        //print("yeah");
        if(other.gameObject.tag=="Enemy")
        {
          //  print(other);
            SceneManager.LoadScene(0);
        }
    }
}
