#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Example.Ecommerce.Service.WebApi/Example.Ecommerce.Service.WebApi.csproj", "Example.Ecommerce.Service.WebApi/"]
COPY ["Example.Ecommerce.Application.DTO/Example.Ecommerce.Application.DTO.csproj", "Example.Ecommerce.Application.DTO/"]
COPY ["Example.Ecommerce.Domain/Example.Ecommerce.Domain.csproj", "Example.Ecommerce.Domain/"]
COPY ["Example.Ecommerce.Application.Interface/Example.Ecommerce.Application.Interface.csproj", "Example.Ecommerce.Application.Interface/"]
COPY ["Example.Ecommerce.Transversal.Common/Example.Ecommerce.Transversal.Common.csproj", "Example.Ecommerce.Transversal.Common/"]
COPY ["Example.Ecommerce.Application.UseCases/Example.Ecommerce.Application.UseCases.csproj", "Example.Ecommerce.Application.UseCases/"]
COPY ["Example.Ecommerce.Application.Validator/Example.Ecommerce.Application.Validator.csproj", "Example.Ecommerce.Application.Validator/"]
COPY ["Example.Ecommerce.Persistence/Example.Ecommerce.Persistence.csproj", "Example.Ecommerce.Persistence/"]
RUN dotnet restore "Example.Ecommerce.Service.WebApi/Example.Ecommerce.Service.WebApi.csproj"
COPY . .
WORKDIR "/src/Example.Ecommerce.Service.WebApi"
RUN dotnet build "Example.Ecommerce.Service.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Example.Ecommerce.Service.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.Ecommerce.Service.WebApi.dll"]