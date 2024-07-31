# Перший запуск Backend частини коду на Linux

Для запуску проекту ASP.NET Core на Linux без використання Visual Studio вам потрібно виконати наступні кроки:

1. **Встановлення .NET Core SDK на Linux**:
   - Відкрийте термінал.
   - Додайте репозиторій Microsoft:
     ```bash
     wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
     sudo dpkg -i packages-microsoft-prod.deb
     ```
   - Встановіть SDK:
     ```bash
     sudo apt-get update; \
     sudo apt-get install -y apt-transport-https && \
     sudo apt-get update && \
     sudo apt-get install -y dotnet-sdk-7.0
     ```
     Зверніть увагу, що я використовую `dotnet-sdk-7.0` як приклад. Вам може знадобитися інша версія SDK в залежності від вашого проекту.

2. **Отримання файлів проекту**:
   - Відкрийте термінал директорії, де ви хочете розмістити проект:
   - Клонуйте репозиторій проекту за допомогою Git. Якщо у вас ще не встановлено Git, ви можете встановити його, використовуючи команду `sudo apt-get install git`. Після встановлення Git, клонуйте репозиторій:
     ```bash
     git clone https://github.com/putsan/teamchallenge_chat.git
     ```
   - Перейдіть до директорії проекту:
     ```bash
     cd teamchallenge_chat
     ```
   Тепер ви маєте локальну копію проекту і готові перейти до наступних кроків для його запуску.

3. **Запуск проекту**:
   - Перейдіть до директорії проекту з backend кодом:
     ```bash
     cd backend/Ldis_Team_Project/
     ```
   - Встановіть залежності:
     ```bash
     dotnet restore
     ```
   - Запустіть проект:
     ```bash
     dotnet run
     ```

Після цього ваш проект має бути запущений, і ви зможете отримати доступ до нього через веб-браузер, перейшовши за адресою, яка відображається у терміналі (зазвичай це `http://localhost:44451`).

Якщо у вас є додаткові питання або проблеми, будь ласка, дайте знати!
