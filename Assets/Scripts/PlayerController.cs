﻿using System;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : NetworkBehaviour
{
    public float movementSpeed = 5.0f;

    private Rigidbody body;
    private RaycastHit hit;
    private float turnRate = 150.0f;

    void Start()
    {
        body = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        if (!isLocalPlayer) return;

        var x = CrossPlatformInputManager.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = CrossPlatformInputManager.GetAxis("Vertical") * Time.deltaTime * 5.0f;
        
        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    }

    private void FixedUpdate()
    {
        if (!isLocalPlayer) return;
        
        if ((Input.GetKeyDown ("space") || CrossPlatformInputManager.GetButtonDown("Jump")) && !IsFalling()) {
            Vector3 up = transform.TransformDirection (Vector3.up);
            body.AddForce (up * 5, ForceMode.Impulse);
        }
    }

    public override void OnStartLocalPlayer()
    {
        Camera.main.GetComponent<CameraFollow>().setTarget(gameObject.transform);
    }

    private bool IsFalling()
    {
        RaycastHit hit;
        if (Physics.Raycast (transform.position, -Vector3.up, out hit)) {
            return hit.distance > 1.1;
        }

        throw new Exception("Could not create Raycast");
    }
}