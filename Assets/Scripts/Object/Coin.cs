using UnityEngine;

public class coin : MonoBehaviour
{
    public int coinValue = 1;
    public float rotSpeed = 1.0f;

    private void Update()
    {
        transform.Rotate(new Vector3(0, rotSpeed * Time.deltaTime, 0));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.UpdateCoinCount(coinValue);
            Destroy(this.gameObject);
        }
    }
}