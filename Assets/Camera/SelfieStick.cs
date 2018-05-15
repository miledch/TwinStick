﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfieStick : MonoBehaviour
{
    public float panSpeed = 10f;

    private Vector3 armRotation;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        armRotation = transform.rotation.eulerAngles;
    }

    void Update()
    {
        armRotation.y += Input.GetAxis("RHoriz") * panSpeed;
        armRotation.x += Input.GetAxis("RVert") * panSpeed;

        transform.position = player.transform.position;
        transform.rotation = Quaternion.Euler(armRotation);
    }
}
