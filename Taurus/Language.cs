using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Taurus
{
    public class Language
    {
        public class Arabic
        {
            public const string id = "ar";
            public const string name = "Arabic";
        }

        public struct Simplified_Chinese
        {
            public const string id = "CHS";
            public const string name = "SimplifiedChinese";
        }

        public struct Traditional_Chinese
        {
            public const string id = "CHT";
            public const string name = "TraditionalChinese";
        }

        public struct English
        {
            public const string id = "en";
            public const string name = "English";
        }

        public struct Korean
        {
            public const string id = "KR";
            public const string name = "Korean";
        }

        public struct ThaiLanguage
        {
            public const string id = "th";
            public const string name = "ThaiLanguage";
        }

        public struct Turkish
        {
            public const string id = "tr";
            public const string name = "Turkish";
        }
        public struct Spanish_Argentine
        {
            public const string id = "es-AR";
            public const string name = "Spanish-Argentine";
        }
        public struct Spanish
        {
            public const string id = "es";
            public const string name = "Spanish";
        }

        public struct Portuguese
        {
            public const string id = "pt";
            public const string name = "Portuguese";
        }
        public struct Portuguese_Brazilian
        {
            public const string id = "pt-BR";
            public const string name = "Portuguese-Brazilian";
        }
        public struct French
        {
            public const string id = "FRA";
            public const string name = "French";
        }

        public struct Indonesian
        {
            public const string id = "id";
            public const string name = "Indonesian";
        }

        public struct German
        {
            public const string id = "de";
            public const string name = "German";
        }
        public struct Persian
        {
            public const string id = "fa";
            public const string name = "Persian";
        }
        public struct Japanese
        {
            public const string id = "ja";
            public const string name = "Japanese";
        }

        public struct Vietnamese
        {
            public const string id = "vi";
            public const string name = "Vietnamese";
        }

        public static string SelectID(string name)
        {
            string id = "";
            switch (name)
            {
                case Arabic.name:
                    id = Arabic.id;
                    break;
                case Simplified_Chinese.name:
                    id = Simplified_Chinese.id;
                    break;
                case Traditional_Chinese.name:
                    id = Traditional_Chinese.id;
                    break;
                case English.name:
                    id = English.id;
                    break;
                case Spanish.name:
                    id = Spanish.id;
                    break;
                case French.name:
                    id = French.id;
                    break;
                case Japanese.name:
                    id = Japanese.id;
                    break;
                case Vietnamese.name:
                    id = Vietnamese.id;
                    break;
                case ThaiLanguage.name:
                    id = ThaiLanguage.id;
                    break;
                case Korean.name:
                    id = Korean.id;
                    break;
                case Turkish.name:
                    id = Turkish.id;
                    break;
                case Spanish_Argentine.name:
                    id = Spanish_Argentine.id;
                    break;
                case Portuguese.name:
                    id = Portuguese.id;
                    break;
                case Portuguese_Brazilian.name:
                    id = Portuguese_Brazilian.id;
                    break;
                case Indonesian.name:
                    id = Indonesian.id;
                    break;
                case German.name:
                    id = German.id;
                    break;
                case Persian.name:
                    id = Persian.id;
                    break;
                default:
                    break;
            }
            return id;
        }

        public static string SelectName(string id)
        {
            string name = "";
            switch (id)
            {
                case Arabic.id:
                    name = Arabic.name;
                    break;
                case Simplified_Chinese.id:
                    name = Simplified_Chinese.name;
                    break;
                case Traditional_Chinese.id:
                    name = Traditional_Chinese.name;
                    break;
                case English.id:
                    name = English.name;
                    break;
                case Spanish.id:
                    name = Spanish.name;
                    break;
                case French.id:
                    name = French.name;
                    break;
                case Japanese.id:
                    name = Japanese.name;
                    break;
                case Vietnamese.id:
                    name = Vietnamese.name;
                    break;
                case ThaiLanguage.id:
                    id = ThaiLanguage.name;
                    break;
                case Korean.id:
                    id = Korean.name;
                    break;
                case Turkish.id:
                    id = Turkish.name;
                    break;
                case Spanish_Argentine.id:
                    id = Spanish_Argentine.name;
                    break;
                case Portuguese.id:
                    id = Portuguese.name;
                    break;
                case Portuguese_Brazilian.id:
                    id = Portuguese_Brazilian.name;
                    break;
                case Indonesian.id:
                    id = Indonesian.name;
                    break;
                case German.id:
                    id = German.name;
                    break;
                case Persian.id:
                    id = Persian.name;
                    break;
                default:
                    break;
            }
            return name;
        }
    }
}
