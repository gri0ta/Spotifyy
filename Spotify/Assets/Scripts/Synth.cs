using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Synth : MonoBehaviour
{
    public AudioSource source;
    public float frequency;


    void Start()
    {   
        var clip =  source.clip = AudioClip.Create("Sin",441000,1, 44100,false);

        var data = new float[441000]; //441000 susitarimas kiek daro frequency, nes tai didziausias kiek zmogus gali girdet
        for (int i = 0;i < data.Length; i++)
        {
            data[i] = Mathf.Sin(i/44100f * Mathf.PI * 2 * 853); ; //0 - 44100. Vienas sinusas per sekunde
            data[i] += Mathf.Sin(i / 44100f * Mathf.PI * 2 * 960);
            data[i] /= 2f;
        }

        clip.SetData(data, 0);
        source.clip = clip;
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
