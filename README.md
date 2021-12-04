# DeChallenge 2021 Backend

C# task - Financial calculations

## Table of Content

- [Run](#run)
- [Test](#test)
- [Todo](#todo)

## Run

```bash
# Go into the folder with DevChallenge.sln and run
docker-compose up
```

Service will be available on port 8080.

When docker runs open http://localhost:8080/swagger on your browser to see swagger docs and try api.

## Test

Requirements to run tests

- [Install .NET 6](https://dotnet.microsoft.com/download)

```bash
# Go into the folder with DevChallenge.sln and run
dotnet test DevChallenge.sln
```

There are two test types used in solution: unit and component.
There are pretty good test coverage for the most critical parts.

## Description

Solution consider box as a solid rectangle without possibility to overlap.
There are two options how we can place rectangle: horizontally and vertically.
According to the sheet size might be situations were either one of two options has better coverage.
Example:
![example-1](https://raw.githubusercontent.com/alexkhil/devchallenge-backend-2021/main/.assets/example.png?token=AHDLFBVWU2WRSOSNTBMTKXLBVNMTU)
Both of these strategies are implemented, so we pick results from strategy with better coverage.

## TODO

- [ ] Simplify mapping on `SimpleBoxMappingProfile` caused by `System.Text.Json` which doesn't support polymorphic serialization
- [ ] Improve assertion on `Endpoint_called_with_valid_request_respond_with_status_code_200_and_boxes` test by getting rid of string comparison
- [ ] Run tests in container to avoid installations of .Net runtime
