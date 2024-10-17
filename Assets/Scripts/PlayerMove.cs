using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController player;
    [SerializeField] float ZplayerSpeed;
    [SerializeField] int timeToLifeBullet;
    [SerializeField] int timeToShoot;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform spawnBullet;
    float lifeBullet;
    float timerForShoot;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Shoot();
    }

    void Movement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 moveDirection = new Vector3(0, 0, moveHorizontal);
        moveDirection += new Vector3(-1, 0, 0);

        player.Move(moveDirection * ZplayerSpeed * Time.deltaTime);
    }

    void Shoot()
    {
        if(timerForShoot < timeToShoot)
            timerForShoot += Time.deltaTime;
        else
        {
            timerForShoot = 0;
            Instantiate(bullet, spawnBullet.position, transform.rotation);
        }
    }
}
