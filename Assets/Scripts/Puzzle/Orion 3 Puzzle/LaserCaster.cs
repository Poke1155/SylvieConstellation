using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCaster : MonoBehaviour
{
    [SerializeField] private GameObject beam;
    [SerializeField] private Transform Origin;


    public bool isFiring = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isFiring)
        {
            GameObject newBeam = Instantiate(beam, Origin.position, Quaternion.Euler(0, 0, 0));
            newBeam.tag = "Line";
            isFiring = true;
        }
    }
}
