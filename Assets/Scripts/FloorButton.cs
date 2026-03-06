using UnityEngine;

public class FloorButton : MonoBehaviour
{
    public int floorNumber;

    public ElevatorManager manager;

    public void OnPress()
    {
        if (manager.can_request)
        {
            manager.RequestElevator(floorNumber);
            manager.can_request = false;
        }
        else
        {
            GameObject temp = Instantiate(manager.warning_tag , manager.canvas);
            Destroy(temp, 2f);
        }
            

    }
}
