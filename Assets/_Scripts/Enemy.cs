using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    public class EnemyStats
    {
        public int Health = 40;
    }

    public Player player;

    public EnemyStats stats = new EnemyStats();

    public void DamageEnemy(int damage)
    {
        stats.Health -= damage;
        if(stats.Health <= 0)
        {
            GameManager.KillEnemy(gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("hit");
            collision.gameObject.GetComponent<Player>().TakeDamage(2);
            
        }

    }

    public void TakeDamage(int damage)
    {
        stats.Health -= damage;


        if (stats.Health <= 0)
        {
            GameManager.KillEnemy(gameObject);
        }
    }
}
