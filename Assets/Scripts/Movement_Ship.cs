using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Movement_Ship : MonoBehaviour
{

	[SerializeField]
	Vector2 Area;
    
    [SerializeField]
	Camera Camera;

    Rigidbody2D rgBody;

    public Vector2 targetPosition;

    // Use this for initialization
    void Start () {
		Camera = FindObjectOfType<Camera> ();
        rgBody = GetComponent<Rigidbody2D>();
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawWireCube (Vector3.zero, Area*2f);
	}

    void Update () {

        targetPosition = (Vector2)Camera.ScreenToWorldPoint(Input.mousePosition);

        targetPosition.x = Mathf.Clamp(targetPosition.x, -Area.x, Area.x);
        targetPosition.y = Mathf.Clamp(targetPosition.y, -Area.y, Area.y) + 0.7f;

        transform.position = Vector3.Lerp(transform.position, (Vector2)targetPosition, Time.deltaTime * 7f);


    }
}
