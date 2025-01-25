using UnityEngine;

public class AnimationOnClick : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private string boolParameterName = "SweepBool";

    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("No Animator component found on this GameObject.");
        }
    }

    void Update()
    {
        // Check if the left mouse button (or primary touch) is pressed
        if (Input.GetMouseButtonDown(0)) // 0 is for the left mouse button
        {
            if (animator != null)
            {
                // Set the bool parameter to true
                animator.SetBool(boolParameterName, true);
            }
        }

        // Check if the left mouse button is released
        if (Input.GetMouseButtonUp(0)) // 0 is for the left mouse button
        {
            if (animator != null)
            {
                // Set the bool parameter to false
                animator.SetBool(boolParameterName, false);
            }
        }
    }
}
