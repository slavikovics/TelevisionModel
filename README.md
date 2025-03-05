# Television Model

Модель телевизора 64

Предметная область: электроника и телевизионные технологии.

Важные сущности: телевизор, пульт дистанционного управления, экран, звуковая система, технические характеристики.

Операции: операция включения и выключения, операция выбора телеканала, операция настройки изображения и звука, операция подключения внешних устройств, операция обновления программного обеспечения.

# Состояния системы

Для модели телевизора выделим следующие состояния: выключен, главное меню, просмотр телеканалов, просмотр стриминга, трансляция с внешних устройств.

Пользователь будет взаимодействовать с телевизором посредством пульта.
В состоянии, когда телевизор выключен нажатие любых кнопок на пульте, кроме включения, никак не отражается на состоянии системы. Из выключенного состояния
система может переходить только в состояние главного меню.

В состоянии главного меню пользователь может изменять громкость и разрешение, обновлять программное обеспечение, переходить в любое другое состояние.

В состоянии просмотра телевидения пользователь может изменять громкость, переключаться на следующий (предыдущий) телеканал, переходить в любое другое состояние.

В состоянии просмотра стриминга система работает по аналогии с состоянием просмотра телевидения, но при этом происходит переключение не телеканалов, а контента, предоставляемого
стриминговым сервисом.

В состоянии трансляции со стороннего устройства пользователь может изменять громкость и переходить в любое другое состояние.

![Диаграмма состояний](./Images/UmlStateDiagram.jpg)

# Разделение на проекты

```
│   .gitattributes
│   .gitignore
│   README.md
│   TelevisionModel.sln
│
├───Images
│       UmlStateDiagram.jpg
│
├───TelevisionModel # проект, описывающий модель системы независимо от способа взаимодействия с пользователем
│   │   Television.cs
│   │   TelevisionModel.csproj
│   │
│   ├───Content
│   │       ChannelBroadcastingSystem.cs
│   │       IContentProvider.cs
│   │       SignalTransmitter.cs
│   │       StreamingService.cs
│   │       TelevisionChannel.cs
│   │       TelevisionSeries.cs
│   │
│   ├───Data # исходные данные для работы программы (при сборке копируются в выходной каталог)
│   │       logo_paths.json # телевизионные каналы
│   │       Resources.Designer.cs
│   │       Resources.resx # ресурсы для модели телевизора (например, сообщения исключений), в этом месте добавляется локализация
│   │       tv_shows.json # сериалы для стримингового сервиса
│   │
│   ├───Devices
│   │       Device.cs
│   │       RemoteControl.cs
│   │
│   ├───TelevisionStates
│   │       ExternalDeviceScreencastState.cs
│   │       ITelevisionState.cs
│   │       MainMenuState.cs
│   │       StreamingState.cs
│   │       TelevisionBroadcastingState.cs
│   │       TurnedOffState.cs
│   │       TurnedOnStateBase.cs
│   │
│   ├───TelevisionSubsystems
│   │       Screen.cs
│   │       Software.cs
│   │       SoundSystem.cs
│   │
│   └───Utils
│           ActionResult.cs
│           Saver.cs
│           States.cs
│           TechnicalSpecifications.cs
│
├───TelevisionModelConsole # консольный интерфейс для модели
│   │   CommandLineInterface.cs
│   │   ConsoleMessages.Designer.cs
│   │   ConsoleMessages.resx
│   │   Program.cs
│   │   TelevisionModelConsole.csproj
│
├───TelevisionModelTests # тесты модели
│   │   MSTestSettings.cs
│   │   SignalTransmitterTests.cs
│   │   TelevisionModelTests.csproj
│   │   TelevisionTests.cs
│
```

# Основные сущности

## 1. Интерфейс ITelevisionState

Описывает методы, которые должны реализовывать классы состояний системы.

- Метод для переключения на следующий канал предоставителя контента.
```c#
public ActionResult SwitchToNextChannel(IContentProvider contentProvider);
```

- Метод для переключения на предыдущий канал предоставителя контента.
```c#
public ActionResult SwitchToPreviousChannel(IContentProvider contentProvider);
```

- Метод для изменения громкости.
```c#
public ActionResult EditVolume(SoundSystem soundSystem, double newVolume);
```

- Метод для изменения разрешения экрана.
```c#
public ActionResult ChangeResolution(Screen screen, int newResolutionX, int newResolutionY);
```

- Метод для обновления программного обеспечения.
```c#
public ActionResult UpdateSoftware(Software software, string newSoftwareVersion);
```

- Метод для переключения в состояние главного меню.
```c#
public ActionResult SwitchToMainMenuState(Television television);
```

- Метод для выключения.
```c#
public ActionResult SwitchToTurnedOffState(Television television);
```

- Метод для переключения в состояние просмотра телеканалов.
```c#
public ActionResult SwitchToTelevisionBroadcastingState(Television television);
```

- Метод для переключения в состояние просмотра стримингового сервиса.
```c#
public ActionResult SwitchToStreamingState(Television television);
```

- Метод для переключения в состояние трансляции экрана с внешнего устройства.
```c#
public ActionResult SwitchToExternalDeviceScreencastState(Television television, Device externalDevice);
```

Данный интерфейс реализуется классами:
- TurnedOffState - для описания выключенного состояния
- TurnedOnStateBase - абстрактный класс для обобщения всех остальных состояний
- - MainMenuState - для описания состояния главного меню
- - TelevisionBroadcastingState - для описания состояния просмотра телеканалов
- - StreamingState - для описания состояния просмотра стриминга
- - ExternalDeviceScreencastState - для описания состояния трансляции с внешних устройств

## 2. Интерфейс IContentProvider

Описывает взаимодействие телевизора с системой предоставления контента.

- Метод для переключения на следующее содержимое.
```c#
public ActionResult SwitchToNext();
```

- Метод для переключения на предыдущее содержимое.
```c#
public ActionResult SwitchToPrevious();
```

Данный интерфейс реализуется классами:
- ChannelBroadcastingSystem
- StreamingService

## 3. ChannelBroadcastingSystem

Класс для просмотра телевидения

- Свойство для хранения индекса выбранного канала.
```c#
public int SelectedChannelIndex { get; private set; }
```

- Список доступных каналов.
```c#
private List<TelevisionChannel> AvailableChannels { get; }
```

- Конструктор для инициализации без параметров.
```c#
public ChannelBroadcastingSystem()
```

- Конструктор с заранее известным индексом выбранного канала.
```c#
public ChannelBroadcastingSystem(int selectedChannelIndex) : this()
```

- Метод для переключения на следующий канал.
```c#
public ActionResult SwitchToNext()
```




