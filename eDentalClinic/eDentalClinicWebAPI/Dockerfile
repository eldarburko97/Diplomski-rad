FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["eDentalClinicWebAPI/eDentalClinicWebAPI.csproj", "eDentalClinicWebAPI/"]
COPY ["eDentalClinic.Model/eDentalClinic.Model.csproj", "eDentalClinic.Model/"]
RUN dotnet restore "eDentalClinicWebAPI/eDentalClinicWebAPI.csproj"
COPY . .
WORKDIR "/src/eDentalClinicWebAPI"
RUN dotnet build "eDentalClinicWebAPI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "eDentalClinicWebAPI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ADD eDentalClinicWebAPI/Images Images/
ENTRYPOINT ["dotnet", "eDentalClinicWebAPI.dll"]
