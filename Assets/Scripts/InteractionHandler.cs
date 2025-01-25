using UnityEngine;

public class InteractionHandler : MonoBehaviour
{
    [SerializeField] private Transform rayPosition;
    [SerializeField] private float distance;

    private GameObject currentTarget;

    void Update()
    {
        GetTarget();

        if (Input.GetKeyDown(KeyCode.E))
        {
            if(currentTarget && currentTarget.TryGetComponent(out ICleanable cleanableObj))
            {
                cleanableObj.CleanMess();
            }
        }
    }

    void GetTarget()
    {
        if (Physics.Raycast(rayPosition.position, Camera.main.transform.TransformDirection(Vector3.forward), out RaycastHit hitInfo, distance))
        {
            GameObject hitObject = hitInfo.collider.gameObject;

            currentTarget = hitObject;


            if(currentTarget.TryGetComponent(out ICleanable cleanableObj))
            {
                Debug.Log("Press E to clean");
            }
        }

        Debug.DrawRay(rayPosition.position, transform.TransformDirection(Vector3.forward) * distance, Color.red);
    }

}
