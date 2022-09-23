using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Vector3 JumpForce;
    public GameObject Target;

    private Vector3 CurrentVelocity;

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        if (navMeshAgent)
        {
            navMeshAgent.updatePosition = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        var DesiredVelocity = Vector3.zero;
        
        if (navMeshAgent)
        {
            //var Direction = Target.transform.position - transform.position;
            //Direction.y = 0.0f;
            //DesiredVelocity = Vector3.ClampMagnitude(Direction, 1.0f);
            //if (!NavMeshAgent.hasPath)
            //{
            //    NavMeshAgent.SetDestination(Target.transform.position);
            //}

            DesiredVelocity = navMeshAgent.desiredVelocity;
        }
        else
        {
            DesiredVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            DesiredVelocity *= Input.GetKey(KeyCode.LeftShift) ? 2.0f : 1.0f;
        }

        var Steering = DesiredVelocity - CurrentVelocity;

        CurrentVelocity += Steering * 5.0f * Time.deltaTime;
        if (DesiredVelocity != Vector3.zero)
        {
            transform.forward = DesiredVelocity.normalized;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(CurrentVelocity + JumpForce, ForceMode.Impulse);
        }
        
        transform.position += CurrentVelocity * Time.deltaTime;
        GetComponent<Animator>().SetFloat("Forward", CurrentVelocity.magnitude);
    }
}