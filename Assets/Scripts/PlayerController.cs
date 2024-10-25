using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] int moneyCount;
    [SerializeField] float playerSpeed;
    [SerializeField] TextMeshProUGUI moneyCountText;
    Damage _damage;
    CharacterController _ch;

    [Header("Mouse")]
    [SerializeField] float maxXRotation;
    [SerializeField] float maxYRotation;



    void Start()
    {
        _damage = GetComponent<Damage>();
        _ch = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 moveDirection = new Vector3(0, 0, moveHorizontal);
        moveDirection += new Vector3(-1, 0, 0);

        _ch.Move(moveDirection * playerSpeed * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("enemy"))
        {
            Debug.Log("Игрок столкнулся с врагом.");
            _damage.TakeDamage(3);
            Destroy(hit.gameObject);
        }
        else if (hit.gameObject.CompareTag("prop"))
        {
            Debug.Log("Игрок столкнулся с пропом.");
            _damage.TakeDamage(1);
            Destroy(hit.gameObject);
        }
    }

    void Money()
    {
        moneyCount++;
        moneyCountText.text = moneyCount.ToString();
    }

}
