using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    [SerializeField] Vector3 sittingOffset = new Vector3(0, 0.308f, 0.048f);

    private float timeAtTable;
    Animator animator;

    private void OnEnable()
    {
        Invoke(nameof(SitAtTable), 0.9f);

        timeAtTable = Random.Range(5f, 10f);

        animator = GetComponent<Animator>();
        animator.SetFloat("walkOffset", Random.Range(0.0f, 2.0f));
        animator.SetFloat("speedMultiplier", Random.Range(0.5f, 1.2f));
    }

    void SitAtTable()
    {
        int randomIndex = Random.Range(0, CustomerManager.chairs.Count);

        if (CustomerManager.chairs[randomIndex].transform.childCount > 0)
            SitAtTable();
        else
        {
            animator.SetTrigger("Sit");
            transform.SetParent(CustomerManager.chairs[randomIndex].transform);
            transform.localPosition = Vector3.zero + sittingOffset;
            transform.localRotation = Quaternion.identity;
        }

        Invoke(nameof(LeaveTable), timeAtTable);
    }

    void LeaveTable()
    {
        Destroy(gameObject);
    }
}
