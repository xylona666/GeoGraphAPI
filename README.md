# GeoGraphAPI pipeline
Using C# and Azure to build a API which could response a shortest path from our current location to destination(input)

# Structure

- Client
   ↓
- Controller Layer (API Routing)
  Handles HTTP routing, request validation, and response formatting.
   ↓
- Business Logic Layer (Service)
  Contains business logic (BFS shortest path algorithm).
   ↓
- Domain Layer (Graph) / Infrastructure Layer (future DB integration)
  Represents the graph structure of country borders (in-memory adjacency list) because the data provided is few and fixed.
  i leave some space for extension , If countries/borders are maintained dynamically in the future, I will put the graph data into Azure SQL/Cosmos DB and cache it (Redis).  
  **trade off**
  small fixed data → in-memory；
  dynamic data → DB + cache
   ↓
- Test
  **Unit tests**
  
  BFS shortest path correctness
  Input validation
  Edge cases (same source/destination, invalid codes)
  
  **Integration tests**
  
  Check if the JSON complies with the contract
  ↓
- Deploy
Deploy to Azure and provide an accessible URL






  
 
