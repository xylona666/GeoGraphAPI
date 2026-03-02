# 🌍GeoGraphAPIA 
A cloud-native REST API built with C# (.NET) and Azure App Service that computes the shortest path between countries using the BFS algorithm.
## Demo

curl https://geograph-c9bpd6ewhbf5b6d5.canadacentral-01.azurewebsites.net/{code}
Input: 3-letter uppercase country code (ISO-like format)

Output: Shortest path from source to destination in JSON

# Structure 

- Client
   
- Controller Layer (API Routing)
  Handles HTTP routing, request validation, and response formatting.
   
- Business Logic Layer (Service)
  Contains business logic (BFS shortest path algorithm).
   
- Domain Layer (Graph) / Infrastructure Layer (future DB integration)
  Represents the graph structure of country borders (in-memory adjacency list) because the data provided is few and fixed.
  i leave some space for extension , If countries/borders are maintained dynamically in the future, I will put the graph data into Azure SQL/Cosmos DB and cache it (Redis).  
  **trade off**
  small fixed data → in-memory；
  dynamic data → DB + cache
   
- Test
  **Unit tests**
  
  BFS shortest path correctness
  Input validation
  Edge cases (same source/destination, invalid codes)
  
  **Integration tests**
  
  Check if the JSON complies with the contract
  
- ☁️ Cloud Deployment

Deployed to Azure App Service

CI/CD ready

Environment-based configuration


*there will be a API structure graph  and BFS graph*

RUN Locally:
   dotnet run

<img width="348" height="448" alt="image" src="https://github.com/user-attachments/assets/fc75770e-d162-40cd-96eb-190b0c7880b5" />




  
 
