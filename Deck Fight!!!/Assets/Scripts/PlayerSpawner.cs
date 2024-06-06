using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawner : MonoBehaviour
{

    public GameObject player;
    public GameObject playerOne;
    public GameObject playerTwo;
    // Start is called before the first frame update
    void Start()
    {
        var player1 = PlayerInput.Instantiate(prefab: player, playerIndex: 0, controlScheme: "WASD", pairWithDevice: Keyboard.current);
        var player2 = PlayerInput.Instantiate(prefab: player, playerIndex: 0, controlScheme: "Numpad", pairWithDevice: Keyboard.current);
        player1.transform.position = new Vector2(-5, -2.5f);
        player2.transform.position = new Vector2(5, -2.5f);
        
    }

    private void Update()
    {
        if(playerOne == null)
        {
            playerOne = GameObject.FindGameObjectWithTag("Player 1");
        }
        if(playerTwo == null)
        {
            playerTwo = GameObject.FindGameObjectWithTag("Player 2");
        }

        this.transform.position = 0.5f*(playerOne.transform.position + playerTwo.transform.position);
        
    }
}
