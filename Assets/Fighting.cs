using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighting : MonoBehaviour
{
    public BoxCollider2D attackBox;
    [SerializeField] private Animator anime;
    [SerializeField] private LayerMask enemyLayer;
    public int playerHealth = 100;
    private bool playerDead = false;

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
        if (playerHealth <= 0)
        {
            if (!playerDead)
            {
            anime.SetBool("Died", true);
            playerDead = true;
            }
            Invoke(nameof(SDied),1f);
            Invoke(nameof(Destroy),5f);
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
    void Destroy()
    {
        Destroy(gameObject);
    }
    void SDied()
    {
        anime.SetBool("Died", false);
    }
    public void PlayerDamageTaken(int Enemydamage)
    {
        playerHealth -= Enemydamage;
        if (playerHealth <= 0)
        {
            Debug.Log("Player died");
            if (!playerDead)
            {
            anime.SetBool("Died", true);
            playerDead = true;
            Invoke(nameof(Destroy),5f);
            }
        }
    }
}
