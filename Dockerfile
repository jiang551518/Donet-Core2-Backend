# 使用官方 .NET Core SDK 镜像构建项目
FROM mcr.microsoft.com/dotnet/core/sdk:2.0 AS build

# 设置工作目录
WORKDIR /src

# 将项目文件复制到容器中
COPY Asp.net Test/Asp.net Test1.csproj ./MyApi/

# 恢复项目依赖
RUN dotnet restore Asp.net Test/Asp.net Test1.csproj

# 将其余的源代码复制到容器
COPY . .

# 构建项目
WORKDIR /src/Asp.net Test1
RUN dotnet build Asp.net Test/Asp.net Test1.csproj --configuration Release --output /app/build

# 发布应用程序
RUN dotnet publish Asp.net Test/Asp.net Test1.csproj --configuration Release --output /app/publish

# 使用官方 .NET Core 运行时镜像来运行应用
FROM mcr.microsoft.com/dotnet/core/aspnet:2.0

# 设置工作目录
WORKDIR /app

# 将发布的文件复制到运行时镜像中
COPY --from=build /app/publish .

# 暴露应用运行的端口
EXPOSE 80

# 设置容器启动命令
ENTRYPOINT ["dotnet", "Asp.net Test1.dll"]
