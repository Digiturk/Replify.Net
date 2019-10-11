using System;
using System.Collections.Generic;
using System.Text;

namespace Replify.Net.Extensions
{
    /// <summary>
    /// Console ekrani icin yazilan ozel fonksiyonlarin oldugu class
    /// </summary>
    public static class ConsoleExtensions
    {
        #region Console.WriteLine Functions

        /// <summary>
        /// Istenilen renge gore Console'de yazdirilmak istenilen yazinin yazdirilip alt satira gecmesini saglayan fonksiyon
        /// </summary>
        /// <param name="value">Console'de yazilacak olan icerik</param>
        /// <param name="textColor">Yazinin yazilmasi istenilen renk parametresi</param>
        public static void WriteLine(string value, ConsoleColor textColor = ConsoleColor.White)
        {
            Console.ForegroundColor = textColor;
            Console.WriteLine(value: value);
            Console.ResetColor();
        }

        /// <summary>
        /// Hata mesajlari icin Console'de Red olarak yazi yazdirir
        /// </summary>
        /// <param name="value">Console'de yazilacak olan icerik</param>
        public static void WriteLineError(string value)
        {
            WriteLine(value, ConsoleColor.Red);
        }

        /// <summary>
        /// Basari mesajlari icin Console'de Green olarak yazi yazdirir
        /// </summary>
        /// <param name="value">Console'de yazilacak olan icerik</param>
        public static void WriteLineSuccess(string value)
        {
            WriteLine(value, ConsoleColor.Green);
        }

        /// <summary>
        /// Uyari mesajlari icin Console'de Yellow olarak yazi yazdirir
        /// </summary>
        /// <param name="value">Console'de yazilacak olan icerik</param>
        public static void WriteLineWarning(string value)
        {
            WriteLine(value, ConsoleColor.Yellow);
        }

        /// <summary>
        /// Bilgilendirme mesajlari icin Console'de Cyan olarak yazi yazdirir
        /// </summary>
        /// <param name="value">Console'de yazilacak olan icerik</param>
        public static void WriteLineInfo(string value)
        {
            WriteLine(value, ConsoleColor.Cyan);
        }

        #endregion

        #region Console.Write Functions

        /// <summary>
        /// Istenilen renge gore Console'de yazdirilmak istenilen yazinin yazilmasini saglayan fonksiyon
        /// </summary>
        /// <param name="value">Console'de yazilacak olan icerik</param>
        /// <param name="textColor">Yazinin yazilmasi istenilen renk parametresi</param>
        public static void Write(string value, ConsoleColor textColor = ConsoleColor.White)
        {
            Console.ForegroundColor = textColor;
            Console.Write(value: value);
            Console.ResetColor();
        }

        /// <summary>
        /// Hata mesajlari icin Console'de Red olarak yazi yazdirir
        /// </summary>
        /// <param name="value">Console'de yazilacak olan icerik</param>
        public static void WriteError(string value)
        {
            Write(value, ConsoleColor.Red);
        }

        /// <summary>
        /// Basari mesajlari icin Console'de Green olarak yazi yazdirir
        /// </summary>
        /// <param name="value">Console'de yazilacak olan icerik</param>
        public static void WriteSuccess(string value)
        {
            Write(value, ConsoleColor.Green);
        }

        /// <summary>
        /// Uyari mesajlari icin Console'de Yellow olarak yazi yazdirir
        /// </summary>
        /// <param name="value">Console'de yazilacak olan icerik</param>
        public static void WriteWarning(string value)
        {
            Write(value, ConsoleColor.Yellow);
        }

        /// <summary>
        /// Bilgilendirme mesajlari icin Console'de Cyan olarak yazi yazdirir
        /// </summary>
        /// <param name="value">Console'de yazilacak olan icerik</param>
        public static void WriteInfo(string value)
        {
            Write(value, ConsoleColor.Cyan);
        }

        #endregion
    }
}