using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNoteSpawn : MonoBehaviour
{
    public Pattern pattern;

    [SerializeField] private GameObject _notePrefab;

    public List<float> _noteTiming;

    private int currentNoteIndex;
    private float noteSpawnStopDuration;

    [SerializeField] Transform _noteSpawnPositon;

    public bool IsLastNoteSpawn;
    public float noteSpeed;
    public Vector2 noteDirection;

    [SerializeField] private ObjectPool ObjectPool;

    private Coroutine noteSpawnCoroutine;

    public void StartGame()
    {
        _noteTiming = new List<float>(pattern.noteTiming);

        currentNoteIndex = 0;
        noteSpawnStopDuration = 0f;
        noteDirection = Vector2.left;
        if (_noteTiming.Count != 0)
        {
            StartNoteSpawnCoroutine();
        }
    }
    private IEnumerator NoteSpawnCoroutine()
    {
        int NoteLength = _noteTiming.Count;
        
        Debug.Log(3);
        yield return new WaitForSeconds(1.0f);
        Debug.Log(2);
        yield return new WaitForSeconds(1.0f);
        Debug.Log(1);
        yield return new WaitForSeconds(1.0f);

        while (!IsLastNoteSpawn)
        {
            noteSpawnStopDuration = _noteTiming[currentNoteIndex];
            yield return new WaitForSeconds(noteSpawnStopDuration);

            currentNoteIndex++;

            if (currentNoteIndex == NoteLength)
            {
                IsLastNoteSpawn = true;
            }

            GameObject obj = ObjectPool.GetNote();
            if(obj==null)
            {
                Debug.Log("오브젝트 풀 널");
            }
            obj.SetActive(true);
            obj.transform.position = _noteSpawnPositon.position;
            Note note = obj.GetComponent<Note>();
            note.SetDirection(noteDirection * noteSpeed);
            note.lastNote = IsLastNoteSpawn;
        }
    }

    public void SetNoteTiming(List<float> noteTiming)
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
       if(noteSpawnCoroutine == null)
       {
            Debug.Log("코루틴 널");
       }
    }
    public void StopNoteSpawnCoroutine()
    {
        if (noteSpawnCoroutine != null)
        {
            StopCoroutine(noteSpawnCoroutine);
        }
    }

    public void SetNoteTimin(List<float> noteTiming) => _noteTiming = noteTiming;
    public void SetObjectPool(ObjectPool pool) => this.ObjectPool = pool;

}
