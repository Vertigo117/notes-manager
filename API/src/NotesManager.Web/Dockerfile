FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/NotesManager.Web/NotesManager.Web.csproj", "NotesManager.Web/"]
RUN dotnet restore "src/NotesManager.Web/NotesManager.Web.csproj"
COPY . .
WORKDIR "/src/NotesManager.Web"
RUN dotnet build "NotesManager.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NotesManager.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NotesManager.Web.dll"]
