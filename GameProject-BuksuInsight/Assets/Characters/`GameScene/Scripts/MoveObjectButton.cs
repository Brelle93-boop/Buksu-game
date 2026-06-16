using UnityEngine;

public class MoveObjectButton : MonoBehaviour
{
    public Transform objectToMove;   // Object that will move
    public Transform targetLocation; // Target position

    public void MoveObject()
    {
        objectToMove.position = targetLocation.position;
    }
}