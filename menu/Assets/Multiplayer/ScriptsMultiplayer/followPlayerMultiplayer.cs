using UnityEngine;
using System.Collections;

public class followPlayerMultiplayer : MonoBehaviour
{

    public GameObject player;       //reference to player


    private Vector3 offset;         


    void Start()
    {
        //Berechnen und speichern Sie des Offsets, indem man den Abstand zwischen der Position des Spielers und der Kameraposition ermittelt.
         offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {

        // Stelle die Position der Kamera so ein, dass sie der des Spielers entspricht, aber um den berechneten Abstand versetzt ist.
        transform.position = player.transform.position + offset;
    }
}