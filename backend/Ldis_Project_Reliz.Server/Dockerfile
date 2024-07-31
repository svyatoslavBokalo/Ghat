FROM mcr.microsoft.com/dotnet/aspnet:latest AS base
WORKDIR /app
EXPOSE 7209

FROM mcr.microsoft.com/dotnet/sdk:latest AS build
WORKDIR /src
# The context of the build should be the root directory of your solution.
# Adjust the path to the csproj file accordingly.
COPY ["Ldis_Project_Reliz.Server.csproj", "/src"]
RUN dotnet restore "Ldis_Project_Reliz.Server.csproj"
# Make sure to copy the entire solution context, including the csproj subdirectory.
COPY . .
WORKDIR "/src"
RUN dotnet build "Ldis_Project_Reliz.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ldis_Project_Reliz.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ldis_Project_Reliz.Server.dll"]
