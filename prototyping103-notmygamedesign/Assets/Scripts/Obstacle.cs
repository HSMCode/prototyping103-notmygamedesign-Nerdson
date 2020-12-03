using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject playerExplosion;
    public GameController gameController;

   
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Boundary")
        {
            return;
        }
        
        Instantiate(playerExplosion, transform.position, transform.rotation);
        Time.timeScale = 0;
        Destroy(other.gameObject);
        Destroy(gameObject);
        gameController.GameOver();
        
    }
}
