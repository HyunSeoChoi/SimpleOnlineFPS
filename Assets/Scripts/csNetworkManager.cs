using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class csNetworkManager : MonoBehaviour {

    static public csNetworkManager instance;
    public Canvas canvas;
    // public socketIOComponent socket;
    public InputField playerNameInput;
    public GameObject player;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else if(instance != this)
        {
            Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
        }
    }

    public void JoinGame()
    {
        StartCoroutine(ConnectToServer());
    }

    #region Comands

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

        public PlayerJSON(string _name, List<csSpawnPoint> _playerSpawnPoints, List<csSpawnPoint> _enemySpawnPoints)
        {
            playerSpawnPoints = new List<PointJSON>();
            enemySpawnPoints = new List<PointJSON>();

            name = _name;

            foreach(csSpawnPoint playerSpawnPoint in _playerSpawnPoints)
            {
                PointJSON pointJSON = new PointJSON(playerSpawnPoint);
                playerSpawnPoints.Add(pointJSON);
            }

            foreach (csSpawnPoint enemySpawnPoint in _enemySpawnPoints)
            {
                PointJSON pointJSON = new PointJSON(enemySpawnPoint);
                enemySpawnPoints.Add(pointJSON);
            }
        }
    }
    [SerializeField]
    public class PointJSON
    {
        public PointJSON(csSpawnPoint spawnPoint)
        {

        }
    }

    #endregion
}
