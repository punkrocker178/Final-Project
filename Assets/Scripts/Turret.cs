using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform target;
    public float range = 15f;
    public Transform rotator;

    public string agentTag = "Agent";

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) {
            return;
        }

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(rotator.rotation, lookRotation, Time.deltaTime).eulerAngles;
        rotator.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void UpdateTarget()
    {
        GameObject[] agents = GameObject.FindGameObjectsWithTag(agentTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestAgent = null;

        foreach (GameObject agent in agents)
        {
            float distanceToAgent = Vector3.Distance(transform.position, agent.transform.position);
            if (distanceToAgent < shortestDistance) { 
                shortestDistance = distanceToAgent;
                nearestAgent = agent;
            }

            if (nearestAgent != null && shortestDistance <= range) {
                target = nearestAgent.transform;
            } else {
                target = null;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
