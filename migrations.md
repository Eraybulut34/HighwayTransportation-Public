##Migrationlar /HighwayTransportation.Domain dizininde atılacak

dotnet ef migrations add InitialCreate --context AppDbContext --startup-project ../HighwayTransportation/HighwayTransportation_Web.csproj

dotnet ef database update  --context AppDbContext --startup-project ../HighwayTransportation/HighwayTransportation_Web.csproj


dotnet ef migrations remove --context AppDbContext --startup-project ../HighwayTransportation/HighwayTransportation_Web.csproj