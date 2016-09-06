using System;
using System.Collections;
using System.Diagnostics;

namespace Task1
{
    static class TestsHelper
    {
        public static void DumpFields(this object obj)
        {
            var fields = obj.GetType().GetFields();
            foreach (var field in fields)
            {
                var value = field.GetValue(obj);
                if (value != null)
                {
                    if (field.FieldType.IsClass)
                    {
                        value.DumpFields();
                        return;
                    }
                    if (field.FieldType.IsArray)
                    {
                        foreach (var item in (IEnumerable)value)
                        {
                            item.DumpFields();
                        }
                        return;
                    }
                }

                Debug.WriteLine($"{field.Name}: {field.GetValue(obj)}");
            }
        }

        public static void DumpValue(this object obj)
        {
            Console.WriteLine(obj);
        }
    }
}
