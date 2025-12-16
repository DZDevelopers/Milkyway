using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBox : MonoBehaviour
{
    private bool hasHit;
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
    void OnEnable()
    {
        hasHit = false;
    }
    void OnTriggerEnter2D(Collider2D collision)
{
    Debug.Log("Hit: " + collision.name);

    EnemyHealth enemy = collision.GetComponent<EnemyHealth>();
    if (enemy != null)
    {
        Debug.Log("Enemy damaged");
        enemy.TakeDamage(playerDamage);
    }
}
}
