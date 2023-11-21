# SolforbTest
## Getting started

Прежде чем запустить проект нужно настроить окружение

Первмым делом нужно задать ConnectionString для базы данных
в файле appsettings.json

Вставьте в строку SolfOrbTest свой путь до БД, например

```json 
"SolfOrbTest": "Host=localhost;Port=5432;Database=SolfOrbTest;Username=postgres;Password=1015"
```

Затем нужно сделать миграцию в БД.

Для этого отокройте `Package Manager Console` выберите проект DAL и запустите `Update-Database`.

Следующим шагом настройте окружение для клиента.

Для этого перейдите в папку SolfOrbUI/ClientApp и выполните команду `npm install`

## Запуск приложения

Сервер должен запускаться на порту 7238, когда среда Development, когда среда Production сервер запускается на порту 5000.

Клиент должен запускаться 4200, либо на любом другом порту.

Чтобы запустить клиент перейдите в папку ClientApp и запустите команду `ng serve`, либо же можно все запустить через Visual Studio

## Что используется в проекте

- .NET 7  
- ASP.NET  
- Automapper  
- EF Core  
- Angular  
- TypeScript  
- Bootstrap  
