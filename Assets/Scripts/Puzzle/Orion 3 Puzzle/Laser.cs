using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] Transform laserSprite;
    Vector3 direction;

    // Update is called once per frame
    void Start()
    {
        direction = Vector3.right;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootLaser();
        }
    }
    void ShootLaser()
    {
        laserSprite.position = new Vector3(75.01f, -18.47f, 0f);

    }
}
