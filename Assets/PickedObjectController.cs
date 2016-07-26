using UnityEngine;
using System.Collections;

public class PickedObjectController : MonoBehaviour {

    private Rigidbody rigidBody = null;

    private void Start()
    {
        this.rigidBody = this.gameObject.GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider hand)
    {
        this.rigidBody.useGravity = true;
    }
}
