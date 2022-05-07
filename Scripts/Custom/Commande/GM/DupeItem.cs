using System;
using System.Reflection;

namespace Server.Custom.Misc
{
    public class DupeItem
    {
        public static Item ItemDupe(Item targ)
        {
            Item copy = (Item)targ;
            Type t = copy.GetType();

            ConstructorInfo[] info = t.GetConstructors();

            foreach (ConstructorInfo c in info)
            {
                //if ( !c.IsDefined( typeof( RawConstructableAttribute ), false ) ) continue;

                ParameterInfo[] paramInfo = c.GetParameters();

                if (paramInfo.Length == 0)
                {
                    object[] objParams = new object[0];

                    try
                    {
                        for (int i = 0; i < 1; i++)
                        {
                            object o = c.Invoke(objParams);

                            if (o != null && o is Item)
                            {
                                Item newItem = (Item)o;
                                CopyProperties(newItem, copy);//copy.Dupe( item, copy.Amount );
                                newItem.Parent = null;
                                return newItem;
                            }
                        }
                    }
                    catch
                    {
                    }
                }
            }

            return null;
        }

        private static void CopyProperties(Item dest, Item src)
        {
            PropertyInfo[] props = src.GetType().GetProperties();

            for (int i = 0; i < props.Length; i++)
            {
                try
                {
                    if (props[i].CanRead && props[i].CanWrite)
                    {
                        //Console.WriteLine( "Setting {0} = {1}", props[i].Name, props[i].GetValue( src, null ) );
                        props[i].SetValue(dest, props[i].GetValue(src, null), null);
                    }
                }
                catch
                {
                    //Console.WriteLine( "Denied" );
                }
            }
        }
    }
}
