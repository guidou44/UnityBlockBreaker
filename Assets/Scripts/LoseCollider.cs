using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    [SerializeField] Ball mainBall;
    [SerializeField] int numberOfLifes;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        numberOfLifes--;
        mainBall.HasStarted = false;
        if (numberOfLifes == 0)
        {
            SceneLoader sceneLoader = new SceneLoader();
            sceneLoader.LoadNextScene();
        }

    }

    private void Start()
    {
        numberOfLifes = 3;
    }
}
