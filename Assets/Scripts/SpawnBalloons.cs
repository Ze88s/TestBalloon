using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBalloons : MonoBehaviour
{
    public GameObject[] ballon;
    public GameObject inst_balloon;
    
    // Start is called before the first frame update
    public float TimeSpawn=0.5f;
    public float speed_ball=3;
    void Start()
    {
        StartCoroutine (spawnBalloon());
    }


        IEnumerator  spawnBalloon() {
		while (true) {
			//то что будет выполняться через 1,5 секунды времени	

		inst_balloon = Instantiate (getBalloon(), new Vector3 (Random.Range(-3.5f,3.5f), -2, 3), Quaternion.identity) as GameObject;
            inst_balloon.GetComponent<Balloon>().setSpeed(speed_ball);
            speed_ball+=0.03f;//добавляем скорость шарикам
			yield return new WaitForSeconds (TimeSpawn);
		}
	}


      GameObject getBalloon()
      {
          return ballon[Random.Range(0,ballon.Length)];
      }

    // Update is called once per frame
    void Update()
    {
        
    }
}
