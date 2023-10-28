using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEffect : MonoBehaviour
{
    public GameObject player;

    public bool isFiring = true;

    private void Update()
    {
        if (isFiring)
        {
            SoundControl.instance.PlaySE("Fire");

            if (player != null)
            {
                if (player.GetComponent<PlayerCollider>().total == 0)
                {
                    isFiring = false;
                    SoundControl.instance.StopSE("Fire");
                }
            }
        }
    }
}
