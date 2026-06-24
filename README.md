# DevPulseApi

Infrastructure health monitoring API built from scratch with C# and ASP.NET Core. The idea came from wanting to replicate what tools like Datadog and New Relic do internally — collect service metrics, detect anomalies, and track incidents in a structured way.

This is not a tutorial CRUD app. It's a domain-driven system with a layered architecture, fully containerized with Docker, and running in production.


---


## What it does

You register the services you want to monitor, send metrics periodically (latency, CPU, memory), and the API stores everything with full history. When something goes wrong, you register an incident and can resolve it through a dedicated endpoint — with an automatic resolution timestamp.

---

## Stack

- **C# + ASP.NET Core .NET 10** — REST API
- **PostgreSQL + EF Core** — database with automatic migrations on startup
- **Docker + Docker Compose** — full containerization
- **Kubernetes** — deployment manifests with 2 replicas and LoadBalancer
- **Railway** — production deployment

---

## Architecture

The project follows a layered architecture with clear separation of concerns:
Controllers  →  handle incoming HTTP requests

Services     →  business logic lives here

Repositories →  database access only

Models       →  domain entities

DTOs         →  API input contracts

Each layer communicates only with the layer below it, through interfaces — making it easy to test and swap implementations without touching the rest of the system.

---

## Endpoints

### Services
| Method | Route | Description |
|--------|-------|-------------|
| GET | /api/services | List all services |
| GET | /api/services/{id} | Get a service by ID |
| POST | /api/services | Register a new service |

### Metrics
| Method | Route | Description |
|--------|-------|-------------|
| GET | /api/metrics/service/{serviceId} | List metrics for a service |
| POST | /api/metrics | Record a new metric |

### Incidents
| Method | Route | Description |
|--------|-------|-------------|
| GET | /api/incidents/service/{serviceId} | List incidents for a service |
| POST | /api/incidents | Register an incident |
| PATCH | /api/incidents/{id}/resolve | Resolve an incident |

---

## Running locally

**Requirements:** .NET 10 SDK, PostgreSQL

```bash
git clone https://github.com/Micaelatamir/DevPulseApi
cd DevPulseApi
```

Set your connection string in `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=devpulsedb;Username=postgres;Password=your_password"
}
```

```bash
dotnet ef database update
dotnet run
```

API available at `http://localhost:5135`

---

## Running with Docker

```bash
docker-compose up --build
```

API available at `http://localhost:8080`

The database starts alongside the API and migrations run automatically on startup.

---

## Kubernetes

Manifests are inside the `/k8s` folder. The deployment runs with 2 replicas by default and exposes the API via LoadBalancer on port 80.

```bash
kubectl apply -f k8s/
```

---

## Cloud Deployment

The plan was always to deploy on AWS EC2. Currently working on the setup — in the meantime the API is live on Railway, which supports Docker natively and works great for showcasing the project.

AWS EC2 deploy coming soon.

---

## Live

https://devpulseapi-production-c9ef.up.railway.app

