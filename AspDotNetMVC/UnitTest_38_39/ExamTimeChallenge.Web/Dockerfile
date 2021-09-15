FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
RUN apt-get update && apt-get install -y nodejs
COPY ["ExamTimeChallenge.Web/*.csproj", "ExamTimeChallenge.web/"]
COPY ["ExamTimeChallenge.Data/*.csproj", "ExamTimeChallenge.Data/"]
COPY ["ExamTimeChallenge.Membership/*.csproj", "ExamTimeChallenge.Membership/"]
COPY ["ExamTimeChallenge.Training/*.csproj", "ExamTimeChallenge.Training/"]
RUN dotnet restore "ExamTimeChallenge.Web/ExamTimeChallenge.Web.csproj"
COPY . .
WORKDIR "/src/ExamTimeChallenge.Web"
RUN dotnet build "ExamTimeChallenge.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ExamTimeChallenge.Web.csproj" -c Release -o /app

FROM build AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ExamTimeChallenge.Web.dll"]