using UnityEngine;

interface IIinteractable
{
    /// <summary>
    /// Interact with the object.
    /// </summary>
    public void OnInteraction(GameObject player);
    public string GetName();
}