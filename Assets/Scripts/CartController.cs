using UnityEngine;
using System.Collections;

public class CartController : MonoBehaviour {

    public ParticleSystem cartSparkle;

    void OnTriggerEnter(Collider product)
    {
        cartSparkle.Play();
    }
}
