using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayandNight : MonoBehaviour
{
    [SerializeField] private float secondPerRealTimesecond; //게임 세계의 100초 = 현실 세계의 1초

    private bool isNight = false;

    [SerializeField] private float fogDensityCalc; //증감량 비율

    [SerializeField] private float nightFogDensity; //밤 상태의 Fog 밀도
    private float dayFogDensity; //낮 상태의 FoG 밀도
    private float currentFogDensity; //계산

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right, 0.1f * secondPerRealTimesecond * Time.deltaTime);
        
        if (transform.eulerAngles.x >= 170)
           isNight = true;
        else if (transform.eulerAngles.x <= 10)
           isNight = false;

           if (isNight)
           {
             if (currentFogDensity <= nightFogDensity)
             {
                currentFogDensity += 0.1f * fogDensityCalc * Time.deltaTime;
            RenderSettings.fogDensity = currentFogDensity;
             }

           }
           else
           {
            if (currentFogDensity >= dayFogDensity)
             {
                currentFogDensity += 0.1f * fogDensityCalc * Time.deltaTime;
            RenderSettings.fogDensity = currentFogDensity;
             }

           }
    }
}
