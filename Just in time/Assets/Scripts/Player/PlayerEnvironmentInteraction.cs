using UnityEngine;

///<sumary>Class that is responsible for handling interaction with environment</sumary>
public class PlayerEnvironmentInteraction : MonoBehaviour
{
    public Vector3 ThrowableItemOffset;
    
    private DialogCloud _dialogCloudGameObject;
    public DialogCloud DialogCloudGameObject
    {
        get => _dialogCloudGameObject;
        set => _dialogCloudGameObject = value;
    }

    [Header("Gizmos")]
    [SerializeField] private bool isDisplayed = true;

    private void OnDrawGizmos()
    {
        if (!isDisplayed)
            return;
        
        Gizmos.color = Color.magenta;
        Gizmos.DrawCube(transform.position + ThrowableItemOffset, Vector3.one);
    }
}
