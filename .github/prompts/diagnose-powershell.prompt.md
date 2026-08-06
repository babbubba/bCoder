---
name: diagnose-powershell
description: Diagnostica un comando o script PowerShell in sola lettura.
agent: PowerShell Diagnostician
argument-hint: target=<script o comando> error=<messaggio>
---

Diagnostica `${input:target}` con errore `${input:error}`.

Identifica shell/versione, riproduci senza processi PowerShell annidati, esegui parser/analyzer quando possibile e restituisci la correzione minima. Non modificare file.
