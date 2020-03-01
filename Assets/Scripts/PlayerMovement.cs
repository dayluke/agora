﻿using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 1f;
    [SerializeField] private float resistanceDrag = 10f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 movementInput = GetMovement();
        rb.velocity = movementInput;
    }

    private Vector3 GetMovement()
    {
        float x, y, z;

        x = Input.GetAxis("Horizontal");
        y = HandleYMovement();
        z = Input.GetAxis("Vertical");

        return new Vector3(x * speed, y, z * speed);
    }

    private float HandleYMovement()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            return jumpForce; // IsGrounded...
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            return -jumpForce;
        }
        else
        {
            return Mathf.Lerp(rb.velocity.y, 0, Time.deltaTime * resistanceDrag);
        }
    }
}
