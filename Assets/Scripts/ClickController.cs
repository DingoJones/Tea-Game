using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickController : MonoBehaviour
{
    public static ClickController instance = null;

    [SerializeField] private float scrollSpeed = 0.25f;
    [SerializeField] private float smoothSpeed = 0.05f;

    private Pickupable heldObj;
    private Rigidbody objRB;

    private bool isHolding = false;

    private Ray ray;
    private RaycastHit tableHit;
    private RaycastHit selectHit;
    private bool isTableHit;
    private Vector3 mousePosition;
    private Vector3 mouseTableOffset;
    private Camera mainCam;
    private int tableLayer = 1 << 8;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    void Start()
    {
        mainCam = Camera.main;
    }

    void Update()
    {
        ray = mainCam.ScreenPointToRay(Input.mousePosition);
        isTableHit = Physics.Raycast(ray, out tableHit, 100, tableLayer);

        if (Input.GetMouseButtonDown(0)) {
            if (!isHolding && Physics.Raycast(ray, out selectHit, 100))
            {
                Pickup(selectHit.collider.GetComponentInParent<Pickupable>());
            }
            else if (isHolding) {
                Drop();
            }
        }

        if (isHolding)
        {
            if (isTableHit)
            {
                mousePosition = tableHit.point;
            }
            else {
                mousePosition = heldObj.transform.position;
            }
            Vector3 newPosition = mousePosition + mouseTableOffset;
            newPosition.x = Mathf.Clamp(newPosition.x, Table.instance.minX, Table.instance.maxX);
            newPosition.z = Mathf.Clamp(newPosition.z, Table.instance.minZ, Table.instance.maxZ);
            newPosition.y = heldObj.transform.position.y + Input.mouseScrollDelta.y * scrollSpeed;

            if (heldObj.transform.position != newPosition - Vector3.one * -Mathf.Epsilon) {
                heldObj.transform.position = Vector3.Lerp(heldObj.transform.position, newPosition, smoothSpeed);
            }
        }
    }

    public bool Pickup(Pickupable newObject) {
        if (newObject != null)
        {
            heldObj = newObject;
            objRB = heldObj.GetComponentInParent<Rigidbody>();
            objRB.useGravity = false;
            objRB.constraints = RigidbodyConstraints.FreezeAll;
            isHolding = true;
            if (isTableHit)
            {
                mouseTableOffset = heldObj.transform.position - tableHit.point;
                mouseTableOffset.y += 5;
            }
            else
            {
                mouseTableOffset = Vector3.up;
            }
            return true;
        }
        else {
            return false;
        }
    }

    public void Drop() {
        isHolding = false;
        objRB.useGravity = true;
        objRB.constraints = RigidbodyConstraints.None;
        objRB.constraints = RigidbodyConstraints.FreezeRotation;
        objRB.constraints = RigidbodyConstraints.FreezePositionX;
        objRB.constraints = RigidbodyConstraints.FreezePositionZ;
        heldObj = null;
        mouseTableOffset = Vector3.zero;
    }
}