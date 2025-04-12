# تحديد الصورة الأساسية .NET SDK
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# تحديد الصورة الخاصة بعملية البناء
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Coffee-Shop2/Coffee-Shop2.csproj", "Coffee-Shop2/"]
RUN dotnet restore "Coffee-Shop2/Coffee-Shop2.csproj"
COPY . .
WORKDIR "/src/Coffee-Shop2"
RUN dotnet build "Coffee-Shop2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Coffee-Shop2.csproj" -c Release -o /app/publish

# تعيين صورة النهاية التي سيتم نشرها على Vercel
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Coffee-Shop2.dll"]