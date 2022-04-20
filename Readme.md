# Clean architecture application

## Domain
- The domain layer is responsible for representing business concepts, information about the business situation and business rules.

## Details
- How we generated intial create?

  `dotnet ef migrations add InitialCreate --project CleanArchMvc.Infra.Data/CleanArchMvc.Infra.Data.csproj -s CleanArchMvc.WebUI/CleanArchMvc.WebUI.csproj -c ApplicationDbContext --verbose`

- Command for migration

  `dotnet ef database update --project CleanArchMvc.Infra.Data/CleanArchMvc.Infra.Data.csproj -s CleanArchMvc.WebUI/CleanArchMvc.WebUI.csproj`