using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleController : MonoBehaviour
{
    [SerializeField]
    private float minVerticalSpeed = 0.5f;
    [SerializeField]
    private float maxVerticalSpeed = 1f;

    private float verticalSpeed;
    private Vector3 movement;

    [SerializeField]
    private float minRotationSpeed = -60f;
    [SerializeField]
    private float maxRotationSpeed = 60f;

    private float rotationSpeed;
    private Vector3 rotation;
    
    private void Awake ()
    {
        verticalSpeed = Random.Range(minVerticalSpeed, maxVerticalSpeed);
        rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
	}
	
	private void Update ()
    {
        if (transform.position.y < 0f && verticalSpeed < 0f || transform.position.y > 0.7f && verticalSpeed > 0f) verticalSpeed *= -1;
        movement = new Vector3(0f, verticalSpeed, 0f);
        rotation = new Vector3(0f, rotationSpeed, 0f);
	}

    private void FixedUpdate()
    {
        transform.Translate(movement * Time.deltaTime, Space.World);
        transform.Rotate(rotation * Time.deltaTime, Space.World);
    }
}
