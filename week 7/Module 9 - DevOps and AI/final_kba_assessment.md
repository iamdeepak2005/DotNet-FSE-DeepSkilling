# KBA Final Assessment Review

This assessment review compiles crucial conceptual answers for the .NET Full Stack Track.

## 1. Database Transactions (ACID Rules)
* **Atomicity**: Either all operations succeed or all rollback. In SQL, managed via `BEGIN TRANSACTION`, `COMMIT`, and `ROLLBACK`.
* **Consistency**: DB state changes strictly according to defined database schema schemas (constraints, indexes, foreign keys).
* **Isolation**: Concurrent transactions execute independently. Controlled using isolation levels (e.g. `READ COMMITTED`, `SERIALIZABLE`).
* **Durability**: Committed data remains stored in log files even during crashes.

## 2. REST vs SOAP
* **REST**: Representational State Transfer. Uses stateless HTTP verbs (GET, POST, etc.), lightweight data formats (JSON), and is scalable.
* **SOAP**: Simple Object Access Protocol. XML-based contract protocol requiring strict definitions (WSDL) and is heavier.

## 3. Microservices vs Monoliths
* **Monolithic**: Single unit containing all features. Easy to develop initial states, but deployment scaling is complex.
* **Microservices**: Independent service databases communicating via REST, gRPC, or messaging brokers (Kafka). Highly scalable, but introduces distributed transactions.

## 4. Docker Volumes & Networks
* **Volumes**: Mount paths on host to keep database records persistent even when container instances are removed.
* **Networks**: Bridge virtual nets allowing multiple containers to locate and communicate using hostnames (e.g. webapi calls database).

## 5. RAG (Retrieval-Augmented Generation)
* Augments LLMs by querying custom embeddings vectors from Vector databases (e.g. Pinecone) to inject local knowledge as prompt context before querying.