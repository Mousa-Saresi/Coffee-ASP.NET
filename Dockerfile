# تحديد الصورة الأساسية .NET 8.0
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# تحديد صورة عملية البناء .NET 8.0 SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Coffee-Shop2.csproj", "./"]
RUN dotnet restore "Coffee-Shop2.csproj"
COPY . . 
WORKDIR "/src"
RUN dotnet build "Coffee-Shop2.csproj" -c Release -o /app/build

# نشر التطبيق
FROM build AS publish
RUN dotnet publish "Coffee-Shop2.csproj" -c Release -o /app/publish

# الصورة النهائية التي سيتم نشرها
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Coffee-Shop2.dll"]