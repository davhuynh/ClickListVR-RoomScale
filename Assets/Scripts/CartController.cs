using UnityEngine;
using System.Collections;

public class CartController : MonoBehaviour {

    void OnTriggerEnter(Collider product)
    {
        Destroy(product.gameObject);
    }
}
