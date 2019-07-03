using UnityEngine;

// Keeps track of if something is on the node
// user input, and building something on top of it.
public class Node : MonoBehaviour
{

    [SerializeField] Color hoverColor;
    [SerializeField] Vector3 postionOffset;

    private GameObject turret;

    private Renderer rend;
    private Color startColor;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    // Unity callbacks
    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    private void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("Can't build here");
            return;
        }

        GameObject turretTobuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretTobuild, transform.position + postionOffset, transform.rotation);
    }
}
