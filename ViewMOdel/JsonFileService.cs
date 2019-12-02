using System;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{/*
    class JsonFileService : IFileService
    {
        public List<Phone> Open(string fileName)
        {
            List<Phone> phones = new List<Phone>();
            DataContractJsonSerializer jsonSerializer =
                    new DataContractJsonSerializer(typeof(List<Phone>));
            using (FileStream stream = new FileStream(fileName,FileMode.OpenOrCreate))
            {
                phones = jsonSerializer.ReadObject(stream) as List<Phone>;
            }
            return phones;
        }

        public void Save(string fileName, List<Phone> phonesList)
        {
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<Phone>));

            using(FileStream stream = new FileStream(fileName, FileMode.Create))
            {
                jsonSerializer.WriteObject(stream, phonesList);
            }
        }
    }*/
}
