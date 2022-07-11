using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    public LayerMask whatCanBeClickedOn;
    private NavMeshAgent myAgent;
    public Animator playerAnimator;
    const float diff = 1f;
    

    private void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        myAgent.speed = 0f;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 currentPos = myAgent.transform.position;
            myAgent.speed = 5f;
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            float dist = 0f;

            if (Physics.Raycast(myRay, out hit, 100f, whatCanBeClickedOn))
            {
                Vector3 newPos = hit.point;
                myAgent.SetDestination(newPos);
                
            }
            Vector3 newPoss = hit.point;
            dist = Vector3.Distance(newPoss, currentPos);
            if (Mathf.Abs((Vector3.Distance(myAgent.transform.position, currentPos)) - dist) <= 1f)
            {
                myAgent.speed = 0f;
            }

            

            if (myAgent.speed > 0f)
            {
                playerAnimator.SetBool("isWalking", true);
            }
            else
            {
                playerAnimator.SetBool("isWalking", false);
            }
        }



    }
}
