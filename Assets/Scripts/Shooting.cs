using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] Bullet bullet;
    [SerializeField] Bullet fastbullet;
    [SerializeField] float shotSpeed;
    [SerializeField] float fastShotSpeed;
    [SerializeField] Transform gunPosition;
    [SerializeField] float fireRate;
    [SerializeField] float fastFireRate;

    bool fireTimer;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !fireTimer)
        {
            var bulletInstance = Instantiate(bullet, gunPosition.position, Quaternion.identity);
            bulletInstance.GetComponent<Rigidbody>().AddForce(Vector3.up * shotSpeed);
            fireTimer = true;
            StartCoroutine(FireTimer());
        }
        else if (Input.GetKey(KeyCode.LeftShift) && !fireTimer)
        {
            var bulletInstance = Instantiate(fastbullet, gunPosition.position, Quaternion.identity);
            bulletInstance.GetComponent<Rigidbody>().AddForce(Vector3.up * fastShotSpeed);
            fireTimer = true;
            StartCoroutine(FastFireTimer());
        }
    }

    IEnumerator FireTimer()
    {
        yield return new WaitForSeconds(fireRate);
        fireTimer = false;
    }
    IEnumerator FastFireTimer()
    {
        yield return new WaitForSeconds(fastFireRate);
        fireTimer = false;
    }
}
