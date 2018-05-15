using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySystem : MonoBehaviour
{
    private const int bufferFrames = 1000;
    private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrames];
    private int _frameIndex;

    private Rigidbody rigidBody;
    private GameManager gameManager;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }


    void Update()
    {
        if(gameManager.recording)
        {
            Record();
        }
        else if(!gameManager.recording)
        {
            PlayBack();
        }
        
    }

    void PlayBack()
    {
        rigidBody.isKinematic = true;
        int frame = Time.frameCount % _frameIndex;
        transform.position = keyFrames[frame].position;
        transform.rotation = keyFrames[frame].rotation;
    }

    private void Record()
    {
        rigidBody.isKinematic = false;
        int frame = Time.frameCount % bufferFrames;
        float time = Time.deltaTime;
        keyFrames[frame] = new MyKeyFrame(time, transform.position, transform.rotation);

        if(frame<=bufferFrames)
        {
            _frameIndex = frame;
        }
        else
        {
            _frameIndex = 0;
        }
    }
}

/// <summary>
/// A structure for storing time, rotation and position.
/// </summary>
public struct MyKeyFrame
{
    public float frameTime;
    public Vector3 position;
    public Quaternion rotation;

    public MyKeyFrame(float frameTime, Vector3 position, Quaternion rotation)
    {
        this.frameTime = frameTime;
        this.position = position;
        this.rotation = rotation;
    }
}
