using UnityEngine;

public class ChangeAnimGun : MonoBehaviour
{
    [SerializeField] public AudioClip[] LightPopAudio;
    private Animator animator;
    [SerializeField] private string boolParameterName = "SweepBool";
    public ParticleSystem gunParticleSystem;

    private float delay = 0.25f;    

    private float timer = 0f;    
    private bool isPlaying = false;
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
        if (Input.GetMouseButton(0))
        {
            if (animator != null)
            {

                animator.SetBool(boolParameterName, true);
            }

            if (!gunParticleSystem.isPlaying)
            {
                gunParticleSystem.Play();

            }
            isPlaying = true;
            timer += Time.deltaTime;

            if (timer >= delay)
            {
                SoundFXManager.instance.PlaySoundFXClips(LightPopAudio, transform, 1f); 
                timer = 0f; 
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isPlaying = false;
            timer = 0f;
            if (animator != null)
            {
                animator.SetBool(boolParameterName, false);
            }
            if (gunParticleSystem.isPlaying)
            {
                gunParticleSystem.Stop();
            }
        }
    }
    
}
