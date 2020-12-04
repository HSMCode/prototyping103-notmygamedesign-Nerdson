using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{
    public int scoreValue;
    private GameController gameController;

    // get access to GameController script
    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if(gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    //Destroy on boundary exit and add points
    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
        gameController.AddScore(scoreValue);
    }
}
