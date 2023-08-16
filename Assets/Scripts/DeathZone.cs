using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public GameManager gm;

    private void OnCollisionEnter(Collision other)
    {
        Destroy(other.gameObject);
        gm.GameOver();
    }
}
