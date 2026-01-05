# ApiVersioning.Sample

A small ASP.NET Core sample demonstrating API versioning patterns (URL-segment versioning) with multiple API versions (v1, v2, and a deprecated v3). Includes controllers, example HTTP requests, and minimal models to illustrate versioned APIs.

## Requirements

- .NET 10 SDK
- Visual Studio 2026 (recommended) or VS Code

## Quick start

1. Clone the repository:
2. Restore and build:
3. Run the project:

By default the application launches on http://localhost:5208 (see launch settings).

## API Versioning

This project demonstrates URL-segment versioning using routes such as:

- `GET /api/v1.0/blogs` — v1
- `GET /api/v2.0/blogs` — v2 (paged)
- `GET /api/v3.0/blogs` — v3 (deprecated / preview)
- `GET /api/v{version}/blogs/{id}` — shared endpoint across versions

Versions are configured in `Program.cs` and controllers use `[ApiVersion]` and `[MapToApiVersion]` attributes.

## Example requests

A ready-to-use HTTP collection is included: `ApiVersioning.Sample.http` (contains samples for v1, v2, v3 and GetById).

## Testing

Add unit or integration tests as needed. Run tests with:

## Contributing

Follow the repository standards described in `CONTRIBUTING.md`. Ensure code follows the project's `.editorconfig` rules and contribution guidelines.

## License

See the license file at the repository root. If none is present, contact the repository owner.

## Contact

For questions or issues, open an issue on the repository:
https://github.com/ashiqofficial/ApiVersioning