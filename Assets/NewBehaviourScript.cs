using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform Target;
    void Update()
    {
        transform.LookAt(Target);
    }
}
