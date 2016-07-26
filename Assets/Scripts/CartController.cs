using UnityEngine;
using System.Collections;

public class CartController : MonoBehaviour {

    public ParticleSystem cartSparkle;
    public TextMesh cartAddText;
    public GameObject controllerMenuLeft;
    public GameObject controllerMenuRight;

    void OnTriggerEnter(Collider product)
    {
        cartSparkle.Play();
        StartCoroutine(DisplayProductAdded());

        string productName = product.gameObject.GetComponent<ProductInitializer>().productName;
        cartAddText.text = productName;
        controllerMenuLeft.GetComponent<VRTK.VRTK_ControllerTooltips>().UpdateListText(productName);
        controllerMenuRight.GetComponent<VRTK.VRTK_ControllerTooltips>().UpdateListText(productName);
    }

    IEnumerator DisplayProductAdded()
    {
        cartAddText.gameObject.SetActive(true);            
        yield return new WaitForSeconds(5);
        cartAddText.gameObject.SetActive(false);            
    }

}
