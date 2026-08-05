# Registro rischi

| Rischio | Impatto | Mitigazione |
|---|---:|---|
| Modello locale produce piano errato | Alto | structured output, validazione e review |
| Esfiltrazione codice | Critico | privacy gate, redazione, approval |
| Comando distruttivo | Critico | allow-list, worktree, approval |
| Modello gratuito instabile | Medio | catalogo dinamico, retry limitati |
| Costi incontrollati | Alto | budget, stima, approval |
| Prompt injection | Alto | dati non attendibili, policy fuori dal prompt |
| Workflow non riprendibile | Alto | checkpoint e idempotenza |
| Contesto troppo grande/lento | Medio | task piccoli, 32K default, 64K selettivo |
| Reviewer conferma il proprio codice | Medio | sessione indipendente e quality gate deterministici |
| API provider cambia | Medio | adapter, contract test, catalog refresh |
