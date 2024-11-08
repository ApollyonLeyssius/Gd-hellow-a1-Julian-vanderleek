using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beweegopbject : MonoBehaviour
{
    public float speed = 3f; // De snelheid van de NPC
    public Vector3 areaSize = new Vector3(10f, 0f, 10f); // Het gebied waarin de NPC mag bewegen
    private Vector3 targetPosition;

    void Start()
    {
        // Stel een willekeurige startpositie in
        SetRandomTargetPosition();
    }

    void Update()
    {
        // Beweeg de NPC naar de doelpositie
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Controleer of de NPC het doel heeft bereikt
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            SetRandomTargetPosition();
        }
    }

    void SetRandomTargetPosition()
    {
        // Kies een nieuwe, willekeurige doelpositie binnen het gebied
        float randomX = Random.Range(-areaSize.x / 2, areaSize.x / 2);
        float randomZ = Random.Range(-areaSize.z / 2, areaSize.z / 2);
        targetPosition = new Vector3(randomX, transform.position.y, randomZ);
    }
}