using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField]
    private GameObject objectToFollow;
    private Vector3 offset;

	private void Start ()
    {
        objectToFollow = GameObject.FindWithTag("Player");
        offset = new Vector3 (0, 3, -3);
        transform.eulerAngles = new Vector3 (45, 0, 0);
	}
	
	private void LateUpdate ()
    {
        transform.position = objectToFollow.transform.position + offset;
	}
}
 