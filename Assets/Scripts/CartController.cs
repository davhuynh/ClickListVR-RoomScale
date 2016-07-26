using UnityEngine;
using System.Collections;

public class CartController : MonoBehaviour {

    public ParticleSystem cartSparkle;
    public TextMesh cartAddText;

    void OnTriggerEnter(Collider product)
    {
        cartSparkle.Play();
        StartCoroutine(DisplayProductAdded());

        cartAddText.text = product.gameObject.GetComponent<ProductInitializer>().productName;
    }

    IEnumerator DisplayProductAdded()
    {
        cartAddText.gameObject.SetActive(true);            
        yield return new WaitForSeconds(5);
        cartAddText.gameObject.SetActive(false);            
    }

}
