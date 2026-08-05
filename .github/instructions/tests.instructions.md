---
name: Test standards
description: Regole per test unitari, integrazione ed end-to-end.
applyTo: "tests/**/*"
---

- Test deterministici e indipendenti.
- Nomi `Method_Scenario_ExpectedResult`.
- Nessuna dipendenza da provider LLM reali nei test unitari.
- Usa fake HTTP server o test double per DS4/OpenRouter.
- Verifica cancellation, timeout, retry e redazione segreti.
- I test di integrazione devono pulire le proprie risorse.
