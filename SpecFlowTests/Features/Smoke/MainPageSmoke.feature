﻿# language: ru
Функционал: Проверка элементов главной страницы
@BadLogins
Сценарий: Проверка наличия элементов
       Когда открывается страница "Главная"
	   Тогда пользователь (проверяет наличие текста на странице) "Услуги"
	   Тогда пользователь (проверяет наличие элемента) из списка
	   | Название элемента     |
	   | Войти                 |
	   | Контактная информация |
	   | Навигация             |
