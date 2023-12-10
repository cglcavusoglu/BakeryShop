using UnityEngine;
using System.Collections.Generic; 
public class DragAndSnap : MonoBehaviour
{
    public AudioManager audioManager;
    private Vector3 mOffset;
    private float mZCoord;
    public List<Transform> snapPoints; 

    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + mOffset;
    }

    void OnMouseUp()
    {
        float closestDistance = Mathf.Infinity;
        Transform closestSnapPoint = null;

        // En yakın snap point'i bul
        foreach (Transform snapPoint in snapPoints)
        {
            float distance = Vector3.Distance(transform.position, snapPoint.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestSnapPoint = snapPoint;
            }
        }

       
        if (closestSnapPoint != null && closestDistance < 0.7f) 
        {
            transform.position = closestSnapPoint.position;
            GetComponent<Rigidbody>().isKinematic = true; 
        }
        audioManager.PlayNextNumberSound();
    }
}
