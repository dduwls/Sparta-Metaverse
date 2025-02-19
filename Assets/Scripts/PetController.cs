using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetController : MonoBehaviour
{
    public GameObject player;
    public float followSpeed;
    public Vector3 offset;

    private Vector3 targetPosition;

    void Start()
    {

    }

    void Update()
    {
        // transform.position = player.transform.position;

        targetPosition = player.transform.position + offset; // new Vector3(0.7f, 0.25f);
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * followSpeed);
    }
}
