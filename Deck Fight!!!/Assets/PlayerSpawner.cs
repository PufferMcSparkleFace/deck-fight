using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawner : MonoBehaviour
{

    public GameObject playerOne;
    // Start is called before the first frame update
    void Start()
    {
        var player1 = PlayerInput.Instantiate(prefab: playerOne, playerIndex: 0, controlScheme: "WASD", pairWithDevice: Keyboard.current);
        var player2 = PlayerInput.Instantiate(prefab: playerOne, playerIndex: 0, controlScheme: "Numpad", pairWithDevice: Keyboard.current);
        player1.transform.position = new Vector2(-5, -2.5f);
        player2.transform.position = new Vector2(5, -2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
