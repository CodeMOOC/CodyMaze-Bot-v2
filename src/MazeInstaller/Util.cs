﻿using CodyMazeBot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeInstaller
{
    internal static class Util
    {
        public static Dictionary<string, string> Ita(string v) => new()
        {
            { "it", v }
        };

        public static Dictionary<string, string> Eng(string v) => new()
        {
            { "en", v }
        };

        public static Dictionary<string, string> EngIta(string en, string it) => new()
        {
            { "en", en },
            { "it", it },
        };

        public static async Task AddCategory(Storage s, string eventCode, string categoryName, Dictionary<string, string> categoryTitles, params CodyMazeBot.StoreModels.Question[] questions)
        {
            await s.StoreCategory(eventCode, categoryName, new CodyMazeBot.StoreModels.Category
            {
                Code = categoryName,
                Title = categoryTitles,
            });

            foreach (var q in questions)
            {
                await s.AddQuestion(eventCode, categoryName, q);
            }
        }
    }
}
