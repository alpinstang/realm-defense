using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dweiss;

public class UseSettings : MonoBehaviour {

	void Start () {
        gameObject.SetActive(Settings.Instance.show);

        QualitySettings.SetQualityLevel(Settings.Instance.qualitySettings);
        if (Settings.Instance.show)
        {
            StartCoroutine(ColorChange());
        }


    }
	
    private IEnumerator ColorChange()
    {
        var mat = GetComponent<Renderer>().material;
        var minColor = new Color(0, 0, 0, 0);
        var maxColor = new Color(mat.color.r, mat.color.g, mat.color.b, 1);

        var halfCycle = (Settings.Instance.colorChangeCycle / 2);
        while (true)
        {
            var value = Time.time % halfCycle;
            if(Time.time% Settings.Instance.colorChangeCycle > halfCycle)
            {
                value = halfCycle - value;
            }
            var dist = value / halfCycle;
            mat.color = Color.Lerp(minColor, maxColor, dist);
            
            yield return new WaitForEndOfFrame();
        }
    }
}
