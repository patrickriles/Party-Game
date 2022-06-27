using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBall : MonoBehaviour {

    public MinigameManager minigameManager;

    Rigidbody rb;

    public Vector3 initialVelocity;

    void Start() {
        rb = GetComponent<Rigidbody>();
        rb.velocity = initialVelocity;
    }
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            Destroy(collision.gameObject);
            minigameManager.removePlayerFromArray(collision.gameObject.GetComponent<PlayerWithMovement>());
        }
        if (collision.gameObject.tag == "Wall") {
            rb.velocity = Vector3.Reflect(transform.position, collision.GetContact(0).normal);
        }
    }

    void Update() {
        if(minigameManager.getMinigameOver()) {
            Destroy(this.gameObject);
        }
    }
}
