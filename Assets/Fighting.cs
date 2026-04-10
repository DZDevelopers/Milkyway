using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighting : MonoBehaviour
{
    public BoxCollider2D attackBox;
    public BoxCollider2D hitBox;
    [SerializeField] private Animator anime;
    [SerializeField] private LayerMask enemyLayer;
    public int playerHealth = 5;
    private bool playerDead = false;

    // Start is called before the first frame update
    void Start()
    {
        attackBox.enabled = false; 
        playerHealth = 5;

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

    AttackBox ab = attackBox.GetComponent<AttackBox>();
    ab.hasHit = false;

    anime.SetBool("IsAttacking", true);
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
            Debug.Log("Player died");
            if (!playerDead)
            {
            anime.SetBool("Died", true);
            playerDead = true;
            Invoke(nameof(PDestroy),5f);
            }
        }
    }
}