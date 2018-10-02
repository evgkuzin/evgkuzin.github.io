<?php
/* Осуществляем проверку вводимых данных и их защиту от враждебных 
скриптов */
$name = htmlspecialchars($_POST["name"]);
$email = htmlspecialchars($_POST["email"]);
$message = htmlspecialchars($_POST["message"]);
/* Проверяем заполнены ли обязательные поля ввода, используя check_input 
функцию */
$name = check_input($_POST["name"], "Введите ваше имя!");
$email = check_input($_POST["email"], "Введите ваш e-mail!");
$message = check_input($_POST["message"], "Вы забыли написать сообщение!");

/* Проверяем правильно ли записан e-mail */
if (!preg_match("/([\w\-]+\@[\w\-]+\.[\w\-]+)/", $email))
{
show_error("<br /> Е-mail адрес не существует");
}
$to_adm  = "e.u.kuzin@gmail.com" ; 
$subject = "Сообщение от evgkuzin.ru"; 
$message = "Привет! <br><br>
Пришло новое сообщение от формы на evgkuzin.ru!<br><br>
Имя: $name <br>
Почта: $email <br>
Сообщение: $message";

$headers  = "Content-type: text/html; charset=utf-8 \r\n"; 
$headers .= "From: Форма с сайта <evgeniy@evgkuzin.ru>\r\n"; 

mail($to_adm, $subject, $message, $headers); 

$subject = "I received your message! — Evgeniy"; 
$message = "Hi! <br><br>
Thank you for your message! I will answer you as soon as possible.<br>
Together we will succeed.<br><br>
All the best<br>
Evgeniy";

$headers  = "Content-type: text/html; charset=utf-8 \r\n"; 
$headers .= "From: Evgeniy Kuzin <noreply@evgkuzin.ru>\r\n"; 

mail($email, $subject, $message, $headers); 

header('Location: ../#successfully');
?>
<?php
/* Если при заполнении формы были допущены ошибки сработает 
следующий код: */
function check_input($data, $problem = "")
{
$data = trim($data);
$data = stripslashes($data);
$data = htmlspecialchars($data);
if ($problem && strlen($data) == 0)
{
show_error($problem);
}
return $data;
}
function show_error($myError)
{
header('Location: ../#error');
exit();
}
?>