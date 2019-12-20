using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] const float screenWidthInUnits = 16f;
    [SerializeField] const float paddleY = 0.4f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float paddleX = (Input.mousePosition.x / Screen.width) * screenWidthInUnits;
        Vector2 paddlePos = new Vector2(paddleX, paddleY);
        paddlePos.x = Mathf.Clamp(paddlePos.x, minX, maxX);
        transform.position = paddlePos;
    }
}
