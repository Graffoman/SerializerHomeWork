using System.ComponentModel;

namespace SerializerHomework.MySerializers
{
    public class MyCsvSerializer(string separator)
    {
        private readonly string Separator = separator;

        public T Deserialize<T>(string[] rows) where T : new()
        {
            T myObject = new();

            if (rows.Length != 2) return myObject;

            var propNames = rows[0].Split(Separator);
            var propValues = rows[1].Split(Separator);

            if (propNames.Length != propValues.Length) return myObject;

            foreach (var prop in myObject.GetType().GetProperties())
            {
                int index = Array.IndexOf(propNames, prop.Name);

                if (index == -1) continue;

                string? value = propValues[index];

                if (value == null) continue;

                TypeConverter converter = TypeDescriptor.GetConverter(prop.PropertyType);
                object? convertedvalue = converter.ConvertFrom(value);

                if (convertedvalue == null) continue;
                
                prop.SetValue(myObject, convertedvalue);
            }

            return myObject;
        }
    }
}
