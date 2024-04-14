using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalSpawner : MonoBehaviour {
    public GameObject goal;
    
    public float spawnRadius = 10f;
    private GameObject currentGoal;
    private GameObject pointer;

    void Start() {
       SpawnGoal();
       pointer = FindObjectOfType<GoalPointer>().gameObject;
    }

    public void SpawnGoal() {
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        Vector2 spawnPosition = (Vector2)transform.position + randomDirection * Random.Range(0f, spawnRadius);

        if(currentGoal != null) {
            Destroy(currentGoal);
        }

        Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

        currentGoal = Instantiate(goal, spawnPosition, randomRotation);
        pointer.GetComponent<GoalPointer>().currentGoal = currentGoal;
        
    }
}