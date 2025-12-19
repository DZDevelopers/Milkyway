using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowSlime : MonoBehaviour
{
    [SerializeField]private float patrolSpeed = 2f;
    [SerializeField]private float aggroSpeed = 4f;
    [SerializeField]private float aggroDistance = 4f;
    [SerializeField]private Transform player;
    [SerializeField]private GameObject RPoint;
    [SerializeField]private GameObject LPoint;

    private bool playerisinfront;
    private Rigidbody2D rb;
    public bool isBiengKnocked;
    private int direction = 1; // 1 = right, -1 = left

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isBiengKnocked)
        {
            return;
        }
        PlayerInFront();
        if (playerisinfront)
        {
            AggroMove();
        }
        else
        {
            Patrol();
        }
    }
    void Patrol()
    {
        rb.velocity = new Vector2 (patrolSpeed * direction,rb.velocity.y);
        if (direction == 1 && transform.position.x >= RPoint.transform.position.x)
            {
                Flip();
            }
        if (direction == -1 && transform.position.x <= LPoint.transform.position.x)
            {
                Flip();
            }
    }
    void Flip()
    {
        direction *= -1;
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * direction;
        transform.localScale = scale;
        Debug.Log("Fliped");
    }
    void PlayerInFront()
    {
        if (Math.Abs(player.position.x - transform.position.x) >= aggroDistance)
        {
            playerisinfront = false;
        }
        else
        {
            int playerDir;
            if (player.position.x > transform.position.x)
            {
                playerDir = 1;
            }
            else
            {
                playerDir = -1;
            }
            if (playerDir == direction)
            {
                playerisinfront = true;
            }
            else
            {
                playerisinfront = false;
            }
        }
    }
    void AggroMove()
    {
        int playerDir;
    if (player.position.x > transform.position.x)
    {  
        playerDir = 1;
    }
    else
    { 
        playerDir = -1;
    }
    rb.velocity = new Vector2(aggroSpeed * playerDir, rb.velocity.y);
    }
}