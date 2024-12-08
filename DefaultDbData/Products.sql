-- This script only contains the table creation statements and does not fully represent the table in the database. It's still missing: sequences, indices, triggers. Do not use it as a backup.

CREATE TABLE [dbo].[Products] (
    [Id] int,
    [Name] nvarchar(450),
    [Description] nvarchar(MAX),
    [Cost] float,
    [Count] int,
    [ImagePath] nvarchar(MAX),
    [CategoryId] int,
    [ManufacturerId] int,
    [CreatedAt] datetimeoffset,
    [UpdatedAt] datetimeoffset,
    CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Categories]([Id]),
    CONSTRAINT [FK_Products_Manufacturers_ManufacturerId] FOREIGN KEY ([ManufacturerId]) REFERENCES [dbo].[Manufacturers]([Id]),
    PRIMARY KEY ([Id])
);


INSERT INTO [dbo].[Products] ([Id],[Name],[Description],[Cost],[Count],[ImagePath],[CategoryId],[ManufacturerId],[CreatedAt],[UpdatedAt]) VALUES (1,'HP DesignJet T630 24-in','Широкоформатный принтер HP DesignJet T630 24-in позволит работать с бумагой A1-формата при ширине печати, достигающей 24 дюйма. Оборудование для большого офиса действует по принципу термоструйной четырехцветной печати с разрешением 2400x1200 dpi. На печать одного листа A1 уходит всего 30 секунд – в цветном и черно-белом режиме. Прибор HP DesignJet T630 24-in оснащен USB-портом стандарта 2.0, Ethernet-интерфейсом и модулем Wi-Fi. Конструкция дополнена дисплеем, автоматическим резаком и лотком для материалов печати. Принтер поставляется вместе с комплектом картриджей, кабелем питания, шпинделем, печатающей головкой, подставкой и устройством для подачи листов в автоматическом режиме. Оборудование весит 28.9 кг и обладает размерами 101.3x93.2x60.5 см.','162999',1,'',5,6,'2024-11-28 12:26:37.6534999','0001-01-01 00:00:00.0000000');
INSERT INTO [dbo].[Products] ([Id],[Name],[Description],[Cost],[Count],[ImagePath],[CategoryId],[ManufacturerId],[CreatedAt],[UpdatedAt]) VALUES (2,'HP DesignJet T230','Широкоформатный принтер HP DesignJet T230 используется для печати чертежей и презентационных материалов. Оборудование позволяет работать с бумагой A1-формата, обеспечивая печать шириной 24 дюйма. Вы можете использовать техническую, фотобумагу, пленку, документальную, с покрытием и самоклеящуюся бумагу. Модель HP DesignJet T230 работает по принципу термоструйной печати с применением чернил на основе пигментов и красителей. Оборудование оснащено модулем Wi-Fi, а также USB-портом, сетевым интерфейсом Ethernet. Устройство дополняется автоматическим резаком, а поставляется вместе с печатающей головкой, набором пробных струйных картриджей и кабелем питания.','105499',1,'',5,6,'2024-11-28 12:31:40.5091356','0001-01-01 00:00:00.0000000');
INSERT INTO [dbo].[Products] ([Id],[Name],[Description],[Cost],[Count],[ImagePath],[CategoryId],[ManufacturerId],[CreatedAt],[UpdatedAt]) VALUES (3,'Canon CanoScan LiDE 300','Сканер Canon CanoScan LiDE 300 с компактной планшетной конструкцией обеспечивает высокое качество сканирования и удобство в эксплуатации. В устройстве установлены датчик CIS и светодиодный источник, который позволяет создавать четкие насыщенные отпечатки с разрешением до 2400x2400 dpi. Данная модель поддерживает различные документы форматом до А4. Из особенностей сканера отмечаются 4 кнопки управления и технология автоматического сканирования. Подключение и питание Canon CanoScan LiDE 300 осуществляется посредством интерфейсного разъема USB.','9999',2,'',3,7,'2024-11-28 12:35:09.1997333','0001-01-01 00:00:00.0000000'),(4,'HP Scanjet Pro 2600 f1','Повысьте производительность профессионального сканирования с помощью быстрого, компактного и надежного сканера HP ScanJet Pro, предназначенного для сканирования до 1500 страниц в день. Автоматизируйте рабочие процессы с помощью ярлыков для вызова функций одной кнопкой и автоподатчика с поддержкой быстрого двустороннего сканирования.','34499',1,'',3,6,'2024-11-28 12:35:56.9109773','0001-01-01 00:00:00.0000000'),(5,'Xerox Phaser 3020','Принтер лазерный Xerox Phaser 3020 со светодиодной системой и разрешением 1200х1200 dpi обеспечивает четкость при печати черно-белых документов. Модель ориентирована на ежемесячную нагрузку до 15000 страниц. За 1 минуту устройство печатает 20 страниц формата А4. Подключение принтера Xerox Phaser 3020 к компьютеру выполняется по кабелю с разъемом USB. Для беспроводной синхронизации и обмена файлами реализован модуль Wi-Fi. Функция Apple AirPrint предусматривает печать из поддерживаемых приложений устройств Apple.','34499',4,'',4,8,'2024-11-28 12:37:56.0342299','0001-01-01 00:00:00.0000000'),(6,'Raspberry Pi 4 Model B','Микрокомпьютер Raspberry Pi 4 Model B ориентирован на решение различных повседневных задач, не настаивающих на наличии внушительной вычислительной мощности. Благодаря процессору Broadcom BCM2711 вы сможете обрабатывать небольшие файлы, общаться с друзьями, а также использовать всевозможные приложения. В модели Raspberry Pi 4 Model B появился интерфейс Bluetooth, незаменимый для сопряжения с необходимыми устройствами. Быстрое подключение накопителей обеспечивается посредством предусмотренных в микрокомпьютере портов USB 3.0. Необходимое ПО пользователь выбирает в соответствии со своими предпочтениями.','13999',3,'',6,2,'2024-11-28 12:40:16.3527130','0001-01-01 00:00:00.0000000'),(7,'Raspberry Pi 4 Model B 8GB','Микрокомпьютер Raspberry Pi 4 Model B 8GB представляет собой одноплатное компактное решение, которое при этом отличается высокой функциональностью и широкими возможностями использования. Данное устройство может выступать в качестве платформы для разработки программного обеспечения, эмулятора игровой приставки, а также медиа-центра и просто рабочей станции. В основе микрокомпьютера Raspberry Pi 4 Model B 8GB используется 4-ядерный процессор Broadcom BCM2711, работающий на частоте 1500 МГц, что вкупе с 8 ГБ оперативной памяти типа LPDDR4 может обеспечить комфортный уровень производительности для различных базовых задач. Для использования накопителей на плате предусмотрено множество интерфейсов периферии. Также есть полноформатные разъемы USB и HDMI 2.0, позволяющий выводить изображение в разрешении до 4K. Для доступа к сети модель поддерживает Wi-Fi и проводное подключение посредством Ethernet. Также для беспроводного соединения микрокомпьютер оснащен модулем Bluetooth. Устройство поставляется без операционной системы.','24999',1,'',6,2,'2024-11-28 12:41:24.5515856','0001-01-01 00:00:00.0000000'),(8,'ASUS ExpertCenter PN52-S5149MD','Мини ПК ASUS ExpertCenter PN52-S5149MD в корпусе-неттопе с размерами 130x120x58 мм предусматривает встроенный сетевой адаптер для проводного подключения к сети Интернет со скоростью обработки данных до 2.5 Гбит/с. Модель поддерживает вывод изображения на экраны нескольких мониторов благодаря присутствию на задней панели видеоразъемов HDMI (2 шт.) и USB Type-C. Для удобного подключения внешних накопителей данных на передней панели есть интерфейсы USB Type-A и USB Type-C. Мини ПК ASUS ExpertCenter PN52-S5149MD предусматривает твердотельный накопитель данных емкостью 256 ГБ для установки программ и хранения файлов, которые могут понадобиться в повседневной работе. 6-ядерный процессор AMD Ryzen 5 5600H и 8 ГБ оперативной памяти обеспечат достаточное быстродействие для запуска популярных офисных программ и решения нересурсоемких задач. На борту устройства отсутствует предустановленная операционная система.','61799',2,'',1,3,'2024-11-28 12:46:08.2861818','0001-01-01 00:00:00.0000000');
INSERT INTO [dbo].[Products] ([Id],[Name],[Description],[Cost],[Count],[ImagePath],[CategoryId],[ManufacturerId],[CreatedAt],[UpdatedAt]) VALUES (9,'Apple Mac mini','Мини ПК Apple Mac mini может похвастаться миниатюрным корпусом с «серьезной» начинкой внутри. В основе его производительности – процессор Apple M2. Благодаря прогрессивной системе Neural Engine скорость машинного обучения возросла до 15 раз. ПК обеспечит недоступные ранее ресурсы для работы, игр и творчества – больше, чем вы могли себе представить. Процессор сочетается с оперативной памятью LPDDR5 объемом 8 ГБ и интегрированной видеокартой Apple M2 10-core. Твердотельного накопителя хватает для размещения до 256 ГБ информации. Производитель гордится тем, что Apple Mac mini работает «как большой», несмотря на свои миниатюрные размеры.','79999',1,'',1,1,'2024-11-28 12:47:09.6666581','0001-01-01 00:00:00.0000000'),(10,'Acer Veriton N4710GT','Мини ПК Acer Veriton N4710GT [DT.VXVCD.001] с малогабаритным корпусом-неттопом черного цвета рассчитан на выполнение офисных задач или эксплуатацию в качестве универсальной домашней станции. В сборке предусмотрены центральный процессор Intel Core i3-13100 оперативная память стандарта DDR4 общей емкостью 8 ГБ. Для операций с графическими данными используется встроенное графическое видеоядро ЦПУ Intel UHD Graphics 730. Для установки операционной системы и долговременного хранения данных компьютер компактного форм-фактора Acer Veriton N4710GT [DT.VXVCD.001] располагает одним накопителем SSD объемом 512 ГБ. Задачу снабжения всех потребителей системного блока электроэнергией решает блок питания с выходной мощностью 90 Вт. ПК поставляется без предустановленной рабочей платформы, чтобы вы смогли выбрать для него ОС самостоятельно.','42799',3,'',1,5,'2024-11-28 13:23:37.2552573','0001-01-01 00:00:00.0000000'),(11,'MSI PRO DP 21 13M-631XRU','Мини ПК MSI PRO DP 21 13M-631XRU в компактном корпусе размерами 208x54.8x204 мм предусматривает интерфейсы USB и jack 3.5 mm для подключения периферийных устройств, которые могут понадобиться в повседневной работе за компьютером. Модель совместима с VESA-крепежом, благодаря чему ее можно незаметно зафиксировать в любом удобном месте при помощи кронштейна. Устройство предусматривает COM-порт, который используется для подключения различного торгового оборудования, чековых принтеров и сканеров штрих-кодов. Мини ПК MSI PRO DP 21 13M-631XRU оснащен интерфейсом USB 3.2 Gen2 Type-C, благодаря которому при подключении к компьютеру внешних накопителей обеспечивается быстрый обмен файлами. Сборка функционирует на базе 10-ядерного процессора Intel Core i5-13400 и 16 ГБ оперативной памяти, которые обеспечивают стабильную работу при обработке данных электронной и мобильной коммерции.','64999',3,'',1,4,'2024-11-28 13:25:24.9111284','0001-01-01 00:00:00.0000000'),(12,'HP ProDesk 400 G9 R Mini','Мини ПК HP ProDesk 400 G9 R Mini имеет компактный корпус из черного пластика, который можно установить в вертикальном положении на специальной подставке. Он занимает мало места на рабочем столе. 16 ядер процессора Intel Core i7 производят вычисления в 24 потока, что обеспечивает моментальное выполнение разных задач без зависаний и торможений. Модуль оперативной памяти на 8 ГБ позволяет открывать множество программ или вкладок в браузере, легко переключаясь между ними. За хранение и быструю загрузку файлов отвечает SSD-накопитель на 512 ГБ. На корпусе мини ПК HP ProDesk 400 G9 R Mini имеются разъемы USB для подключения периферийных устройств и видеоразъемы для мониторов. Возможно беспроводное подключение устройств через Bluetooth. Встроенный сетевой адаптер обеспечивает стабильное интернет-соединение со скоростью 1 Гбит/с. Для этой же цели можно использовать модуль Wi-Fi. В комплекте с мини ПК предусмотрены проводные клавиатура и мышь.','80999',1,'',1,6,'2024-11-28 13:29:18.9782576','0001-01-01 00:00:00.0000000');