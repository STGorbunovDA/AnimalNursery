﻿using System.Net;
using System.Windows;
using System;

namespace AnimalNursery.Infrastructure.Base
{
    internal class InternetCheck
    {
        /// <summary> Проверка интернета </summary>
        public static bool CheckSkyNET()
        {
            try
            {
                Dns.GetHostEntry("yandex.com");
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show(@"Отсутствует подключение к Интернету. Проверьте настройки сети и повторите попытку",
                        "Сеть недоступна");
                return false;
            }
        }
    }
}
