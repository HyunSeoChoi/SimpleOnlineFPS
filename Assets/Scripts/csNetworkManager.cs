using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SocketIO;

public class csNetworkManager : MonoBehaviour {

    static public csNetworkManager instance;
    public Canvas canvas;
    public SocketIOComponent socket;
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

    public void Start()
    {
        socket.On("enemies", OnEnemies);
        socket.On("other player connected", OnOtherPlayerConnected);
        socket.On("play", OnPlay);
        socket.On("player move", OnPlayerMove);
        socket.On("player turn", OnPlayerTurn);
        socket.On("player shoot", OnPlayerShoot);
        socket.On("health", OnHealth);
        socket.On("other player disconnected", OnOtherPlayerDisconnected);
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

    void OnEnemies(SocketIOEvent socketIOEvent)
    {

    }

    void OnOtherPlayerConnected(SocketIOEvent socketIOEvent)
    {

    }

    void OnPlay(SocketIOEvent socketIOEvent)
    {

    }

    void OnPlayerMove(SocketIOEvent socketIOEvent)
    {

    }

    void OnPlayerTurn(SocketIOEvent socketIOEvent)
    {

    }

    void OnPlayerShoot(SocketIOEvent socketIOEvent)
    {

    }

    void OnHealth(SocketIOEvent socketIOEvent)
    {

    }

    void OnOtherPlayerDisconnected(SocketIOEvent socketIOEvent)
    {

    }

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
