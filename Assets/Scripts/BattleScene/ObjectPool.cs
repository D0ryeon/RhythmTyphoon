using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject NotePrefab;
    private Queue<GameObject> NotePool;
    public int NotePoolSize;

    [SerializeField] private GameObject TrapNotePrefab;
    private Queue<GameObject> TrapNotePool;
    public int TrapNotePoolSize;

    [SerializeField] private GameObject[] SpecialNotePrefab;
    private Queue<GameObject> SpecialTrapNotePool;
    public int SpecialTrapNotePoolSize;

    void Start()
    {
        NotePool = new Queue<GameObject>();
        for (int i = 0; i < NotePoolSize; i++)
        {
            GameObject note = Instantiate(NotePrefab);
            note.SetActive(false);
            NotePool.Enqueue(note);
        }
        TrapNotePool = new Queue<GameObject>();
        for (int i = 0; i < TrapNotePoolSize; i++)
        {
            GameObject trapNote = Instantiate(TrapNotePrefab);
            trapNote.SetActive(false);
            TrapNotePool.Enqueue(trapNote);
        }
    }

    public GameObject GetNote()
    {
        GameObject note = NotePool.Dequeue();
        NotePool.Enqueue(note);
        return note;
    }

    public GameObject GetTrapNote()
    {
        GameObject TrapNote = TrapNotePool.Dequeue();
        TrapNotePool.Enqueue(TrapNote);
        return TrapNote;
    }

}
