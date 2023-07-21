using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShowDamage : MonoBehaviour
{
    [SerializeField] Canvas impactCanvas;
    [SerializeField] Image splatter;
    
    void Start()
    {
        impactCanvas.enabled = false;
    }
 
    void Update()
    {
        
    }

    public void ShowDamageImpact()
    {
        StartCoroutine(ShowDamageSplatter());
    }
    IEnumerator ShowDamageSplatter()
    {
        impactCanvas.enabled = true;

        float opacity  = splatter.color.a;
        float opacityTemp = opacity;
        Color color = splatter.color;

        while (opacityTemp > 0)
        {
            opacityTemp -= .1f;
            color.a = opacityTemp;
            splatter.color = color;
            yield return new WaitForSeconds(.1f);

        }
        color.a = opacity;
        splatter.color = color;
        impactCanvas.enabled = false;
    }
}
