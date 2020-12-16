# Laba4

Для того, чтобы вам было проще проверять лаб. работу я сделал консольное приложение(А так оно подходит для запуска, как служба)

(..) - (Скрин в папке "Example" c пометкой).

1) Первоначально был развернут бд "AdventureWorks2012". От туда был взят набор таблиц "HumanResource.*"(1). Там вышло 6 таблиц.

2) Для работы с бд разработан класс "DataAccess" являющийся одним из элементов трехуровневой Архитектуры DAL.

3) Business logic(BLL) – Средство связи Пользовательского интерфейса (Models) и работы с бд (DataAccess)

4) Проекты были выполнены все отдельно и подключены(2):

Models – основной сборщик всех проектов;
DataAccess – работа с БД.
DataManager – работа с обработкой данных(Парсеры);
FileManager – работа с перемещение фаилов;
BusnessLogic – связующий БД и пользователя компонент;
ConfigurationManager – менеджер конфигураций;
JsonBuilder – json генератор;
RequestManager – запрос к бд менеджер; 

5) RequestManager - связующее звено между пользователем и бд. Оно ограничивает пользователя от сухого запроса в виде string, защищая его от нежелательной ошибки.

6) FileManager – менеджер слежки(взят из 3 лаб. Работы) использует ConfigurationManager, который в свою очередь использует DataManager для получения данных из фаила.

7) Программа получается из json/xml конфигурацию сборки и выполняет эти действия с сгенерированными json фаилами(Фаил находиться рядом с *.exe).

8) Разработана логичная структура папок и namespace’ов.

9) Работа JsonBuilder и FileManager(3 и 4)

Данная лабораторный работа заняла кучу времени в связи с тем, что я вручную прописывал Работу с бд и дополнительно прописал еще некоторые фичи(Тк есть кучу nugget пакетов для работы с бд, но как просил Артем, я писал все вручную)
