# ASP.NET Core 后端demo项目

一个基于 .NET Core 2.0 的示例项目，实现了 JWT 登录鉴权、Redis 缓存、MySQL CRUD、Excel 导出加密、天气接口、Hangfire 定时任务等功能，并集成 Swagger 方便查看文档，通过 Postman 测试接口。

## 功能特性
- **JWT Token** 登录鉴权
- **Redis** 缓存（StackExchange.Redis）
- **MySQL** 基本增删改查
- **Excel** 导出并加密（EPPlus/ClosedXML）
- **天气** 第三方接口调用
- **Hangfire** 定时任务调度
- **Swagger** 自动生成 API 文档
- 并发控制优化
- Postman 接口测试

## 环境要求
- .NET Core 2.0 SDK  
- MySQL 5.7+  
- Redis 5.0+  
- Windows 或 Linux  

## 配置说明
根据自己需要在 `appsettings.json` 中配置以下字段：
- `HangfireConfig`
- `MysqlConnection`
- `AllowedOrigins`

## 图片截图
![82e215289f883c4958bd214882feaca](https://github.com/user-attachments/assets/fca44370-4ce6-4efe-91c4-42a5520279f6)
![5d7bf796b3bfa028aa21a598c3ee511](https://github.com/user-attachments/assets/6faa46b1-5285-4c7a-9032-ed21be37037b)
![image](https://github.com/user-attachments/assets/40ffd48d-e58f-4b1e-b872-79377cc87f65)
![image](https://github.com/user-attachments/assets/404b8f04-08a5-444d-a585-a49d652db252)
