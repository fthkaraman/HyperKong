using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;

    void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        direction.z = forwardSpeed;

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        controller.center = controller.center;
    }

    private void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Score.scoreValue += 1;
            FinalScore.finalScore += 75;
            Object.Destroy(gameObject);
            Debug.Log("hit");
        }
    }
}
