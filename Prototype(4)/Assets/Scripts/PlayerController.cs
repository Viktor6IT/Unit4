using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody PlayerRB;
    private float ForwardSpeed = 3.0f;
    private GameObject FocalPoint;

    public bool hasPowerup = false;
    private float PowerUpStrength = 15.0f;
    public GameObject PowerUpIndicator;
    void Start()
    {
        PlayerRB = GetComponent<Rigidbody>();
        FocalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float ForwardInput = Input.GetAxis("Vertical");
        PlayerRB.AddForce(FocalPoint.transform.forward * ForwardSpeed * ForwardInput);
        PowerUpIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountDownRoutine());
            PowerUpIndicator.gameObject.SetActive(true);
        }
    }
    IEnumerator PowerUpCountDownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        PowerUpIndicator.gameObject.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("enemy") && hasPowerup)
        {
            Rigidbody EnemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 AwayFromplayer = (collision.gameObject.transform.position - transform.position);

            Debug.Log("Colided with" + collision.gameObject.name + "with powerup is set to" + hasPowerup);
            EnemyRigidbody.AddForce(AwayFromplayer * PowerUpStrength,ForceMode.Impulse);
        }
    }
}
