﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterController : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Rigidbody2D rigid2D;
    public float axisX, axisY, angular;
    public float Speed, AngularSpeed;
    // Use this for initialization
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Grid.GameLogic.IsDialogActive)
        {
            this.axisX = Input.GetAxis("Horizontal");
            this.axisY = Input.GetAxis("Vertical");
            this.angular = Input.GetAxis("HorizontalRight");
            angular = Math.Abs(angular) < 0.25 ? 0 : angular;

            rigid2D.velocity = new Vector2(axisX * Speed, axisY * Speed);
            rigid2D.angularVelocity = -angular * AngularSpeed;

            float rotationNorm = transform.rotation.eulerAngles.z;
            //sprite.flipX = rotationNorm > 180;
            sprite.flipY = rotationNorm >= 90 && rotationNorm <= 270;
        }

        DoNotLeaveCamera();
    }

    void DoNotLeaveCamera()
    {
        var viewPos = Grid.GameCamera.WorldToViewportPoint(transform.position);
        float vx = Range(0, viewPos.x, 1);
        float vy = Range(0, viewPos.y, 1);

        transform.position = Grid.GameCamera.ViewportToWorldPoint(new Vector3(vx, vy, viewPos.z));
    }

    float Range(float min, float val, float max)
    {
        if (val < min)
            return min;
        if (val > max)
            return max;
        return val;
    }
}
