using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject doorGo;
    [SerializeField] Player player;
    int coinsNeeded = 16;
    [SerializeField]
    private CameraShaker shaker;

    [SerializeField] Cinemachine.CinemachineBrain cb;
    [SerializeField] Cinemachine.CinemachineVirtualCamera c1;
    [SerializeField] Cinemachine.CinemachineVirtualCamera c2;
    [SerializeField] Cinemachine.CinemachineVirtualCamera c3;
    private void Start()
    {
        player.onCoinCollected += ReduceCoinsNeeded;
        player.onDiamondCollected += Win;

    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.C))
            ChangeCameras();
    }

    void ReduceCoinsNeeded()
    {
        shaker.Shake();
        coinsNeeded--;
        if (coinsNeeded <= 0)
            GameObject.Destroy(doorGo.gameObject);

    }
    void Win() {

        SceneManager.LoadScene("Menu");
    }


    void ChangeCameras() {

        cb.ActiveVirtualCamera.Priority = 0;

        if (c1.Priority == 0 && c2.Priority == 0 && c3.Priority == 0) {
            c1.Priority = 13;
            c2.Priority = 12;
            c3.Priority = 11;

        }
    }
}
