using UnityEngine;
using UnityEngine.AI;

public class NetworkedCharacterController : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent m_navMeshAgent;

    private void Update()
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
}
