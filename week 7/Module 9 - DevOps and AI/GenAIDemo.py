# simple rag prompt pipeline simulation in python
# deepa nair - cognizant dot-net training

import math

# vector database simulation containing document text and mock embeddings
# we represent embeddings here simply as 2D vectors for demo calculations
vector_db = [
    {
        "content": "To configure git, use git config --global user.name and user.email.",
        "embedding": [0.12, 0.85]
    },
    {
        "content": "To containerize a web api, write a Dockerfile and compile it using docker build.",
        "embedding": [0.75, 0.22]
    },
    {
        "content": "RAG architecture stands for Retrieval-Augmented Generation using embeddings and vector lookups.",
        "embedding": [0.88, 0.91]
    }
]

# prompt template mapping
def generate_prompt(context, query):
    return f"""
System: Answer the question based solely on the provided context below.

Context: {context}

Question: {query}
Answer:
""".strip()

def calculate_cosine_similarity(vec1, vec2):
    dot_product = sum(v1 * v2 for v1, v2 in zip(vec1, vec2))
    magnitude1 = math.sqrt(sum(v ** 2 for v in vec1))
    magnitude2 = math.sqrt(sum(v ** 2 for v in vec2))
    return dot_product / (magnitude1 * magnitude2)

def query_rag_pipeline(user_query, query_embedding):
    print(f"User Query: {user_query}")
    
    # lookup matching document in vector DB based on cosine similarity
    best_doc = None
    max_similarity = -1
    
    for doc in vector_db:
        sim = calculate_cosine_similarity(query_embedding, doc["embedding"])
        if sim > max_similarity:
            max_similarity = sim
            best_doc = doc
            
    print(f"Top matching document found (Similarity: {max_similarity:.4f}):")
    print(f" -> \"{best_doc['content']}\"")
    
    # construct prompt passed to LLM
    prompt = generate_prompt(best_doc["content"], user_query)
    print("\n[LLM Prompt Generated]:")
    print(prompt)

if __name__ == '__main__':
    # mock query: how to build docker containers
    # target query embedding close to docker documentation [0.70, 0.25]
    query_text = "How do I build docker containers?"
    query_vector = [0.70, 0.25]
    
    query_rag_pipeline(query_text, query_vector)