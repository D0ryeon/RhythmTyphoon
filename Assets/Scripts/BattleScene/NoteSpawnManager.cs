using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _notePrefab;
    [SerializeField] private GameObject _trapNotePrefab;
    [SerializeField] private float[] _noteTiming;
    [SerializeField] private int[] TrapNoteIndex;

    private int currentNoteIndex;
    private float noteSpawnStopDuration;

    [SerializeField] Transform _noteSpawnPositon;

    public bool IsLastNoteSpawn;
    public float noteSpeed;
    public Vector2 noteDirection;

    [SerializeField] private UIManager UIManager;

    private Coroutine noteSpawnCoroutine;

    public void StartGame()
    {
        currentNoteIndex = 0;
        noteSpawnStopDuration = 0f;
        noteDirection = Vector2.left * 3;
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
        int CursorTrapNoteIndex = 0;
        int IndexTrapNote = TrapNoteIndex[CursorTrapNoteIndex];
        while (!IsLastNoteSpawn)
        {
            noteSpawnStopDuration = _noteTiming[currentNoteIndex];
            currentNoteIndex++;
            if(currentNoteIndex == NoteLength)
            {
                IsLastNoteSpawn = true;
            }
            if (currentNoteIndex == IndexTrapNote)
            {
                GameObject obj = Instantiate(_trapNotePrefab, _noteSpawnPositon.position, Quaternion.identity);
                TrapNote trapNote = obj.GetComponent<TrapNote>();
                trapNote.lastNote = IsLastNoteSpawn;
                trapNote.SetUIManager(UIManager);
                trapNote.SetDirection(noteDirection* noteSpeed);
                CursorTrapNoteIndex++;
                IndexTrapNote = TrapNoteIndex[CursorTrapNoteIndex];
            }
            else
            {
                GameObject obj = Instantiate(_notePrefab, _noteSpawnPositon.position, Quaternion.identity);
                Note note = obj.GetComponent<Note>();
                note.SetUIManager(UIManager);
                note.SetDirection(noteDirection * noteSpeed);
                note.lastNote = IsLastNoteSpawn;
            }
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

    public void SetNoteTimin(float[] noteTiming) => _noteTiming = noteTiming;

}
