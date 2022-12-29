using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DayController : MonoBehaviour
{

    [SerializeField] GameObject lights;
    [SerializeField] UnityEngine.Rendering.Universal.Light2D globalLight;


    public bool isDay;
    public float time;
    public bool lightsOn;


    // Start is called before the first frame update
    IEnumerator Start()
    {
        isDay = true;
        while (true)
        {
            if(isDay) { 
                globalLight.intensity -= 0.01f;
                if(globalLight.intensity <= 0.1)
                {
                    isDay = false;
                }

                if(globalLight.intensity <= 0.6)
                {
                    lights.SetActive(true);
                    lightsOn = true;
                }
            }
            else{
                globalLight.intensity += 0.01f;
                if (globalLight.intensity >= 0.9)
                {
                    isDay = true;
                }

                if (globalLight.intensity >= 0.6)
                {
                    lights.SetActive(false);
                    lightsOn = false;
                }
            }
            yield return new WaitForSeconds(time);
        }
    }
}
