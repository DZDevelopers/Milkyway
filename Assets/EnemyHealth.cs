using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private Fighting player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void EnemyDamageTaken()
    {
        health -= player.playerDamage;
        if (health <= 0)
        {
            GameObject.Destroy(this);
        }
    }
}
