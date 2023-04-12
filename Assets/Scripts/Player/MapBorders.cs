using UnityEngine;

public class MapBorders : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerData>())
        {
            Transform playerTransform = other.GetComponent<Transform>();
            playerTransform.position = -1 * (playerTransform.position * 0.9f);
        }
    }
}
