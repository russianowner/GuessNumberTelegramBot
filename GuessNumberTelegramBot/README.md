# GuessNumberTelegramBot
---
- Телеграм бот на C#, игра "Угадай число" для личных и групповых чатов
---
- Telegram bot on c#, a "Guess the number" game for personal and group chats
---

## Функционал
- /start — начать новую игру
- /stop — остановить игру и показать число
- Ввод чисел — угадываем загаданное число
- Бот сообщает "больше" / "меньше" / "угадал" с именем игрока
- Поддержка личных и групповых чатов

---

## Functionality
- /start — start a new game
- /stop — stop the game and show the number
- Entering numbers — guess the hidden number
- The bot reports "more" / "less" / "guessed" with the player's name
- Support for personal and group chats

---

## Nuget Packages
- dotnet add package Telegram.Bot
- dotnet add package Microsoft.Extensions.Configuration
- dotnet add package Microsoft.Extensions.Configuration.Json

---

## Установка бота
- Клонируем репозиторий
- Устанавливаем пакеты NuGet
- Заходим в "appsettings.json" там меняем токен бота(его можно создать в @BotFather)
- Запускаем проект, добавляем бота в группу или сами играем с ним в личных сообщениях прописав /start

---

## Installing the bot
- Cloning the repository
- Install NuGet packages
- Go to "appsettings.json" there we change the bot token (it can be created in @BotFather)
- Launch the project, add the bot to the group, or play with it in private messages by writing /start
- 
---