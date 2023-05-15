#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

ARG FEED_TOKEN
ADD ./../src .
#RUN dotnet nuget add source https://nuget.pkg.github.com/artur-mezhidov-itechart/index.json --name github.com --username github --password $FEED_TOKEN --store-password-in-clear-text
WORKDIR /src
COPY ["./Sms.Sender.Application/Sms.Sender.Application.csproj", "src/Sms.Sender.Application/"]

#COPY ["src/Sms.Sender.Services/Sms.Sender.Services.csproj", "src/Sms.Sender.Services/"]
#COPY ["src/Sms.Sender.Provider.Twilio/Sms.Sender.Provider.Twilio.csproj", "src/Sms.Sender.Provider.Twilio/"]
#COPY ["src/Sms.Sender.Provider/Sms.Sender.Provider.csproj", "src/Sms.Sender.Provider/"]
#COPY ["src/Sms.Sender.Provider.Mock/Sms.Sender.Provider.Mock.csproj", "src/Sms.Sender.Provider.Mock/"]
#RUN dotnet restore "src/Sms.Sender.Application/Sms.Sender.Application.csproj"
#COPY . .
#WORKDIR "/src/src/Sms.Sender.Application"
#RUN dotnet build "Sms.Sender.Application.csproj" -c Release -o /app/build

#FROM build AS publish
#RUN dotnet publish "Sms.Sender.Application.csproj" -c Release -o /app/publish

#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "Sms.Sender.Application.dll"]
