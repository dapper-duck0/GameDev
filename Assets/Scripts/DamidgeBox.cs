using UnityEngine;

public class DamidgeBox : MonoBehaviour
{
    public bool IsInside = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IsInside = true;
        }
    }
    private void OnTriggerExit(Collider others)
    {
        if (other.CompareTag("Player"))
        {
            IsInside = false;
        }
    }
}