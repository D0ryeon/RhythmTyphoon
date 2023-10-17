using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using EventPattern = Pattern.EventData;

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
    private Coroutine specialnoteSpawnCoroutine;

    public bool Pause = false;

    public void Awake()
    {
        _noteTiming = new List<float>();    
        _noteTiming.AddRange(pattern.noteTiming);
    }
    public void StartGame()
    {
        currentNoteIndex = 0;
        noteSpawnStopDuration = 0f;
        noteDirection = Vector2.left;

        if (_noteTiming.Count != 0)
        {
            StartNoteSpawnCoroutine();
        }
        if(pattern.Events.Count != 0)
        {
            StartNoteSpecialSpawnCoroutine();
        }
    }
    private IEnumerator SpecialNoteSpawnCoroutine()
    {
        int SpecialNoteLength = pattern.Events.Count;
        bool IsLastSpecialNoteSpawn = false;

        int CursorSpecialNote = 0;

        while (!IsLastSpecialNoteSpawn)
        {
            if (Pause)
            {
                yield return null; 
                continue; 
            }

            Debug.Log("SpecialNote : " + CursorSpecialNote);
            float SpecialnoteSpawnStopDuration = pattern.Events[CursorSpecialNote].indexTiming;
       
            yield return new WaitForSeconds(SpecialnoteSpawnStopDuration);

            CursorSpecialNote++;

            if (currentNoteIndex == SpecialNoteLength)
            {
                IsLastSpecialNoteSpawn = true;
            }

            GameObject obj = ObjectPool.GetTrapNote();
            if(obj==null)
            {
                Debug.Log("오브젝트 풀 널");
            }
            obj.SetActive(true);
            obj.transform.position = _noteSpawnPositon.position;
            TrapNote note = obj.GetComponent<TrapNote>();
            note.SetDirection(noteDirection * noteSpeed);
            Debug.Log(currentNoteIndex);
            note.lastNote = IsLastNoteSpawn;
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
            if (Pause)
            {
                yield return null;
                continue;
            }

            Debug.Log(currentNoteIndex);
            noteSpawnStopDuration = _noteTiming[currentNoteIndex];
            yield return new WaitForSeconds(noteSpawnStopDuration);

            currentNoteIndex++;

            if (currentNoteIndex == NoteLength)
            {
                IsLastNoteSpawn = true;
            }

            GameObject obj = ObjectPool.GetNote();
            if (obj == null)
            {
                Debug.Log("오브젝트 풀 널");
            }
            obj.SetActive(true);
            obj.transform.position = _noteSpawnPositon.position;
            Note note = obj.GetComponent<Note>();
            note.SetDirection(noteDirection * noteSpeed);
            Debug.Log(currentNoteIndex);
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
    public void StartNoteSpecialSpawnCoroutine()
    {
        specialnoteSpawnCoroutine = StartCoroutine(SpecialNoteSpawnCoroutine());
        if (noteSpawnCoroutine == null)
        {
            Debug.Log("코루틴 널");
        }
    }
    public void StopNoteSpecialSpawnCoroutine()
    {
        if (specialnoteSpawnCoroutine != null)
        {
            StopCoroutine(noteSpawnCoroutine);
        }
    }
    public void PauseCorutine()
    {
        Pause = true;
    }

    public void SetNoteTimin(List<float> noteTiming) => _noteTiming = noteTiming;
    public void SetObjectPool(ObjectPool pool) => this.ObjectPool = pool;

}
