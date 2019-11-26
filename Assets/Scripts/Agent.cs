using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Agent : MonoBehaviour
{
    public float startHealth = 100;
    public float speed = 150;
    public int value = 50;
    private float health;
    private Transform target;
    private int wavepointIndex = 0;

    public Image healthBar;
        
    void Start()
    {
        target = Waypoints.points[0];
        health = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    public void TakeDamage(int damage)
    {
        Debug.Log(damage + " " + health);
        health -= damage;
        healthBar.fillAmount = health / startHealth;
        
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        PlayerStats.Money += value;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            if (gameObject != null)
            {
                Destroy(gameObject);
            }
            EndPath();
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    void EndPath()
    {
        Destroy(gameObject);
        WaveSpawner.EnemiesAlive--;
        PlayerStats.Lives -= 1;
    }
}
