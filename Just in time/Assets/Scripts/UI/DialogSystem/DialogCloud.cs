using System.Collections;
using TMPro;
using UnityEngine;

///<summary>Script that is responsible for displaying and controlling dialog clouds</summary>>
[RequireComponent(typeof(TextMeshPro))]
public class DialogCloud : MonoBehaviour
{
    [SerializeField] private Vector2 borderOffset;
    [SerializeField] private GameObject backgroundCloud;
    
    [SerializeField] private GameObject objectToFollow;
    [SerializeField] [Range(0, .5f)] private float transactionTime;

    [Header("Gizmos")] [SerializeField] private bool isActive = false;
    
    private Vector3 _offset;
    private TextMeshPro _textMeshPro;

    private Vector3 _velocity = new Vector3(0,0,0);
    private void Start()
    { 
        gameObject.SetActive(false);
        
        if (objectToFollow != null)
        {
            var z = transform.position.z;
            _offset = transform.position - objectToFollow.transform.position;
            _offset.z = z;
            
            var playerEnvironmentInteraction = objectToFollow.GetComponent<PlayerEnvironmentInteraction>();
            if (playerEnvironmentInteraction != null)
                playerEnvironmentInteraction.DialogCloudGameObject = this;
        }
        
        _textMeshPro = GetComponent<TextMeshPro>();
    }

    private void Update()
    {
        if (objectToFollow != null && gameObject.activeSelf)
        {
            var currentPos = transform.position;
            var destination = objectToFollow.transform.position + _offset;
            destination.z = transform.position.z;

            transform.position = Vector3.SmoothDamp(currentPos, destination, ref _velocity, transactionTime);
            
            if(isActive && backgroundCloud != null)
                backgroundCloud.transform.localScale = (Vector2)_textMeshPro.textBounds.size + borderOffset;
        }
    }

    public void InvokeDialog(string message, float timeout, TMP_FontAsset font = null)
    {
        if (font != null)
            _textMeshPro.font = font;
        _textMeshPro.SetText(message);

        gameObject.SetActive(true);
        
        StartCoroutine(HideDialogAfterSomeTime(timeout));
    }

    private IEnumerator HideDialogAfterSomeTime(float timeout)
    {
        yield return new WaitForSeconds(timeout);
        gameObject.SetActive(false);
    }

    private void OnDrawGizmos()
    {
        if (objectToFollow == null || !isActive)
            return;

        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(transform.position, objectToFollow.transform.position);
    }
}