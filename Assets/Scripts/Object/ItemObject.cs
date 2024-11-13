using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public int id;
    public GameObject prefab;

    private void Update()
    {
        if (transform.position.x < -5f || transform.position.x > 5f)
        {
            GameManager.instance.ReturnObject(gameObject, id);
        }
    }
}
