using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BottleJump : MonoBehaviour
{
    Rigidbody rbComponent;
    [SerializeField] Vector3 ForceVector;
    [SerializeField] AudioSource GameOverSound;
    [SerializeField] AudioSource JumpSound;
    [SerializeField] AudioSource DBJumpSound;
    [SerializeField] GameObject Cells;
    [SerializeField] GameObject Skin;
    public bool IsLanded;
    public bool IsDoubleJumpAvailable;
    public float maxXAxisSpeed;
    public float RortationSpeeModifier;
    public Vector3 CenterOfMass;

    Vector3 StartPos;
    private void Start()
    {
        StartPos = transform.position;
        rbComponent = GetComponent<Rigidbody>();
        rbComponent.centerOfMass = CenterOfMass;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.isGameActive)
        {
            if (IsLanded)
            {
                JumpSound.Play();
                StartCoroutine(SpinBottle());
            }
            else if (IsDoubleJumpAvailable)
            {
                DBJumpSound.Play(); 
                IsDoubleJumpAvailable = false;
                StartCoroutine(DoubleJump());
            }

        }
        //Ограничиваю горизонтальную скорость
        Vector2 velocity = rbComponent.velocity;
        velocity.x = Mathf.Clamp(velocity.x, -maxXAxisSpeed, maxXAxisSpeed);
        rbComponent.velocity = velocity;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LandingZone"))
        {
            IsLanded = true;
            IsDoubleJumpAvailable = true;
            if (other.TryGetComponent(out IntaractableObject intaractableObject))
            {
                intaractableObject.DoAction();
            }
        }
        else if (other.CompareTag("KillTrigger") && GameManager.isGameActive)
        {
            GameOverSound.Play();
            Cells.transform.parent = null;
            Cells.SetActive(true);
            Skin.SetActive(false);
            EventManager.CallRestartGame();
        }
        else if (other.TryGetComponent(out IntaractableObject intaractableZone))
        {
            intaractableZone.DoAction();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {

    }
    IEnumerator SpinBottle()
    {

        yield return new WaitForSeconds(0.1f);
        IsLanded = false;
        rbComponent.angularVelocity = Vector3.zero;
        rbComponent.AddForce(ForceVector - (Vector3.up * rbComponent.velocity.y), ForceMode.VelocityChange);
        float zAxisRot = transform.localEulerAngles.z;

        if (zAxisRot >= 285)
        {
            zAxisRot = 720 - transform.localEulerAngles.z;
        }
        else
        {
            zAxisRot = 360 - transform.localEulerAngles.z;
        }
        for (float i = 0; i < 1; i += Time.deltaTime * RortationSpeeModifier)
        {
            rbComponent.angularVelocity = Vector3.zero;
            if (IsLanded)
            {
                break;
            }
            transform.Rotate(Vector3.forward, zAxisRot / RortationSpeeModifier * Time.deltaTime);
            yield return null;
        }
    }
    IEnumerator DoubleJump()
    {
        rbComponent.angularVelocity = Vector3.zero;
        rbComponent.AddForce(ForceVector - (Vector3.up * rbComponent.velocity.y), ForceMode.VelocityChange);
        for (float i = 0; i < 1; i += Time.deltaTime * RortationSpeeModifier)
        {
            rbComponent.angularVelocity = Vector3.zero;
            if (IsLanded)
            {
                break;
            }
            transform.Rotate(Vector3.forward, 360 / RortationSpeeModifier * Time.deltaTime);
            yield return null;
        }
    }
}
