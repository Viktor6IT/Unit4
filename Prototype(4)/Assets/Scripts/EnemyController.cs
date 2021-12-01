using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{ 
    // Start is called before the first frame update
    public float EnemySpeed = 3.0f;
    private Rigidbody EnenemyRB;
    private GameObject player;
    void Start()
    {
        EnenemyRB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 LookDirection = (player.transform.position - transform.position).normalized;
        EnenemyRB.AddForce( LookDirection * EnemySpeed);

        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
