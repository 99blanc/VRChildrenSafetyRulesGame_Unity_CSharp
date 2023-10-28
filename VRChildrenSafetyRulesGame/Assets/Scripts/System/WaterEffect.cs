using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterEffect : MonoBehaviour
{
    public OVRGrabbable fireE;
    public OVRGrabber hand;
    public ParticleSystem water;
    
    private void Start()
    {
        
    }

    private void Update()
    {
        DestroyFire();
    }

    private void DestroyFire()
    {
        if (fireE.GetComponent<OVRGrabbable>().isGrabbed && fireE.GetComponent<OVRGrabbable>().grabbedBy == hand)
        {
            if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
            {
                water.gameObject.SetActive(true);
                SoundControl.instance.PlaySE("Water");
            }
            else
            {
                water.gameObject.SetActive(false);
                SoundControl.instance.StopSE("Water");
            }
        }
    }
}
