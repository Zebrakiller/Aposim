using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour {

    private Animator animator;
    private NavMeshAgent navMeshAgent;
    private bool running = false;

	void Start () {

        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
	}
	
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(ray,out hit, 100))
            {
                navMeshAgent.destination = hit.point;
            }
        }
        if(navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            running = false;
        }
        else
        {
            running = true;
        }
        //animator.SetBool("Run", running);
	}
}
