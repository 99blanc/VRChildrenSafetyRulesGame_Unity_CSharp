using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabCollider : MonoBehaviour
{
    public PlayerCollider player;
    private bool isShield = false;
    private bool isPlayer = false;

    private void OnTriggerStay(Collider hit)
    {
        if (hit.transform.tag.Equals("Shield"))
        {
            isShield = true;
            if (isShield && isPlayer)
            {
                player.connect = true;
            }
        }
        if (hit.transform.tag.Equals("Player"))
        {
            isPlayer = true;

            if (isShield && isPlayer)
            {
                player.connect = true;
            }
        }
    }

    private void OnTriggerExit(Collider hit)
    {
        if (hit.transform.tag.Equals("Shield"))
        {
            isShield = false;
            player.connect = false;
        }
        if (hit.transform.tag.Equals("Player"))
        {
            isPlayer = false;
            player.connect = false;
        }
    }
}
