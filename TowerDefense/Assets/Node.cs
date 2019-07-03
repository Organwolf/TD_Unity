using UnityEngine;

// Keeps track of if something is on the node
// user input, and building something on top of it.
public class Node : MonoBehaviour
{

    [SerializeField] Color hoverColor;

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
}
