/* Zachary Yates
 * Copyright 2009 YatesMorrison Software Company
 * Source: http://geekswithblogs.net/jcdickinson/archive/2008/08/27/serializing_xelements.aspx
 * 1.30.2009
 */
namespace YatesMorrison.Xml
{
	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using System.Threading;
	using System.Xml;
	using System.Xml.Linq;

	public static class XmlSerializationExtensions
	{
        private static Dictionary<Type, DataContractSerializer> _knownTypes
			= new Dictionary<Type, DataContractSerializer>();
        private static ReaderWriterLockSlim _rwl = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);

        /// <summary>
        /// Deserializes an <see cref="XNode"/> to a specific type.
        /// </summary>
        /// <typeparam name="T">The type of object to deserialize to.</typeparam>
        /// <param name="node">The <see cref="XNode"/> to deserialize.</param>
        /// <returns>A new object of type <see cref="T"/>.</returns>
        public static T Deserialize<T>(this XNode node) where T : class
        {
			DataContractSerializer serializer;
            Type t = typeof(T);
            using(_rwl.Read(true))
            {
                if (!_knownTypes.TryGetValue(t, out serializer))
                {
                    using(_rwl.Write())
                    {
                        if (!_knownTypes.TryGetValue(t, out serializer))
                        {
							serializer = new DataContractSerializer(t, null, 0x7FFF, true, true, null);
                            _knownTypes.Add(t, serializer);
                        }
                    }
                }
            }

            using (XmlReader reader = node.CreateReader())
            {
				while (!serializer.IsStartObject(reader)) { reader.Read(); } // For some reason, the start element written by WriteObject screws the next line up, this advances to the deserializable part of the xml dom
                return serializer.ReadObject(reader) as T;
            }
        }

        /// <summary>
        /// Serializes an object into an <see cref="XContainer"/>.
        /// </summary>
        /// <param name="target">The target <see cref="XContainer"/>.</param>
        /// <param name="value">The value to serialize.</param>
        static void Serialize(this XContainer container, object value)
        {
            if (value == null)
                return;

            DataContractSerializer serializer;
            Type t = value.GetType();
            using (_rwl.Read(true))
            {
                if (!_knownTypes.TryGetValue(t, out serializer))
                {
                    using (_rwl.Write())
                    {
                        if (!_knownTypes.TryGetValue(t, out serializer))
                        {
                            serializer = new DataContractSerializer(t, null, 0x7FFF, true, true, null);
                            _knownTypes.Add(t, serializer);
                        }
                    }
                }
            }

            using (XmlWriter writer = container.CreateWriter())
            {
                serializer.WriteObject(writer, value);
            }
        }

		// todo: Figure out how to make this work
		//public static XElement ToXml(object value)
		//{
		//    XElement x = null;
		//}

        private class ReaderWriterLockSlimController : IDisposable
        {
            private bool _closed = false;
            private ReaderWriterLockSlim _slim;
            private bool _read = false;
            private bool _upgrade = false;

            public ReaderWriterLockSlimController(ReaderWriterLockSlim slim, bool read, bool upgrade)
            {
                _slim = slim;
                _read = read;
                _upgrade = upgrade;

                if (_read)
                {
                    if (upgrade)
                    {
                        _slim.EnterUpgradeableReadLock();
                    }
                    else
                    {
                        _slim.EnterReadLock();
                    }
                }
                else
                {
                    _slim.EnterWriteLock();
                }
            }

            #region IDisposable Members

            ~ReaderWriterLockSlimController()
            {
                Dispose();
            }

            public void Dispose()
            {
                if (_closed)
                    return;
                _closed = true;

                if (_read)
                {
                    if (_upgrade)
                    {
                        _slim.ExitUpgradeableReadLock();
                    }
                    else
                    {
                        _slim.ExitReadLock();
                    }
                }
                else
                {
                    _slim.ExitWriteLock();
                }

                GC.SuppressFinalize(this);
            }

            #endregion
        }

        public static IDisposable Read(this ReaderWriterLockSlim slim, bool upgradeable)
        {
            return new ReaderWriterLockSlimController(slim, true, upgradeable);
        }

        public static IDisposable Read(this ReaderWriterLockSlim slim)
        {
            return new ReaderWriterLockSlimController(slim, true, false);
        }

        public static IDisposable Write(this ReaderWriterLockSlim slim)
        {
            return new ReaderWriterLockSlimController(slim, false, false);
        }
    }
}