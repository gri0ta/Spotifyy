using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleDancer : MonoBehaviour
{
    public int count = 10;
    public float radius = 5f;
    public GameObject prefab;
    public float rotateSpeed = 360;
    public float sensitivity = 2f;

    void Start()
    {
        for (float i = 0; i < count; i++)
        {
            var angle = i / count * Mathf.PI *2; //i/count gauname 0.1 reiksmes, * 2PI gauname reiksmes nuo 0 iki 6.28
            var x = Mathf.Cos(angle);
            var y = Mathf.Sin(angle);
            var pos = new Vector3(x,y,0) * radius; //positionai objektau, kurie issideste apskritimu

            var obj= Instantiate(prefab, pos, Quaternion.identity,transform);
            obj.transform.LookAt(transform);//atsispawnine objects ziuri i parenta viduri
            
        }
        Analyzer.onVolumeChanged.AddListener(Dance);
    }

    void Dance(float volume)
    {
        var intensity = Mathf.Pow(volume, sensitivity);
        transform.Rotate(0, 0, intensity * Time.deltaTime *rotateSpeed);
        transform.localScale = Vector3.one * volume;
    }
}
