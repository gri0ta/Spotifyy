using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dancer : MonoBehaviour
{
    public float power = 2;
    public float maxSize = 5;

    public Color startColor;
    public Color endColor;
    public Vector3 rotationA;
    public Vector3 rotationB;
    public void Start()
    {
        Analyzer.onVolumeChanged.AddListener(Dance);

    }

    public void Dance(float volume)
    {
        transform.localScale = Vector3.one * (0.5f + Mathf.Pow(volume,power)*maxSize); //keis dydi priklausant nuo garso
        
        var mixedColor = Color.Lerp(startColor,endColor,volume*5); // lerpinimas mixuot
        transform.rotation = Quaternion.Lerp(Quaternion.Euler(rotationA), Quaternion.Euler(rotationB), volume);

        GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", mixedColor *3);
    }
}
