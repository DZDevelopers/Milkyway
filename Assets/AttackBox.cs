using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AttackBox : MonoBehaviour
{
    public bool hasHit;
    public float knockbackForce;
    public float verticalKnockForce;
    public int enemyDir;
    [SerializeField] public int playerDamage =1;
    // Start is called before the first frame update
    void Start()
    {
        hasHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
{
    Debug.Log("Hit: " + collision.name);
    Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
    EnemyHealth enemy = collision.GetComponent<EnemyHealth>();
    ShadowSlime shadow = collision.GetComponent<ShadowSlime>();
    if (rb.position.x > transform.position.x)
    {  
       enemyDir = +1;
    }
    else
    { 
       enemyDir = -1;
    }
    if (enemy != null && hasHit == false)
    {
        Debug.Log("Enemy damaged");
        enemy.TakeDamage(playerDamage);
        hasHit = true;
        shadow.isBiengKnocked = true;
        Vector2 knockDir = new Vector2(enemyDir * knockbackForce,verticalKnockForce);
        rb.AddForce(knockDir,ForceMode2D.Impulse);
    }
}
}