# Autonomous runner state

| Campo | Valore |
|---|---|
| Project status | Ready |
| Current task | Auto-detect |
| Current phase | Idle |
| Attempt | 0 |
| Baseline commit | Auto-detect |
| Last approved commit | Auto-detect |
| Last update | Not started |
| Block reason | None |

## Regole di aggiornamento

- Aggiornare questo file prima e dopo ogni fase significativa.
- Non cancellare un blocco senza averne registrato la risoluzione.
- In caso di crash, `/resume-project` riconcilia questo stato con Git e i report sotto `runs/`.
