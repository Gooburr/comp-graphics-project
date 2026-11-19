using UnityEngine;

public class Footprint : MonoBehaviour
{
    private float currentFade = 0;
    public float fadeSpeed;
    public Material footPrint;


    private void Update()
    {
        currentFade += Time.deltaTime*fadeSpeed;
        footPrint.SetFloat("_Fade", currentFade);

        if(currentFade >= 1)
        {
            Destroy(gameObject);
        }
    }

}
