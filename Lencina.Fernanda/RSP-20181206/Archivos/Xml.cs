using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace Archivos
{
    public class Xml<T>:IArchivo<T>
    {
        public void Guardar(string destino, T dato)
        {
            XmlSerializer sr = new XmlSerializer(typeof(T));
            XmlTextWriter writer = new XmlTextWriter(destino, null);
            try
            {
                sr.Serialize(writer, dato);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                writer.Close();
            }
        }
        public T Leer(string origen)
        {
            T retorno;
            XmlTextReader reader;
            XmlSerializer sr;
            reader = new XmlTextReader(origen);
            sr = new XmlSerializer(typeof(T));
            retorno = (T)sr.Deserialize(reader);
            reader.Close();
            return retorno;
        }
    }
}
