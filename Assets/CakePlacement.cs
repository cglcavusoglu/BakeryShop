using UnityEngine;

public class CakePlacement3D : MonoBehaviour
{
    public AudioSource placementSound; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("cake")) 
        {
            placementSound.Play();
            
        }
    }
}
