# Tassonomia sintetica dei failure .NET

## Restore

Segnali: NUxxxx, feed, lock file, incompatibilità TFM/package. Verificare sorgenti, package effettivamente risolti e assets file.

## MSBuild evaluation

Segnali: proprietà/item condizionali, target non eseguiti, framework/configurazione errati. Usare `-getProperty`, `-getItem` e binary log.

## C# binding/compile

Segnali: CSxxxx. Verificare simbolo, namespace, reference assembly, tipo effettivo e overload. Non correggere con cast o `dynamic` senza root cause.

## Analyzer

Segnali: CAxxxx, VSTHRDxxx o analyzer custom. Correggere il comportamento; sopprimere solo con motivazione specifica e review.

## Test discovery/runtime

Build verde ma test assenti o crash. Distinguere adapter, discovery, host, dipendenza runtime e test failure.

## Incremental/stale output

Confrontare una build normale con `--no-incremental`. Non usare pulizia globale come spiegazione permanente.
