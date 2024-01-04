using UnityEngine;
using UnityEngine.AI;

public class NetworkedCharacterController : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent m_navMeshAgent;
    private Animator m_animator;    

    private void Start()
    {
        m_animator = GetComponent<Animator>();        
    }

    private void Update()
    {
        
        UpdateMovementInput();
        UpdateAnimator();
    }

    private void UpdateMovementInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            int layerMask = LayerMask.NameToLayer("NavMesh");

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ~layerMask)) //~ means that raycast will hit everything except the layers specified in layerMask
            {
                m_navMeshAgent.SetDestination(hit.point);
            }
        }
    }

    private void UpdateAnimator()
    {
        bool isMoving = m_navMeshAgent.velocity.magnitude > 0.1f;
        //bool isMoving = m_navMeshAgent.remainingDistance > m_navMeshAgent.stoppingDistance;

        m_animator.SetBool("Walking", isMoving);
    }
}
