using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Vector3 JumpForce;

    private Vector3 CurrentVelocity;

    // Update is called once per frame
    void Update()
    {
        var DesiredVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        DesiredVelocity *= Input.GetKey(KeyCode.LeftShift) ? 2.0f : 1.0f;

        var Steering = DesiredVelocity - CurrentVelocity;

        CurrentVelocity += Steering * 5.0f * Time.deltaTime;
        if (CurrentVelocity != Vector3.zero)
        {
            transform.forward = CurrentVelocity.normalized;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(CurrentVelocity + JumpForce, ForceMode.Impulse);
        }
        
        transform.position += CurrentVelocity * Time.deltaTime;
        GetComponent<Animator>().SetFloat("Forward", CurrentVelocity.magnitude);
    }
}
