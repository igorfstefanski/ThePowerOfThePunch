using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] targets;
    public Transform[] points;
    readonly float START_SPAWN_SPEED = 2.5f;
    readonly float INCREASE_SPEED = 0.1f;
    float spawnSpeed;
    private float timer;
    bool isGamePaused;

    private void Awake()
    {
        GameManager.IncreaseSpawnSpeed += IncreaseSpawnSpeed;
        GameManager.Pause += Pause;
        PauseManager.UnPause += UnPause;
    }

    // Start is called before the first frame update
    void Start()
    {
        spawnSpeed = START_SPAWN_SPEED;
        UnPause();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGamePaused)
        {
            if (timer > spawnSpeed)
            {
                GameObject target = Instantiate(targets[Random.Range(0, 2)], points[Random.Range(0, 4)]);
                target.transform.localPosition = Vector3.zero;
                timer -= spawnSpeed;
            }
            timer += Time.deltaTime;
        }
    }

    public void IncreaseSpawnSpeed()
    {
        spawnSpeed -= INCREASE_SPEED;
    }

    public void Pause()
    {
        isGamePaused = true;
    }

    public void UnPause()
    {
        isGamePaused = false;
    }

    private void OnDestroy()
    {
        GameManager.IncreaseSpawnSpeed -= IncreaseSpawnSpeed;
        GameManager.Pause -= Pause;
        PauseManager.UnPause -= UnPause;
    }
}
