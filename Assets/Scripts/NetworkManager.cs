﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviour
{
    public static NetworkManager instance;
    public Canvas canvas;
    //public SocketIOComponent socket;
    public InputField playerNameInput;
    public GameObject player;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else if(instance !=this)
        {
            Destroy(gameObject);
          
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
                
    }

    public void JoinGame()
    {
        StartCoroutine(ConnectToServer());
    }

    #region Commands

    IEnumerator ConnectToServer()
    {
        yield return new WaitForSeconds(0.5f);
    }

    #endregion

    #region Listening

    #endregion

    #region JSONMessageClasses
    [SerializeField]
    public class PlayerJSON
    {
        public string name;
        public List<PointJSON> playerSpawnPoints;
        public List<PointJSON> enemySpawnPoints;

        public PlayerJSON(string _name, List<SpawnPoint> _playerSpawnPoints, List<SpawnPoint> _enemySpawnPoints)
        {
            playerSpawnPoints = new List<PointJSON>();
            enemySpawnPoints = new List<PointJSON>();
            name = _name;

            foreach(SpawnPoint playerSpawnPoint in _playerSpawnPoints)
            {
                PointJSON pointJSON = new PointJSON(playerSpawnPoint);
                playerSpawnPoints.Add(pointJSON);
            }
            foreach (SpawnPoint enemySpawnPoint in _enemySpawnPoints)
            {
                PointJSON pointJSON = new PointJSON(enemySpawnPoint);
                playerSpawnPoints.Add(pointJSON);
            }
        }
    }

    [SerializeField]
    public class PointJSON
    {
        public float[] position;
        public float[] rotation;
        public PointJSON(SpawnPoint spawnPoint)
        {
            position = new float[] {
                spawnPoint.transform.position.x,
                spawnPoint.transform.position.y,
                spawnPoint.transform.position.z
            };

            rotation = new float[] {
                spawnPoint.transform.eulerAngles.x,
                spawnPoint.transform.eulerAngles.y,
                spawnPoint.transform.eulerAngles.z
            };
        }
    }
    [SerializeField]
    public class PositionJSON
    {
        public float[] position;

        public PositionJSON(Vector3 _position)
        {
            position = new float[] { _position.x, _position.y, _position.z };
        }
    }

    [SerializeField]
    public class RotationJSON
    {
        public float[] rotation;

        public RotationJSON(Quaternion _rotation)
        {
            rotation = new float[] { _rotation.x, _rotation.y, _rotation.z };
        }
    }

    [SerializeField]
    public class UserJSON
    {
        public string name;
        public float[] position;
        public float[] rotation;
        public int health;

        public static UserJSON CreateFromJSON(string data)
        {
            return JsonUtility.FromJson<UserJSON>(data);
        }
        
    }

    [SerializeField]
    public class HealthChangeJSON
    {
        public string name;
        public int healthChange;
        public string from;
        public bool isEnemy;

        public HealthChangeJSON(string _name, int _healthChange, string _from, bool _isEnemy)
        {
            name = _name;
            healthChange = _healthChange;
            from = _from;
            isEnemy = _isEnemy;
        }
    }

    [SerializeField]
    public class EnemiesJSON
    {
        public List<UserJSON> enemies;

        public static EnemiesJSON CreateFromJSON(string data)
        {
            return JsonUtility.FromJson<EnemiesJSON>(data);
        }
    }

    [SerializeField]
    public class ShootJSON
    {
        public string name;

        public static ShootJSON CreateFromJSON(string data)
        {
            return JsonUtility.FromJson<ShootJSON>(data);
        }
    }

    [SerializeField]
    public class UserHealthJSON
    {
        public string name;
        public int health;

        public static UserHealthJSON CreateFromJSON(string data)
        {
            return JsonUtility.FromJson<UserHealthJSON>(data);
        }
    }
    #endregion
}
