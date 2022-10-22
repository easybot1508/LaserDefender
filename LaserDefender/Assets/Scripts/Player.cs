using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector2 rawInput;
    [SerializeField] float speedMove = 5f;
    //phan` dem. xung quanh man` hinh`
    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;

    //tao. gioi' han. khung hinh`
    Vector2 minBounds;
    Vector2 maxBounds;

    Shooter shooter;

    private void Awake()
    {
        shooter = GetComponent<Shooter>();
    }

    private void Start()
    {
        InitBounds();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove(); 
    }

    void PlayerMove()
    {
        Vector2 delta = rawInput * speedMove * Time.deltaTime;

        Vector2 newPosition = new Vector2();
        //Mathf.Clamp: giup han che bat ky gia tri nao nam` ngoai` gia tri. toi thieu? va` toi' da ma` chung' ta da~ dat.
        //vi. tri' hien. tai. + delta
        //tinh' toan' vi. tri' X ,Y moi'
        newPosition.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        newPosition.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);
        transform.position = newPosition;
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {
        if(shooter != null)
        {
            shooter.isFiring = value.isPressed;
        }
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }
}
