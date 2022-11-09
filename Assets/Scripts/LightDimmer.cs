using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDimmer : MonoBehaviour
{
    //Lights
    public GameObject dirLight;
    public GameObject spot1;
    public GameObject spot2;
    public GameObject spot3;
    public GameObject point1;
    public GameObject matLight1;

    //Light Components
    Light dir1;
    Light light1;
    Light light2;
    Light light3;
    Light plight1;
    Renderer matl1;
    public Color startColor;

    //boolean trigger
    bool trigger = false;

    //LightsChanger
    delegate void LightsChange();
    List<LightsChange> changeLights = new List<LightsChange>();
    int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        dir1 = dirLight.GetComponent<Light>();
        light1 = spot1.GetComponent<Light>();
        light2 = spot2.GetComponent<Light>();
        light3 = spot3.GetComponent<Light>();
        plight1 = point1.GetComponent<Light>();
        matl1 = matLight1.GetComponent<Renderer>();
        //matl2 = matLight2.GetComponent<Renderer>();

        //add to delegate list
        changeLights.Add(LightsDimmed);
        changeLights.Add(LightsOff);
        changeLights.Add(LightsOn);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && !trigger)
        {
            changeLights[counter++]();
        }
        if (counter > 2) counter = 0;
    }

    void LightsDimmed()
    {
        light1.intensity = 100;
        light2.intensity = 100;
        light3.intensity = 100;
        matl1.material.SetColor("_EmissionColor", startColor * 5.2f);
    }

    void LightsOff()
    {
        dir1.enabled = false;
        light1.enabled = false;
        light2.enabled = false;
        light3.enabled = false;
        plight1.enabled = false;
        matl1.material.DisableKeyword("_EMISSION");
        trigger = false;
    }

    void LightsOn()
    {
        dir1.enabled = true;
        light1.enabled = true;
        light2.enabled = true;
        light3.enabled = true;
        light1.intensity = 884;
        light2.intensity = 2776;
        light3.intensity = 3413;
        plight1.enabled = true;
        matl1.material.EnableKeyword("_EMISSION");
        matl1.material.SetColor("_EmissionColor", startColor * 46f);
        trigger = false;
    }
}
