using UnityEngine;

public class CharacterMovment : MonoBehaviour
{
    public float speed = 6f;
    public float turnSpeed = 60f;
    public float turnSmoothing = 15f;

    private Vector3 movement;
    private Vector3 turning;
    private Animator anim;
    private Rigidbody playeRigidbody;
    // Use this for initialization
    void Awake()
    {
        //Get references
        anim = GetComponent<Animator>();
        playeRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        var lh = Input.GetAxisRaw("Horizontal");
        var lv = Input.GetAxisRaw("Vertical");

        Move(lh, lv);
        Animating(lh, lv);
    }


    void Move(float lh, float lv)
    {
        //Move the player
        movement.Set(lh, 0f, lv);
        //Makes Player look forwad
        movement = movement.normalized * speed * Time.deltaTime;
        //Tells Player to move. Takes position and adds movment.
        playeRigidbody.MovePosition(transform.position + movement);

        if (lh != 0f || lv != 0f)
        {
            Rotating(lh, lv);
        }

    }

    void Rotating(float lh, float lv)
    {
        Vector3 targetDirection = new Vector3(lh, 0f, lv);
        Quaternion targetRutation = Quaternion.LookRotation(targetDirection, Vector3.up);
        Quaternion newRotation = Quaternion.Lerp(GetComponent<Rigidbody>().rotation, targetRutation, turnSmoothing * Time.deltaTime);

        GetComponent<Rigidbody>().MoveRotation(newRotation);
    }
    void Animating(float lh, float lv)
    {
        bool running = lh != 0f || lv != 0f;
        anim.SetBool("IsRunning",running);
    }
    void Start()
    {
        //Store input axes

    }

    // Update is called once per frame
    void Update()
    {

    }
}
