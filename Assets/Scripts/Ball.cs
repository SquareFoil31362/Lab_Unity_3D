using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball: MonoBehaviour
{
    private Transform _respawnPoint;
    public string nextLevelName = "Level_2";

    // Start is called before the first frame update
    void Start()
    {
        _respawnPoint = GameObject.Find("BallRespawnPoint").transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Death"))
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true; 
            transform.position = _respawnPoint.position;
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
        else if (other.gameObject.CompareTag($"Goal")) {
            SceneManager.LoadScene(nextLevelName);
        }
    }

}
