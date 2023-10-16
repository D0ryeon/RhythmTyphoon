using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _notePrefab;
    [SerializeField] private float[] _noteTiming;

    private int currentNoteIndex;
    private float noteSpawnStopDuration;

    [SerializeField] Transform _noteSpawnPositon;

    public bool IsLastNoteSpawn;

    private Vector2 noteDirection;

    [SerializeField] private UIManager UIManager;

    private Coroutine noteSpawnCoroutine;


    public void Awake()
    {
        currentNoteIndex = 0;
        noteSpawnStopDuration = 0f;
        noteDirection = Vector2.left  * 3;
        StartNoteSpawnCoroutine();
    }

    private IEnumerator NoteSpawnCoroutine()
    {
        UIManager.UpdateStartCount(3);
        yield return new WaitForSeconds(1.0f);
        UIManager.UpdateStartCount(2);
        yield return new WaitForSeconds(1.0f);
        UIManager.UpdateStartCount(1);
        yield return new WaitForSeconds(1.0f);
        UIManager.UpdateStartCount(-1);
        int NoteLength = _noteTiming.Length;
        while (!IsLastNoteSpawn)
        {
            noteSpawnStopDuration = _noteTiming[currentNoteIndex];
            currentNoteIndex++;
            if(currentNoteIndex == NoteLength)
            {
                IsLastNoteSpawn = true;
            }
            GameObject obj = Instantiate(_notePrefab, _noteSpawnPositon.position, Quaternion.identity);
            Note note = obj.GetComponent<Note>();
            note.SetUIManager(UIManager);
            note.InitializeDirection(noteDirection);
            note.lastNote = IsLastNoteSpawn;
            yield return new WaitForSeconds(noteSpawnStopDuration);
        }
    }

    public void SetNoteTiming(float[] noteTiming)
    {
        _noteTiming = noteTiming;
    }
    public void SetDirction(Vector2 direction)
    {
        noteDirection = direction;
    }
    public void StartNoteSpawnCoroutine()
    {
        noteSpawnCoroutine = StartCoroutine(NoteSpawnCoroutine());
    }
    public void StopNoteSpawnCoroutine()
    {
        if (noteSpawnCoroutine != null)
        {
            StopCoroutine(noteSpawnCoroutine);
        }
    }

    public void SetUIManager(UIManager uiManager) => this.UIManager = uiManager;
}
