using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NoteSpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] NotePrefabs;
    [SerializeField] private ObjectPool objectPool;

    [SerializeField] private Transform NoteSpawnPosition;
    public Pattern InputPattern;
    private Coroutine coroutine;
    private UIManager UIManager;
    public Vector3 direction;

    private bool Pause;

    public void SetPattern(Pattern pattern)
    {
        InputPattern.Notes = new List<Pattern.Note>(pattern.Notes.Select(note => new Pattern.Note { time = note.time, type = note.type }));
    }

    public void StartNoteSpawn(float sink)
    {
        if(coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }
        coroutine = StartCoroutine(NoteSpawnCoroutine(sink));
    }

    public void StopNoteSpawn()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
    }
    IEnumerator NoteSpawnCoroutine(float sink)
    {

        yield return new WaitForSeconds(sink);

        float cuTime = 0;
        int Length = InputPattern.Notes.Count;
        for (int i = 0; i < Length; i++)
        {
            while(Pause)
            {
                yield return null;
            }

            float nextTime = InputPattern.Notes[i].time;
            float duration= nextTime - cuTime;
            cuTime = nextTime;
            int type = InputPattern.Notes[i].type;

            GameObject obj = objectPool.GetNoteUseType(type);
            obj.SetActive(true);
            obj.transform.position = NoteSpawnPosition.position;
            NoteBasic noteBasic= obj.GetComponent<NoteBasic>();
            noteBasic.SetDirection(direction);
            noteBasic.SetUIManager(UIManager);

            if(i== Length - 1)
            {
                noteBasic.lastNote = true;
            }

            yield return new WaitForSeconds(duration);
        }
    }

    public void SetUIManager(UIManager manager) => UIManager = manager;

    public void SetDirection(Vector3 direction) => this.direction = direction;

    public void SetPause(bool state) => Pause = state;

    public void SetObjectPool(ObjectPool objectPool) => this.objectPool = objectPool;
}
