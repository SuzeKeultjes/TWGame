using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<NavMeshAgent>().destination = target.position;
    }

}
