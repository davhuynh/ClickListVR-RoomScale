using UnityEngine;
using System.Collections;

public class ProductInitializer : MonoBehaviour
{
    public string upc;
    public string productName;
    public bool requiresImage;

    IEnumerator Start()
    {
        if(requiresImage)
        {
            WWW productImageFront = new WWW("https://www.kroger.com/product/images/large/front/" + upc);
            yield return productImageFront;

            WWW productImageRight = new WWW("https://www.kroger.com/product/images/large/right/" + upc);
            yield return productImageRight;

            Renderer renderer = GetComponent<Renderer>();
            Vector2 productImageFrontDimensions = new Vector2(productImageFront.texture.width, productImageFront.texture.height).normalized;
            Vector2 productImageRightDimensions = new Vector2(productImageRight.texture.width, productImageRight.texture.height).normalized;

            renderer.material.mainTexture = productImageFront.texture;
            transform.localScale = new Vector3(productImageFrontDimensions.x * 0.25f, productImageFrontDimensions.y * 0.25f, productImageRightDimensions.x * 0.25f);
        }
    }
}