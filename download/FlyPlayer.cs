using UnityEngine;
using UnityEngine.SceneManagement;

public class FlyPlayer : MonoBehaviour, IObjectStates
{

    [SerializeField] private float speedY;
    [SerializeField] private float speedX;
    [SerializeField] private float turnSpeed;
    [SerializeField] private GameObject bullet;

    private float acceleration;
    private Rigidbody2D _rigidbody2D;
    private Transform _transform;
    private MoveStates moveStates = MoveStates.Idle;
    

    public void Turn()
    {
        Quaternion rotationZ = Quaternion.AngleAxis(acceleration * turnSpeed, new Vector3(0f, 0f, 1f));
        _transform.rotation = rotationZ;
    }

    public void Move()
    {
        acceleration = Input.GetAxis("Vertical");
        _rigidbody2D.velocity = new Vector2(acceleration * speedX * Time.deltaTime, acceleration * Time.deltaTime * speedY);


    }

    public void AfterMap()
    {
        if (_transform.position.y < -6.5f)
            _transform.position = new Vector2(_transform.position.x, 6.2f);
        else if(_transform.position.y > 6.5f)
            _transform.position = new Vector2(_transform.position.x, -6.2f);
    }


    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        Move();
        Turn();
        AfterMap();
    }

    private void Update()
    {
        CheckMoveState();
        Fire();
    }
 

    private void Fire()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(bullet, _transform.position, Quaternion.identity);
        }

        /*if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)            
                Instantiate(bullet, _transform.position, Quaternion.identity);      
        }*/
    }

    private void SceneReload()
    {
        SceneManager.LoadScene("FlyLevel");
    }



    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "Enemy")
        {
            SceneReload();
        }
    }
    private void CheckMoveState()
    {
        if (acceleration > 0)
            moveStates = MoveStates.FlyUp;
        else if (acceleration < 0)
            moveStates = MoveStates.FlyDown;
        else
            moveStates = MoveStates.Idle;
        Debug.Log(moveStates);
    }

    enum MoveStates
    {
        Idle,
        FlyUp,
        FlyDown
    }

}
