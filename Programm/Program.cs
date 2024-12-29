using lab7; 
using System; 
using System.IO; 
using System.Reflection;
using System.Xml; 
using System.Xml.Linq;

namespace ClassDiagramGenerator 
{
    class Program 
    {
        static void Main() 
        {
            string outputFileName = "ClassDiagram.xml"; // Определяем имя выходного XML файла.
            XmlDocument xmlDoc = new XmlDocument(); // Создаем новый экземпляр XmlDocument.
            XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null); // Создаем декларацию XML с версией 1.0 и кодировкой UTF-8.
            xmlDoc.AppendChild(xmlDeclaration); // Добавляем декларацию в документ.
            XmlElement root = xmlDoc.CreateElement("ClassDiagram"); // Создаем корневой элемент ClassDiagram.
            xmlDoc.AppendChild(root); // Добавляем корневой элемент в документ.

            Assembly assembly = Assembly.Load("lib"); // Загружаем сборку "lib" с определением классов животных.
            Type[] types = assembly.GetTypes(); // Получаем массив типов (классов) из сборки.

            // Перебираем все типы в загруженной сборке.
            foreach (Type type in types)
            {
                XmlElement classElement = xmlDoc.CreateElement("Class"); // Создаем новый элемент Class для текущего типа.
                classElement.SetAttribute("name", type.Name); // Устанавливаем имя класса как значение атрибута name.

                // Получаем атрибуты типа и проверяем, есть ли MyAttribute.
                object[] attributes = type.GetCustomAttributes(typeof(MyAttribute), false);
                if (attributes.Length > 0) // Если найден хотя бы один атрибут MyAttribute.
                {
                    MyAttribute customAttribute = (MyAttribute)attributes[0]; // Получаем первый атрибут.
                    classElement.SetAttribute("comment", customAttribute.Comment); // Добавляем комментарий как атрибут comment элемента.
                }

                PropertyInfo[] properties = type.GetProperties(); // Получаем все свойства текущего типа.
                // Перебираем каждое свойство.
                foreach (PropertyInfo property in properties)
                {
                    XmlElement propertyElement = xmlDoc.CreateElement("property"); // Создаем элемент property для свойства.
                    propertyElement.SetAttribute("name", property.Name); // Устанавливаем имя свойства как значение атрибута name.
                    propertyElement.SetAttribute("type", property.PropertyType.Name); // Устанавливаем тип свойства как значение атрибута type.
                    classElement.AppendChild(propertyElement); // Добавляем элемент свойства в элемент класса.
                }
                root.AppendChild(classElement); // Добавляем элемент класса в корневой элемент.
            }
            xmlDoc.Save(outputFileName); // Сохраняем созданный XML-документ в файл.
        }
    }
}
