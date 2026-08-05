# Osservabilità

## Correlation

Ogni richiesta usa:

- WorkRequestId;
- TaskId;
- AttemptId;
- TraceId.

## Traces

Span principali:

- plan;
- route-model;
- provider-call;
- tool-call;
- build;
- test;
- review;
- checkpoint;
- approval.

## Metrics

- task completati/falliti;
- tentativi per task;
- token input/output;
- costo;
- time-to-first-token se disponibile;
- durata prefill/provider call;
- build/test duration;
- escalation rate;
- approval latency.

## Logging

Log strutturati, redazione segreti e limite dimensionale degli output.
