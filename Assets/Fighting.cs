using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighting : MonoBehaviour
{
    public BoxCollider2D attackBox;
    [SerializeField] private Animator anime;
    [SerializeField] private LayerMask enemyLayer;
    public int playerHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        attackBox.enabled = false; 
        playerHealth = 100;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }
    
    void Attack()
    {
        attackBox.enabled = true;
        anime.SetBool("IsAttacking",true);
    }
    void SAttack()
    {
        attackBox.enabled = false;
        anime.SetBool("IsAttacking",false);
    }
    public void PlayerDamageTaken(int Enemydamage)
    {
        playerHealth -= Enemydamage;
        if (playerHealth <= 0)
        {
            Debug.Log("Player died");
        }
    }
}
