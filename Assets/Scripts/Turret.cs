using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform target;
    public float range = 15f;

    public string agentTag = "Agent";

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateTarget()
    {
        GameObject[] agents = GameObject.FindGameObjectsWithTag(agentTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestAgent = null;

        foreach (GameObject agent in agents)
        {
            float distanceToAgent = Vector3.Distance(transform.position, agents.position);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
