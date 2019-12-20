using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //config
    [SerializeField] Paddle paddle1;
    [SerializeField] float ballStartSpeedY;
    [SerializeField] AudioClip[] ballSounds;

    public bool HasStarted { get; set; }
    private float paddleLastX;
    private float paddleSpeedX;

    //state
    Vector2 paddleToBallVector;

    //Cached Component reference
    private AudioSource _ballAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        HasStarted = false;
        paddleLastX = paddle1.transform.position.x;
        _ballAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!HasStarted)
        {
            LockBallOnPaddle();
            UpdatePaddleSpeed();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(paddleSpeedX, ballStartSpeedY);
            HasStarted = true;
        }
    }

    private void LockBallOnPaddle()
    {
        var paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (HasStarted)
        {
            _ballAudioSource.PlayOneShot(ballSounds[Random.Range(0, ballSounds.Length)]);
        }
        
    }

    private void UpdatePaddleSpeed()
    {
        var paddleNowX = paddle1.transform.position.x;
        paddleSpeedX = (paddleNowX - paddleLastX) / Time.fixedDeltaTime;
        paddleLastX = paddleNowX;
    }
}
