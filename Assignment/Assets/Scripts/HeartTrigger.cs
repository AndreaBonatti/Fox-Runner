using UnityEngine;

public class HeartTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //if the fox hits the heart it gains 1 more heart! (Max health = 3)
        if (other.name == "Mesh Collider Rotated" && PlayerPrefs.GetInt("Health") < 3)
        {
            PlayerPrefs.SetInt("Health", PlayerPrefs.GetInt("Health") + 1);  
        }
        this.gameObject.SetActive(false);
    }
}
