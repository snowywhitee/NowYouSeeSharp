# NowYouSeeSharp
Labs for NYSS course

Задание на лабораторную работу:

Необходимо создать программу, которая будет выполнять функции автоматического
парсера информации из сети Интернет. Для удобства, мы заранее определим ресурс откуда
будем брать информацию и заранее определим логику её обработки. Часть мы сделаем на
занятии, ну а оставшуюся часть работы завершим дома. Итак, наша новая программа
должна обеспечивать возможность:

1) Автоматического создания локальной базы данных угроз безопасности
	информации, путем загрузки и последующего парсинга информации из официального
	банка данных угроз ФСТЭК России. Каждая запись об угрозе безопасности информации
	должна включать в себя следующие сведения об угрозе:
				a. Идентификатор угрозы;
				b. Наименование угрозы;
				c. Описание угрозы;
				d. Источник угрозы;
				e. Объект воздействия угрозы;
				f. Нарушение конфиденциальности (да\нет);
				g. Нарушение целостности (да\нет);
				h. Нарушение доступности (да\нет).
				
2) Автоматического обновления сведений (по запросу пользователя) локальной
	базы данных угроз безопасности информации. В результате обновления, программа должна
	выводить пользователю отчет об обновлении, с указанием:
				a. Статуса обновления (Успешно\Ошибка);
				b. Общего количества обновленных записей (если успешно, ну а если
				произошла ошибка вывести сведения о причинах ошибки).
				c. Идентификаторов измененных угроз и указанием состава измененной
				информации (в формате «БЫЛО - СТАЛО»)
				
3) Просмотр общего перечня угроз безопасности информации в сокращенном
	виде, с указанием:
				a. Идентификатор угрозы в формате «УБИ.ХХХ»
				b. Наименование угрозы.
				
4) Просмотр общего перечня угроз безопасности информации в должен быть
	представлен в табличном виде (либо списком), с постраничным выводом (пагинацией).
	Количество угроз на 1 странице – не менее 15.
	
5) Просмотр всех сведений о каждой из угроз безопасности информации.

6) Возможность сохранения всех сведений локальной базы данных угроз
	безопасности информации в файле на жестком диске компьютера.

При запуске, программа должна проверять наличие на локальном компьютере файла
с сохраненными сведениями и в случае его наличия, должна загружать данные именно из
него. В случае его отсутствия – программа должна оповестить пользователя о том, что
файла с локальной базой не существует, и предложить ему провести первичную загрузку
данных. Программа должна представлять собой приложение WPF (Windows Presentation
Foundation), реализованное с использованием стека технологий .Net, предоставлять
интерактивный интерфейс для взаимодействия с пользователем и иметь возможность
хранения созданной информации в файле на жестком диске.