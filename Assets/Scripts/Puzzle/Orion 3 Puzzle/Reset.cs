using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    [SerializeField] private LaserCaster laserCaster;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Resetting Scene");
            ResetScene();
        }
    }
    public void ResetScene()
    {
        GameObject[] lines = GameObject.FindGameObjectsWithTag("Line");
        foreach (GameObject line in lines)
        {
            Destroy(line);
            laserCaster.isFiring = false;
        }
    }
}
