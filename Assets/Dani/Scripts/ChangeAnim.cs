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
    
        if (Input.GetMouseButtonDown(0)) 
        {
            if (animator != null)
            {
           
                animator.SetBool(boolParameterName, true);
            }
        }

        if (Input.GetMouseButtonUp(0)) 
        {
            if (animator != null)
            {
                animator.SetBool(boolParameterName, false);
            }
        }
    }
}
