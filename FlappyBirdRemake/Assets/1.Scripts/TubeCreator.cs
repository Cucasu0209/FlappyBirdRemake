using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TubeCreator : MonoBehaviour
{
    [SerializeField] private Tube TubePrefabs;
    private List<Tube> TubeList = new List<Tube>();
    [SerializeField] private float DistanceEachCreating = 250;
    IEnumerator ICreator;

    private bool IsGameRunning = false;
    private void Start()
    {
        GameManager.Instance.OnStartGame += StartGame;
        GameManager.Instance.OnRestartGame += RestartGame;
        GameManager.Instance.OnEndGame += OnEndGame;
    }
    private void OnDestroy()
    {
        GameManager.Instance.OnStartGame -= StartGame;
        GameManager.Instance.OnRestartGame -= RestartGame;
        GameManager.Instance.OnEndGame -= OnEndGame;
    }


    public void StartGame()
    {
        IsGameRunning = true;
        ICreator = IDelayCreateTube();
        StartCoroutine(ICreator);
    }

    public void RestartGame()
    {

        foreach (var tube in TubeList)
        {
            if (tube != null)
            {

                Destroy(tube.gameObject);

            }

        }
        TubeList = TubeList.Where(t => t != null).ToList();

    }
    public void OnEndGame()
    {
        StopCoroutine(ICreator);
        IsGameRunning = false;
    }

    IEnumerator IDelayCreateTube()
    {
        while (true)
        {
            Debug.Log("???");
            Tube newTube = Instantiate(TubePrefabs, transform);
            newTube.GetComponent<RectTransform>().anchoredPosition = new Vector2(650, Random.Range(-100, 100));
            TubeList.Add(newTube);


            yield return new WaitForSeconds(DistanceEachCreating / GameManager.Instance.GameSpeed);

        }
    }

    private void Update()
    {
        if (IsGameRunning)
        {
            TubeList = TubeList.Where(t => t != null).ToList();

            foreach (var tube in TubeList)
            {
                if (tube != null)
                {
                    if (tube.GetComponent<RectTransform>().anchoredPosition.x < -600)
                    {
                        Destroy(tube.gameObject);
                    }
                    tube.GetComponent<RectTransform>().anchoredPosition -= GameManager.Instance.GameSpeed * Vector2.right * Time.deltaTime;
                }

            }

        }

    }

}
