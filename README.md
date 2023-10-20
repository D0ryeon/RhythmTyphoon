# RhythmTyphoon
 
1. BattleSceneCreativeScene 에서 노트 패턴 기록, 노트패턴은 ScriptableObject와 Struct 활용
2. BattleScene에서 BattleSceneManager가 저장된 int StageNumber에 따라 노트 출력
3. 노트의 판정은 Collider를 SetActive를 사용해서 구현.
4. 노트의 소환에는 오브젝트풀 적용, 노트 사이 간격은 코루틴을 활용, NoteSpawnManger에 존재.
5. NoteSpawnManger에서 노트 패턴에 저장된 int type에 따라 다른 노트 활성화, 현재는 일반 노트, 건드리면 체력이 깎이는 노트 2가지 뿐이지만 확장 가능
