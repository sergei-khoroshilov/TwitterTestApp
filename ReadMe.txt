﻿Перед запуском прописать в Web.config параметры ConsumerKey и ConsumerSecret - данные для авторизации в API Твиттера. Для работы используется application-only аутентификация.

Также в конфиге есть параметры 
	- Hashtag - хештег, для которого отображаются твиты
	- TwitsCount - максимальное кол-во отображаемых твитов

Замечание: АПИ Твиттера при поиске по хештегу отдает не все данные, а только за последние 7 дней.
