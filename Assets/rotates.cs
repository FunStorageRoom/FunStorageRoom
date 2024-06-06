using UnityEngine;

public class RotateEarth : MonoBehaviour
{
    public Transform targetObject; 
    public float rotationSpeed = 10f; 
    public float stopAngle = 90f; 
    public AudioClip clockwiseRotationAudio; 
    public AudioClip counterClockwiseRotationAudio;

    private float currentRotation = 0f;
    private float targetRotation = 0f;
    private bool isReversing = false; 
    private bool stop = false;
    private bool rotating = false; 

    private AudioSource audioSource; 

    private void Start()
    {
        
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void StartRotation()
    {
        rotating = true; 
        stop = false;
        targetRotation = stopAngle; 

        
        audioSource.clip = clockwiseRotationAudio;
        audioSource.Play();
    }

    void StopRotation()
    {
        rotating = false; 
        stop = true;
        audioSource.Stop(); 
    }

    void Update()
    {
        if (!rotating || targetObject == null)
            return; 

        
        float speed = isReversing ? -rotationSpeed : rotationSpeed;
        
        float rotationThisFrame = speed * Time.deltaTime;
        currentRotation += rotationThisFrame;

        
        if (!isReversing && currentRotation >= targetRotation)
        {
            isReversing = true; 
            targetRotation = 0f; 

            
            audioSource.clip = counterClockwiseRotationAudio;
            audioSource.Play();
        }
        else if (isReversing && currentRotation <= targetRotation)
        {
            isReversing = false; 
            currentRotation = 0f; 
            StopRotation(); 
        }

        
        targetObject.Rotate(Vector3.up, rotationThisFrame);
    }
}
