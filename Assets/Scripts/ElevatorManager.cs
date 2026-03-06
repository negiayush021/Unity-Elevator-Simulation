using UnityEngine;

public class ElevatorManager : MonoBehaviour
{
    public ElevatorController[] elevators;

    public GameObject warning_tag;
    public Transform canvas;
    public bool can_request = true;
    public void RequestElevator(int floor)
    {
        ElevatorController nearestElevator = null;
        int shortestDistance = int.MaxValue;

        foreach(var elevator in elevators)
        {
            int distance = Mathf.Abs(elevator.currentFloor - floor);

            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestElevator = elevator;
            }
            
        }

        nearestElevator.AddRequest(floor);
    }
}
