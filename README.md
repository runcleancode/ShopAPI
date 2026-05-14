# ShopAPI

A minimal ASP.NET Core Web API for e-commerce operations.

## Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | /products | List all products (supports minPrice, maxPrice filters) |
| GET | /products/{id} | Get product by id |
| GET | /categories | List all categories |

## Tech Stack

- .NET 10
- ASP.NET Core Minimal API

## Getting Started

```bash
dotnet run
```

---

## Development Scenarios

### Scenario 1 — Feature Branch & Price Filter
> **@hakan** — We need price filtering for the products endpoint.
> It should work like `/products?minPrice=100&maxPrice=500`. Can you handle it today?

- Created branch `feature/price-filter`
- Added optional `minPrice` and `maxPrice` query parameters
- Merged into `main` via fast-forward

### Scenario 2 — Merge Conflict
Two developers modified the same line simultaneously.
- Branch `feature/update-keyboard-price` → price: 599.90
- Branch `feature/update-keyboard-stock` → stock: 50
- Resolved manually: kept both changes

### Scenario 3 — Revert in Production
> **@hakan** — We deployed last night and orders are broken.
> Customers are complaining. Check what happened ASAP!

- Identified bad commit with `git log`
- Used `git revert` to safely undo without rewriting history

### Scenario 4 — Stash & Hotfix
> **@hakan** — Stop what you're doing, we have a critical bug
> in the products endpoint. Fix it now, then continue your work.

- Saved unfinished work with `git stash`
- Created `hotfix/products-null-check` branch
- Fixed bug, merged to `main`
- Restored unfinished work with `git stash pop`