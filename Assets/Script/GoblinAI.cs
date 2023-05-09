using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoblinAI : MonoBehaviour
{
    public GameObject target;
    NavMeshAgent Goblin;

    // Start is called before the first frame update
    void Start()
    {
        Goblin = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Goblin.destination != target.transform.position)
        {
            Goblin.SetDestination(target.transform.position);
        }
        else
        {
            Goblin.SetDestination(transform.position);
        }
    }
}
