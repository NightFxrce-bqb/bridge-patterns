using System;

// 1. Базовый интерфейс
public interface INotification
{
    void Send(string message);
}

// 2. Реализации интерфейса
public class EmailNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"Отправка Email: {message}");
    }
    public class SMSNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"Отправка SMS: {message}");
        }
    }

    // 3. Абстрактный класс
    public abstract class Notification
    {
        protected INotification notification;

        protected Notification(INotification notification)
        {
            this.notification = notification;
        }

        public abstract void SendNotification(string message);
    }

    // 4. Конкретные классы уведомлений
    public class TextNotification : Notification
    {
        public TextNotification(INotification notification) : base(notification) { }

        public override void SendNotification(string message)
        {
            // Можно добавить дополнительную обработку текста
            notification.Send(message);
        }
    }

    public class HtmlNotification : Notification
    {
        public HtmlNotification(INotification notification) : base(notification) { }

        public override void SendNotification(string message)
        {
            // Можно добавить дополнительную обработку HTML
            string htmlMessage = $"<html><body>{message}</body></html>"; // Пример форматирования в HTML
            notification.Send(htmlMessage);
        }
    }

    // Пример использования
    class Program
    {
        static void Main()
        {
            INotification emailNotification = new EmailNotification();
            INotification smsNotification = new SMSNotification();

            Notification textEmail = new TextNotification(emailNotification);
            textEmail.SendNotification("Привет! Это текстовое уведомление.");

            Notification htmlSMS = new HtmlNotification(smsNotification);
            htmlSMS.SendNotification("Привет! Это <b>HTML</b> уведомление.");
        }
    }
}