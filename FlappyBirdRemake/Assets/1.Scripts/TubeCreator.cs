using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeCreator : MonoBehaviour
{
    [SerializeField] private Tube TubePrefabs;
    private List<Tube> TubeList;
    IEnumerator ICreator;
    private void Start()
    {
        GameManager.Instance.OnStartGame += StartGame;
    }
    private void OnDestroy()
    {
        GameManager.Instance.OnStartGame -= StartGame;

    }


    public void StartGame()
    {
        ICreator = IDelayCreateTube();
        StartCoroutine(ICreator);
    }

    IEnumerator IDelayCreateTube()
    {

    }

}
