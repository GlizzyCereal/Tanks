using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 10f;

    [Header("Shooting")]
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float fireRate = 0.5f;

    void Start()
    {
        InvokeRepeating("Shoot", 0.0f, fireRate);
    }

    void Update() {
        Move();
    }

    private void Move() {
        var input = new Vector3();
        input.x = Input.GetAxis("Horizontal");
        input.z = Input.GetAxis("Vertical");

        transform.position += input * speed * Time.deltaTime;

        if (input != Vector3.zero) {
            Quaternion targetRotation = Quaternion.LookRotation(input);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speed);
        }
    }

    private void Shoot() {
        Instantiate(bulletPrefab, bulletSpawn.position, transform.rotation);
    }
}
