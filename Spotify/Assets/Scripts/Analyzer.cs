using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Analyzer : MonoBehaviour
{
    AudioSource source;
    public static UnityEvent<float>onVolumeChanged = new();
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        var samples = new float[735]; //apskaiciuoti muzikos kadrai video kadruose
        source.clip.GetData(samples,source.timeSamples); //timesamples duoda kurioj vietoj dabar groja muzika

        var sum = 0f;
        for(int i = 0; i < samples.Length; i++)
        {
            sum += Mathf.Abs(samples[i]);
        }

        var average = sum / samples.Length;

        onVolumeChanged.Invoke(average);
    }
}
