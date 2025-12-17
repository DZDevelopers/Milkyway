using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighting : MonoBehaviour
{
    public BoxCollider2D attackBox;
    public BoxCollider2D hitBox;
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
    void PDestroy()
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
            if (!playerDead)
            {
            anime.SetBool("Died", true);
            playerDead = true;
            Vector2 newSize = new Vector2(hitBox.size.x, 0.22f);
            hitBox.size = newSize;
            }
            Invoke(nameof(SDied),1f);
            Invoke(nameof(PDestroy),5f);
        }
    }
}