using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private LayerMask cubeFilter;


    private void FixedUpdate()
    {

        // Debug.DrawLine(playerCamera.transform.position, playerCamera.transform.forward * 10);
        // RaycastHit hit;

        // // origin -> direction -> output variable -> max distance
        // if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, 10, cubeFilter.value))
        // {
        //     if (hit.collider.TryGetComponent(out Renderer renderer))
        //     {
        //         renderer.material.color = Color.red;
        //     }
        // }
    }
}
