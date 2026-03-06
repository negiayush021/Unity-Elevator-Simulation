using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] bool isMoving = false;

    [Space]
    [SerializeField] private TextMeshProUGUI display_text;
    public int currentFloor = 0;

    Queue<int> floorQueue = new Queue<int>();

    public ElevatorManager manager;
    private Animator _animator;

    private void Start()
    {
        _animator = transform.GetChild(0).GetComponent<Animator>();
    }
    private void Update()
    {
        if (!isMoving && floorQueue.Count > 0)
        {
            int targetFloor = floorQueue.Dequeue();
            StartCoroutine(MoveToFloor(targetFloor));
        }
        display_text.text = currentFloor.ToString();
    }

    IEnumerator MoveToFloor(int targetFloor)
    {
        isMoving = true;

        Vector3 targetPosition = new Vector3(transform.localPosition.x, targetFloor * 20f, transform.localPosition.z);

        while(Vector3.Distance(transform.localPosition , targetPosition) > 0.01f)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        //Playing Animation
        _animator.CrossFadeInFixedTime("door_open", 0.2f);
        yield return new WaitForSeconds(1);


        currentFloor = targetFloor;
        isMoving = false;
        manager.can_request = true;

    }

    public void AddRequest(int floor)
    {
        if (!floorQueue.Contains(floor))
        {
            floorQueue.Enqueue(floor);
            print("Added");
        }
    }

}
