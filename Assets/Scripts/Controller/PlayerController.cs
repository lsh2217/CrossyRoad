using UnityEngine;
using UnityEngine.InputSystem;
public interface IHit
{
    public void GetHit();
}
public class PlayerController : MonoBehaviour, IHit
{
    public float moveDistance = 1;
    private Vector3 curPos;
    private Vector3 moveValue;
    public float moveTime = 0.4f;
    public float colliderDistCheck = 1.1f;

    public ParticleSystem particle = null;
    public Transform chick = null;
    public bool isDead = false;

    void Start()
    {
        moveValue = Vector3.zero;
        curPos = transform.position;
    }

    void Update()
    {
        
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        Vector3 input = new Vector3(context.ReadValue<Vector2>().x, 0, context.ReadValue<Vector2>().y);

        Debug.Log(input);

        if (input.magnitude > 1f) return;

        if (input.magnitude == 0f)
        {
            Moving(transform.position + moveValue);
            moveValue = Vector3.zero;
        }
        else
        {
            moveValue = input * moveDistance;
            Rotate(moveValue);
        }
    }
    void Moving(Vector3 pos)
    {
        LeanTween.move(this.gameObject, pos, moveTime).setOnComplete(() => { if (pos.z > curPos.z) SetMoveForwardState(); });
    }

    void Rotate(Vector3 pos)
    {
        if (pos.magnitude > 0f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(pos, Vector3.up);
            chick.rotation = targetRotation;
        }
    }
    void SetMoveForwardState()
    {
        GameManager.instance.UpdateDistanceCount();
        curPos = transform.position;
    }

    public void GetHit()
    {
        GameManager.instance.GameOver();
        isDead = true;
        ParticleSystem.EmissionModule em = particle.emission;
        em.enabled = true;
    }
}
