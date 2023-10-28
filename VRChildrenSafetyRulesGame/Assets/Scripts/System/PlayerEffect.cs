using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffect : MonoBehaviour
{
    private Vector3 moveVector;

    private void Update()
    {
        PlayerPosition();

        if (moveVector != Vector3.zero)
        {
            SoundControl.instance.PlaySE("Walk");

        }
        else
        {
            SoundControl.instance.StopSE("Walk");
        }
    }

    private void PlayerPosition()
    {
        var hAxis = Input.GetAxisRaw("Horizontal");
        var vAxis = Input.GetAxisRaw("Vertical");

        moveVector = new Vector3(hAxis, 0, vAxis).normalized;
    }
}
