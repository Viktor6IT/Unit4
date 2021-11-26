using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody PlayerRB;
    private float ForwardSpeed = 3.0f;
    private GameObject FocalPoint;
    void Start()
    {
        PlayerRB = GetComponent<Rigidbody>();
        FocalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float ForwardInput = Input.GetAxis("Vertical");
        PlayerRB.AddForce(FocalPoint.transform.forward * ForwardInput * ForwardSpeed);
    }
}
