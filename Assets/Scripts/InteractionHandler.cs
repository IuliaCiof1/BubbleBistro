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
            if(currentTarget && currentTarget.TryGetComponent(out Plate_Cleanable cleanableObj))
            {
                cleanableObj.CleanMess();
            }
        }
    }

    void GetTarget()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Camera.main.transform.TransformDirection(Vector3.forward), out RaycastHit hitInfo, distance)
        if (Physics.Raycast(ray, out RaycastHit hitInfo, distance))
        {
            GameObject hitObject = hitInfo.collider.gameObject;

            currentTarget = hitObject;


            if(currentTarget.TryGetComponent(out ICleanable cleanableObj))
            {
                Debug.Log("Press E to clean");
            }
        }

        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);
    }

}
