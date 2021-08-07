using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    //gat specs
    public GameObject special;
    public float timeBeforeNextSpecial = 5.0f;
    public float distanceTraveled = 25;
    public float specialSpeed = 5000;
    private float canShoot = 0f;

    //unit/s

    public float startAccel;
    public float maxAccel;
    public float maxAccelTime;
    public float maxDeAccelTime;
    private float currentAccelTime;
    public float slideSpeed = 5;
    public float jumpForce = 300;
    public float timeBeforeNextJump = 1.2f;
    private float canJump = 0f;
    private float speedInAir;
    private bool standby = true;




    GameObject curBullet;
    Animator anim;
    Rigidbody rb;
    int currentLane = 0;
    float[] laneLocs;

    void OnCollisionEnter(Collision collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.tag == "Obstacle")
        {
            quickReset();
        }
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        currentAccelTime = 0f;
        laneLocs = GameManager.laneXOne;
        standby = false;
        anim.SetInteger("Walk", 1);


    }

    void Update()
    {

        //Capture left and right movement 
        if (Input.GetKeyDown("a") && currentLane != 0)
        {
            //for future add animation
            currentLane--;
        }
        if (Input.GetKeyDown("d") && currentLane != laneLocs.Length - 1)
        {
            //for future add animation
            currentLane++;
        }

        //*Capture Jump movement and Makes user jump 
        if (Input.GetButtonDown("Jump") && Time.time > canJump)
        {
            // rb.AddForce(0, jumpForce, 0);
            canJump = Time.time + timeBeforeNextJump;
            anim.SetTrigger("jump");
            
        }
        //That boy a shooter
        if (Input.GetKeyDown("p") && Time.time > canShoot)
        {
            if (curBullet)
                Destroy(curBullet);
            curBullet = Instantiate(special, new Vector3(transform.position.x, transform.position.y, transform.position.z + 5), transform.rotation);
            Rigidbody bulletRb = curBullet.GetComponent<Rigidbody>();
            bulletRb.AddForce(0, 0, specialSpeed);
            canShoot = Time.time + timeBeforeNextSpecial;
        }
        //standy= after hitting obj
        if (!standby)
        {
            move();
        }
    }
    void quickReset()
    {
        currentAccelTime = 0;
        // Debug.Log (currentAccelTime);
        standby = true;
        transform.Translate(new Vector3(0.0f, 0.0f, -35f), Space.World);

        StartCoroutine(HoldPlayer());
    }
    IEnumerator HoldPlayer()
    {
        yield return new WaitForSeconds(1);
        standby = false;
    }

    void move()
    {
        // 1 or 0
        float moveVertical = Input.GetAxisRaw("Vertical");



        float moveHorizontal = (laneLocs[currentLane] - transform.position.x);
        Vector3 movement1 = new Vector3(0.0f, 0.0f, 1f);
        Vector3 movement2 = new Vector3(moveHorizontal, 0.0f, 0.0f);
        if (currentAccelTime < maxAccelTime && moveVertical == 1)
        {
            currentAccelTime += Time.deltaTime;
        }
        else if (moveVertical == -1 && currentAccelTime > 0)
        {
            currentAccelTime -= 2 * Time.deltaTime;
        }
        else if (moveVertical == 0 && currentAccelTime > 0)
            currentAccelTime -= (float)0.3 * Time.deltaTime;

        float movementSpeed = startAccel + (maxAccel - startAccel) * (currentAccelTime / maxAccelTime);

        // Debug.Log ("cur accel time:" + currentAccelTime);

        // if (movementSpeed == 0)
        // {
        //     Debug.Log("walk");
        //     anim.SetInteger("Walk", 0);
        // }
        // else
        // {
        //     Debug.Log("run");
        //     anim.SetInteger("Walk", 1);
        // }



        transform.Translate(movement1 * movementSpeed * Time.deltaTime, Space.World);
        transform.Translate(movement2 * Time.deltaTime * slideSpeed, Space.World);

    }
}