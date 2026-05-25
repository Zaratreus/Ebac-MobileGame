using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform container;

    public List<GameObject> levels;

    public ArtManager.ArtType artType;

    [Header("Pieces")]
    public List<LevelPieceBase> levelPiecesStart;
    public List<LevelPieceBase> levelPieces;
    public List<LevelPieceBase> levelPiecesEnd;
    public int piecesStartNumber = 3;
    public int piecesNumber = 5;
    public int piecesEndNumber = 1;
    public float timeBetweenPieces = .3f;

    [SerializeField] private int _index;

    private GameObject currentLevel;

    private List<LevelPieceBase> _spawnedPieces = new List<LevelPieceBase>();

    private void Awake()
    {
        //SpawnNextLevel();
        CreateLevelPieces();
    }

    private void SpawnNextLevel()
    {
        if (currentLevel != null)
        {
            Destroy(currentLevel);
            _index++;

            if (_index >= levels.Count)
            {
                ResetLevelIndex();
            }
        }

        currentLevel = Instantiate(levels[_index], container);
        currentLevel.transform.localPosition = Vector3.zero;
    }

    private void ResetLevelIndex()
    {
        _index = 0;
    }

    private void CreateLevelPieces()
    {
        CleanSpawnedePieces();

        for (int i = 0; i < piecesStartNumber; i++)
        {
            CreateLevelPiece(levelPiecesStart);
        }

        for (int i = 0; i < piecesNumber; i++)
        {
            CreateLevelPiece(levelPieces);
        }
        for (int i = 0; i < piecesEndNumber; i++)
        {
            CreateLevelPiece(levelPiecesEnd);
        }

        ColorManager.Instance.ChangeColorByType(artType);

    }

    private void CreateLevelPiece(List<LevelPieceBase> list)
    {
        var piece = list[Random.Range(0, list.Count)];
        var SpawnedPiece = Instantiate(piece, container);

        if(_spawnedPieces.Count > 0)
        {
            var lastPiece = _spawnedPieces[_spawnedPieces.Count - 1];

            SpawnedPiece.transform.position = lastPiece.endPiece.position;
        }
        foreach(var p in SpawnedPiece.GetComponentsInChildren<ArtPiece>())
        {
            p.ChangePiece(ArtManager.Instance.GetSetupByType(artType).gameObject);
        }

        _spawnedPieces.Add(SpawnedPiece);

    }

    private void CleanSpawnedePieces()
    {
        for(int i = _spawnedPieces.Count; i > 0; i--)
        {
            Destroy(_spawnedPieces[i].gameObject);
        }

        _spawnedPieces.Clear();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            SpawnNextLevel();
        }

    }
}
