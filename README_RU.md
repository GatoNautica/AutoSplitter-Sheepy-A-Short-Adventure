# SheepyAutoSplitter

## Обзор

SheepyAutoSplitter — это инструмент, разработанный для того, чтобы помочь спидраннерам автоматически разбивать время на предопределенных контрольных точках (сплитах) во время гонки Sheepy A Short Adventure. Он позволяет игрокам сосредоточиться на игре, не беспокоясь о ручной записи результатов.

## Кто я?

Я GatoNáutica, начинающий разработчик мультимедиа, увлеченный видеоиграми и программированием. Мне нравится создавать и исследовать новые идеи в свободное время, всегда ищу веселья и хорошего времяпрепровождения.

## Почему я это сделал?

Сначала я не думал об этом. Идея пришла после того, как я попытался сделать свой первый спидранн и загрузил его на страницу до прочтения форума. Именно тогда я понял, что в игре нет поддержки автосплиттера, что сильно отвлекало меня от необходимости делать сплиты вручную (и еще потому, что мне было лень это делать).

Итак, однажды ночью 8 декабря в 3:09 утра, пока я не мог уснуть, я решил начать этот проект. Вот результат. Это первый раз, когда я делаю что-то подобное, так что тут могут быть ошибки и есть место для улучшений. Поскольку у меня нет больших знаний в этих темах, я сначала попытался использовать Cheat Engine, но это не сработало; я никогда не знал точно, что делать.

## Как работает код?

Авторазделитель работает путем захвата экрана игры и анализа содержимого, чтобы определить, когда достигаются контрольные точки. Он использует методы обработки изображений для обнаружения черных экранов и проверки контрольных изображений. Он также запрограммирован на избежание ложных срабатываний в определенных областях или при выполнении определенных действий.

Согласно правилам запуска, он действителен только и заканчивается на первом черном экране после завершения главы 6, прямо перед титрами. Поэтому код анализирует черные экраны при переходе от одной главы к другой, чтобы сделать разделения более точными.

Такие действия, как проигрыш или открытие игрового меню, которые генерируют экраны с черными тонами и могут вызывать ложные срабатывания, полностью контролируются. Я убедился, что каждое действие, которое генерирует нежелательный черный экран, не обнаруживается, чтобы избежать ошибок.

## Функции, реализованные в коде

1. **Захват экрана**:

Код использует библиотеку OpenCvSharp для захвата экрана игры. Функция CaptureFullScreen делает полный снимок экрана и преобразует его в матрицу изображения (Mat).

2. **Обнаружение черного экрана**:

Функция IsBlackScreen преобразует снимок экрана в оттенки серого и вычисляет гистограмму изображения. Если процент черных пикселей или темных тонов превышает определенный порог, это считается черным экраном.

3. **Проверка эталонного изображения**:

Авторазделитель сравнивает текущий снимок экрана с эталонными изображениями (end.png) каждой главы с помощью функции IsMatch. Эта функция преобразует оба изображения в оттенки серого и использует метод сопоставления шаблонов для определения уровня соответствия.

4. **Исключение нежелательных изображений**:

Чтобы избежать ложных срабатываний, код также проверяет, совпадает ли снимок экрана с каким-либо из изображений исключения (noSplit1.png, noSplit2.png и т. д.). Если есть совпадение, черный экран игнорируется.

5. **Выполнение Авторазделителя**:

Функция StartSplitting является сердцем Авторазделителя. Она непрерывно захватывает экран, проверяет, является ли он черным экраном, и проверяет совпадения с эталонным и исключающим изображениями. При обнаружении допустимого разделения время записывается, и он переходит к следующей контрольной точке.

6. **Конфигурация изображения**:

Эталонные изображения (end.png) и изображения исключения (noSplit1.png, noSplit2.png) должны быть помещены в соответствующие папки для корректной работы Авторазделителя. Универсальные изображения, такие как start.png и menu.png, также необходимы для поддержки обнаружения.

## Правильное использование Авторазделителя

1. **Установка**: следуйте инструкциям в файле `INSTALL.md`, чтобы настроить все зависимости и подготовить среду.

2. **Выполнение**: запустите Авторазделитель из Visual Studio. Желательно от имени администратора.

3. **Конфигурация**: настройте эталонные изображения и изображения исключения в соответствии с вашим конкретным запуском. Пример: C:\Users\Your User\OneDrive\Desktop\AutoSplitter-Sheepy A Short Adventure

## README_LANGUAGES.md?

Здесь вы найдете все сообщения, отображаемые в коде и терминале. Только для людей, не говорящих по-испански.

## Вклады

Вклады приветствуются и ценятся! Если у вас есть идеи, улучшения или вы обнаружили какие-либо проблемы, не стесняйтесь сотрудничать с проектом. Вот несколько способов внести свой вклад:

1. **Сообщить о проблемах**: если вы обнаружите какие-либо ошибки или у вас возникнут проблемы с использованием авторазделителя, откройте проблему в репозитории GitHub.

2. **Предложить улучшения**: если у вас есть идеи для новых функций или улучшений в коде, откройте проблему на GitHub, чтобы обсудить их с сообществом.

3. **Отправить запросы на извлечение**: если вы внесли изменения или улучшения в код, отправьте запрос на извлечение. Обязательно следуйте рекомендациям по внесению вклада и убедитесь, что ваш код хорошо документирован.

4. **Документация**: Помогите улучшить документацию проекта, добавив или обновив информацию в файлах README или вики проекта.

5. **Переводы**: Если вы можете помочь перевести проект или сообщения кода на другие языки, откройте запрос на извлечение с переводами.

6. **Поделитесь и продвигайте**: Поделитесь проектом с другими спидраннерами и любителями видеоигр. Чем больше людей будут использовать и вносить свой вклад в проект, тем он будет лучше.

## Лицензия

Этот проект лицензирован в соответствии с [Лицензией MIT](https://opensource.org/licenses/MIT)