using UnityEngine;
using UnityEngine.EventSystems;

// Keeps track of if something is on the node
// user input, and building something on top of it.
public class Node : MonoBehaviour
{

    [SerializeField] Color hoverColor;
    [SerializeField] Vector3 postionOffset;

    private GameObject turret;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    // Unity callbacks
    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (buildManager.GetTurretToBuild() == null)
        {
            // if we don't have a turret to build we don't highlight the node
            return;
        }
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (buildManager.GetTurretToBuild() == null)
        {
            return;
        }

        if (turret != null)
        {
            Debug.Log("Can't build here");
            return;
        }

        GameObject turretTobuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretTobuild, transform.position + postionOffset, transform.rotation);
    }
}
